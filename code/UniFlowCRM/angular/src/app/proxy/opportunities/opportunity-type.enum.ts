import { mapEnumToOptions } from '@abp/ng.core';

export enum OpportunityType {
  NewBusiness = 0,
  ExistingBusiness = 1,
  Renewal = 2,
}

export const opportunityTypeOptions = mapEnumToOptions(OpportunityType);
