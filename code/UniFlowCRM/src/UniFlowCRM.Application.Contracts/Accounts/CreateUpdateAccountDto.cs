using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Money;
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Accounts
{
    public class CreateUpdateAccountDto: EntityDto<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public string? PhoneCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxCode { get; set; }
        public string? FaxNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Country { get; set; }
        public int? PostalCode { get; set; }


        public AccountType Type { get; set; }
        public AccountIndustry? Industry { get; set; }

        public decimal? RevenueAmount { get; set; }
        public Currency? RevenueCurrency { get; set; }
        public int? Employees { get; set; }

        public Guid? UserID { get; set; } // user fk
    }
}
