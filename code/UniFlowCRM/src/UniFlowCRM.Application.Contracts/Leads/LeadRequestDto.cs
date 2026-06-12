using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Leads;


public class LeadRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}

