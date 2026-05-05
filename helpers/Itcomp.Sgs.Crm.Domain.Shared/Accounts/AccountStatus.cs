namespace Itcomp.Sgs.Crm.Accounts
{
    public enum AccountStatus : byte
    {
        Prospect,  // A potential customer; early stage.
        Active,    // Currently doing business with you.
        Inactive,  // No recent activity; not currently engaged.
        Closed     // Relationship ended or lost permanently.
    }
}