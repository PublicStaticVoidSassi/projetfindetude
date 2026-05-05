using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Tasks
{
    public class CrmTask : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual string? Description { get; protected set; }
        public virtual TaskStatus Status { get; protected set; }
        public virtual TaskPriority Priority { get; protected set; }
        public virtual DateTime? DateStart { get; protected set; }
        public virtual DateTime? DateEnd { get; protected set; }
        public virtual DateTime? DateCompleted { get; protected set; }

        // Relations avec d'autres entités CRM
        public virtual Guid? AccountId { get; protected set; }
        public virtual Guid? ContactId { get; protected set; }
        public virtual Guid? OpportunityId { get; protected set; }
        public virtual Guid? LeadId { get; protected set; }

        // Assignation
        public virtual Guid? AssignedUserId { get; protected set; }
        public virtual string? AssignedUserName { get; protected set; }

        protected CrmTask()
        {
            // Constructeur protégé pour Entity Framework
        }

        public CrmTask(Guid id, string name) : base(id)
        {
            SetName(name);
            Status = TaskStatus.NotStarted;
            Priority = TaskPriority.Normal;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name), CrmTaskConsts.MaxNameLength);
            Name = name;
        }

        public virtual void SetDescription(string? description)
        {
            Check.Length(description, nameof(description), CrmTaskConsts.MaxDescriptionLength);
            Description = description;
        }

        public virtual void SetStatus(TaskStatus status)
        {
            Status = status;
        }

        public virtual void SetPriority(TaskPriority priority)
        {
            Priority = priority;
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

        public virtual void SetDateCompleted(DateTime? dateCompleted)
        {
            DateCompleted = dateCompleted;
            if (dateCompleted.HasValue)
            {
                Status = TaskStatus.Completed;
            }
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
            Check.Length(assignedUserName, nameof(assignedUserName), CrmTaskConsts.MaxAssignedUserNameLength);
            AssignedUserName = assignedUserName;
        }
    }
}