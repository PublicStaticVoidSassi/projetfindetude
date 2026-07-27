using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Campaigns
{
    public interface ICampaignsRepository : IRepository<Campaign,Guid>
    {
    }
}
