using Itcomp.Shared.Domain;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Itcomp.Sgs.Crm.Accounts
{
    public class Account : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual string? Description { get; protected set; }
        public virtual string? Email { get; protected set; }
        public virtual string? Phone { get; protected set; }
        public virtual string? AddressLine1 { get; protected set; }
        public virtual string? AddressLine2 { get; protected set; }
        public virtual int? LocalityId { get; protected set; }
        public virtual string? Fax { get; protected set; }
        public virtual byte[]? Logo { get; protected set; }
        public virtual string? LogoContentType { get; protected set; }
        public virtual int? IndustryId { get; protected set; }
        public virtual string? ShortName { get; protected set; }
        public virtual CompanySizes? CompanySize { get; protected set; }
        public virtual AccountStatus Status { get; protected set; }

        public virtual IdentificationInfo IdentificationInfo { get; protected set; }

        protected Account()
        {
            // Constructeur protégé pour Entity Framework
        }

        public Account(Guid id, string name) : base(id)
        {
            SetName(name);
            Status = AccountStatus.Prospect;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name), AccountConsts.MaxNameLength);
            Name = name;
        }

        public virtual void SetDescription(string? description)
        {
            Check.Length(description, nameof(description), AccountConsts.MaxDescriptionLength);
            Description = description;
        }

        public virtual void SetEmail(string? email)
        {
            Check.Length(email, nameof(email), AccountConsts.MaxEmailLength);
            Email = email;
        }

        public virtual void SetPhone(string? phone)
        {
            Check.Length(phone, nameof(phone), AccountConsts.MaxPhoneLength);
            Phone = phone;
        }

        public virtual void SetAddressLine1(string? addressLine1)
        {
            Check.Length(addressLine1, nameof(addressLine1), AccountConsts.MaxAddressLine1Length);
            AddressLine1 = addressLine1;
        }

        public virtual void SetAddressLine2(string? addressLine2)
        {
            Check.Length(addressLine2, nameof(addressLine2), AccountConsts.MaxAddressLine2Length);
            AddressLine2 = addressLine2;
        }

        public virtual void SetLocalityId(int? localityId)
        {
            LocalityId = localityId;
        }

        public virtual void SetFax(string? fax)
        {
            Check.Length(fax, nameof(fax), AccountConsts.MaxFaxLength);
            Fax = fax;
        }

        public virtual void SetLogo(byte[]? logo)
        {
            if (logo != null && logo.Length > AccountConsts.MaxLogoSize)
            {
                throw new ArgumentException($"Logo size exceeds maximum allowed size of {AccountConsts.MaxLogoSize} bytes.", nameof(logo));
            }
            Logo = logo;
        }

        public virtual void SetLogoContentType(string? logoContentType)
        {
            Check.Length(logoContentType, nameof(logoContentType), AccountConsts.MaxLogoContentTypeLength);
            LogoContentType = logoContentType;
        }

        public virtual void SetIndustryId(int? industryId)
        {
            IndustryId = industryId;
        }

        public virtual void SetShortName(string? shortName)
        {
            Check.Length(shortName, nameof(shortName), AccountConsts.MaxShortNameLength);
            ShortName = shortName;
        }

        public virtual void SetCompanySize(CompanySizes? companySize)
        {
            CompanySize = companySize;
        }

        public virtual void SetStatus(AccountStatus status)
        {
            Status = status;
        }

        public virtual void SetIdentificationInfo(IdentificationInfo? identificationInfo)
        {
            IdentificationInfo = identificationInfo;
        }
    }
}