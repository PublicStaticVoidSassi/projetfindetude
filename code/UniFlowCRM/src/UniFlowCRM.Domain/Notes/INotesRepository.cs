using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Notes;

public interface INotesRepository : IRepository<Note, Guid>
{
    // Task<List<Note>> GetForLead(Guid id);
    // Task<List<Note>> GetForContact(Guid id);
    // Task<List<Note>> GetForAccount(Guid id);
    // Task<List<Note>> GetForOpportunity(Guid id);
}
