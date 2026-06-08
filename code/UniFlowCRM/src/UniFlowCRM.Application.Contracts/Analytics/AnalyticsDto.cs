using System;
using System.Collections.Generic;
using System.Text;

namespace UniFlowCRM.Analytics
{
    public abstract class BaseAnalytics
    {
        public virtual int Total { get; set; }
    }
    public class LeadAnalytics : BaseAnalytics
    {
        public int Converted { get; set; }
    }
    public class ContactAnalytics : BaseAnalytics {
        public int active { get; set; }
    }
    public class AccountAnalytics : BaseAnalytics { }
    public class OpportunityAnalytics : BaseAnalytics {
        public int Won { get; set; }
        public int Lost { get; set; }
    }
    public class AnalyticsDto
    {
        public LeadAnalytics Lead { get; set; }
        public AccountAnalytics Account { get; set; }
        public ContactAnalytics Contact { get; set; }
        public OpportunityAnalytics Opportunity { get; set; }
    }
}
