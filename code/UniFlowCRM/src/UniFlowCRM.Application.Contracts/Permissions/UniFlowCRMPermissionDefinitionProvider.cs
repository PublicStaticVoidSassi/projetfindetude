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

        //var booksPermission = myGroup.AddPermission(UniFlowCRMPermissions.Books.Default, L("Permission:Books"));
        //booksPermission.AddChild(UniFlowCRMPermissions.Books.Create, L("Permission:Books.Create"));
        //booksPermission.AddChild(UniFlowCRMPermissions.Books.Edit, L("Permission:Books.Edit"));
        //booksPermission.AddChild(UniFlowCRMPermissions.Books.Delete, L("Permission:Books.Delete"));
        var AssignPermission = myGroup.AddPermission(UniFlowCRMPermissions.Administration.Default, L("Permission:Assign"));
        var LeadPermission = myGroup.AddPermission(UniFlowCRMPermissions.Lead.Default, L("Permission:Lead"));
        LeadPermission.AddChild(UniFlowCRMPermissions.Lead.ViewAll, L("Permission:Books.ViewAll"));
        LeadPermission.AddChild(UniFlowCRMPermissions.Lead.Create, L("Permission:Books.Create"));
        LeadPermission.AddChild(UniFlowCRMPermissions.Lead.Edit, L("Permission:Books.Edit"));
        LeadPermission.AddChild(UniFlowCRMPermissions.Lead.Delete, L("Permission:Books.Delete"));
        LeadPermission.AddChild(UniFlowCRMPermissions.Lead.Convert, L("Permission:Lead.Convert"));

        var AccountPermission = myGroup.AddPermission(UniFlowCRMPermissions.Account.Default, L("Permission:Account"));
        AccountPermission.AddChild(UniFlowCRMPermissions.Account.ViewAll, L("Permission:Books.ViewAll"));
        AccountPermission.AddChild(UniFlowCRMPermissions.Account.Create, L("Permission:Books.Create"));
        AccountPermission.AddChild(UniFlowCRMPermissions.Account.Edit, L("Permission:Books.Edit"));
        AccountPermission.AddChild(UniFlowCRMPermissions.Account.Delete, L("Permission:Books.Delete"));

        var ContactPermission = myGroup.AddPermission(UniFlowCRMPermissions.Contact.Default, L("Permission:Contact"));
        ContactPermission.AddChild(UniFlowCRMPermissions.Contact.ViewAll, L("Permission:Books.ViewAll"));
        ContactPermission.AddChild(UniFlowCRMPermissions.Contact.Create, L("Permission:Books.Create"));
        ContactPermission.AddChild(UniFlowCRMPermissions.Contact.Edit, L("Permission:Books.Edit"));
        ContactPermission.AddChild(UniFlowCRMPermissions.Contact.Delete, L("Permission:Books.Delete"));

        var OpportunityPermission = myGroup.AddPermission(UniFlowCRMPermissions.Opportunity.Default, L("Permission:Opportunity"));
        OpportunityPermission.AddChild(UniFlowCRMPermissions.Opportunity.ViewAll, L("Permission:Books.ViewAll"));
        OpportunityPermission.AddChild(UniFlowCRMPermissions.Opportunity.Create, L("Permission:Books.Create"));
        OpportunityPermission.AddChild(UniFlowCRMPermissions.Opportunity.Edit, L("Permission:Books.Edit"));
        OpportunityPermission.AddChild(UniFlowCRMPermissions.Opportunity.Delete, L("Permission:Books.Delete"));
        OpportunityPermission.AddChild(UniFlowCRMPermissions.Opportunity.Close, L("Permission:Opportunity.Close"));

        var TaskPermission = myGroup.AddPermission(UniFlowCRMPermissions.Task.Default, L("Permission:Task"));
        TaskPermission.AddChild(UniFlowCRMPermissions.Task.ViewAll, L("Permission:Books.ViewAll"));
        TaskPermission.AddChild(UniFlowCRMPermissions.Task.Create, L("Permission:Books.Create"));
        TaskPermission.AddChild(UniFlowCRMPermissions.Task.Edit, L("Permission:Books.Edit"));
        TaskPermission.AddChild(UniFlowCRMPermissions.Task.Delete, L("Permission:Books.Delete"));

        var CallPermission = myGroup.AddPermission(UniFlowCRMPermissions.Call.Default, L("Permission:Call"));
        CallPermission.AddChild(UniFlowCRMPermissions.Call.ViewAll, L("Permission:Books.ViewAll"));
        CallPermission.AddChild(UniFlowCRMPermissions.Call.Create, L("Permission:Books.Create"));
        CallPermission.AddChild(UniFlowCRMPermissions.Call.Edit, L("Permission:Books.Edit"));
        CallPermission.AddChild(UniFlowCRMPermissions.Call.Delete, L("Permission:Books.Delete"));

        var MeetingPermission = myGroup.AddPermission(UniFlowCRMPermissions.Meeting.Default, L("Permission:Meeting"));
        MeetingPermission.AddChild(UniFlowCRMPermissions.Meeting.ViewAll, L("Permission:Books.ViewAll"));
        MeetingPermission.AddChild(UniFlowCRMPermissions.Meeting.Create, L("Permission:Books.Create"));
        MeetingPermission.AddChild(UniFlowCRMPermissions.Meeting.Edit, L("Permission:Books.Edit"));
        MeetingPermission.AddChild(UniFlowCRMPermissions.Meeting.Delete, L("Permission:Books.Delete"));

        var EmailPermission = myGroup.AddPermission(UniFlowCRMPermissions.Email.Default, L("Permission:Email"));
        EmailPermission.AddChild(UniFlowCRMPermissions.Email.ViewAll, L("Permission:Books.ViewAll"));
        EmailPermission.AddChild(UniFlowCRMPermissions.Email.Create, L("Permission:Books.Create"));
        EmailPermission.AddChild(UniFlowCRMPermissions.Email.Edit, L("Permission:Books.Edit"));
        EmailPermission.AddChild(UniFlowCRMPermissions.Email.Delete, L("Permission:Books.Delete"));
        EmailPermission.AddChild(UniFlowCRMPermissions.Email.Send, L("Permission:Email.Send"));

        var NotePermission = myGroup.AddPermission(UniFlowCRMPermissions.Note.Default, L("Permission:Note"));
        NotePermission.AddChild(UniFlowCRMPermissions.Note.Create, L("Permission:Books.Create"));
        //NotePermission.AddChild(UniFlowCRMPermissions.Note.Edit, L("Permission:Books.Edit"));
        //NotePermission.AddChild(UniFlowCRMPermissions.Note.Delete, L("Permission:Books.Delete"));




        //Define your own permissions here. Example:
        //myGroup.AddPermission(UniFlowCRMPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UniFlowCRMResource>(name);
    }
}
