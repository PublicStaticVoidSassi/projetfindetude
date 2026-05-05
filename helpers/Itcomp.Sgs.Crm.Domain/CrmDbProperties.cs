namespace Itcomp.Sgs.Crm;

public static class CrmDbProperties
{
    public static string DbTablePrefix { get; set; } = "itc";

    public static string? DbSchema { get; set; } = "crm";

    public const string ConnectionStringName = "Crm";
}
