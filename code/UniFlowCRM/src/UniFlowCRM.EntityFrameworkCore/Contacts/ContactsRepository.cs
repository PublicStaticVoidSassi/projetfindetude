using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UniFlowCRM.Contacts
{
    internal class ContactsRepository : EfCoreRepository<UniFlowCRMDbContext, Contact>, IContactsRepository
    {
        public ContactsRepository(IDbContextProvider<UniFlowCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
