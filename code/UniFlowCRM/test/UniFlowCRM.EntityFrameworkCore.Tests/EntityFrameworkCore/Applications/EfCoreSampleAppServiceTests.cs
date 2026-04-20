using UniFlowCRM.Samples;
using Xunit;

namespace UniFlowCRM.EntityFrameworkCore.Applications;

[Collection(UniFlowCRMTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<UniFlowCRMEntityFrameworkCoreTestModule>
{

}
