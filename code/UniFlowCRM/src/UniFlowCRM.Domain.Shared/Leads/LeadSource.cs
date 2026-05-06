using System;
using System.Collections.Generic;
using System.Text;

namespace UniFlowCRM.Leads
{
    public enum LeadSource
    {
        Unset = 0,
        ExistingCustomer = 1,
        SelfGenerated = 2,
        Employee = 3,
        Partner = 4,
        PublicRelations = 5,
        DirectMail = 6,
        Conference = 7,
        TradeShow = 8,
        WebSite = 9,
        WordOfMouth = 10,
        Email = 11,
        Campaign = 12,
        ColdCall = 13,
        Other = 14,
    }
}
