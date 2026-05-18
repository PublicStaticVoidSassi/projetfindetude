using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace UniFlowCRM.Calls;

public class Call : FullAuditedAggregateRoot<Guid>
{

    public string Name { get; protected set; }
    public string? Description { get; protected set; }
    public CallStatus Status { get; protected set; }
    public CallDirection Direction { get; protected set; }
    public DateTime? StartTime { get; protected set; }
    public DateTime? EndTime { get; protected set; }
    public int? Duration { get; protected set; }
    public string? PhoneNumber { get; protected set; }

    // Relations avec d'autres entités CRM
    public Guid? AccountID { get; protected set; }
    public Guid? ContactID { get; protected set; }
    public Guid? OpportunityID { get; protected set; }
    public Guid? LeadID { get; protected set; }

    // Assignation
    public Guid? OwnerID { get; protected set; }
    public Call(Guid id, string name) : base(id)
    {
        SetName(name);
        Status = CallStatus.Planned;
        Direction = CallDirection.Outbound;
    }
    void SetName(string name)
    {
        Name = name;
    }

    private Call() { }
}
