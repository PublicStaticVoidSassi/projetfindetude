using System;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace UniFlowCRM.Tasks;

public class CreateUpdateTaskDto : EntityDto<Guid>
{
    public string Name { get;  set; }
    public string? Description { get;  set; }
    public TaskStatus Status { get;  set; }
    public TaskPriority Priority { get;  set; }
    public DateTime StartTime { get;  set; }
    public DateTime EndTime { get;  set; }
    public DateTime? CompletedAt { get;  set; }
    public Guid OwnerID { get;  set; }
    // Relations avec d'autres entités CRM
    public Guid? AccountID { get;  set; }
    public Guid? ContactID { get;  set; }
    public Guid? OpportunityID { get;  set; }
    public Guid? LeadID { get;  set; }

}