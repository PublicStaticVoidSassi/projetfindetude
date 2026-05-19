using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace UniFlowCRM.Emails;


public class Email : FullAuditedAggregateRoot<Guid>
{

    public string Subject { get; protected set; } // Subject
    public string? Body { get; protected set; }
    public EmailStatus Status { get; protected set; }
    public string? From { get; protected set; }
    public string? To { get; protected set; }
    public string? Cc { get; protected set; }
    public string? Bcc { get; protected set; }
    public DateTime? SentAt { get; protected set; }
    public bool IsHtml { get; protected set; }

    public Guid? AccountID { get; protected set; }
    public Guid? ContactID { get; protected set; }
    public Guid? OpportunityID { get; protected set; }
    public Guid? LeadID { get; protected set; }

    public Guid? OwnerID { get; protected set; }
    public Email(Guid id, string subject)
    {
        SetSubject(subject);
        Status = EmailStatus.Draft;
    }
    public void SetSubject(string subject)
    {
        Subject = subject;
    }
    private Email() { }
}
