using Volo.Abp.Modularity;

namespace UniFlowCRM;

[DependsOn(
    typeof(UniFlowCRMDomainModule),
    typeof(UniFlowCRMTestBaseModule)
)]
public class UniFlowCRMDomainTestModule : AbpModule
{

}
