namespace Itcomp.Sgs.Crm.Contacts
{
    public static class ContactConsts
    {
        public static int MaxFirstNameLength { get; set; } = 128;
        public static int MaxLastNameLength { get; set; } = 128;
        public static int MaxNameLength { get; set; } = 128 + 128 + 1; // LastName + ' ' + FirstName
        public static int MaxNameArLength { get; set; } = 128 + 128 + 1; // LastNameAr + ' ' + FirstNameAr
        public static int MaxEmailLength { get; set; } = 256;
        public static int MaxPhoneLength { get; set; } = 32;
        public static int MaxMobilePhoneLength { get; set; } = 32;
        public static int MaxAddressLine1Length { get; set; } = 256;
        public static int MaxAddressLine2Length { get; set; } = 256;
        public static int MaxTitleLength { get; set; } = 128;
        public static int MaxDepartmentLength { get; set; } = 128;
        public static int MaxStatusLength { get; set; } = 32;
        public static int MaxLeadSourceLength { get; set; } = 32;
        public static int MaxDescriptionLength { get; set; } = 512;
    }
}