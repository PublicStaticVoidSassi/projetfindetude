import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';
import type { EmailStatus } from './email-status.enum';
import type { AccountDto } from '../accounts/models';
import type { ContactDto } from '../contacts/models';
import type { OpportunityDto } from '../opportunities/models';
import type { LeadDto } from '../leads/models';
import type { IdentityUserDto } from '../volo/abp/identity/models';

export interface CreateUpdateEmailDto extends EntityDto<string> {
  subject?: string;
  body?: string | null;
  status?: EmailStatus;
  from?: string;
  to?: string;
  cc?: string | null;
  bcc?: string | null;
  sentAt?: string | null;
  isHtml?: boolean;
  accountID?: string | null;
  contactID?: string | null;
  opportunityID?: string | null;
  leadID?: string | null;
  ownerID?: string | null;
}

export interface EmailDto extends FullAuditedEntityDto<string> {
  subject?: string;
  body?: string | null;
  status?: EmailStatus;
  from?: string;
  to?: string;
  cc?: string | null;
  bcc?: string | null;
  sentAt?: string | null;
  isHtml?: boolean;
  account?: AccountDto | null;
  contact?: ContactDto | null;
  opportunity?: OpportunityDto | null;
  lead?: LeadDto | null;
  owner?: IdentityUserDto | null;
  creator?: IdentityUserDto | null;
  modifier?: IdentityUserDto | null;
}
