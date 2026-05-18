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
    public Guid? AccountId { get; set; }
    public Guid? ContactId { get; set; }
    public Guid? OpportunityId { get; set; }
    public Guid? LeadId { get; set; }
    public Guid? Owner { get; set; }
}