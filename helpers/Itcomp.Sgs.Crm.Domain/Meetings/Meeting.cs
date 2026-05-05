using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Meetings
{
    public class Meeting : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual string? Description { get; protected set; }
        public virtual MeetingStatus Status { get; protected set; }
        public virtual DateTime DateStart { get; protected set; }
        public virtual DateTime DateEnd { get; protected set; }
        public virtual string? Location { get; protected set; }

        // Relations avec d'autres entités CRM
        public virtual Guid? AccountId { get; protected set; }
        public virtual Guid? ContactId { get; protected set; }
        public virtual Guid? OpportunityId { get; protected set; }
        public virtual Guid? LeadId { get; protected set; }

        // Assignation
        public virtual Guid? AssignedUserId { get; protected set; }
        public virtual string? AssignedUserName { get; protected set; }

        protected Meeting()
        {
            // Constructeur protégé pour Entity Framework
        }

        public Meeting(Guid id, string name, DateTime dateStart, DateTime dateEnd) : base(id)
        {
            SetName(name);
            SetDates(dateStart, dateEnd);
            Status = MeetingStatus.Planned;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name), MeetingConsts.MaxNameLength);
            Name = name;
        }

        public virtual void SetDescription(string? description)
        {
            Check.Length(description, nameof(description), MeetingConsts.MaxDescriptionLength);
            Description = description;
        }

        public virtual void SetStatus(MeetingStatus status)
        {
            Status = status;
        }

        public virtual void SetDates(DateTime dateStart, DateTime dateEnd)
        {
            if (dateEnd <= dateStart)
            {
                throw new ArgumentException("End date must be after start date", nameof(dateEnd));
            }
            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        public virtual void SetDateStart(DateTime dateStart)
        {
            if (dateStart >= DateEnd)
            {
                throw new ArgumentException("Start date must be before end date", nameof(dateStart));
            }
            DateStart = dateStart;
        }

        public virtual void SetDateEnd(DateTime dateEnd)
        {
            if (dateEnd <= DateStart)
            {
                throw new ArgumentException("End date must be after start date", nameof(dateEnd));
            }
            DateEnd = dateEnd;
        }

        public virtual void SetLocation(string? location)
        {
            Check.Length(location, nameof(location), MeetingConsts.MaxLocationLength);
            Location = location;
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
            Check.Length(assignedUserName, nameof(assignedUserName), MeetingConsts.MaxAssignedUserNameLength);
            AssignedUserName = assignedUserName;
        }
    }
}