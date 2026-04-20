using UniFlowCRM.Localization;
using Volo.Abp.Application.Services;

namespace UniFlowCRM;

/* Inherit your application services from this class.
 */
public abstract class UniFlowCRMAppService : ApplicationService
{
    protected UniFlowCRMAppService()
    {
        LocalizationResource = typeof(UniFlowCRMResource);
    }
}
