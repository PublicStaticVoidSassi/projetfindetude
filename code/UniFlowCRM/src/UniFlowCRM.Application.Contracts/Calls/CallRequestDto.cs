using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Calls;

public class CallRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
