using Xunit;

namespace UniFlowCRM.EntityFrameworkCore;

[CollectionDefinition(UniFlowCRMTestConsts.CollectionDefinitionName)]
public class UniFlowCRMEntityFrameworkCoreCollection : ICollectionFixture<UniFlowCRMEntityFrameworkCoreFixture>
{

}
