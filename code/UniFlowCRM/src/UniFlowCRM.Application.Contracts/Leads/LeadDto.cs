using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Constraints;
using Volo.Abp.Application.Dtos;

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
        public string? UserName { get; set; } // user Assigned to
        public Guid? AccountID { get; set; } // Account FK
        public string? AccountName { get; set; } // Account Name
    }
}
