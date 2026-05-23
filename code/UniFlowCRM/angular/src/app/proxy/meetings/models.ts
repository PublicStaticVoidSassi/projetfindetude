import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';
import type { MeetingStatus } from './meeting-status.enum';
import type { AccountDto } from '../accounts/models';
import type { ContactDto } from '../contacts/models';
import type { OpportunityDto } from '../opportunities/models';
import type { LeadDto } from '../leads/models';
import type { IdentityUserDto } from '../volo/abp/identity/models';

export interface CreateUpdateMeetingDto extends EntityDto<string> {
  name?: string;
  description?: string | null;
  status?: MeetingStatus;
  startTime?: string;
  endTime?: string;
  location?: string | null;
  accountID?: string | null;
  contactID?: string | null;
  opportunityID?: string | null;
  leadID?: string | null;
  ownerID?: string | null;
}

export interface MeetingDto extends FullAuditedEntityDto<string> {
  name?: string;
  description?: string | null;
  status?: MeetingStatus;
  startTime?: string;
  endTime?: string;
  location?: string | null;
  account?: AccountDto | null;
  contact?: ContactDto | null;
  opportunity?: OpportunityDto | null;
  lead?: LeadDto | null;
  owner?: IdentityUserDto | null;
  creator?: IdentityUserDto | null;
  modifier?: IdentityUserDto | null;
}
