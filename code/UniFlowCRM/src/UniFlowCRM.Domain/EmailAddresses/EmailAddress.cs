using System.Collections.Generic;
using System.Net.Mail;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.EmailAddresses;
public class EmailAddress : ValueObject
{
    private string _value { get; init; }

    protected EmailAddress() { }

    public EmailAddress(string email)
    {
        email = email.Trim();
        Validate(email);
        _value = email;
    }

    private void Validate(string email)
    {
        // basic validation lol
        string test = (new MailAddress(email)).ToString();
        if (!test.Equals(email)) {
            throw new UserFriendlyException("::EmailAddress:Invalid");
        }
    }
    public static implicit operator string(EmailAddress emailaddress) => (emailaddress == null)? null: emailaddress.ToString();

    public override string ToString() => _value;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return _value;
    }
}