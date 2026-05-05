namespace Itcomp.Sgs.Crm.Accounts
{
    public static class AccountConsts
    {
        public static int MaxNameLength { get; set; } = 128;
        public static int MaxDescriptionLength { get; set; } = 512;
        public static int MaxEmailLength { get; set; } = 256;
        public static int MaxPhoneLength { get; set; } = 32;
        public static int MaxFaxLength { get; set; } = 32;
        public static int MaxAddressLine1Length { get; set; } = 256;
        public static int MaxAddressLine2Length { get; set; } = 256;
        public static int MaxLogoSize { get; set; } = 1048576; // 1MB
        public static int MaxLogoContentTypeLength { get; set; } = 128;
        public static int MaxShortNameLength { get; set; } = 64;

        public static int MaxNisLength { get; set; } = 32;
        public static int MaxNifLength { get; set; } = 32;
        public static int MaxNssLength { get; set; } = 32;
        public static int MaxRibLength { get; set; } = 64;
    }
}