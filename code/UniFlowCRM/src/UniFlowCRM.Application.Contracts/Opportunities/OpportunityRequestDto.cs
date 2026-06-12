using Volo.Abp.Application.Dtos;

public class OpportunityRequestDto : PagedAndSortedResultRequestDto
{
    public string? filter { get; set; }
}
