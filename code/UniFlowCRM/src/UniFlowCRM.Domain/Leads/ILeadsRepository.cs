using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Leads
{
    public interface ILeadsRepository: IRepository<Lead>
    {
    }
}
