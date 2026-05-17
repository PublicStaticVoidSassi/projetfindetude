using System;
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Notes;

public class CreateUpdateNoteDto : EntityDto<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public NoteType Type { get; set; }
    public Guid? LeadId { get; set; }
    public Guid? AccountId { get; set; }
    public Guid? ContactId { get; set; }
    public Guid? OpportunityId { get; set; }
}