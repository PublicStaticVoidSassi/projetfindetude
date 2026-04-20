using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Money;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }
        public Currency Currency { get; private set; }

        public void ValidateValue(decimal Value)
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
            Check.Positive(Value, "Money");
            Value = value;
            Currency = currency;
        }
    }
}
