
using System;
using Volo.Abp.Application.Dtos;
using UniFlowCRM.Leads;
using UniFlowCRM.Contacts;
using UniFlowCRM.Accounts;
using UniFlowCRM.Opportunities;
using Volo.Abp.Identity;
namespace UniFlowCRM.Meetings;

public class MeetingDto : FullAuditedEntityDto<Guid>
{

    public string Name { get; set; }
    public string? Description { get; set; }
    public MeetingStatus Status { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Location { get; set; }
    public AccountDto? Account { get; set; }
    public ContactDto? Contact { get; set; }
    public OpportunityDto? Opportunity { get; set; }
    public LeadDto? Lead { get; set; }

    public IdentityUserDto? Owner { get; set; }
    public IdentityUserDto? Creator { get; set; }
    public IdentityUserDto? Modifier { get; set; }
}
