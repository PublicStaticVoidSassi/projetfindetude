using System;
using Volo.Abp.Domain.Entities.Auditing;
using UniFlowCRM.PhoneNumbers;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.URLs;
using UniFlowCRM.Addresses;

namespace UniFlowCRM.Contacts
{
    
    public class Contact : FullAuditedAggregateRoot<Guid>
    {
        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string? LastName { get; private set; }

        public string? Description { get; private set; }

        public ContactStatus Status { get; private set; }
        public ContactSource Source { get; private set; }

        public PhoneNumber? Phone { get; private set; }
        public PhoneNumber? Fax { get; private set; }
        public EmailAddress? Email { get; private set; }
        public URL? Website { get; private set; }
        public Address? Address { get; private set; }

        public string? Job { get; private set; } // I want one
        public string? Department { get; private set; }

        public Guid UserID { get; private set; } // user FK
        public Guid? LeadID { get; private set; }
        public Guid? AccountID { get; private set; } // Account FK

        public Contact(
        Guid id,
        string firstName):base(id)
        {
            FirstName = firstName;
        }
        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.", nameof(firstName));

            FirstName = firstName;
        }

        public void SetMiddleName(string? middleName)
        {
            MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName;
        }

        public void SetLastName(string? lastName)
        {
            LastName = string.IsNullOrWhiteSpace(lastName) ? null : lastName;
        }

        public void SetDescription(string? description)
        {
            Description = string.IsNullOrWhiteSpace(description) ? null : description;
        }

        public void SetStatus(ContactStatus status)
        {
            Status = status;
        }

        public void SetSource(ContactSource source)
        {
            Source = source;
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

        public void SetJob(string? job)
        {
            Job = string.IsNullOrWhiteSpace(job) ? null : job;
        }

        public void SetDepartment(string? department)
        {
            Department = string.IsNullOrWhiteSpace(department) ? null : department;
        }

        public void AssignUser(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId cannot be empty.", nameof(userId));

            UserID = userId;
        }

        public void AssignLead(Guid? leadId)
        {
            LeadID = leadId;
        }

        public void AssignAccount(Guid? accountId)
        {
            AccountID = accountId;
        }
        protected Contact() { } // one day EF wont need this. but its not today
    }
}