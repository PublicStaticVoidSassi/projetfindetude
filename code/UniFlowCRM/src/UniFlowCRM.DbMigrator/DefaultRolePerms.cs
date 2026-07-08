using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UniFlowCRM.Permissions;
using Volo.Abp.Identity;

namespace UniFlowCRM.Permission
{
    public static class DefaultRolesPerms
    {
        public static string ManagerName = "Directeur";
        public static string SalesmanName = "Marketaire";

        public static string[] DefaultMarketairePerms = {
        IdentityPermissions.Users.Default, // gotta see the users;
        UniFlowCRMPermissions.Lead.Default,
        UniFlowCRMPermissions.Lead.Create,
        UniFlowCRMPermissions.Lead.Edit,
        UniFlowCRMPermissions.Lead.Delete,
        UniFlowCRMPermissions.Account.Default,
        UniFlowCRMPermissions.Account.Create,
        UniFlowCRMPermissions.Account.Edit,
        UniFlowCRMPermissions.Account.Delete,
        UniFlowCRMPermissions.Contact.Default,
        UniFlowCRMPermissions.Contact.Create,
        UniFlowCRMPermissions.Contact.Edit,
        UniFlowCRMPermissions.Contact.Delete,
        UniFlowCRMPermissions.Opportunity.Default,
        UniFlowCRMPermissions.Opportunity.Create,
        UniFlowCRMPermissions.Opportunity.Edit,
        UniFlowCRMPermissions.Opportunity.Delete,
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
        public static string[] DefaultManagerPerms = DefaultMarketairePerms.Concat(
                    new[] {
                UniFlowCRMPermissions.Lead.Convert,
                UniFlowCRMPermissions.Opportunity.Close,
                UniFlowCRMPermissions.Email.Send,
                
                    }
                    ).Concat(IdentityPermissions.GetAll())
            .ToArray();
    }
}