import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';
import type { LeadStatus } from './lead-status.enum';
import type { LeadSource } from './lead-source.enum';

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
  accountID?: string | null;
}
