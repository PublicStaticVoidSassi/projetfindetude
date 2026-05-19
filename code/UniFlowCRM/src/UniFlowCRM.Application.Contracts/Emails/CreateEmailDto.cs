using System;
using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Emails;

public class CreateUpdateEmailDto : EntityDto<Guid>
{
    public string Subject { get; protected set; } // Subject
    public string? Body { get; protected set; }
    public EmailStatus Status { get; protected set; } = EmailStatus.Draft;
    public string From { get; protected set; }
    public string To { get; protected set; }
    public string? Cc { get; protected set; }
    public string? Bcc { get; protected set; }
    public DateTime? SentAt { get; protected set; }
    public bool IsHtml { get; protected set; } = false;

    public Guid? AccountID { get; protected set; }
    public Guid? ContactID { get; protected set; }
    public Guid? OpportunityID { get; protected set; }
    public Guid? LeadID { get; protected set; }

    public Guid? OwnerID { get; protected set; }
}
