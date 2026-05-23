import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';
import type { CallStatus } from './call-status.enum';
import type { CallDirection } from './call-direction.enum';
import type { AccountDto } from '../accounts/models';
import type { ContactDto } from '../contacts/models';
import type { OpportunityDto } from '../opportunities/models';
import type { LeadDto } from '../leads/models';
import type { IdentityUserDto } from '../volo/abp/identity/models';

export interface CallDto extends FullAuditedEntityDto<string> {
  name?: string;
  description?: string | null;
  status?: CallStatus;
  direction?: CallDirection;
  startTime?: string | null;
  endTime?: string | null;
  duration?: number | null;
  phoneNumber?: string | null;
  account?: AccountDto | null;
  contact?: ContactDto | null;
  opportunity?: OpportunityDto | null;
  lead?: LeadDto | null;
  owner?: IdentityUserDto | null;
  creator?: IdentityUserDto | null;
  modifier?: IdentityUserDto | null;
}

export interface CreateUpdateCallDto extends EntityDto<string> {
  name?: string;
  description?: string | null;
  status?: CallStatus;
  direction?: CallDirection;
  startTime?: string | null;
  endTime?: string | null;
  duration?: number | null;
  phoneNumber?: string | null;
  accountId?: string | null;
  contactId?: string | null;
  opportunityId?: string | null;
  leadId?: string | null;
  owner?: string | null;
}
