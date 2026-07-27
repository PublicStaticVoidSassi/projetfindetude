using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Campaigns;
using UniFlowCRM.Moneys;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace UniFlowCRM.Campaigns
{
    public class CampaignDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CampaignStatus Status { get; set; }
        public decimal BudgetValue { get; set; }
        public Currency BudgetCurrency { get; set; }
        public decimal? CostSoFarValue { get; set; }
        public Currency CostSoFarCurrency { get; set; }
        public int ExpectedAccounts { get; set; }
        public int ExpectedLeads {get;set;}
        public int ExpectedContacts {get;set;}
        public int ExpectedOpportunities {get;set;}
        public int ReachedAccounts {get;set;}
        public int ReachedLeads {get;set;}
        public int ReachedContacts {get;set;}
        public int ReachedOpportunities {get;set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid AssignedTo { get; set; }
        public IdentityUserDto Owner { get; set; }
    }
}