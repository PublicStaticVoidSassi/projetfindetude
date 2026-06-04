using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using UniFlowCRM.Leads;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace UniFlowCRM.Opportunities;

public class OpportunityJoined
{
    public OpportunityDto Opportunity { get; set; }
    public LeadDto? Lead { get; set; }
    public ContactDto? Contact { get; set; }
    public AccountDto? Account { get; set; }
    public IdentityUserDto? Owner { get; set; }
    public IdentityUserDto? Creator { get; set; }
    public IdentityUserDto? LastModifier { get; set; }
}
public class OpportunitiesAppService : CrudAppService<
                                       Opportunity,
                                       OpportunityDto,
                                       Guid,
                                       PagedAndSortedResultRequestDto,
                                       CreateUpdateOpportunityDto>, IOpportunityAppService
{
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    private readonly IRepository<Account, Guid> _accountRepository;
    private readonly IRepository<Lead, Guid> _leadRepository;
    private readonly IRepository<Contact, Guid> _contactRepository;
    public OpportunitiesAppService(
        IRepository<Opportunity, Guid> r,
        IRepository<IdentityUser, Guid> u,
        IRepository<Account, Guid> a,
        IRepository<Lead, Guid> l,
        IRepository<Contact, Guid> c) : base(r)
    {
        _userRepository = u;
        _leadRepository = l;
        _contactRepository = c;
        _accountRepository = a;
    }
    private async Task<IQueryable<OpportunityJoined>> GetQueryableAsync(PagedAndSortedResultRequestDto input)
    {
    var opportunities = (await Repository.GetQueryableAsync())
            .OrderBy(input.Sorting??"creationTime desc")
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

    var users = await _userRepository.GetQueryableAsync();
    var accounts = await _accountRepository.GetQueryableAsync();
    var contacts = await _contactRepository.GetQueryableAsync();
    var leads = await _leadRepository.GetQueryableAsync();

    var query =
        from opportunity in opportunities

        join account in accounts
            on opportunity.AccountID equals account.Id
            into accountJoin
        from account in accountJoin.DefaultIfEmpty()

        join contact in contacts
            on opportunity.ContactID equals contact.Id
            into contactJoin
        from contact in contactJoin.DefaultIfEmpty()

        join lead in leads
            on opportunity.LeadID equals lead.Id
            into leadJoin
        from lead in leadJoin.DefaultIfEmpty()

        join owner in users
            on opportunity.UserID equals owner.Id
            into ownerJoin
        from owner in ownerJoin.DefaultIfEmpty()

        join creator in users
            on opportunity.CreatorId equals creator.Id
            into creatorJoin
        from creator in creatorJoin.DefaultIfEmpty()

        join modifier in users
            on opportunity.LastModifierId equals modifier.Id
            into modifierJoin
        from modifier in modifierJoin.DefaultIfEmpty()
        orderby "opportunity."+input.Sorting
        select new OpportunityJoined
        {
            Opportunity = ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity),

            Account = account != null
                ? ObjectMapper.Map<Account, AccountDto>(account)
                : null,

            Contact = contact != null
                ? ObjectMapper.Map<Contact, ContactDto>(contact)
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
    private async Task<IQueryable<OpportunityJoined>> GetQueryableAsync(Guid id)
{
    var opportunities = await Repository.GetQueryableAsync();

    var users = await _userRepository.GetQueryableAsync();
    var accounts = await _accountRepository.GetQueryableAsync();
    var contacts = await _contactRepository.GetQueryableAsync();
    var leads = await _leadRepository.GetQueryableAsync();

    var query =
        from opportunity in opportunities
        where opportunity.Id == id
        join account in accounts
            on opportunity.AccountID equals account.Id
            into accountJoin
        from account in accountJoin.DefaultIfEmpty()

        join contact in contacts
            on opportunity.ContactID equals contact.Id
            into contactJoin
        from contact in contactJoin.DefaultIfEmpty()

        join lead in leads
            on opportunity.LeadID equals lead.Id
            into leadJoin
        from lead in leadJoin.DefaultIfEmpty()

        join owner in users
            on opportunity.UserID equals owner.Id
            into ownerJoin
        from owner in ownerJoin.DefaultIfEmpty()

        join creator in users
            on opportunity.CreatorId equals creator.Id
            into creatorJoin
        from creator in creatorJoin.DefaultIfEmpty()

        join modifier in users
            on opportunity.LastModifierId equals modifier.Id
            into modifierJoin
        from modifier in modifierJoin.DefaultIfEmpty()
        
        select new OpportunityJoined
        {
            Opportunity = ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity),

            Account = account != null
                ? ObjectMapper.Map<Account, AccountDto>(account)
                : null,

            Contact = contact != null
                ? ObjectMapper.Map<Contact, ContactDto>(contact)
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
    private Opportunity Initialize(Opportunity opportunity, CreateUpdateOpportunityDto input)
    {
        opportunity.SetName(input.Name!);

        opportunity.SetDescription(input.Description);

        opportunity.SetAmount(
            new Moneys.Money(
              input.AmountValue ?? 0,
                input.AmountCurrency!.Value

            )
        );

        opportunity.SetStage(input.Stage!.Value);

        opportunity.SetType(input.Type!.Value);

        opportunity.SetSaleStage(input.SaleStage!.Value);

        opportunity.SetProbability(input.Probability);

        opportunity.SetNextStep(input.NextStep);

        opportunity.SetClosedAt(input.ClosedAt);
        if (input.UserID is not null)
            opportunity.AssignTo(input.UserID!.Value);

        opportunity.SetLead(input.LeadID);

        opportunity.SetAccount(input.AccountID);

        opportunity.SetContact(input.ContactID);


        return opportunity;
    }
    public override async Task<OpportunityDto> CreateAsync(CreateUpdateOpportunityDto input)
    {
        var opportunity = new Opportunity(
        input.Id == Guid.Empty
        ? GuidGenerator.Create()
        : input.Id
        );
        if (input.UserID is null || input.UserID == Guid.Empty)
        {
            input.UserID = CurrentUser.Id;
        }
        opportunity = Initialize(opportunity, input);
        opportunity = await Repository.InsertAsync(opportunity);
        return ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity);
    }
    public override async Task<OpportunityDto> UpdateAsync(Guid id, CreateUpdateOpportunityDto input)
    {
        var opportunity = await Repository.GetAsync(id);
        opportunity = Initialize(opportunity, input);
        await Repository.UpdateAsync(opportunity);
        return ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity);
    }
    public override async Task<OpportunityDto> GetAsync(Guid id)
    {
        var query = (await GetQueryableAsync(id));
        var res = await AsyncExecuter.FirstAsync(query);
        var dto = res.Opportunity;
        dto.Lead = res.Lead;
        dto.Account = res.Account;
        dto.Contact = res.Contact;
        dto.Owner = res.Owner;
        dto.Creator = res.Creator;
        dto.Modifier = res.LastModifier;
        return dto;
    }
    
    /*private async Task<OpportunityDto> AddNavigationProperties(OpportunityDto dto)
    {
        if (dto.AccountID is not null)
            dto.Account = ObjectMapper.Map<Account, AccountDto>(await _accountRepository.GetAsync((Guid)dto.AccountID));
        if (dto.UserID is not null)
            dto.User = ObjectMapper.Map<IdentityUser, IdentityUserDto>(
                (await _userRepository.GetAsync((Guid)dto.UserID)));
        if (dto.LeadID is not null)
            dto.Lead = ObjectMapper.Map<Lead, LeadDto>(await _leadRepository.GetAsync((Guid)dto.LeadID));
        if (dto.ContactID is not null)
            dto.Contact = ObjectMapper.Map<Contact, ContactDto>(await _contactRepository.GetAsync((Guid)dto.ContactID));
        return dto;
    }*/

    public override async Task<PagedResultDto<OpportunityDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var query = (await GetQueryableAsync(input));
        var res = (await AsyncExecuter.ToListAsync(query)).Select<OpportunityJoined, OpportunityDto>(res =>
        {
            var dto = res.Opportunity;
            dto.Lead = res.Lead;
            dto.Account = res.Account;
            dto.Contact = res.Contact;
            dto.Owner = res.Owner;
            dto.Creator = res.Creator;
            dto.Modifier = res.LastModifier;
            return dto;
        }).ToList();
            var count = await Repository.GetCountAsync();


        return new PagedResultDto<OpportunityDto>(
            count,
            res
        );
    }

    public async Task<OpportunityDto> CloseAsync(Guid id,bool won)
    {
        var opp = await Repository.GetAsync(id);
        if (won)
        {
            opp.CloseWon();
        }
        else
        {
            opp.CloseLost();
        }
        await Repository.UpdateAsync(opp);
        return ObjectMapper.Map<Opportunity,OpportunityDto>(opp);
    }
}
