using System;
using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Emails;

public class CreateUpdateEmailDto : EntityDto<Guid>
{
    public string Subject { get; set; } // Subject
    public string? Body { get; set; }
    public EmailStatus Status { get; set; } = EmailStatus.Draft;
    public string From { get; set; }
    public string To { get; set; }
    public string? Cc { get; set; }
    public string? Bcc { get; set; }
    public DateTime? SentAt { get; set; }
    public bool IsHtml { get; set; } = false;

    public Guid? AccountID { get; set; }
    public Guid? ContactID { get; set; }
    public Guid? OpportunityID { get; set; }
    public Guid? LeadID { get; set; }

    public Guid? OwnerID { get; set; }
}
