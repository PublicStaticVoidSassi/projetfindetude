using System;
using UniFlowCRM.Addresses;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.PhoneNumbers;
using UniFlowCRM.URLs;
using Volo.Abp.Domain.Entities.Auditing;
using UniFlowCRM.Moneys;
using Volo.Abp;
namespace UniFlowCRM.Accounts;



public class Account : FullAuditedAggregateRoot<Guid>
{

    public string Name { get; private set; }
    public string? Description { get; private set; }

    public PhoneNumber? Phone { get; private set; }
    public PhoneNumber? Fax { get; private set; }
    public EmailAddress? Email { get; private set; }
    public URL? Website { get; private set; }
    public Address? Address { get; private set; }


    public AccountType Type { get; private set; }
    public AccountIndustry? Industry { get; private set; }

    public Money? Revenue { get; private set; }
    public int? Employees { get; private set; }

    public Guid UserID { get; private set; } // user fk

    protected Account() { }

    public Account(Guid id, string name, Guid userID) : base(id)
    {
        Name = name;
        Type = AccountType.Prospect;
        UserID = userID;
    }
    public Account(
    Guid id,
    string name,
    Guid userId,
    string? description,
    AccountType type,
    AccountIndustry? industry
    ) : this(id, name, userId)
    {
        this.SetDescription(description);
        this.SetType(type);
        this.SetIndustry(industry);
    }
    public Account(
    Guid id,
    string name,
    Guid userId,
    string? description,
    AccountType type,
    AccountIndustry? industry,
    PhoneNumber? phone,
    PhoneNumber? fax,
    EmailAddress? email,
    URL? website,
    Address? address
    ) : this(id, name, userId, description, type, industry)
    {
        this.SetPhone(phone);
        this.SetFax(fax);
        this.SetEmail(email);
        this.SetWebsite(website);
        this.SetAddress(address);
    }
    public Account(
    Guid id,
    string name,
    Guid userId,
    string? description,
    AccountType type,
    AccountIndustry? industry,
    PhoneNumber? phone,
    PhoneNumber? fax,
    EmailAddress? email,
    URL? website,
    Address? address,
    Money? revenue,
    int? employees
    ) : this(id, name, userId, description, type, industry, phone, fax, email, website, address)
    {
        this.SetRevenue(revenue);
        this.SetEmployees(employees);
    }
    public void SetName(string name)
    {
        Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            AccountConstraints.Name.MaxLength,
            AccountConstraints.Name.MinLength
        );
        Name = name;
    }

    public void SetDescription(string? description)
    {
        Check.NotNullOrWhiteSpace(
            description,
            nameof(description),
            AccountConstraints.Description.MaxLength,
            AccountConstraints.Description.MinLength
        );
        Description = description;
    }

    public void SetPhone(PhoneNumber? phone)
    {
        Phone = phone;
    }

    public void SetFax(PhoneNumber? fax)
    {
        Fax = fax;
    }

    public void SetEmail(EmailAddress? email)
    {
        Email = email;
    }

    public void SetWebsite(URL? website)
    {
        Website = website;
    }

    public void SetAddress(Address? address)
    {
        Address = address;
    }

    public void SetType(AccountType type)
    {
        Type = type;
    }

    public void SetIndustry(AccountIndustry? industry)
    {
        Industry = industry;
    }

    public void SetRevenue(Money? revenue )
    {
        Check.Positive(revenue.Value + 1 , nameof(revenue));
        Revenue = revenue;
    }

    public void SetEmployees(int? employees)
    {
        Check.Positive(employees ?? 0, nameof(employees));
        Employees = employees;
    }
    private void SetUserId(Guid userId)
    {
        UserID = userId;
    }
    public void AssignTo(Guid userId)
    {
        SetUserId(userId);
    }
}
