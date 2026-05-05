namespace Itcomp.Sgs.Crm.Opportunities
{
    public static class OpportunityConsts
    {
        public static int MaxNameLength { get; set; } = 128;
        public static int MaxDescriptionLength { get; set; } = 512;
        public static string AmountColumnType { get; set; } = "decimal(18,2)";
        public static int MaxStageLength { get; set; } = 64;
        public static int MaxSalesStageLength { get; set; } = 64;
        public static int MaxTypeLength { get; set; } = 64;
        public static int MaxLeadSourceLength { get; set; } = 128;
        public static int MaxNextStepLength { get; set; } = 256;
    }
}