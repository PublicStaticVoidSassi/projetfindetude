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

        public Address()
        {
        }
        public Address(string? street) {
            Street = street;
        }
        public Address(string? street,string? city): this(street)
        {
            City = city;
        }
        public Address(string? street, string? city, string? country) : this(street,city)
        {
             Country = country;
        }
        public Address(string? street, string? city, string? country, int? postalcode) : this(street, city,country)
        {
            PostalCode = postalcode;
        }
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
            yield return Street;
            yield return City;
            yield return Country;
            yield return PostalCode;
        }
    }
}
