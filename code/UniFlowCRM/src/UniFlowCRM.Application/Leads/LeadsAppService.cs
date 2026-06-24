using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using UniFlowCRM.Accounts;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.PhoneNumbers;
using Volo.Abp.Identity;
using UniFlowCRM.Contacts;

namespace UniFlowCRM.Leads
{
    public class LeadJoined
    {
        public LeadDto Lead { get; set; }
        public AccountDto? Account { get; set; }
        public IdentityUserDto? Owner { get; set; }
        public IdentityUserDto? Creator { get; set; }
        public IdentityUserDto? LastModifier { get; set; }
    }
    public class LeadsAppService :
        CrudAppService<Lead, LeadDto, Guid, LeadRequestDto, CreateUpdateLeadDto>
        , ILeadsAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<Account, Guid> _accountsRepository;
        private readonly IRepository<Contact, Guid> _contactRepository;
        public LeadsAppService(
            IRepository<Lead, Guid> repository,
            IRepository<Account, Guid> accountsRepository,
            IRepository<IdentityUser, Guid> userRepository
,
            IRepository<Contact, Guid> contactRepository) : base(repository)
        {
            _userRepository = userRepository;
            _accountsRepository = accountsRepository;
            _contactRepository = contactRepository;
        }

        private async Task<IQueryable<LeadJoined>> GetQueryableAsync(Guid id)
        {
            var leads = await Repository.GetQueryableAsync();
            var users = await _userRepository.GetQueryableAsync();
            var accounts = await _accountsRepository.GetQueryableAsync();

            var query =
                from lead in leads
                where lead.Id == id
                join account in accounts
                    on lead.AccountID equals account.Id
                    into accountJoin
                from account in accountJoin.DefaultIfEmpty()

                join owner in users
                    on lead.UserID equals owner.Id
                    into ownerJoin
                from owner in ownerJoin.DefaultIfEmpty()

                join creator in users
                    on lead.CreatorId equals creator.Id
                    into creatorJoin
                from creator in creatorJoin.DefaultIfEmpty()

                join modifier in users
                    on lead.LastModifierId equals modifier.Id
                    into modifierJoin
                from modifier in modifierJoin.DefaultIfEmpty()
                select new LeadJoined
                {
                    Lead = ObjectMapper.Map<Lead, LeadDto>(lead),
                    Account = ObjectMapper.Map<Account, AccountDto>(account),
                    Owner = ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner),
                    Creator = ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator),
                    LastModifier = ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier)
                };

            return query;
        }
        private async Task<IQueryable<LeadJoined>> GetQueryableAsync(LeadRequestDto input)
        {
            var leads = (await Repository.GetQueryableAsync())
                .OrderBy(input.Sorting ?? "creationTime desc")
                .Where(e =>
                    (input.filter == null) ||
                    e.FirstName.ToLower().Contains(input.filter) ||
                    (!string.IsNullOrEmpty(e.LastName) && e.LastName.ToLower().Contains(input.filter))
                )
                .Skip(input.SkipCount).
                Take(input.MaxResultCount);
            var users = await _userRepository.GetQueryableAsync();
            var accounts = await _accountsRepository.GetQueryableAsync();

            var query =
                from lead in leads

                join account in accounts
                    on lead.AccountID equals account.Id
                    into accountJoin
                from account in accountJoin.DefaultIfEmpty()

                join owner in users
                    on lead.UserID equals owner.Id
                    into ownerJoin
                from owner in ownerJoin.DefaultIfEmpty()

                join creator in users
                    on lead.CreatorId equals creator.Id
                    into creatorJoin
                from creator in creatorJoin.DefaultIfEmpty()

                join modifier in users
                    on lead.LastModifierId equals modifier.Id
                    into modifierJoin
                from modifier in modifierJoin.DefaultIfEmpty()
                orderby input.Sorting
                select new LeadJoined
                {
                    Lead = ObjectMapper.Map<Lead, LeadDto>(lead),
                    Account = ObjectMapper.Map<Account, AccountDto>(account),
                    Owner = ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner),
                    Creator = ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator),
                    LastModifier = ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier)
                };

            return query;
        }

        public override async Task<LeadDto> GetAsync(Guid id)
        {
            var query = (await GetQueryableAsync(id));
            var joineddto = await AsyncExecuter.FirstAsync(query);
            LeadDto dto = joineddto.Lead;
            dto.Account = joineddto.Account;
            dto.Owner = joineddto.Owner;
            dto.Modifier = joineddto.LastModifier;
            dto.Creator = joineddto.Creator;
            return dto;
        }

        public override async Task<PagedResultDto<LeadDto>> GetListAsync(LeadRequestDto input)
        {
            var query = (await GetQueryableAsync(input));
            var result = (await AsyncExecuter.ToListAsync(query)).Select<LeadJoined, LeadDto>(e =>
                {
                    var result = e.Lead;
                    result.Account = e.Account;
                    result.Owner = e.Owner;
                    result.Creator = e.Creator;
                    result.Modifier = e.LastModifier;
                    return result;
                }
            ).ToList();
            var count = await Repository.GetCountAsync();
            return new PagedResultDto<LeadDto>(
                count,
                result
            );
        }

        private Lead Initialize(Lead lead, CreateUpdateLeadDto input)
        {
            lead.SetFirstName(input.FirstName);
            lead.SetLastName(input.LastName);
            lead.SetDescription(input.Description);
            if (input.Status is not null)
                lead.SetStatus((LeadStatus)input.Status);
            if (input.Source is not null)
                lead.SetSource((LeadSource)input.Source);
            if (input.PhoneNumber is not null)
                lead.SetPhone(new PhoneNumber(number: input.PhoneNumber, countryCode: input.PhoneCode));
            if (input.Email is not null)
                lead.SetEmail(new EmailAddress(input.Email));
            if (input.AccountID is not null)
                lead.AssignToAccount((Guid)input.AccountID);
            if (input.UserID is not null)
                lead.AssignToUser((Guid)input.UserID);
            else
                lead.AssignToUser(CurrentUser.Id!.Value);
            return lead;
        }
        public override async Task<LeadDto> CreateAsync(CreateUpdateLeadDto input)
        {
            Lead lead = new Lead(input.Id, input.FirstName);
            lead = Initialize(lead, input);
            await Repository.InsertAsync(lead);
            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }
        public override async Task<LeadDto> UpdateAsync(Guid id, CreateUpdateLeadDto input)
        {
            Lead? lead = await Repository.FindAsync(id) ?? throw new EntityNotFoundException();
            lead = Initialize(lead, input);
            await Repository.UpdateAsync(lead);
            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }
        public async Task<ContactDto> ConvertAsync(Guid id)
        {
            var lead = await Repository.GetAsync(id);
            lead.Convert();
            var contact = new Contact(GuidGenerator.Create(), lead.FirstName);
            contact.SetLastName(lead.LastName);
            contact.SetEmail(lead.Email);
            contact.AssignUser(lead.UserID);
            contact.AssignLead(lead.Id);
            contact.AssignAccount(lead.AccountID);
            contact.SetSource(ContactSource.ConvertedFromLead);
            contact = await _contactRepository.InsertAsync(contact);
            return ObjectMapper.Map<Contact, ContactDto>(contact);
        }
    }
}
