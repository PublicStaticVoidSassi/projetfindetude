import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { LeadStatus } from './lead-status.enum';
import type { LeadSource } from './lead-source.enum';
import type { IdentityUserDto } from '../volo/abp/identity/models';
import type { AccountDto } from '../accounts/models';

export interface CreateUpdateLeadDto extends EntityDto<string> {
  firstName?: string;
  lastName?: string | null;
  description?: string | null;
  status?: LeadStatus | null;
  source?: LeadSource | null;
  phoneNumber?: string | null;
  phoneCode?: string | null;
  email?: string | null;
  userID?: string | null;
  accountID?: string | null;
}

export interface LeadDto extends FullAuditedEntityDto<string> {
  firstName?: string;
  lastName?: string | null;
  description?: string | null;
  status?: LeadStatus;
  source?: LeadSource;
  phone?: string | null;
  email?: string | null;
  userID?: string;
  owner?: IdentityUserDto | null;
  creator?: IdentityUserDto | null;
  modifier?: IdentityUserDto | null;
  account?: AccountDto | null;
  accountID?: string | null;
}

export interface LeadRequestDto extends PagedAndSortedResultRequestDto {
  filter?: string | null;
}

export interface LeadsPerSourceDto {
  source?: LeadSource;
  count?: number;
}
