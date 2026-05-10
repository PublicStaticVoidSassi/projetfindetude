using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UniFlowCRM.Money;
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Accounts
{
    public class AccountDto: FullAuditedEntityDto<Guid>
    {
        public required string Name { get;  set; }
        public string? Description { get;  set; }

        public string? Phone{ get;  set; }
        public string? Fax{ get;  set; }
        public string? Email { get;  set; }
        public string? Website { get;  set; }
        public string? City { get; set; }
        public string? Street{ get; set; }
        public string? Country { get; set; }
        public int? PostalCode { get; set; }

        public AccountType Type { get;  set; }
        public AccountIndustry? Industry { get;  set; }

        public float? RevenueValue { get;  set; }
        public Currency? RevenueCurrency { get;  set; }
        public int? Employees { get;  set; }

        public Guid UserID { get;  set; } // user fk
        public string? Username { get; set; }
        public string? creatorName { get; set; }
    }
}
