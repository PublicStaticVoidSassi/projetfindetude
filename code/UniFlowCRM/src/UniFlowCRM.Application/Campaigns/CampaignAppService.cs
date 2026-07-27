using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Campaigns
{
    public class CampaignAppService :
        CrudAppService<Campaign, CampaignDto, Guid, CampaignResultRequestDto, CreateUpdateCampaignDto>
        , ICampaignAppService
    {
        public CampaignAppService(ICampaignsRepository repository) : base(repository)
        {
        }
        public async Task<bool> ActivateAsync(Guid id)
        {
            var obj = await Repository.GetAsync(id);
            if (obj.Status != CampaignStatus.active && obj.EndDate > DateTime.Now)
            {
                obj.Status = CampaignStatus.active;
                await Repository.UpdateAsync(obj);
                return true;
            }
            return false;
        }
        public async Task<bool> DeactivateAsync(Guid id)
        {
            var obj = await Repository.GetAsync(id);
            if (obj.Status != CampaignStatus.inactive && obj.EndDate > DateTime.Now)
            {
                obj.Status = CampaignStatus.inactive;
                await Repository.UpdateAsync(obj);
                return true;
            }
            return false;
        }
        public async Task<List<CampaignDto>> GetLookup()
        {
            var q = await Repository.GetQueryableAsync();
            q = q.Where(c => c.Status == CampaignStatus.active);
            var dtos = q.ToList();
            return ObjectMapper.Map<List<Campaign>, List<CampaignDto>>(dtos);
        }
        public override async Task<PagedResultDto<CampaignDto>> GetListAsync(CampaignResultRequestDto input)
        {
            var q = await Repository.GetQueryableAsync();
            if (!string.IsNullOrWhiteSpace(input.name))
            {
                q = q.Where(c => c.Name.ToLower().Contains(input.name));
            }
            q = q.OrderBy(input.Sorting ?? "CreationTime desc");
            q = q.Skip(input.SkipCount).Take(input.MaxResultCount);
            var dtos = q.ToList();
            var count = q.Count();
            return new PagedResultDto<CampaignDto>(count, ObjectMapper.Map<List<Campaign>, List<CampaignDto>>(dtos));
        }
    }
}
