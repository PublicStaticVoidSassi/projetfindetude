using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Dashboards;

public class DashboardDto : EntityDto
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

    public int totalleads { get; set; }
    public int totalcontacts { get; set; }
    public int totalopportunities { get; set; }
}
