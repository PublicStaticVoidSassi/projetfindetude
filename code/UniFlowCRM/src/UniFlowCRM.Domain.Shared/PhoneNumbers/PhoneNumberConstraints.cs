namespace UniFlowCRM.PhoneNumbers
{
    public static class PhoneNumberConstraints
    {
        // Country code (E.164 max is 1–3 digits, but we allow + and a bit of flexibility)
        public const int CodeMinLength = 2;   // e.g. "1"
        public const int CodeMaxLength = 4;   // e.g. "+123"

        // National number (real-world varies widely)
        public const int MinLength = 4;        // very small local numbers exist
        public const int MaxLength = 14;       // E.164 standard max total length is 15 incl. country code
    }
}
