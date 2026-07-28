using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Accounts;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace UniFlowCRM.Leads
{
    public class LeadDto : FullAuditedEntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Description { get; set; }

        public LeadStatus Status { get; set; }
        public LeadSource Source { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }

        public Guid UserID { get; set; } // user FK
        public IdentityUserDto? Owner { get; set; }
        public IdentityUserDto? Creator { get; set; }
        public IdentityUserDto? Modifier { get; set; }
        public AccountDto? Account { get; set; }
        public Guid? AccountID { get; set; } // Account FK
        public Guid? CampaignId { get; set; }
    }
}
