using System;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace UniFlowCRM.Calls;

public class CallDto : FullAuditedEntityDto<Guid>
{

    public string Name { get; set; }
    public string? Description { get; set; }
    public CallStatus Status { get; set; }
    public CallDirection Direction { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
    public string? PhoneNumber { get; set; }
    public AccountDto? Account { get; set; }
    public ContactDto? Contact { get; set; }
    public OpportunityDto? Opportunity { get; set; }
    public LeadDto? Lead { get; set; }
    public IdentityUserDto? Owner { get; set; }
    public IdentityUserDto? Creator { get; set; }
    public IdentityUserDto? Modifier { get; set; }
}