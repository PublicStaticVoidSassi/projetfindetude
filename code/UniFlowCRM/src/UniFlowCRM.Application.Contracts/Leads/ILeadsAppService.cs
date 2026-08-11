using System;
using System.Threading.Tasks;
using UniFlowCRM.Contacts;
using Volo.Abp.Application.Services;

namespace UniFlowCRM.Leads
{
    public interface ILeadsAppService : ICrudAppService<
        LeadDto,
        Guid,
        LeadRequestDto,
        CreateUpdateLeadDto>
    {
        Task<Guid> ConvertAsync(Guid id);
    }
}
