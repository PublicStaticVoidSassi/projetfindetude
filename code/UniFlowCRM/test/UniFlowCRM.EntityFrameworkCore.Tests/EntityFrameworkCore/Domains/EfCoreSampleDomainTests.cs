using UniFlowCRM.Samples;
using Xunit;

namespace UniFlowCRM.EntityFrameworkCore.Domains;

[Collection(UniFlowCRMTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<UniFlowCRMEntityFrameworkCoreTestModule>
{

}
