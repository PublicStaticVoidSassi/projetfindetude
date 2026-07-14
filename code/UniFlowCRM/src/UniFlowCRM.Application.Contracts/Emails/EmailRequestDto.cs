using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Emails;

public class EmailRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
