using System;
using System.Linq;
using System.Threading;
using UniFlowCRM.Calls;
using UniFlowCRM.Meetings;
using UniFlowCRM.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Activities;

public class ActivityManager
    (
        IRepository<Meeting, Guid> meetingRepository,
        IRepository<Call, Guid> callRepository,
        IRepository<Task, Guid> taskRepository
        ) : IActivityManager
{
    public async System.Threading.Tasks.Task CheckTimeAvailableAsync(Guid userid, DateTime start, DateTime end, CancellationToken ctx = default)
    {
        var meeting = (await meetingRepository.GetQueryableAsync())
            .FirstOrDefault(m => m.OwnerID == userid && start < m.EndTime && end > m.StartTime);
        var call = (await callRepository.GetQueryableAsync())
            .FirstOrDefault(m => m.OwnerID == userid && start < m.EndTime && end > m.StartTime);
        var task = (await taskRepository.GetQueryableAsync())
            .FirstOrDefault(m => m.OwnerID == userid && start < m.EndTime && end > m.StartTime);
        if (meeting != null || call != null || task != null)
            throw new UserFriendlyException($"Cet utilisateur a déjà une activité programmée entre {start} et {end}");
        return;
    }

}
