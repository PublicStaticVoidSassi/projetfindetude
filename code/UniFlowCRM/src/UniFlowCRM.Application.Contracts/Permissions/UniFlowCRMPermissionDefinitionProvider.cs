using UniFlowCRM.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace UniFlowCRM.Permissions;

public class UniFlowCRMPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UniFlowCRMPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(UniFlowCRMPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(UniFlowCRMPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(UniFlowCRMPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(UniFlowCRMPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(UniFlowCRMPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UniFlowCRMResource>(name);
    }
}
