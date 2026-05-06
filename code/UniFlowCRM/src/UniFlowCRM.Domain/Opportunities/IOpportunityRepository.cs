using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Opportunities
{
    public interface IOpportunityRepository: IRepository<Opportunity,Guid>
    {
    }
}
