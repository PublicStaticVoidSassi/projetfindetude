using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Meetings;

public class MeetingRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
