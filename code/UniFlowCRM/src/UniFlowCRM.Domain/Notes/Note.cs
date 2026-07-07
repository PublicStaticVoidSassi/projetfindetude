using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UniFlowCRM.Notes;



public class Note : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public NoteType Type { get; set; }
    public Guid? LeadId { get; set; }
    public Guid? AccountId { get; set; }
    public Guid? ContactId { get; set; }
    public Guid? OpportunityId { get; set; }

    public void LinkToLead(Guid id)
    {
        LeadId = id;
    }

    public void LinkToContact(Guid id)
    {
        ContactId = id;
    }

    public void LinkToAccount(Guid id)
    {
        AccountId = id;
    }

    public void LinkToOpportunity(Guid id)
    {
        OpportunityId = id;
    }
    public Note(Guid id, string title, string content) : base(id)
    {
        SetTitle(title);
        SetContent(content);
        SetType(NoteType.General);
    }

    private void SetType(NoteType type)
    {
        Type = type;
    }

    private void SetContent(string content)
    {
        Content = content;
    }

    private void SetTitle(string title)
    {
        Title = title;
    }

    protected Note() { }
}
