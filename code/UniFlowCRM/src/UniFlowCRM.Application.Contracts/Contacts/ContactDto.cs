using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UniFlowCRM.Accounts;
using UniFlowCRM.Leads;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace UniFlowCRM.Contacts
{
    public class ContactDto: FullAuditedEntityDto<Guid>
    {
        public string FirstName { get;  set; }
        public string? MiddleName { get;  set; }
        public string? LastName { get;  set; }

        public string? Description { get;  set; }

        public ContactStatus Status { get;  set; }
        public ContactSource Source { get;  set; }

        public string? Phone { get;  set; }
        public string? Fax { get;  set; }
        public string? Email { get;  set; }
        public string? Website { get;  set; }
        public string? Country { get;  set; }
        public string? City { get;  set; }
        public string? Street { get;  set; }
        public int? PostalCode { get;  set; }

        public string? Job { get;  set; } // I want one
        public string? Departement { get;  set; }

        public Guid UserID { get;  set; } // user FK
        public IdentityUserDto? Owner { get; set; }
        public IdentityUserDto? Modifier { get; set; }
        public IdentityUserDto? Creator { get; set; }
        public Guid? LeadID { get; set; }
        public LeadDto? Lead { get; set; }
        public Guid? AccountID { get;  set; } // Account FK
        public AccountDto? Account { get; set; }
        public Guid? CampaignId { get; set; }
    }
}
