using Volo.Abp.Modularity;

namespace UniFlowCRM;

[DependsOn(
    typeof(UniFlowCRMApplicationModule),
    typeof(UniFlowCRMDomainTestModule)
)]
public class UniFlowCRMApplicationTestModule : AbpModule
{

}
