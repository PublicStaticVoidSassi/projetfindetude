using Volo.Abp.Settings;

namespace UniFlowCRM.Settings;

public class UniFlowCRMSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(UniFlowCRMSettings.MySetting1));
    }
}
