using System;
using UniFlowCRM.Addresses;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.PhoneNumbers;
using UniFlowCRM.URLs;
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
    public Address? Address { get; private set; }


    public AccountType Type { get; private set; }
    public AccountIndustry? Industry { get; private set; }

    public Moneys.Money? Revenue { get; private set; }
    public int? Employees { get; private set; }

    public Guid UserID { get; private set; } // user fk

    protected Account() { }

    public Account(
        Guid id,
        string name,
        Guid userID
    ):base(id)
    {
        Name = name;
        Type = AccountType.Prospect;
        UserID = userID;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetDescription(string? description)
    {
        Description = description;
    }

    public void SetPhone(PhoneNumbers.PhoneNumber? phone)
    {
        Phone = phone;
    }

    public void SetFax(PhoneNumbers.PhoneNumber? fax)
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

    public void SetRevenue(Moneys.Money? revenue)
    {
        Revenue = revenue;
    }

    public void SetEmployees(int? employees)
    {
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
