using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Itcomp.Sgs.Crm.Accounts
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
        Task<List<Account>> GetListAsync(string? filter = null,
                                         string? name = null,
                                         string? email = null,
                                         string? phone = null,
                                         int? skipCount = null,
                                         int? maxResultCount = null);
        Task<long> GetCountAsync(string? filter = null,
                                 string? name = null,
                                 string? email = null,
                                 string? phone = null);

    }
}