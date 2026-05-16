using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.EntityFrameworkCore;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UniFlowCRM.Notes;



public class NotesRepository : EfCoreRepository<UniFlowCRMDbContext,Note,Guid>,INotesRepository
{
    public NotesRepository(IDbContextProvider<UniFlowCRMDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<NoteDetails> GetDetailsAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();

        var result =
            await (
                from dbNote in dbContext.Notes

                join dbLead in dbContext.Leads
                    on dbNote.LeadId equals dbLead.Id
                    into leadJoin
                from dbLead in leadJoin.DefaultIfEmpty()

                join dbAccount in dbContext.Accounts
                    on dbNote.AccountId equals dbAccount.Id
                    into accountJoin
                from dbAccount in accountJoin.DefaultIfEmpty()

                join dbContact in dbContext.Contacts
                    on dbNote.ContactId equals dbContact.Id
                    into contactJoin
                from dbContact in contactJoin.DefaultIfEmpty()

                join dbOpportunity in dbContext.Opportunities
                    on dbNote.OpportunityId equals dbOpportunity.Id
                    into opportunityJoin
                from dbOpportunity in opportunityJoin.DefaultIfEmpty()

                where dbNote.Id == id

                select new NoteDetails
                {
                    Note = dbNote,
                    Account = dbAccount,
                    Contact = dbContact,
                    Opportunity = dbOpportunity,
                    Lead = dbLead
                }
            ).FirstOrDefaultAsync(cancellationToken);
        return result ?? throw new EntityNotFoundException();
    }

    public async Task<List<Note>> GetForLead(Guid id)
    {
        var dbContext = await GetDbContextAsync();
        var notes = dbContext.Notes.Where(n => n.LeadId == id).ToList();
        return notes;
    }

    public async Task<List<Note>> GetForContact(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Note>> GetForAccount(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Note>> GetForOpportunity(Guid id)
    {
        throw new NotImplementedException();
    }
}