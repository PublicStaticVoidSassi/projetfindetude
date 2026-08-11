import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
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

export interface CallRequestDto extends PagedAndSortedResultRequestDto {
  filter?: string | null;
}

export interface CreateUpdateCallDto extends EntityDto<string> {
  name?: string;
  description?: string | null;
  status?: CallStatus;
  direction?: CallDirection;
  startTime?: string;
  endTime?: string;
  duration?: number | null;
  phoneCode?: string | null;
  phoneNumber?: string | null;
  accountID?: string | null;
  contactID?: string | null;
  opportunityID?: string | null;
  leadID?: string | null;
  ownerID?: string;
}
