using System;
using Volo.Abp.Application.Dtos;
using UniFlowCRM.Accounts;
using UniFlowCRM.Opportunities;
using UniFlowCRM.Leads;
using UniFlowCRM.Contacts;
using Volo.Abp.Identity;
namespace UniFlowCRM.Emails;

public class EmailDto : FullAuditedEntityDto<Guid>
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

    public AccountDto? Account { get; set; }
    public ContactDto? Contact { get; set; }
    public OpportunityDto? Opportunity { get; set; }
    public LeadDto? Lead { get; set; }

    public IdentityUserDto? Owner { get; set; }
    public IdentityUserDto? Creator { get; set; }
    public IdentityUserDto? Modifier { get; set; }
}
