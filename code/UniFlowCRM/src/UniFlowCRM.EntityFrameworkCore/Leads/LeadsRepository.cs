using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UniFlowCRM.Leads
{
    class LeadsRepository : EfCoreRepository<UniFlowCRMDbContext, Lead, Guid>, ILeadsRepository
    {
        public LeadsRepository(IDbContextProvider<UniFlowCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        /*public async Task<LeadAccountUser> GetFull()
        {

        }*/
    }
}
