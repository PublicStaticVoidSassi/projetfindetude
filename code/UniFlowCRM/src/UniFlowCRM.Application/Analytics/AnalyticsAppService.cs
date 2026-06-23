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
        IRepository<Lead, Guid> _leadRepository,
        IRepository<Account, Guid> _accountRepository,
        IRepository<Contact, Guid> _contactRepository,
        IRepository<Opportunity, Guid> _opportunityRepository,
        IRepository<IdentityUser, Guid> _userRepository
        ) : UniFlowCRMAppService
    {
        private async Task<LeadAnalytics> GetLeadAnalyticsAsync()
        {
            var analytics = new LeadAnalytics();
            analytics.Total = (int)await _leadRepository.GetCountAsync();
            analytics.Converted = (await _leadRepository.GetQueryableAsync())
                .Where(lead => lead.Status == LeadStatus.Converted)
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
        private async Task<OpportunityAnalytics> GetOpportunityAnalyticsAsyncV2()
        {
            var query = await _opportunityRepository.GetQueryableAsync();

            var analytics = query
                .GroupBy(o => 1) // Group everything into a single bucket
                .Select(g => new OpportunityAnalytics()
                {
                    Total = g.Count(),

                    Won = g.Count(o => o.Stage == OpportunityStage.ClosedWon),

                    Lost = g.Count(o => o.Stage == OpportunityStage.ClosedLost),

                    dzdincome = g.Where(o => o.Stage == OpportunityStage.ClosedWon && o.Amount.Currency == Moneys.Currency.DZD)
                                 .Sum(o => o.Amount.Value),

                    eurincome = g.Where(o => o.Stage == OpportunityStage.ClosedWon && o.Amount.Currency == Moneys.Currency.EUR)
                                 .Sum(o => o.Amount.Value),

                    usdincome = g.Where(o => o.Stage == OpportunityStage.ClosedWon && o.Amount.Currency == Moneys.Currency.USD)
                                 .Sum(o => o.Amount.Value)
                })
                .FirstOrDefault(); // Executes everything server-side in 1 trip

            // Return empty analytics object if database table is completely empty
            return analytics ?? new OpportunityAnalytics();
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
                .Count(),
                dzdincome = (await _opportunityRepository.GetQueryableAsync())
                .Where(o => o.Stage == OpportunityStage.ClosedWon &&
                o.Amount.Currency == Moneys.Currency.DZD).Sum(o => o.Amount.Value),
                eurincome = (await _opportunityRepository.GetQueryableAsync())
                .Where(o => o.Stage == OpportunityStage.ClosedWon &&
                o.Amount.Currency == Moneys.Currency.EUR).Sum(o => o.Amount.Value),
                usdincome = (await _opportunityRepository.GetQueryableAsync())
                .Where(o => o.Stage == OpportunityStage.ClosedWon &&
                o.Amount.Currency == Moneys.Currency.USD).Sum(o => o.Amount.Value),
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
