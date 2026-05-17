using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.PhoneNumbers
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; private init; }
        public string CountryCode { get; private init; }
        public PhoneNumber(string number)//for loading from EF core
        {
            var temp = number.Split(' ');
            CountryCode = temp[0];
            Number = temp[1];
        }
        public PhoneNumber(string number, string countryCode) {
            // check the number
            number = number.Trim();
            countryCode = countryCode.Trim();
            CheckNumber(number);
            CheckCountryCode(countryCode);
            Number = number;
            CountryCode = countryCode;
            // check the country code
        }
        private void CheckNumber(string number)
        {
            if (!number.Length.IsBetween(PhoneNumberConstraints.MinLength, PhoneNumberConstraints.MaxLength))
            {
                throw new UserFriendlyException("PhoneNumber:Number:Invalid");
            }
        }
        private void CheckCountryCode(string code)
        {
            if (
                !code.StartsWith('+') ||
                !(code.Length.IsBetween(
                    PhoneNumberConstraints.CodeMinLength,
                    PhoneNumberConstraints.CodeMaxLength
                ))){
                throw new UserFriendlyException("PhoneNumber:CountryCode:Invalid");
            }
        }
        public override string ToString()
        {
            return CountryCode + " " + Number;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
            yield return CountryCode;
        }
    }
}
