using Volo.Abp.Application.Dtos;

public class MeetingRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
