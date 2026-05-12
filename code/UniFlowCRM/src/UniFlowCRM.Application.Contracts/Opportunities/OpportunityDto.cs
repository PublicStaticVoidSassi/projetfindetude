using System;
using UniFlowCRM.Money;
using UniFlowCRM.Leads;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using Volo.Abp.Identity;
using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Opportunities;

public class OpportunityDto : FullAuditedEntityDto<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Currency? AmountCurrency { get; set; }
    public decimal? AmountValue { get; set; }
    public OpportunityStage? Stage { get; set; }
    public OpportunityType? Type { get; set; }
    public SaleStage? SaleStage { get; set; }
    public short Probability { get; set; }
    public string? NextStep { get; set; }
    public DateTime? ClosedAt { get; set; }
    public Guid? UserID { get; set; }
    public IdentityUserDto? User { get; set; }
    public Guid? LeadID { get; set; }
    public LeadDto? Lead { get; set; }
    public Guid? AccountID { get; set; }
    public AccountDto? Account { get; set; }
    public Guid? ContactID { get; set; }
    public ContactDto? Contact { get; set; }
}
