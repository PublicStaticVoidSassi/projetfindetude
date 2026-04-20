using UniFlowCRM.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace UniFlowCRM.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UniFlowCRMEntityFrameworkCoreModule),
    typeof(UniFlowCRMApplicationContractsModule)
)]
public class UniFlowCRMDbMigratorModule : AbpModule
{
}
