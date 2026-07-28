using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.Permissions;
using UniFlowCRM.PhoneNumbers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

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
[Authorize(UniFlowCRMPermissions.Lead.Default)]
    public class LeadsAppService :
        CrudAppService<Lead, LeadDto, Guid, LeadRequestDto, CreateUpdateLeadDto>
        , ILeadsAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly ILeadsManager leadManager;
        private readonly IRepository<Account, Guid> _accountsRepository;
        private readonly IRepository<Contact, Guid> _contactRepository;
        private IPermissionChecker permissionChecker;

        public LeadsAppService(
            IRepository<Lead, Guid> repository,
            IRepository<Account, Guid> accountsRepository,
            IRepository<IdentityUser, Guid> userRepository,
            ILeadsManager _leadManager,
            IRepository<Contact, Guid> contactRepository,
            IPermissionChecker permissionChecker) : base(repository)
        {
            _userRepository = userRepository;
            leadManager = _leadManager;
            _accountsRepository = accountsRepository;
            _contactRepository = contactRepository;
            this.permissionChecker = permissionChecker;
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
            var leads = (await Repository.GetQueryableAsync());
            // view own only
            if (!await permissionChecker.IsGrantedAsync(UniFlowCRMPermissions.Lead.ViewAll))
            {
                leads = leads.Where(a => a.CreatorId == CurrentUser.Id || a.UserID == CurrentUser.Id);
            }
            //
            leads = leads.OrderBy(input.Sorting ?? "creationTime desc")
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
            var count = await AsyncExecuter.CountAsync(query);
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
            if (input.CampaignId is not null)
            {
                lead.CampaignId = input.CampaignId;
            }
            return lead;
        }
        [Authorize(UniFlowCRMPermissions.Lead.Create)]

        public override async Task<LeadDto> CreateAsync(CreateUpdateLeadDto input)
        {
            Lead lead = new Lead(input.Id, input.FirstName);
            lead = Initialize(lead, input);
            await Repository.InsertAsync(lead);
            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }
        [Authorize(UniFlowCRMPermissions.Lead.Edit)]

        public override async Task<LeadDto> UpdateAsync(Guid id, CreateUpdateLeadDto input)
        {
            Lead? lead = await Repository.FindAsync(id) ?? throw new EntityNotFoundException();
            lead = Initialize(lead, input);
            await Repository.UpdateAsync(lead);
            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }
        [Authorize(UniFlowCRMPermissions.Lead.Convert)]

        public async Task<ContactDto> ConvertAsync(Guid id)
        {
            var newContactId = await leadManager.ConvertAsync(id);
            var contact = await _contactRepository.GetAsync(newContactId);
            return ObjectMapper.Map<Contact, ContactDto>(contact);
        }
    }
}
