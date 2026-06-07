using System;
using UniFlowCRM.EmailAddresses;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
namespace UniFlowCRM.Emails;


public class Email : FullAuditedAggregateRoot<Guid>
{

    public string Subject { get; set; } // Subject
    public string? Body { get; set; }
    public EmailStatus Status { get; set; }
    public EmailAddress? From { get; set; }
    public EmailAddress? To { get; set; }
    public EmailAddress? Cc { get; set; }
    public EmailAddress? Bcc { get; set; }
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

    public void MarkAsSent()
    {
        if (this.Status == EmailStatus.Sent) throw new BusinessException("Email Already Sent");
        this.SentAt = DateTime.UtcNow;
        this.Status = EmailStatus.Sent;
    }
    public void MarkAsFailed()
    {
        this.Status = EmailStatus.Failed;
    }
    private Email() { }
}
