using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniFlowCRM.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UniFlowCRM.Campaigns
{
    
     

    public class CampaignsRepository(IDbContextProvider<UniFlowCRMDbContext> dbContextProvider) : EfCoreRepository<UniFlowCRMDbContext, Campaign, Guid>(dbContextProvider), ICampaignsRepository
    {
        public async Task<Campaign?> FindJoinedAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            var query = from ca in dbContext.Campaigns.AsNoTracking()
                        where ca.Id == id
                        select new Campaign(
                            id: ca.Id,
                            name: ca.Name,
                            description: ca.Description,
                            status: ca.Status,
                            startDate: ca.StartDate,
                            endDate: ca.EndDate,
                            assignedTo: ca.AssignedTo,
                            budget: ca.Budget,
                            costSoFar: ca.CostSoFar,
                            expectedAccounts: ca.ExpectedAccounts,
                            expectedLeads: ca.ExpectedLeads,
                            expectedContacts: ca.ExpectedContacts,
                            expectedOpportunities: ca.ExpectedOpportunities,
                            reachedAccounts: dbContext.Accounts.Count(a => a.CampaignId == ca.Id),
                            reachedLeads: dbContext.Leads.Count(l => l.CampaignId == ca.Id),
                            reachedContacts: dbContext.Contacts.Count(c => c.CampaignId == ca.Id),
                            reachedOpportunities: dbContext.Opportunities.Count(o => o.CampaignId == ca.Id)
                            )
                        {

                        };
            //Console.WriteLine(query.ToString());
            var entity = await AsyncExecuter.FirstOrDefaultAsync(query);
            return entity;
        }
        public async Task<Campaign> GetJoinedAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await this.FindJoinedAsync(id, includeDetails, cancellationToken) ?? throw new EntityNotFoundException();
        }
        public override async Task<List<Campaign>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            var query = from ca in dbContext.Campaigns
                        select new Campaign(
                            name: ca.Name,
                            description: ca.Description,
                            status: ca.Status,
                            startDate: ca.StartDate,
                            endDate: ca.EndDate,
                            assignedTo: ca.AssignedTo,
                            budget: ca.Budget,
                            costSoFar: ca.CostSoFar,
                            expectedAccounts: ca.ExpectedAccounts,
                            expectedLeads: ca.ExpectedLeads,
                            expectedContacts: ca.ExpectedContacts,
                            expectedOpportunities: ca.ExpectedOpportunities,
                            reachedAccounts: dbContext.Accounts.Count(a => a.CampaignId == ca.Id),
                            reachedLeads: dbContext.Leads.Count(l => l.CampaignId == ca.Id),
                            reachedContacts: dbContext.Contacts.Count(c => c.CampaignId == ca.Id),
                            reachedOpportunities: dbContext.Opportunities.Count(o => o.CampaignId == ca.Id));
            Console.WriteLine(query.ToString());
            var entities = await AsyncExecuter.ToListAsync(query);
            return entities;
        }
    }
}
