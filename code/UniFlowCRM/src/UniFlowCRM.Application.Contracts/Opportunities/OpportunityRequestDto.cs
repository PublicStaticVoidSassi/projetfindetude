using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Opportunities;

public class OpportunityRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
