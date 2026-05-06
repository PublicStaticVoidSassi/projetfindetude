using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UniFlowCRM.Opportunities
{
    public class OpportunityRepository : EfCoreRepository<UniFlowCRMDbContext, Opportunity,Guid>, IOpportunityRepository
    {
        public OpportunityRepository(IDbContextProvider<UniFlowCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
