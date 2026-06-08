using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UniFlowCRM.Accounts
{
    public interface IAccountsAppService: ICrudAppService<AccountDto,Guid,AccountRequestDto,CreateUpdateAccountDto>
    {
    }
}
