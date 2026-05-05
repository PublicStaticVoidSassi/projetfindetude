using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Leads
{
    public class Lead : FullAuditedAggregateRoot<Guid>
    {
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string? Email { get; protected set; }
        public virtual string? Phone { get; protected set; }
        public virtual string? Company { get; protected set; }
        public virtual LeadStatus Status { get; protected set; }

        protected Lead()
        {
            // Constructeur protégé pour Entity Framework
        }

        public Lead(Guid id, string firstName, string lastName) : base(id)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            Status = LeadStatus.New;
        }

        public virtual void SetFirstName(string firstName)
        {
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName), LeadConsts.MaxFirstNameLength);
            FirstName = firstName;
        }

        public virtual void SetLastName(string lastName)
        {
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName), LeadConsts.MaxLastNameLength);
            LastName = lastName;
        }

        public virtual void SetEmail(string? email)
        {
            Check.Length(email, nameof(email), LeadConsts.MaxEmailLength);
            Email = email;
        }

        public virtual void SetPhone(string? phone)
        {
            Check.Length(phone, nameof(phone), LeadConsts.MaxPhoneLength);
            Phone = phone;
        }

        public virtual void SetCompany(string? company)
        {
            Check.Length(company, nameof(company), LeadConsts.MaxCompanyLength);
            Company = company;
        }

        public virtual void SetStatus(LeadStatus status)
        {
            Status = status;
        }
    }
}
