using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Moneys;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UniFlowCRM.Campaigns
{
    
    public class Campaign : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CampaignStatus Status { get; set; }
        public Money Budget { get; set; }
        public Money CostSoFar { get; set; }
        public int ExpectedAccounts { get; set; }
        public int ExpectedLeads { get; set; }
        public int ExpectedContacts { get; set; }
        public int ExpectedOpportunities { get; set; }
        public int ReachedAccounts { get; set; }        // DO NOT MAPPPP
        public int ReachedLeads { get; set; }       // DO NOT MAPPPP
        public int ReachedContacts { get; set; }        // DO NOT MAPPPP
        public int ReachedOpportunities { get; set; }       // DO NOT MAPPPP
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid AssignedTo { get; set; }

        public Campaign(string name, string description, CampaignStatus status, DateTime startDate, DateTime endDate, Guid assignedTo, Money budget, Money costSoFar, int expectedAccounts, int expectedLeads, int expectedContacts, int expectedOpportunities, int reachedAccounts = 0, int reachedLeads = 0, int reachedContacts = 0, int reachedOpportunities =0)
        {
            Name = name;
            Description = description;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
            AssignedTo = assignedTo;
            Budget = budget;
            CostSoFar = costSoFar;
            ExpectedAccounts = expectedAccounts;
            ExpectedLeads = expectedLeads;
            ExpectedContacts = expectedContacts;
            ExpectedOpportunities = expectedOpportunities;
            ReachedAccounts = reachedAccounts;
            ReachedLeads = reachedLeads;
            ReachedContacts = reachedContacts;
            ReachedOpportunities = reachedOpportunities;
        }


        protected Campaign() { }
    }
}
