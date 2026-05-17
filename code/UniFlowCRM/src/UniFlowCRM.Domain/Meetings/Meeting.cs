using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace UniFlowCRM.Meetings;

public enum MeetingStatus
{
    Planned = 0,
    Held = 1,
    NotHeld = 2,
    Cancelled = 3
}
public class Meeting : FullAuditedAggregateRoot<Guid>
{

    public string Name { get; protected set; }
    public string? Description { get; protected set; }
    public MeetingStatus Status { get; protected set; }
    public DateTime StartTime { get; protected set; }
    public DateTime EndTime { get; protected set; }
    public string? Location { get; protected set; }
    public Guid? AccountID { get; protected set; }
    public Guid? ContactID { get; protected set; }
    public Guid? OpportunityID { get; protected set; }
    public Guid? LeadID { get; protected set; }

    // Assignation
    public Guid? OwnerID { get; protected set; }
    public Meeting(Guid id, string name) : base(id)
    {
        SetName(name);
        Status = MeetingStatus.Planned;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    private Meeting() { }
}
