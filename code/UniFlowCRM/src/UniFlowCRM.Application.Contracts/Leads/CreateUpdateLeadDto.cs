using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Leads
{
    public class CreateUpdateLeadDto: EntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Description { get; set; }

        public LeadStatus? Status { get; set; }
        public LeadSource? Source { get; set; }

        public string? PhoneNumber { get; set; }
        public string? PhoneCode { get; set; }
        public string? Email { get; set; }

        public Guid? UserID { get; set; } // user FK
        public Guid? AccountID { get; set; } // Account FK
        public Guid? CampaignId { get; set; }
    }
}
