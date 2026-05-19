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
    public string Subject { get; protected set; } // Subject
    public string? Body { get; protected set; }
    public EmailStatus Status { get; protected set; } = EmailStatus.Draft;
    public string From { get; protected set; }
    public string To { get; protected set; }
    public string? Cc { get; protected set; }
    public string? Bcc { get; protected set; }
    public DateTime? SentAt { get; protected set; }
    public bool IsHtml { get; protected set; } = false;

    public AccountDto? Account { get; protected set; }
    public ContactDto? Contact { get; protected set; }
    public OpportunityDto? Opportunity { get; protected set; }
    public LeadDto? Lead { get; protected set; }

    public IdentityUserDto? Owner { get; protected set; }
    public IdentityUserDto? Creator { get; protected set; }
    public IdentityUserDto? Modifier { get; protected set; }
}
