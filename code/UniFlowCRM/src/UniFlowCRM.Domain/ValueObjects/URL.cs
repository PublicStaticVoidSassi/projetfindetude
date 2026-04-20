using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.ValueObjects
{
    public class URL : ValueObject
    {
        public string Value { get; private init; } 

        public URL(string url)
        {
            url = url.Trim();
            Validate(url);
            Value = url;
        }
        private void Validate(string url) {
            if (!url.Length.IsBetween(Constraints.URL.MinLength, Constraints.URL.MaxLength))
            {
                throw new UserFriendlyException("Url:Invalid");
            }
        }
        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        } 
    }
}
