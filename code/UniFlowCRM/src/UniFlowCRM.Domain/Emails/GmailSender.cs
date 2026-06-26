using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
namespace UniFlowCRM.Emails;

public class GmailSender : IEmailSender, ISingletonDependency
{
    public Task SendAsync(MailMessage mail, bool normalize = true)
    {
        var username = "uniflowcrm67@gmail.com";
        var password = "txlh prje ktqf iceb";
        var smtpclient = new SmtpClient("smtp.gmail.com", 587);
        smtpclient.Credentials = new NetworkCredential(username, password);
        smtpclient.EnableSsl = true;
        mail.From = new MailAddress(username);
        mail.Body = this.MakeBody(mail.Body);
        mail.IsBodyHtml = true;
        // System.Console.WriteLine(mail);
        smtpclient.Send(mail);
        return Task.CompletedTask;
    }
    public string MakeBody(string body)
    {
        return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
</head>
<body style='margin:0;padding:40px;background:#f8f5fa;font-family:Segoe UI,Arial,sans-serif;'>

<table width='100%' cellpadding='0' cellspacing='0'>
<tr>
<td align='center'>

<table width='600' cellpadding='0' cellspacing='0'
       style='background:#ffffff;border-radius:14px;
              box-shadow:0 8px 30px rgba(0,0,0,.08);
              overflow:hidden;'>

    <!-- Header -->
    <tr>
        <td style='background:linear-gradient(90deg,#ff4fa3,#d946ef);
                   color:white;
                   padding:28px;
                   text-align:center;'>

            <h1 style='margin:0;font-size:30px;'>UniFlow CRM</h1>
            <div style='margin-top:8px;opacity:.9;font-size:14px;'>
                Intelligent. Simple. Beau.
            </div>

        </td>
    </tr>

    <!-- Body -->
    <tr>
        <td style='padding:35px;color:#444;font-size:16px;line-height:1.7;'>

            {body}

        </td>
    </tr>

    <!-- Footer -->
    <tr>
        <td style='background:#faf5ff;
                   border-top:1px solid #edd5ff;
                   padding:20px;
                   text-align:center;
                   color:#777;
                   font-size:13px;'>

            <strong style='color:#d946ef;'>UniFlow CRM</strong><br><br>

            Merci d'utiliser UniFlow CRM.<br>

            <div style='margin-top:12px;color:#aaa;'>
                2026 UniFlow CRM. Tous droits réservés.
            </div>

        </td>
    </tr>

</table>

</td>
</tr>
</table>

</body>
</html>";
    }






    public Task QueueAsync(string to, string subject, string body, bool isBodyHtml = true, AdditionalEmailSendingArgs? additionalEmailSendingArgs = null)
    {
        throw new System.NotImplementedException();
    }

    public Task QueueAsync(string from, string to, string subject, string body, bool isBodyHtml = true, AdditionalEmailSendingArgs? additionalEmailSendingArgs = null)
    {
        throw new System.NotImplementedException();
    }

    public Task SendAsync(string to, string? subject, string? body, bool isBodyHtml = true, AdditionalEmailSendingArgs? additionalEmailSendingArgs = null)
    {
        throw new System.NotImplementedException();
    }

    public Task SendAsync(string from, string to, string? subject, string? body, bool isBodyHtml = true, AdditionalEmailSendingArgs? additionalEmailSendingArgs = null)
    {
        throw new System.NotImplementedException();
    }


}
