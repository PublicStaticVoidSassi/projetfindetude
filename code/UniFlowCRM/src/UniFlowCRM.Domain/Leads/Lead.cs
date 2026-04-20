using System;
using Volo.Abp.Domain.Entities.Auditing;
using UniFlowCRM.ValueObjects;

namespace UniFlowCRM.Leads;

public class Lead : FullAuditedAggregateRoot<Guid>
{
    public string FirstName { get; private set; }
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; }

    public string? Description { get; private set; }

    public LeadStatus Status { get; private set; }
    public LeadSource Source { get; private set; }

    public PhoneNumber? Phone { get; private set; }
    public PhoneNumber? Fax { get; private set; }
    public EmailAddress? Email { get; private set; }
    public URL? Website { get; private set; }
    public Address? Address { get; private set; }

    public string? Job { get; private set; } // I want one
    public string? Departement { get; private set; }

    public Guid UserID { get; private set; } // user FK
    public Guid? AccountID { get; private set; } // Account FK

    public Lead(
    string firstName,
    string? middleName,
    string lastName,
    string? description,
    LeadStatus status,
    LeadSource source,
    PhoneNumber? phone,
    PhoneNumber? fax,
    EmailAddress? email,
    URL? website,
    Address? address,
    string? job,
    string? departement)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;

        Description = description;

        Status = status;
        Source = source;

        Phone = phone;
        Fax = fax;
        Email = email;
        Website = website;
        Address = address;

        Job = job;
        Departement = departement;
    }
    protected Lead() { } // one day EF wont need this. but its not today
}