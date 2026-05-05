using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Calls
{
    public class Call : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual string? Description { get; protected set; }
        public virtual CallStatus Status { get; protected set; }
        public virtual CallDirection Direction { get; protected set; }
        public virtual DateTime? DateStart { get; protected set; }
        public virtual DateTime? DateEnd { get; protected set; }
        public virtual int? Duration { get; protected set; } // in minutes
        public virtual string? PhoneNumber { get; protected set; }

        // Relations avec d'autres entités CRM
        public virtual Guid? AccountId { get; protected set; }
        public virtual Guid? ContactId { get; protected set; }
        public virtual Guid? OpportunityId { get; protected set; }
        public virtual Guid? LeadId { get; protected set; }

        // Assignation
        public virtual Guid? AssignedUserId { get; protected set; }
        public virtual string? AssignedUserName { get; protected set; }

        protected Call()
        {
            // Constructeur protégé pour Entity Framework
        }

        public Call(Guid id, string name, CallDirection direction) : base(id)
        {
            SetName(name);
            SetDirection(direction);
            Status = CallStatus.Planned;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name), CallConsts.MaxNameLength);
            Name = name;
        }

        public virtual void SetDescription(string? description)
        {
            Check.Length(description, nameof(description), CallConsts.MaxDescriptionLength);
            Description = description;
        }

        public virtual void SetStatus(CallStatus status)
        {
            Status = status;
        }

        public virtual void SetDirection(CallDirection direction)
        {
            Direction = direction;
        }

        public virtual void SetDateStart(DateTime? dateStart)
        {
            DateStart = dateStart;
        }

        public virtual void SetDateEnd(DateTime? dateEnd)
        {
            if (dateEnd.HasValue && DateStart.HasValue && dateEnd.Value < DateStart.Value)
            {
                throw new ArgumentException("End date cannot be before start date", nameof(dateEnd));
            }
            DateEnd = dateEnd;
        }

        public virtual void SetDuration(int? duration)
        {
            if (duration.HasValue && duration.Value < 0)
            {
                throw new ArgumentException("Duration cannot be negative", nameof(duration));
            }
            Duration = duration;
        }

        public virtual void SetPhoneNumber(string? phoneNumber)
        {
            Check.Length(phoneNumber, nameof(phoneNumber), CallConsts.MaxPhoneNumberLength);
            PhoneNumber = phoneNumber;
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

        public virtual void SetAssignedUserId(Guid? assignedUserId)
        {
            AssignedUserId = assignedUserId;
        }

        public virtual void SetAssignedUserName(string? assignedUserName)
        {
            Check.Length(assignedUserName, nameof(assignedUserName), CallConsts.MaxAssignedUserNameLength);
            AssignedUserName = assignedUserName;
        }
    }
}