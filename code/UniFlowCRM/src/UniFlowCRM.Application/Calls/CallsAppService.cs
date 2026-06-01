using System;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

using System.Linq;
using System.Linq.Dynamic.Core;
namespace UniFlowCRM.Calls;

public class CallJoined
{
    public CallDto call { get; set; }
    public AccountDto? account { get; set; }
    public LeadDto? lead { get; set; }
    public ContactDto? contact { get; set; }
    public OpportunityDto? opportunity { get; set; }
    public IdentityUserDto? owner { get; set; }
    public IdentityUserDto? creator { get; set; }
    public IdentityUserDto? modifier { get; set; }

    public CallDto ToDto()
    {
        var res = this.call;
        res.Account = account;
        res.Lead = lead;
        res.Contact = contact;
        res.Opportunity = opportunity;
        res.Creator = creator;
        res.Owner = owner;
        res.Modifier = modifier;
        return res;
    }
}

public class CallsAppService : CrudAppService<Call, CallDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCallDto>, ICallAppService
{
    private readonly IRepository<Account, Guid> _accountRepository;
    private readonly IRepository<Lead, Guid> _leadRepository;
    private readonly IRepository<Contact, Guid> _contactRepository;
    private readonly IRepository<Opportunity, Guid> _opportunityRepository;
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    public CallsAppService(
        IRepository<Call, Guid> repository,
        IRepository<Account, Guid> accountRepository,
        IRepository<Lead, Guid> leadRepository,
        IRepository<Contact, Guid> contactRepository,
        IRepository<Opportunity, Guid> opportunityRepository,
        IRepository<IdentityUser, Guid> userRepository) : base(repository)
    {
        _accountRepository = accountRepository;
        _leadRepository = leadRepository;
        _contactRepository = contactRepository;
        _opportunityRepository = opportunityRepository;
        _userRepository = userRepository;
    }

    public override Task<CallDto> CreateAsync(CreateUpdateCallDto input)
    {
        return base.CreateAsync(input);
    }

    public override async Task<CallDto> GetAsync(Guid id)
    {
        var calls = (await Repository.GetQueryableAsync()).Where(x => x.Id == id);

        var accounts = await _accountRepository.GetQueryableAsync();
        var leads = await _leadRepository.GetQueryableAsync();
        var contacts = await _contactRepository.GetQueryableAsync();
        var opportunities = await _opportunityRepository.GetQueryableAsync();
        var users = await _userRepository.GetQueryableAsync();

        var query =
            from call in calls
            join account in accounts
                on call.AccountID equals account.Id
                into accountJoin
            from account in accountJoin.DefaultIfEmpty()

            join lead in leads
                on call.LeadID equals lead.Id
                into leadJoin
            from lead in leadJoin.DefaultIfEmpty()

            join contact in contacts
                on call.ContactID equals contact.Id
                into contactJoin
            from contact in contactJoin.DefaultIfEmpty()

            join opportunity in opportunities
                on call.OpportunityID equals opportunity.Id
                into opportunityJoin
            from opportunity in opportunityJoin.DefaultIfEmpty()

            join owner in users
                on call.OwnerID equals owner.Id
                into ownerJoin
            from owner in ownerJoin.DefaultIfEmpty()

            join creator in users
                on call.CreatorId equals creator.Id
                into creatorJoin
            from creator in creatorJoin.DefaultIfEmpty()

            join modifier in users
                on call.LastModifierId equals modifier.Id
                into modifierJoin
            from modifier in modifierJoin.DefaultIfEmpty()

            

            select new CallJoined
            {
                call = ObjectMapper.Map<Call, CallDto>(call),

                account = account == null
                    ? null
                    : ObjectMapper.Map<Account, AccountDto>(account),

                contact = contact == null
                    ? null
                    : ObjectMapper.Map<Contact, ContactDto>(contact),

                lead = lead == null
                    ? null
                    : ObjectMapper.Map<Lead, LeadDto>(lead),

                opportunity = opportunity == null
                    ? null
                    : ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity),

                owner = owner == null
                    ? null
                    : ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner),

                creator = creator == null
                    ? null
                    : ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator),

                modifier = modifier == null
                    ? null
                    : ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier),
            };

        var joined = await AsyncExecuter.FirstAsync(query);
        var res = joined.ToDto();
        return res;
    }
}
