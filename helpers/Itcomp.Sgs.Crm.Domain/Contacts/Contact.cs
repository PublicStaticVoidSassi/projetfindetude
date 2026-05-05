using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Contacts
{
    public class Contact : FullAuditedAggregateRoot<Guid>
    {
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string? FirstNameAr { get; protected set; }
        public virtual string? LastNameAr { get; protected set; }
        public virtual string? Email { get; protected set; }
        public virtual string? Phone { get; protected set; }
        public virtual string? MobilePhone { get; protected set; }
        public virtual string? AddressLine1 { get; protected set; }
        public virtual string? AddressLine2 { get; protected set; }
        public virtual int? LocalityId { get; protected set; }
        public virtual string? Title { get; protected set; } // Job title
        public virtual string? Department { get; protected set; }
        public virtual ContactStatus Status { get; protected set; }
        public virtual ContactSource? LeadSource { get; protected set; }
        public virtual Guid? AccountId { get; protected set; }
        public virtual string? Description { get; protected set; }
        public virtual string Name { get; }
        public virtual string? NameAr { get; }


        protected Contact()
        {
            // Constructeur protégé pour Entity Framework
        }

        public Contact(Guid id, string firstName, string lastName) : base(id)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            Status = ContactStatus.Active;
        }

        public virtual void SetFirstName(string firstName)
        {
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName), ContactConsts.MaxFirstNameLength);
            FirstName = firstName;
        }

        public virtual void SetLastName(string lastName)
        {
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName), ContactConsts.MaxLastNameLength);
            LastName = lastName;
        }

        public virtual void SetFirstNameAr(string firstNameAr)
        {
            Check.NotNullOrWhiteSpace(firstNameAr, nameof(firstNameAr), ContactConsts.MaxFirstNameLength);
            FirstNameAr = firstNameAr;
        }

        public virtual void SetLastNameAr(string lastNameAr)
        {
            Check.NotNullOrWhiteSpace(lastNameAr, nameof(lastNameAr), ContactConsts.MaxLastNameLength);
            LastNameAr = lastNameAr;
        }

        public virtual void SetEmail(string? email)
        {
            Check.Length(email, nameof(email), ContactConsts.MaxEmailLength);
            Email = email;
        }

        public virtual void SetPhone(string? phone)
        {
            Check.Length(phone, nameof(phone), ContactConsts.MaxPhoneLength);
            Phone = phone;
        }

        public virtual void SetMobilePhone(string? mobilePhone)
        {
            Check.Length(mobilePhone, nameof(mobilePhone), ContactConsts.MaxMobilePhoneLength);
            MobilePhone = mobilePhone;
        }

        public virtual void SetAddressLine1(string? addressLine1)
        {
            Check.Length(addressLine1, nameof(addressLine1), ContactConsts.MaxAddressLine1Length);
            AddressLine1 = addressLine1;
        }

        public virtual void SetAddressLine2(string? addressLine2)
        {
            Check.Length(addressLine2, nameof(addressLine2), ContactConsts.MaxAddressLine2Length);
            AddressLine2 = addressLine2;
        }

        public virtual void SetLocalityId(int? localityId)
        {
            LocalityId = localityId;
        }

        public virtual void SetTitle(string? title)
        {
            Check.Length(title, nameof(title), ContactConsts.MaxTitleLength);
            Title = title;
        }

        public virtual void SetDepartment(string? department)
        {
            Check.Length(department, nameof(department), ContactConsts.MaxDepartmentLength);
            Department = department;
        }

        public virtual void SetStatus(ContactStatus status)
        {
            Status = status;
        }

        public virtual void SetLeadSource(ContactSource? leadSource)
        {
            LeadSource = leadSource;
        }

        public virtual void SetAccountId(Guid? accountId)
        {
            AccountId = accountId;
        }

        public virtual void SetDescription(string? description)
        {
            Check.Length(description, nameof(description), ContactConsts.MaxDescriptionLength);
            Description = description;
        }
    }
}