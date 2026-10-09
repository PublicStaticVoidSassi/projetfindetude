using System;
using System.Linq;
using UniFlowCRM.Permissions;
using Volo.Abp.Identity;

namespace UniFlowCRM.Permission
{
    public static class DefaultRolesPerms
    {
        public static string ManagerName = "Directeur";
        public static string SalesmanName = "Marketeur";
        public static string SupportName = "Support";

        public static string[] DefaultSupportPerms = {
        IdentityPermissions.Users.Default, // gotta see the users;
        UniFlowCRMPermissions.Lead.Default,
        UniFlowCRMPermissions.Account.Default,
        UniFlowCRMPermissions.Contact.Default,
        UniFlowCRMPermissions.Opportunity.Default,
        UniFlowCRMPermissions.Campaign.Default,
        UniFlowCRMPermissions.Task.Default,
        UniFlowCRMPermissions.Task.Create,
        UniFlowCRMPermissions.Task.Edit,
        UniFlowCRMPermissions.Task.Delete,
        UniFlowCRMPermissions.Call.Default,
        UniFlowCRMPermissions.Call.Create,
        UniFlowCRMPermissions.Call.Edit,
        UniFlowCRMPermissions.Call.Delete,
        UniFlowCRMPermissions.Meeting.Default,
        UniFlowCRMPermissions.Meeting.Create,
        UniFlowCRMPermissions.Meeting.Edit,
        UniFlowCRMPermissions.Meeting.Delete,
        UniFlowCRMPermissions.Email.Default,
        UniFlowCRMPermissions.Email.Create,
        UniFlowCRMPermissions.Email.Edit,
        UniFlowCRMPermissions.Email.Delete,
        UniFlowCRMPermissions.Note.Default,
        UniFlowCRMPermissions.Note.Create

        };
        public static string[] DefaultMarketairePerms = DefaultSupportPerms.Concat(new[]{
        UniFlowCRMPermissions.Lead.Create,
        UniFlowCRMPermissions.Lead.Edit,
        UniFlowCRMPermissions.Lead.Delete,
        UniFlowCRMPermissions.Lead.Qualify,
        UniFlowCRMPermissions.Account.Create,
        UniFlowCRMPermissions.Account.Edit,
        UniFlowCRMPermissions.Account.Delete,
        UniFlowCRMPermissions.Contact.Create,
        UniFlowCRMPermissions.Contact.Edit,
        UniFlowCRMPermissions.Contact.Delete,
        UniFlowCRMPermissions.Opportunity.Create,
        UniFlowCRMPermissions.Opportunity.Edit,
        UniFlowCRMPermissions.Opportunity.Delete,
                }).ToArray();
        public static string[] DefaultManagerPerms = DefaultMarketairePerms.Concat(
                    new[] {
                UniFlowCRMPermissions.Lead.Convert,
                UniFlowCRMPermissions.Opportunity.Close,
                UniFlowCRMPermissions.Email.Send,
                UniFlowCRMPermissions.Administration.Default,
                UniFlowCRMPermissions.Analytics.Default,
        UniFlowCRMPermissions.Lead.ViewAll,
        UniFlowCRMPermissions.Contact.ViewAll,
        UniFlowCRMPermissions.Account.ViewAll,
        UniFlowCRMPermissions.Opportunity.ViewAll,
        UniFlowCRMPermissions.Task.ViewAll,
        UniFlowCRMPermissions.Call.ViewAll,
        UniFlowCRMPermissions.Meeting.ViewAll,
        UniFlowCRMPermissions.Email.ViewAll,
        UniFlowCRMPermissions.Campaign.ViewAll,


                    }
                    ) // Concat(IdentityPermissions.GetAll())
            .ToArray();
    }
}
