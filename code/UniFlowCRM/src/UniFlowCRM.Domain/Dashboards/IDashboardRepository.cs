using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace UniFlowCRM.Dashboards;

public interface IDashboardRepository : ITransientDependency
{
    Task<Dashboard> GetAsync(CancellationToken ct = default);
    Task<Income> GetIncomeAsync(CancellationToken ct = default);
}

