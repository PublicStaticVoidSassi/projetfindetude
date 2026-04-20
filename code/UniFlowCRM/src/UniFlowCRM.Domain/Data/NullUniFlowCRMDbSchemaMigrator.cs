using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace UniFlowCRM.Data;

/* This is used if database provider does't define
 * IUniFlowCRMDbSchemaMigrator implementation.
 */
public class NullUniFlowCRMDbSchemaMigrator : IUniFlowCRMDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
