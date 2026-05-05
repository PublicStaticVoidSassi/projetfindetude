using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Notes
{
    public class CrmNote : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual string? Description { get; protected set; }

        // Relations avec d'autres entités CRM
        public virtual Guid? AccountId { get; protected set; }
        public virtual Guid? ContactId { get; protected set; }
        public virtual Guid? OpportunityId { get; protected set; }
        public virtual Guid? LeadId { get; protected set; }

        protected CrmNote()
        {
            // Constructeur protégé pour Entity Framework
        }

        public CrmNote(Guid id, string name) : base(id)
        {
            SetName(name);
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name), CrmNoteConsts.MaxNameLength);
            Name = name;
        }

        public virtual void SetDescription(string? description)
        {
            Check.Length(description, nameof(description), CrmNoteConsts.MaxDescriptionLength);
            Description = description;
        }

        public virtual void SetAccountId(Guid? accountId)
        {
            AccountId = accountId;
        }

        public virtual void SetContactId(Guid? contactId)
        {
            ContactId = contactId;
        }

        public virtual void SetOpportunityId(Guid? opportunityId)
        {
            OpportunityId = opportunityId;
        }

        public virtual void SetLeadId(Guid? leadId)
        {
            LeadId = leadId;
        }
    }
}