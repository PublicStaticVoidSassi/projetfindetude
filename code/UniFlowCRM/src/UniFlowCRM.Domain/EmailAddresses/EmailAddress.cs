using System.Collections.Generic;
using System.Net.Mail;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace UniFlowCRM.EmailAddresses;
public class EmailAddress : ValueObject
{
    public string Name { get; private init; }
    public string Domain { get; private init; }

    protected EmailAddress() { }

    public EmailAddress(string email)
    {
        email = email.Trim();
        Validate(email);
        var parts = email.Split('@');
        Name = parts[0].ToLowerInvariant();
        Domain = parts[1].ToLowerInvariant();
    }

    private void Validate(string email)
    {
        // basic validation lol
        string test = (new MailAddress(email)).ToString();
        if (!test.Equals(email)) {
            throw new UserFriendlyException("::EmailAddress:Invalid");
        }
    }

    public override string ToString() => $"{Name}@{Domain}";

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Domain;
    }
}