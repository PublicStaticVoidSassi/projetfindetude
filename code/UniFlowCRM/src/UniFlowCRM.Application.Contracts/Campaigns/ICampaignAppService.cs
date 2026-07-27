using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UniFlowCRM.Campaigns
{
    public interface ICampaignAppService : 
        ICrudAppService<CampaignDto,Guid,CampaignResultRequestDto,CreateUpdateCampaignDto>
    {
    }
}
