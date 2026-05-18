using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace UniFlowCRM.Tasks;
public class Task : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; protected set; }
    public string? Description { get; protected set; }
    public TaskStatus Status { get; protected set; }
    public TaskPriority Priority { get; protected set; }
    public DateTime? StartTime { get; protected set; }
    public DateTime? EndTime { get; protected set; }
    public DateTime? CompletedAt { get; protected set; }

    // Relations avec d'autres entités CRM
    public Guid? AccountID { get; protected set; }
    public Guid? ContactID { get; protected set; }
    public Guid? OpportunityID { get; protected set; }
    public Guid? LeadID { get; protected set; }

    // Assignation
    public Guid? OwnerID { get; protected set; }
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
