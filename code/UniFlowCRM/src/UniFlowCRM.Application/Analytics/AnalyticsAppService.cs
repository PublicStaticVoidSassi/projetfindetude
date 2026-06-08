using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace UniFlowCRM.Analytics
{
    public class AnalyticsAppService(
        IRepository<Lead,Guid> _leadRepository,
        IRepository<Account,Guid> _accountRepository,
        IRepository<Contact,Guid> _contactRepository,
        IRepository<Opportunity,Guid> _opportunityRepository,
        IRepository<IdentityUser,Guid> _userRepository
        ) : UniFlowCRMAppService
    {
        private async Task<LeadAnalytics> GetLeadAnalyticsAsync()
        {
            var analytics = new LeadAnalytics();
            analytics.Total = (int)await _leadRepository.GetCountAsync();
            analytics.Converted = (await _leadRepository.GetQueryableAsync())
                .Where(lead=>lead.Status==LeadStatus.Converted)
                .Count();
            return analytics;
        }
        private async Task<AccountAnalytics> GetAccountAnalyticsAsync()
        {
            return new AccountAnalytics()
            {
                Total = (int)await _accountRepository.GetCountAsync()
            };
        }
        private async Task<ContactAnalytics> GetContactAnalyticsAsync()
        {
            return new ContactAnalytics()
            {
                Total = (int)await _contactRepository.GetCountAsync(),
                active = (await _contactRepository.GetQueryableAsync())
                .Where(c => c.Status == ContactStatus.Active)
                .Count()
            };
        }
        private async Task<OpportunityAnalytics> GetOpportunityAnalyticsAsync()
        {
            return new OpportunityAnalytics()
            {
                Total = (int)await _opportunityRepository.GetCountAsync(),
                Won = (await _opportunityRepository.GetQueryableAsync())
                .Where(o => o.Stage == OpportunityStage.ClosedWon)
                .Count(),
                Lost = (await _opportunityRepository.GetQueryableAsync())
                .Where(o => o.Stage == OpportunityStage.ClosedLost)
                .Count()
            };
        }
        // Gets all the analytics
        public async Task<AnalyticsDto> GetAsync()
        {
            var analytics = new AnalyticsDto()
            {
                Lead = await GetLeadAnalyticsAsync(),
                Contact = await GetContactAnalyticsAsync(),
                Account = await GetAccountAnalyticsAsync(),
                Opportunity = await GetOpportunityAnalyticsAsync()
            };
            return analytics;
        }

    }
}
