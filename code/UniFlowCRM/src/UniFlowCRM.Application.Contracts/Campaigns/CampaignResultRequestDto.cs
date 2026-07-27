using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UniFlowCRM.Campaigns
{
    public class CampaignResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string? name { get; set; }
    }
}
