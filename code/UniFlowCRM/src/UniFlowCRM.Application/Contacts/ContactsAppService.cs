using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Addresses;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.Leads;
using UniFlowCRM.Permissions;
using UniFlowCRM.PhoneNumbers;
using UniFlowCRM.URLs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace UniFlowCRM.Contacts
{
    public class ContactJoined
    {
        public required ContactDto Contact { get; set; }
        public AccountDto? Account { get; set; }
        public LeadDto? Lead { get; set; }
        public IdentityUserDto? Owner { get; set; }
        public IdentityUserDto? Creator { get; set; }
        public IdentityUserDto? LastModifier { get; set; }
    }

    [Authorize]
    public class ContactsAppService :
      CrudAppService<
      Contact,
      ContactDto,
      Guid,
      ContactRequestDto,
      CreateUpdateContactDto>, IContactsAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<Account, Guid> _accountsRepository;
        private readonly IRepository<Lead, Guid> _leadRepository;
        private IPermissionChecker permissionChecker;

        public ContactsAppService(IRepository<Contact, Guid> repository,
        IRepository<IdentityUser, Guid> userRepository,
        IRepository<Account, Guid> accountsRepository,
        IRepository<Lead, Guid> leadRepository,
        IPermissionChecker permissionChecker) : base(repository)
        {
            _userRepository = userRepository;
            _accountsRepository = accountsRepository;
            _leadRepository = leadRepository;
            this.permissionChecker = permissionChecker;
        }

        public override async Task<ContactDto> GetAsync(Guid id)
        {
            var query = (await GetQueryableAsync(id));
            var joineddto = await AsyncExecuter.FirstAsync(query);
            ContactDto dto = joineddto.Contact;
            dto.Account = joineddto.Account;
            dto.Lead = joineddto.Lead;
            dto.Owner = joineddto.Owner;
            dto.Modifier = joineddto.LastModifier;
            dto.Creator = joineddto.Creator;
            dto.CampaignId = joineddto.Contact.CampaignId;
            return dto;
        }
        public override async Task<PagedResultDto<ContactDto>> GetListAsync(ContactRequestDto input)
        {
            var query = (await GetQueryableAsync(input));
            var result = (await AsyncExecuter.ToListAsync(query)).Select<ContactJoined, ContactDto>(e =>
                {
                    var result = e.Contact;
                    result.Lead = e.Lead;
                    result.Account = e.Account;
                    result.Owner = e.Owner;
                    result.Creator = e.Creator;
                    result.Modifier = e.LastModifier;
                    result.CampaignId = e.Contact.CampaignId;
                    return result;
                }
            ).ToList();
            var count = await AsyncExecuter.CountAsync(query);
            return new PagedResultDto<ContactDto>(
                count,
                result
            );
        }

        private Contact Initialize(Contact con, CreateUpdateContactDto input)
        {
            con.SetFirstName(input.FirstName);
            con.SetMiddleName(input.MiddleName);
            con.SetLastName(input.LastName);
            con.SetDescription(input.Description);
            con.SetStatus(input.Status);
            con.SetSource(input.Source);
            if (input.PhoneNumber is not null)
                con.SetPhone(new PhoneNumber(number: input.PhoneNumber, countryCode: input.PhoneCode));
            if (input.FaxNumber is not null)
                con.SetFax(new PhoneNumber(number: input.FaxNumber, countryCode: input.FaxCode));
            if (input.Email is not null)
                con.SetEmail(new EmailAddress(input.Email));
            if (input.Website is not null)
                con.SetWebsite(new URL(input.Website));
            con.SetAddress(
                new Address()
                .AddCity(input.City)
                .AddCountry(input.Country)
                .AddStreet(input.Street)
                .AddPostalCode(input.PostalCode)
            );
            con.SetJob(input.Job);
            con.SetDepartment(input.Departement);
            if (input.UserID is not null)
                con.AssignUser((Guid)input.UserID);
            else
                con.AssignUser(CurrentUser.Id!.Value);
            if (input.AccountID is not null)
                con.AssignAccount(input.AccountID);
            if (input.LeadID is not null)
                con.AssignLead(input.LeadID);
            if (input.CampaignId is not null)
            {
                con.CampaignId = input.CampaignId;
            }
            return con;
        }
        private async Task<IQueryable<ContactJoined>> GetQueryableAsync(ContactRequestDto input)
        {
            var contacts = (await Repository.GetQueryableAsync());

            // view own only
            if (!await permissionChecker.IsGrantedAsync(UniFlowCRMPermissions.Contact.ViewAll))
            {
                contacts = contacts.Where(a => a.CreatorId == CurrentUser.Id || a.UserID == CurrentUser.Id);
            }
            //

            contacts = contacts.Where(e =>
                    (input.filter == null) ||
                    e.FirstName.ToLower().Contains(input.filter) ||
                    (!string.IsNullOrEmpty(e.MiddleName) && e.MiddleName.ToLower().Contains(input.filter)) ||
                    (!string.IsNullOrEmpty(e.LastName) && e.LastName.ToLower().Contains(input.filter))
                )
              .OrderBy(input.Sorting ?? "creationTime desc").Skip(input.SkipCount).Take(input.MaxResultCount);
            var users = await _userRepository.GetQueryableAsync();
            var accounts = await _accountsRepository.GetQueryableAsync();
            var leads = await _leadRepository.GetQueryableAsync();

            var query =
                from contact in contacts

                join account in accounts
                    on contact.AccountID equals account.Id
                    into accountJoin
                from account in accountJoin.DefaultIfEmpty()

                join lead in leads
                    on contact.LeadID equals lead.Id
                    into leadJoin
                from lead in leadJoin.DefaultIfEmpty()

                join owner in users
                    on contact.UserID equals owner.Id
                    into ownerJoin
                from owner in ownerJoin.DefaultIfEmpty()

                join creator in users
                    on contact.CreatorId equals creator.Id
                    into creatorJoin
                from creator in creatorJoin.DefaultIfEmpty()

                join modifier in users
                    on contact.LastModifierId equals modifier.Id
                    into modifierJoin
                from modifier in modifierJoin.DefaultIfEmpty()
                    // orderby "contact." + input.Sorting
                select new ContactJoined
                {
                    Contact = ObjectMapper.Map<Contact, ContactDto>(contact),

                    Account = account != null
                        ? ObjectMapper.Map<Account, AccountDto>(account)
                        : null,

                    Lead = lead != null
                        ? ObjectMapper.Map<Lead, LeadDto>(lead)
                        : null,

                    Owner = owner != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner)
                        : null,

                    Creator = creator != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator)
                        : null,

                    LastModifier = modifier != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier)
                        : null
                };



            return query;
        }
        private async Task<IQueryable<ContactJoined>> GetQueryableAsync(Guid id)
        {
            var contacts = await Repository.GetQueryableAsync();
            var users = await _userRepository.GetQueryableAsync();
            var accounts = await _accountsRepository.GetQueryableAsync();
            var leads = await _leadRepository.GetQueryableAsync();

            var query =
                from contact in contacts
                where contact.Id == id
                join account in accounts
                    on contact.AccountID equals account.Id
                    into accountJoin
                from account in accountJoin.DefaultIfEmpty()

                join lead in leads
                    on contact.LeadID equals lead.Id
                    into leadJoin
                from lead in leadJoin.DefaultIfEmpty()

                join owner in users
                    on contact.UserID equals owner.Id
                    into ownerJoin
                from owner in ownerJoin.DefaultIfEmpty()

                join creator in users
                    on contact.CreatorId equals creator.Id
                    into creatorJoin
                from creator in creatorJoin.DefaultIfEmpty()

                join modifier in users
                    on contact.LastModifierId equals modifier.Id
                    into modifierJoin
                from modifier in modifierJoin.DefaultIfEmpty()

                select new ContactJoined
                {
                    Contact = ObjectMapper.Map<Contact, ContactDto>(contact),
                    Account = account != null
                        ? ObjectMapper.Map<Account, AccountDto>(account)
                        : null,

                    Lead = lead != null
                        ? ObjectMapper.Map<Lead, LeadDto>(lead)
                        : null,

                    Owner = owner != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner)
                        : null,

                    Creator = creator != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator)
                        : null,

                    LastModifier = modifier != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier)
                        : null
                };

            return query;
        }
        public override async Task<ContactDto> CreateAsync(CreateUpdateContactDto input)
        {
            Contact con = new Contact(input.Id, input.FirstName);
            Initialize(con, input);
            await Repository.InsertAsync(con);
            return ObjectMapper.Map<Contact, ContactDto>(con);
        }
        public override async Task<ContactDto> UpdateAsync(Guid id, CreateUpdateContactDto input)
        {
            Contact con = await Repository.FindAsync(id) ?? throw new EntityNotFoundException();
            Initialize(con, input);
            await Repository.UpdateAsync(con);
            return ObjectMapper.Map<Contact, ContactDto>(con);
        }
    }
}
