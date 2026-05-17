using System;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace UniFlowCRM.Notes;

public class NoteDto: CreationAuditedEntityDto<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public NoteType Type { get; set; }
    public Guid? LeadId { get; set; }
    public LeadDto? Lead { get; set; }
    public Guid? AccountId { get; set; }
    public AccountDto? Account { get; set; }
    public Guid? ContactId { get; set; }
    public ContactDto? Contact { get; set; }
    public Guid? OpportunityId { get; set; }
    public OpportunityDto? Opportunity { get; set; }
    public IdentityUserDto? Creator { get; set; }
}