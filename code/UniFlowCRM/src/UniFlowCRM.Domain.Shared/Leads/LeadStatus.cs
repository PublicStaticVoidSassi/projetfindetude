using System;
using System.Collections.Generic;
using System.Text;

namespace UniFlowCRM.Leads
{
    public enum LeadStatus
    {
        New = 0,
        // Assigned = 1,
        Qualified = 1,
        InProcess = 2,
        Converted = 3,
        Recycled = 4,
        Dead = 5
    }
}
