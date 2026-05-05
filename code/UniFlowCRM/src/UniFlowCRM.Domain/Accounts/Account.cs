using System;
using UniFlowCRM.ValueObjects;
using Volo.Abp.Domain.Entities.Auditing;

namespace UniFlowCRM.Accounts;

public class Account : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public PhoneNumber? Phone { get; private set; }
    public PhoneNumber? Fax { get; private set; }
    public EmailAddress? Email { get; private set; }
    public URL? Website { get; private set; }
    public Address Address { get; private set; }


    public AccountType Type { get; private set; }
    public AccountIndustry Industry { get; private set; }

    public ValueObjects.Money? Revenue { get; private set; }
    public int? Employees { get; private set; }

    public Guid UserID { get; private set; } // user fk

    protected Account() { }

    public Account(
        Guid id,
        string name,
        PhoneNumber? phone,
        PhoneNumber? fax,
        EmailAddress? email,
        URL? website,
        string? description,
        AccountType type,
        AccountIndustry industry,
        ValueObjects.Money? revenue,
        int? employees,
        Address address):base(id)
    {
        Name = name;
        Phone = phone;
        Fax = fax;
        Email = email;
        Website = website;
        Description = description;
        Type = type;
        Industry = industry;
        Revenue = revenue;
        Employees = employees;
        Address = address;
    }
}
