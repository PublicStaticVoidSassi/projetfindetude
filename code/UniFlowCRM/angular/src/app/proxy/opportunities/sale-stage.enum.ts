import { mapEnumToOptions } from '@abp/ng.core';

export enum SaleStage {
  Prospecting = 0,
  Qualification = 1,
  Proposal = 2,
  Negotiation = 3,
  Closed = 4,
}

export const saleStageOptions = mapEnumToOptions(SaleStage);
