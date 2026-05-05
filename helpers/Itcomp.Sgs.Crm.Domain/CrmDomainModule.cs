using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Itcomp.Sgs.Crm;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CrmDomainSharedModule)
)]
public class CrmDomainModule : AbpModule
{

}
