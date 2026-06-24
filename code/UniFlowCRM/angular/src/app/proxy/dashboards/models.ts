import type { EntityDto } from '@abp/ng.core';

export interface DashboardDto extends EntityDto {
  pendingleads?: number;
  convertedleads?: number;
  deadleads?: number;
  activecontacts?: number;
  inactivecontacts?: number;
  totalaccounts?: number;
  pendingdeals?: number;
  wondeals?: number;
  lostdeals?: number;
  totalleads?: number;
  totalcontacts?: number;
  totalopportunities?: number;
}
export interface IncomeDto extends EntityDto {
  dzdincome?: number,
  eurincome?: number,
  usdincome?: number
}
