using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace UniFlowCRM.Emails;


public class Email : FullAuditedAggregateRoot<Guid>
{

    public string Subject { get; set; } // Subject
    public string? Body { get; set; }
    public EmailStatus Status { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    public string? Cc { get; set; }
    public string? Bcc { get; set; }
    public DateTime? SentAt { get; set; }
    public bool IsHtml { get; set; }

    public Guid? AccountID { get; set; }
    public Guid? ContactID { get; set; }
    public Guid? OpportunityID { get; set; }
    public Guid? LeadID { get; set; }

    public Guid? OwnerID { get; set; }
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
