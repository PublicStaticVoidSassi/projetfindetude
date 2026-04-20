using Microsoft.Extensions.Localization;
using UniFlowCRM.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace UniFlowCRM;

[Dependency(ReplaceServices = true)]
public class UniFlowCRMBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<UniFlowCRMResource> _localizer;

    public UniFlowCRMBrandingProvider(IStringLocalizer<UniFlowCRMResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
