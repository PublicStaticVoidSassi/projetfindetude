using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using UniFlowCRM.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace UniFlowCRM.Campaigns
{
    public class CampaignAppService :
        CrudAppService<Campaign, CampaignDto, Guid, CampaignResultRequestDto, CreateUpdateCampaignDto>
        , ICampaignAppService
    {
        private readonly ICampaignsRepository repository;
        private readonly IIdentityUserRepository userRepository;
        private readonly IPermissionChecker permissionChecker;

        public CampaignAppService(ICampaignsRepository repository, IIdentityUserRepository userRepository, IPermissionChecker permissionChecker) : base(repository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.permissionChecker = permissionChecker;
        }
        [Authorize(UniFlowCRMPermissions.Campaign.Create)]
        public override async Task<CampaignDto> CreateAsync(CreateUpdateCampaignDto dto)
        {
            return await base.CreateAsync(dto);
        }
        [Authorize(UniFlowCRMPermissions.Campaign.Edit)]
        public override async Task<CampaignDto> UpdateAsync(Guid id, CreateUpdateCampaignDto dto)
        {
            return await base.UpdateAsync(id, dto);
        }
        [Authorize(UniFlowCRMPermissions.Campaign.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
        [Authorize(UniFlowCRMPermissions.Campaign.Activate)]
        public async Task<bool> ActivateAsync(Guid id)
        {
            var obj = await Repository.GetAsync(id);
            if (obj.Status != CampaignStatus.active && obj.EndDate > DateTime.Now)
            {
                obj.Activate();
                await Repository.UpdateAsync(obj);
                return true;
            }
            return false;
        }
        [Authorize(UniFlowCRMPermissions.Campaign.Deactivate)]
        public async Task<bool> DeactivateAsync(Guid id)
        {
            var obj = await Repository.GetAsync(id);
            if (obj.Status != CampaignStatus.inactive && obj.EndDate > DateTime.Now)
            {
                obj.Deactivate();
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
        [Authorize(UniFlowCRMPermissions.Campaign.Default)]
        public override async Task<CampaignDto> GetAsync(Guid id)
        {
            var obj = await repository.GetJoinedAsync(id);
            var dto = ObjectMapper.Map<Campaign, CampaignDto>(obj);
            dto.Owner = ObjectMapper.Map<IdentityUser, IdentityUserDto>(await userRepository.GetAsync(dto.AssignedTo));
            if (dto.CreatorId != Guid.Empty && dto.CreatorId != null) dto.Creator = ObjectMapper.Map<IdentityUser, IdentityUserDto>(await userRepository.FindAsync((Guid)dto.CreatorId));
            if (dto.LastModifierId != Guid.Empty && dto.LastModifierId != null) dto.Modifier = ObjectMapper.Map<IdentityUser, IdentityUserDto>(await userRepository.FindAsync((Guid)dto.LastModifierId));
            return dto;
        }
        [Authorize(UniFlowCRMPermissions.Campaign.Default)]
        public override async Task<PagedResultDto<CampaignDto>> GetListAsync(CampaignResultRequestDto input)
        {
            var q = await Repository.GetQueryableAsync();
            if (!string.IsNullOrWhiteSpace(input.name))
            {
                q = q.Where(c => c.Name.ToLower().Contains(input.name));
            }
            if (!await permissionChecker.IsGrantedAsync(UniFlowCRMPermissions.Campaign.ViewAll))
            {
                q = q.Where(
                    a => a.CreatorId == CurrentUser.Id || a.AssignedTo == CurrentUser.Id);
            }
            q = q.OrderBy(input.Sorting ?? "CreationTime desc");
            q = q.Skip(input.SkipCount).Take(input.MaxResultCount);
            var dtos = q.ToList();
            var count = await Repository.GetCountAsync();
            return new PagedResultDto<CampaignDto>(count, ObjectMapper.Map<List<Campaign>, List<CampaignDto>>(dtos));
        }
    }
}
