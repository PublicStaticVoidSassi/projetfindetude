using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using UniFlowCRM.Opportunities;
public interface IOpportunityAppService : ICrudAppService<
        OpportunityDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateOpportunityDto>
{ }
