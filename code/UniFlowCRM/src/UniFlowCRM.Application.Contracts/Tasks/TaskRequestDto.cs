using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Tasks;

public class TaskRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
