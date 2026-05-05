using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Itcomp.Sgs.Crm.Contacts
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
        Task<List<Contact>> GetListAsync(string? filter = null,
                                         string? name = null,
                                         string? nameAr = null,
                                         string? email = null,
                                         string? phone = null,
                                         ContactStatus? status = null,
                                         Guid? accountId = null,
                                         string? title = null,
                                         string? department = null,
                                         int? skipCount = null,
                                         int? maxResultCount = null);
        Task<long> GetCountAsync(string? filter = null,
                                 string? name = null,
                                 string? nameAr = null,
                                 string? email = null,
                                 string? phone = null,
                                 ContactStatus? status = null,
                                 Guid? accountId = null,
                                 string? title = null,
                                 string? department = null);
    }
}