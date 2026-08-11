using System;
using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Meetings;

public class CreateUpdateMeetingDto : EntityDto<Guid>
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

    public Guid OwnerID { get; set; }
}
