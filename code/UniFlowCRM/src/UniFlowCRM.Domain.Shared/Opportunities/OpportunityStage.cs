using System;
using System.Collections.Generic;
using System.Text;

namespace UniFlowCRM.Opportunities
{
    public enum OpportunityStage
    {
        Prospecting = 0,
        Qualification = 1,
        NeedsAnalysis = 2,
        ValueProposition = 3,
        IdDecisionMakers = 4,
        PerceptionAnalysis = 5,
        ProposalPriceQuote = 6,
        NegotiationReview = 7,
        ClosedWon = 8,
        ClosedLost = 9
    }
}
