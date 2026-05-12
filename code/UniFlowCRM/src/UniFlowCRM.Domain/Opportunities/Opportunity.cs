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
        public void SetName(string name)
{
    Name = name;
}

public void SetDescription(string? description)
{
    Description = description;
}

public void SetAmount(ValueObjects.Money amount)
{
    Amount = amount;
}

public void SetStage(OpportunityStage stage)
{
    Stage = stage;
}

public void SetType(OpportunityType type)
{
    Type = type;
}

public void SetSaleStage(SaleStage saleStage)
{
    SaleStage = saleStage;
}

public void SetProbability(short probability)
{
    Probability = probability;
}

public void SetNextStep(string? nextStep)
{
    NextStep = nextStep;
}

public void SetClosedAt(DateTime? closedAt)
{
    ClosedAt = closedAt;
}

public void AssignTo(Guid userID)
{
    UserID = userID;
}

public void SetLead(Guid? leadID)
{
    LeadID = leadID;
}

public void SetAccount(Guid? accountID)
{
    AccountID = accountID;
}

public void SetContact(Guid? contactID)
{
    ContactID = contactID;
}
    }
}
