using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniFlowCRM.Data;
using Volo.Abp.DependencyInjection;

namespace UniFlowCRM.EntityFrameworkCore;

public class EntityFrameworkCoreUniFlowCRMDbSchemaMigrator
    : IUniFlowCRMDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreUniFlowCRMDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the UniFlowCRMDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<UniFlowCRMDbContext>()
            .Database
            .MigrateAsync();
    }
}
