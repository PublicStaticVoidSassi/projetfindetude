using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UniFlowCRM.Notes;



public class Note : CreationAuditedAggregateRoot<Guid>
{
    public string Title { get; protected set; }
    public string Content { get; protected set; }
    public NoteType Type { get; protected set; }
    public Guid? LeadId { get; protected set; }
    public Guid? AccountId { get; protected set; }
    public Guid? ContactId { get; protected set; }
    public Guid? OpportunityId { get; protected set; }

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

    protected Note(){}
}