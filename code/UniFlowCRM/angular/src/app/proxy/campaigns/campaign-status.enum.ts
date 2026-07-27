import { mapEnumToOptions } from '@abp/ng.core';

export enum CampaignStatus {
  planned = 1,
  active = 2,
  inactive = 3,
  completed = 4,
}

export const campaignStatusOptions = mapEnumToOptions(CampaignStatus);
