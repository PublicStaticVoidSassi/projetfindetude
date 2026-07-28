using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Campaigns
{
    public interface ICampaignsRepository : IRepository<Campaign,Guid>
    {
        Task<Campaign?> FindJoinedAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default);
        Task<Campaign> GetJoinedAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default);

    }
}
