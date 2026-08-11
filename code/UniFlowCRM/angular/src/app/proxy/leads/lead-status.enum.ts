import { mapEnumToOptions } from '@abp/ng.core';

export enum LeadStatus {
  New = 0,
  Qualified = 1,
  InProcess = 2,
  Converted = 3,
  Recycled = 4,
  Dead = 5,
}

export const leadStatusOptions = mapEnumToOptions(LeadStatus);
