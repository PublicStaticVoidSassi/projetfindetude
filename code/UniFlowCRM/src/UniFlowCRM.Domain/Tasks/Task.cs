using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace UniFlowCRM.Tasks;
// todo: protect setters
public class Task : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public DateTime? CompletedAt { get; set; }

    // Relations avec d'autres entités CRM
    public Guid? AccountID { get; set; }
    public Guid? ContactID { get; set; }
    public Guid? OpportunityID { get; set; }
    public Guid? LeadID { get; set; }

    // Assignation
    public Guid? OwnerID { get; set; }
    public Task(Guid id, string name) : base(id)
    {
        SetName(name);
        Status = TaskStatus.NotStarted;
        Priority = TaskPriority.Normal;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    private Task() { }
}
