using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UniFlowCRM.Accounts
{
    internal class AccountsRepository : EfCoreRepository<UniFlowCRMDbContext, Account>, IAccountsRepository
    {
        public AccountsRepository(IDbContextProvider<UniFlowCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
