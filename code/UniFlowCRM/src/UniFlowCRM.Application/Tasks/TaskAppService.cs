
using System;
using System.Linq;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Calls;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
namespace UniFlowCRM.Tasks;

public class TaskJoined
{
    public TaskDto task { get; set; }
    public AccountDto? account { get; set; }
    public LeadDto? lead { get; set; }
    public ContactDto? contact { get; set; }
    public OpportunityDto? opportunity { get; set; }
    public IdentityUserDto? owner { get; set; }
    public IdentityUserDto? creator { get; set; }
    public IdentityUserDto? modifier { get; set; }

    public TaskDto ToDto()
    {
        var res = this.task;
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
public class TasksAppService : CrudAppService<Task, TaskDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTaskDto>, ITaskAppService
{
    private readonly IRepository<Account, Guid> _accountRepository;
    private readonly IRepository<Lead, Guid> _leadRepository;
    private readonly IRepository<Contact, Guid> _contactRepository;
    private readonly IRepository<Opportunity, Guid> _opportunityRepository;
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    public TasksAppService(
        IRepository<Task, Guid> repository,
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
    public override Task<TaskDto> CreateAsync(CreateUpdateTaskDto input)
    {
        return base.CreateAsync(input);
    }
    public override async Task<TaskDto> GetAsync(Guid id)
    {
        var tasks = (await Repository.GetQueryableAsync()).Where(x => x.Id == id);

        var accounts = await _accountRepository.GetQueryableAsync();
        var leads = await _leadRepository.GetQueryableAsync();
        var contacts = await _contactRepository.GetQueryableAsync();
        var opportunities = await _opportunityRepository.GetQueryableAsync();
        var users = await _userRepository.GetQueryableAsync();

        var query =
            from task in tasks
            join account in accounts
                on task.AccountID equals account.Id
                into accountJoin
            from account in accountJoin.DefaultIfEmpty()

            join lead in leads
                on task.LeadID equals lead.Id
                into leadJoin
            from lead in leadJoin.DefaultIfEmpty()

            join contact in contacts
                on task.ContactID equals contact.Id
                into contactJoin
            from contact in contactJoin.DefaultIfEmpty()

            join opportunity in opportunities
                on task.OpportunityID equals opportunity.Id
                into opportunityJoin
            from opportunity in opportunityJoin.DefaultIfEmpty()

            join owner in users
                on task.OwnerID equals owner.Id
                into ownerJoin
            from owner in ownerJoin.DefaultIfEmpty()

            join creator in users
                on task.CreatorId equals creator.Id
                into creatorJoin
            from creator in creatorJoin.DefaultIfEmpty()

            join modifier in users
                on task.LastModifierId equals modifier.Id
                into modifierJoin
            from modifier in modifierJoin.DefaultIfEmpty()



            select new TaskJoined
            {
                task = ObjectMapper.Map<Task, TaskDto>(task),

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
