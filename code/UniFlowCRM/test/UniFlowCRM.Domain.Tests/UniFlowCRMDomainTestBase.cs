using Volo.Abp.Modularity;

namespace UniFlowCRM;

/* Inherit from this class for your domain layer tests. */
public abstract class UniFlowCRMDomainTestBase<TStartupModule> : UniFlowCRMTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
