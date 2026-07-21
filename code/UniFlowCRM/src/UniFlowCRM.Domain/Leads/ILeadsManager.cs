using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace UniFlowCRM.Leads
{
    public interface ILeadsManager : ITransientDependency
    {
        Task<Guid> ConvertAsync(Guid id);
    }
}