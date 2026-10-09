
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Activities;
using UniFlowCRM.Calls;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using UniFlowCRM.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
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
[Authorize(UniFlowCRMPermissions.Task.Default)]
public class TasksAppService : CrudAppService<Task, TaskDto, Guid, TaskRequestDto, CreateUpdateTaskDto>, ITaskAppService
{
    private readonly IRepository<Account, Guid> _accountRepository;
    private readonly IRepository<Lead, Guid> _leadRepository;
    private readonly IRepository<Contact, Guid> _contactRepository;
    private readonly IRepository<Opportunity, Guid> _opportunityRepository;
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    private readonly IActivityManager _activityManager;
    private readonly IPermissionChecker permissionChecker;

    public TasksAppService(
        IRepository<Task, Guid> repository,
        IRepository<Account, Guid> accountRepository,
        IRepository<Lead, Guid> leadRepository,
        IRepository<Contact, Guid> contactRepository,
        IRepository<Opportunity, Guid> opportunityRepository,
        IRepository<IdentityUser, Guid> userRepository,
        IPermissionChecker permissionChecker, IActivityManager activityManager) : base(repository)
    {
        _accountRepository = accountRepository;
        _leadRepository = leadRepository;
        _contactRepository = contactRepository;
        _opportunityRepository = opportunityRepository;
        _userRepository = userRepository;
        this.permissionChecker = permissionChecker;
        _activityManager = activityManager;
    }
    public override async Task<PagedResultDto<TaskDto>> GetListAsync(TaskRequestDto input)
    {
        var q = await Repository.GetQueryableAsync();

        // view own only
        if (!await permissionChecker.IsGrantedAsync(UniFlowCRM.Permissions.UniFlowCRMPermissions.Task.ViewAll))
        {
            q = q.Where(a => a.CreatorId == CurrentUser.Id || a.OwnerID == CurrentUser.Id);
        }
        //

        q = q.OrderBy(input.Sorting ?? "creationTime desc")
            .Where((e) =>
                (string.IsNullOrEmpty(input.filter)) ||
                (e.Name.ToLower().Contains(input.filter))
            )
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);
        var dtos = await AsyncExecuter.ToListAsync(q);
        var count = await AsyncExecuter.CountAsync(q);
        return new PagedResultDto<TaskDto>(count, ObjectMapper.Map<List<Task>, List<TaskDto>>(dtos));
    }
    [Authorize(UniFlowCRMPermissions.Task.Create)]
    public override async Task<TaskDto> CreateAsync(CreateUpdateTaskDto input)
    {
        await _activityManager.CheckTimeAvailableAsync(input.OwnerID, input.StartTime, input.EndTime);
        return await base.CreateAsync(input);
    }

    [Authorize(UniFlowCRMPermissions.Task.Edit)]
    public override async Task<TaskDto> UpdateAsync(Guid id, CreateUpdateTaskDto input)
    {
        await _activityManager.CheckTimeAvailableAsync(input.OwnerID, input.StartTime, input.EndTime);

        return await base.UpdateAsync(id, input);
    }
    [Authorize(UniFlowCRMPermissions.Task.Delete)]
    public override async System.Threading.Tasks.Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
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
