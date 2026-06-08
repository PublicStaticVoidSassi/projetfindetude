using System;
using UniFlowCRM.PhoneNumbers;
using Volo.Abp.Domain.Entities.Auditing;

namespace UniFlowCRM.Calls;

public class Call : FullAuditedAggregateRoot<Guid>
{

    public string Name { get; set; }
    public string? Description { get; set; }
    public CallStatus Status { get; set; }
    public CallDirection Direction { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
    public PhoneNumber? PhoneNumber { get; set; }

    // Relations avec d'autres entités CRM
    public Guid? AccountID { get; set; }
    public Guid? ContactID { get; set; }
    public Guid? OpportunityID { get; set; }
    public Guid? LeadID { get; set; }

    // Assignation
    public Guid? OwnerID { get; set; }
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
