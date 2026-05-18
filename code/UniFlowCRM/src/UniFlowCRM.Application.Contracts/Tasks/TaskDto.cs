using System;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace UniFlowCRM.Tasks;

public class TaskDto : FullAuditedEntityDto<Guid>
{
    public string Name { get;  set; }
    public string? Description { get;  set; }
    public TaskStatus Status { get;  set; }
    public TaskPriority Priority { get;  set; }
    public DateTime? StartTime { get;  set; }
    public DateTime? EndTime { get;  set; }
    public DateTime? CompletedAt { get;  set; }
    public IdentityUserDto? Owner { get;  set; }
    public IdentityUserDto? Creator { get;  set; }
    public IdentityUserDto? Modifier { get;  set; }
    // Relations avec d'autres entités CRM
    public AccountDto? Account { get;  set; }
    public ContactDto? Contact { get;  set; }
    public OpportunityDto? Opportunity { get;  set; }
    public LeadDto? Lead { get;  set; }

}