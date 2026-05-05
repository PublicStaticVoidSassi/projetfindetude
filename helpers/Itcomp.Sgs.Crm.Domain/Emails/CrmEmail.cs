using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Emails
{
    public class CrmEmail : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; } // Subject
        public virtual string? Body { get; protected set; }
        public virtual EmailStatus Status { get; protected set; }
        public virtual string? FromAddress { get; protected set; }
        public virtual string? ToAddresses { get; protected set; }
        public virtual string? CcAddresses { get; protected set; }
        public virtual string? BccAddresses { get; protected set; }
        public virtual DateTime? DateSent { get; protected set; }
        public virtual bool IsHtml { get; protected set; }

        // Relations avec d'autres entités CRM
        public virtual Guid? AccountId { get; protected set; }
        public virtual Guid? ContactId { get; protected set; }
        public virtual Guid? OpportunityId { get; protected set; }
        public virtual Guid? LeadId { get; protected set; }

        // Assignation
        public virtual Guid? AssignedUserId { get; protected set; }
        public virtual string? AssignedUserName { get; protected set; }

        protected CrmEmail()
        {
            // Constructeur protégé pour Entity Framework
        }

        public CrmEmail(Guid id, string subject) : base(id)
        {
            SetName(subject);
            Status = EmailStatus.Draft;
            IsHtml = true;
        }

        public virtual void SetName(string subject)
        {
            Check.NotNullOrWhiteSpace(subject, nameof(subject), CrmEmailConsts.MaxNameLength);
            Name = subject;
        }

        public virtual void SetBody(string? body)
        {
            Body = body; // Pas de limite de longueur pour le body (type text en DB)
        }

        public virtual void SetStatus(EmailStatus status)
        {
            Status = status;
        }

        public virtual void SetFromAddress(string? fromAddress)
        {
            Check.Length(fromAddress, nameof(fromAddress), CrmEmailConsts.MaxFromAddressLength);
            FromAddress = fromAddress;
        }

        public virtual void SetToAddresses(string? toAddresses)
        {
            Check.Length(toAddresses, nameof(toAddresses), CrmEmailConsts.MaxToAddressesLength);
            ToAddresses = toAddresses;
        }

        public virtual void SetCcAddresses(string? ccAddresses)
        {
            Check.Length(ccAddresses, nameof(ccAddresses), CrmEmailConsts.MaxCcAddressesLength);
            CcAddresses = ccAddresses;
        }

        public virtual void SetBccAddresses(string? bccAddresses)
        {
            Check.Length(bccAddresses, nameof(bccAddresses), CrmEmailConsts.MaxBccAddressesLength);
            BccAddresses = bccAddresses;
        }

        public virtual void SetDateSent(DateTime? dateSent)
        {
            DateSent = dateSent;
            if (dateSent.HasValue)
            {
                Status = EmailStatus.Sent;
            }
        }

        public virtual void SetIsHtml(bool isHtml)
        {
            IsHtml = isHtml;
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
            Check.Length(assignedUserName, nameof(assignedUserName), CrmEmailConsts.MaxAssignedUserNameLength);
            AssignedUserName = assignedUserName;
        }
    }
}