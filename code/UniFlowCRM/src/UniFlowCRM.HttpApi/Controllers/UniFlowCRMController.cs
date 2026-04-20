using UniFlowCRM.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace UniFlowCRM.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class UniFlowCRMController : AbpControllerBase
{
    protected UniFlowCRMController()
    {
        LocalizationResource = typeof(UniFlowCRMResource);
    }
}
