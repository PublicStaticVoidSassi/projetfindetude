namespace Itcomp.Sgs.Crm.Emails
{
    public static class CrmEmailConsts
    {
        public static int MaxNameLength { get; set; } = 255; // Subject
        public static string BodyColumnType { get; set; } = "text";
        public static int MaxStatusLength { get; set; } = 32;
        public static int MaxFromAddressLength { get; set; } = 255;
        public static int MaxToAddressesLength { get; set; } = 1000;
        public static int MaxCcAddressesLength { get; set; } = 1000;
        public static int MaxBccAddressesLength { get; set; } = 1000;
        public static int MaxAssignedUserNameLength { get; set; } = 64;
    }
}