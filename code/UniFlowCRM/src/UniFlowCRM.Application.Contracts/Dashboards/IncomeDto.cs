using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Dashboards;

public class IncomeDto : EntityDto
{
    public decimal dzdincome { get; set; }
    public decimal eurincome { get; set; }
    public decimal usdincome { get; set; }

}
