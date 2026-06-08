using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Accounts
{
    public class AccountRequestDto : PagedAndSortedResultRequestDto
    {
        public string? Name { get; set; }
        public AccountType? Type { get; set; }
        public AccountIndustry? Industry { get; set; }
    }
}
