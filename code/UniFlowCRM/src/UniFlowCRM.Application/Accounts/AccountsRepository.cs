using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Accounts
{
    public class AccountsAppService : CrudAppService<Account, AccountDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAccountDto>, IAccountsAppService
    {
        public AccountsAppService(IAccountsRepository repository) : base((IRepository<Account, Guid>)repository)
        {
        }
    }
}
