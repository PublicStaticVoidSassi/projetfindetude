using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Opportunities
{
    public class Opportunity : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual string? Description { get; protected set; }
        public virtual decimal? Amount { get; protected set; }
        public virtual DateTime? CloseDate { get; protected set; }
        public virtual OpportunityStage Stage { get; protected set; }
        public virtual SalesStage SalesStage { get; protected set; }
        public virtual OpportunityType Type { get; protected set; }
        public virtual int Probability { get; protected set; } // 0-100
        public virtual Guid? AccountId { get; protected set; }
        public virtual Guid? ContactId { get; protected set; }
        public virtual string? LeadSource { get; protected set; }
        public virtual string? NextStep { get; protected set; }

        protected Opportunity()
        {
            // Constructeur protégé pour Entity Framework
        }

        public Opportunity(Guid id, string name) : base(id)
        {
            SetName(name);
            Stage = OpportunityStage.Prospecting;
            SalesStage = SalesStage.Prospecting;
            Type = OpportunityType.NewBusiness;
            Probability = 10;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name), OpportunityConsts.MaxNameLength);
            Name = name;
        }

        public virtual void SetDescription(string? description)
        {
            Check.Length(description, nameof(description), OpportunityConsts.MaxDescriptionLength);
            Description = description;
        }

        public virtual void SetAmount(decimal? amount)
        {
            if (amount.HasValue && amount.Value < 0)
            {
                throw new ArgumentException("Amount cannot be negative", nameof(amount));
            }
            Amount = amount;
        }

        public virtual void SetCloseDate(DateTime? closeDate)
        {
            CloseDate = closeDate;
        }

        public virtual void SetStage(OpportunityStage stage)
        {
            Stage = stage;
        }

        public virtual void SetSalesStage(SalesStage salesStage)
        {
            SalesStage = salesStage;
        }

        public virtual void SetType(OpportunityType type)
        {
            Type = type;
        }

        public virtual void SetProbability(int probability)
        {
            if (probability < 0 || probability > 100)
            {
                throw new ArgumentException("Probability must be between 0 and 100", nameof(probability));
            }
            Probability = probability;
        }

        public virtual void SetAccountId(Guid? accountId)
        {
            AccountId = accountId;
        }

        public virtual void SetContactId(Guid? contactId)
        {
            ContactId = contactId;
        }

        public virtual void SetLeadSource(string? leadSource)
        {
            Check.Length(leadSource, nameof(leadSource), OpportunityConsts.MaxLeadSourceLength);
            LeadSource = leadSource;
        }

        public virtual void SetNextStep(string? nextStep)
        {
            Check.Length(nextStep, nameof(nextStep), OpportunityConsts.MaxNextStepLength);
            NextStep = nextStep;
        }
    }
}
