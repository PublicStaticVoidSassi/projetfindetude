using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
namespace UniFlowCRM.Emails
{
    public static class EmailExtensions
    {
        public static MailMessage ToMailMessage(this Email email)
        {
            var mailmessage = new MailMessage(email.From, email.To, email.Subject, email.Body)
            {
                IsBodyHtml = email.IsHtml
            };
            if (!string.IsNullOrEmpty(email.Bcc))  mailmessage.Bcc.Add(email.Bcc);
            if (!string.IsNullOrEmpty(email.Cc))  mailmessage.CC.Add(email.Cc);
            return mailmessage;
        }
    }
}
