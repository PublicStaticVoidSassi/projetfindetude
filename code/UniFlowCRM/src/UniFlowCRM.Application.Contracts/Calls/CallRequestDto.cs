using Volo.Abp.Application.Dtos;

public class CallRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
