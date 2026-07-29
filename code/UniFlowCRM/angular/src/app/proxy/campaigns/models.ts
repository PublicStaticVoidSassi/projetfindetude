import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { CampaignStatus } from './campaign-status.enum';
import type { Currency } from '../moneys/currency.enum';
import type { IdentityUserDto } from '../volo/abp/identity/models';

export interface CampaignDto extends FullAuditedEntityDto<string> {
  name?: string;
  description?: string;
  status?: CampaignStatus;
  budgetValue?: number;
  budgetCurrency?: Currency;
  costSoFarValue?: number | null;
  costSoFarCurrency?: Currency;
  expectedAccounts?: number;
  expectedLeads?: number;
  expectedContacts?: number;
  expectedOpportunities?: number;
  reachedAccounts?: number;
  reachedLeads?: number;
  reachedContacts?: number;
  reachedOpportunities?: number;
  startDate?: string;
  endDate?: string;
  assignedTo?: string;
  owner?: IdentityUserDto;
  creator?: IdentityUserDto;
  modifier?: IdentityUserDto;
}

export interface CampaignResultRequestDto extends PagedAndSortedResultRequestDto {
  name?: string | null;
}

export interface CreateUpdateCampaignDto {
  name?: string;
  description?: string;
  status?: CampaignStatus;
  budgetValue?: number;
  budgetCurrency?: Currency;
  costSoFarValue?: number;
  costSoFarCurrency?: Currency;
  expectedAccounts?: number;
  expectedLeads?: number;
  expectedContacts?: number;
  expectedOpportunities?: number;
  startDate?: string;
  endDate?: string;
  assignedTo?: string;
}
