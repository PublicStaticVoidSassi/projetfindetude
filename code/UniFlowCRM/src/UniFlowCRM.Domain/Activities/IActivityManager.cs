using System;
using System.Threading;
using Volo.Abp.DependencyInjection;

namespace UniFlowCRM.Activities;

public interface IActivityManager: ITransientDependency
{
    System.Threading.Tasks.Task CheckTimeAvailableAsync(Guid userid, DateTime start,DateTime end,CancellationToken ctx = default);
}