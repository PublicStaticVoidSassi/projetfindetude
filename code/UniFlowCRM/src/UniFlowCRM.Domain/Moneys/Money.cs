using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.Moneys
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; } = 0;
        public Currency Currency { get; private set; } = Currency.DZD;

        private void ValidateValue(decimal Value)
        {
            Check.Positive(Value, nameof(Value));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Currency;
        }

        public Money(decimal value, Currency currency)
        {
            //Check.Positive(value, nameof(value));
            Value = value;
            Currency = currency;
        }
    }
}
