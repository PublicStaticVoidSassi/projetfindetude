using UniFlowCRM.Books;
using Xunit;

namespace UniFlowCRM.EntityFrameworkCore.Applications.Books;

[Collection(UniFlowCRMTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<UniFlowCRMEntityFrameworkCoreTestModule>
{

}