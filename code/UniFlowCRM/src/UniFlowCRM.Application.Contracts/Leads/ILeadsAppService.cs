using System;
using Volo.Abp.Application.Services;

namespace UniFlowCRM.Leads
{
    public interface ILeadsAppService : ICrudAppService<
        LeadDto,
        Guid,
        LeadRequestDto,
        CreateUpdateLeadDto>
    {
    }
}
