using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Moneys;
using Volo.Abp.Identity;

namespace UniFlowCRM.Campaigns
{
    public class CreateUpdateCampaignDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CampaignStatus Status { get; set; }
        public decimal BudgetValue { get; set; }
        public Currency BudgetCurrency { get; set; }
        public decimal CostSoFarValue { get; set; }
        public Currency CostSoFarCurrency { get; set; }
        public int ExpectedAccounts { get; set; }
        public int ExpectedLeads { get; set; }
        public int ExpectedContacts { get; set; }
        public int ExpectedOpportunities { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid AssignedTo { get; set; }
    }
}
