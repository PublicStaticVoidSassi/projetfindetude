namespace UniFlowCRM.Permissions;

public static class UniFlowCRMPermissions
{
    public const string GroupName = "UniFlowCRM";


    //public static class Books
    //{
    //    public const string Default = GroupName + ".Books";
    //    public const string Create = Default + ".Create";
    //    public const string Edit = Default + ".Edit";
    //    public const string Delete = Default + ".Delete";
    //}

    // administration
    public static class Administration
    {
        public const string Default = GroupName + ".AssignOthers";
    }


    public static class Lead
    {
        public const string Default = GroupName + ".Lead";
        public const string ViewAll = Default + ".ViewAll";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string Convert = Default + ".Convert";
    }

    public static class Account
    {
        public const string Default = GroupName + ".Account";
        public const string ViewAll = Default + ".ViewAll";

        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Contact
    {
        public const string Default = GroupName + ".Contact";
        public const string ViewAll = Default + ".ViewAll";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Opportunity
    {
        public const string Default = GroupName + ".Opportunity";
        public const string ViewAll = Default + ".ViewAll";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string Close = Default + ".Close";
    }

    public static class Task
    {
        public const string Default = GroupName + ".Task";
        public const string ViewAll = Default + ".ViewAll";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Call
    {
        public const string Default = GroupName + ".Call";
        public const string ViewAll = Default + ".ViewAll";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Meeting
    {
        public const string Default = GroupName + ".Meeting";
        public const string ViewAll = Default + ".ViewAll";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Email
    {
        public const string Default = GroupName + ".Email";
        public const string ViewAll = Default + ".ViewAll";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string Send = Default + ".Send";
    }

    public static class Note
    {
        public const string Default = GroupName + ".Note";
        public const string Create = Default + ".Create";
        //public const string Edit = Default + ".Edit";
        //public const string Delete = Default + ".Delete";
    }


    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
