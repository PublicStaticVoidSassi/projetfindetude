
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Contacts;

public class ContactRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
