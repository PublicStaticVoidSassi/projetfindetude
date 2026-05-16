using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.Addresses
{
    public class Address : ValueObject {
        public string? Street { get; private set; }
        public string? City { get; private set; }
        public string? Country { get; private set; }
        public int? PostalCode { get; private set; }

        public Address() { }
        public Address AddStreet(string? street) {
            Street = street;
            return this;
        }
        public Address AddCity(string? city) {
            City = city;
            return this;
        }
        public Address AddCountry(string? country) {
            Country = country;
            return this;
        }
        public Address AddPostalCode(int? postalcode) {
            PostalCode = postalcode;
            return this;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
