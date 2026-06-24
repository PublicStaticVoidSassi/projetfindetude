namespace UniFlowCRM.Dashboards;

public class Dashboard
{
    public int pendingleads { get; set; }
    public int convertedleads { get; set; }
    public int deadleads { get; set; }
    public int activecontacts { get; set; }
    public int inactivecontacts { get; set; }
    public int totalaccounts { get; set; }
    public int pendingdeals { get; set; }
    public int wondeals { get; set; }
    public int lostdeals { get; set; }

    public int totalleads => pendingleads + deadleads + convertedleads;
    public int totalcontacts => activecontacts + inactivecontacts;
    public int totalopportunities => pendingdeals + wondeals + lostdeals;
}
