using Volo.Abp.Application.Dtos;

public class EmailRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
