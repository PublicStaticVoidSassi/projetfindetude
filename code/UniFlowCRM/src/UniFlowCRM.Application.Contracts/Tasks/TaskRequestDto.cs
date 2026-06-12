using Volo.Abp.Application.Dtos;

public class TaskRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
