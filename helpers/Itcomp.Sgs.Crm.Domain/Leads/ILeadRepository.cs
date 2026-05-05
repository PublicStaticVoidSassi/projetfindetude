using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Itcomp.Sgs.Crm.Leads
{
    public interface ILeadRepository : IRepository<Lead, Guid>
    {
        Task<List<Lead>> GetListAsync(string? filter = null,
                                         string? name = null,
                                         string? email = null,
                                         string? phone = null,
                                         LeadStatus? status = null,
                                         int? skipCount = null,
                                         int? maxResultCount = null);
        Task<long> GetCountAsync(string? filter = null,
                                 string? name = null,
                                 string? email = null,
                                 string? phone = null,
                                 LeadStatus? status = null);

    }
}