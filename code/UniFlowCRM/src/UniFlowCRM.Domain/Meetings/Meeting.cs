using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace UniFlowCRM.Meetings;

public class Meeting : FullAuditedAggregateRoot<Guid>
{

    public string Name { get; set; }
    public string? Description { get; set; }
    public MeetingStatus Status { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Location { get; set; }
    public Guid? AccountID { get; set; }
    public Guid? ContactID { get; set; }
    public Guid? OpportunityID { get; set; }
    public Guid? LeadID { get; set; }

    // Assignation
    public Guid? OwnerID { get; set; }
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
