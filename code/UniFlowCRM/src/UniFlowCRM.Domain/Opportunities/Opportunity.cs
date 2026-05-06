using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace UniFlowCRM.Opportunities
{
    public class Opportunity : FullAuditedAggregateRoot<Guid>
    {
        public string Name{get; protected set;}

        public string? Description{get; protected set;}

        public ValueObjects.Money Amount{get; protected set;}


        public OpportunityStage Stage{get; protected set;}

        public OpportunityType Type{get; protected set;}

        public SaleStage SaleStage{get; protected set;}

        public short Probability{get; protected set;}

        public string? NextStep{get; protected set;}

        public DateTime? ClosedAt{get; protected set;}

        public Guid UserID { get; protected set; }
        public Guid? LeadID { get; protected set; }
        public Guid? AccountID { get; protected set; }
        public Guid? ContactID { get; protected set; }
        //TODO:    
        public Opportunity(Guid id): base(id)
        {

        }
        protected Opportunity() { }
    }
}
