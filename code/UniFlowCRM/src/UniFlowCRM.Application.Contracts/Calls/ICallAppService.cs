using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UniFlowCRM.Calls;

public interface ICallAppService : ICrudAppService<CallDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateCallDto> 
{
    
}