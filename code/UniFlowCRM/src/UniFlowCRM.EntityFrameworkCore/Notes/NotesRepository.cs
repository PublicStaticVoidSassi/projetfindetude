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



public class NotesRepository : EfCoreRepository<UniFlowCRMDbContext, Note, Guid>, INotesRepository
{
    public NotesRepository(IDbContextProvider<UniFlowCRMDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

}
