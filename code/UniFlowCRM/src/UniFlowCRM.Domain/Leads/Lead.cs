using System;
using Volo.Abp.Domain.Entities.Auditing;
using UniFlowCRM.ValueObjects;
namespace UniFlowCRM.Leads;

public class Lead : FullAuditedAggregateRoot<Guid>
{
    public string FirstName { get; private set; }
    public string? LastName { get; private set; }

    public string? Description { get; private set; }

    public LeadStatus Status { get; private set; }
    public LeadSource Source { get; private set; }

    public PhoneNumber? Phone { get; private set; }
    public EmailAddress? Email { get; private set; }

    public Guid UserID { get; private set; } // user FK
    public Guid? AccountID { get; private set; } // Account FK

    public Lead(Guid id,string firstName): base(id)
    {
        FirstName = firstName;
        Status = LeadStatus.New;
        Source = LeadSource.Unset;
    }
    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty.", nameof(firstName));

        FirstName = firstName;
    }

    public void SetLastName(string? lastName)
    {
        LastName = string.IsNullOrWhiteSpace(lastName) ? null : lastName;
    }

    public void SetDescription(string? description)
    {
        Description = string.IsNullOrWhiteSpace(description) ? null : description;
    }

    public void SetStatus(LeadStatus status)
    {
        Status = status;
    }

    public void SetSource(LeadSource source)
    {
        Source = source;
    }

    public void SetPhone(PhoneNumber phone)
    {
        Phone = phone;
    }

    public void SetEmail(EmailAddress email)
    {
        Email = email;
    }

    public void AssignToUser(Guid userId)
    {
        UserID = userId;
    }

    public void AssignToAccount(Guid accountId)
    {
        AccountID = accountId;
    }
    protected Lead() { } // one day EF wont need this. but its not today
}