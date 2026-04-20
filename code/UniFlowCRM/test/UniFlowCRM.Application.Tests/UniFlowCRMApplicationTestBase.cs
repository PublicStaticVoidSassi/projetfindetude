using Volo.Abp.Modularity;

namespace UniFlowCRM;

public abstract class UniFlowCRMApplicationTestBase<TStartupModule> : UniFlowCRMTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
