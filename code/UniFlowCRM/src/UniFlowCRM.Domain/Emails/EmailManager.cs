using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Emailing;

namespace UniFlowCRM.Emails
{
    public class EmailManager : DomainService
    {
        private readonly IEmailSender _emailsender;
        private readonly IRepository<Email, Guid> _emailRepository;

        public EmailManager(IEmailSender emailsender, IRepository<Email, Guid> emailRepository)
        {
            _emailsender = emailsender;
            _emailRepository = emailRepository;
        }
        public async Task SendEmailAsync(Email email, CancellationToken ct = default)
        {
            try
            {
                MailMessage message = email.ToMailMessage();
                await _emailsender.SendAsync(message);
                email.MarkAsSent();
            }
            catch (Exception e)
            {
                email.MarkAsFailed();
                throw;
            }
            finally
            {
                await _emailRepository.UpdateAsync(email,cancellationToken: ct);
            }
        }
    }
}
