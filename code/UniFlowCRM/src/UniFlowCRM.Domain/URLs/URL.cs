using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.URLs
{
    public class URL : ValueObject
    {
        public string _value { get; private init; }

        public URL(string url)
        {
            url = url.Trim();
            Validate(url);
            _value = url;
        }
        private void Validate(string url)
        {
            if (!url.Length.IsBetween(URLConstraints.MinLength, URLConstraints.MaxLength))
            {
                throw new UserFriendlyException("Url:Invalid");
            }
        }
        public override string ToString()
        {
            return _value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }
    }
}
