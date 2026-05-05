namespace Itcomp.Sgs.Crm.Opportunities
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

    public enum SalesStage
    {
        Prospecting = 0,
        Qualification = 1,
        Proposal = 2,
        Negotiation = 3,
        Closed = 4
    }

    public enum OpportunityType
    {
        NewBusiness = 0,
        ExistingBusiness = 1,
        Renewal = 2
    }
}