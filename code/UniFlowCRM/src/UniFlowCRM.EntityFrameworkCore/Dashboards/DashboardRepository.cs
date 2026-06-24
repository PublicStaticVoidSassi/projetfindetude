using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniFlowCRM.Dashboards;
using UniFlowCRM.EntityFrameworkCore;

public class DashboardRepository(UniFlowCRMDbContext ctx) : IDashboardRepository
{
    public async Task<Dashboard> GetAsync(CancellationToken ct = default)
    {
        var dashboard = await ctx.Set<Dashboard>()
        .AsNoTracking()
        .FirstAsync();
        return dashboard;
    }
    public async Task<Income> GetIncomeAsync(CancellationToken ct = default)
    {
        return await ctx.Set<Income>().AsNoTracking().FirstAsync();
    }
}
