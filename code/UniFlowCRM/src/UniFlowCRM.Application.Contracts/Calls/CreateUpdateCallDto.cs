using System;
using UniFlowCRM.Calls;
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Calls;

public class CreateUpdateCallDto : EntityDto<Guid>
{

    public string Name { get; set; }
    public string? Description { get; set; }
    public CallStatus Status { get; set; }
    public CallDirection Direction { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid? AccountID { get; set; }
    public Guid? ContactID { get; set; }
    public Guid? OpportunityID { get; set; }
    public Guid? LeadID { get; set; }
    public Guid? OwnerID { get; set; }
}
