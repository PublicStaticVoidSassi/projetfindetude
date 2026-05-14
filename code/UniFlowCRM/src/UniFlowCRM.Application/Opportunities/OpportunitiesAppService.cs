using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using UniFlowCRM.Leads;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
namespace UniFlowCRM.Opportunities;

using System;
using System.Linq;
using System.Threading.Tasks;
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
    private Opportunity Initialize(Opportunity opportunity, CreateUpdateOpportunityDto input)
    {
        opportunity.SetName(input.Name!);

        opportunity.SetDescription(input.Description);

        opportunity.SetAmount(
            new ValueObjects.Money(
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
        var dto = await base.GetAsync(id);
        dto = await AddNavigationProperties(dto);
        return dto;
    }
    private async Task<OpportunityDto> AddNavigationProperties(OpportunityDto dto)
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
    }

    public override async Task<PagedResultDto<OpportunityDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var result = await base.GetListAsync(input);

        var newdtos = await Task.WhenAll(
            result.Items.Select(AddNavigationProperties)
        );

        return new PagedResultDto<OpportunityDto>(
            result.TotalCount,
            newdtos
        );
    }
}
