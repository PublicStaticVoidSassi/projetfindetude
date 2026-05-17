using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UniFlowCRM.Notes;

public interface INotesAppService:
    ICrudAppService<NoteDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateNoteDto>
{
    Task<List<NoteDto>> GetForLead(Guid leadId);
    Task<List<NoteDto>> GetForContact(Guid contactId);
    Task<List<NoteDto>> GetForAccount(Guid AccountId);
    Task<List<NoteDto>> GetForOpportunity(Guid OpportunityId);
}