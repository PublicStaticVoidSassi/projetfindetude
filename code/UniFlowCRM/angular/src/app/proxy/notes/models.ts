import type { CreationAuditedEntityDto, EntityDto } from '@abp/ng.core';
import type { NoteType } from './note-type.enum';
import type { LeadDto } from '../leads/models';
import type { AccountDto } from '../accounts/models';
import type { ContactDto } from '../contacts/models';
import type { OpportunityDto } from '../opportunities/models';
import type { IdentityUserDto } from '../volo/abp/identity/models';

export interface CreateUpdateNoteDto extends EntityDto<string> {
  title?: string;
  content?: string;
  type?: NoteType;
  leadId?: string | null;
  accountId?: string | null;
  contactId?: string | null;
  opportunityId?: string | null;
}

export interface NoteDto extends CreationAuditedEntityDto<string> {
  title?: string;
  content?: string;
  type?: NoteType;
  leadId?: string | null;
  lead?: LeadDto | null;
  accountId?: string | null;
  account?: AccountDto | null;
  contactId?: string | null;
  contact?: ContactDto | null;
  opportunityId?: string | null;
  opportunity?: OpportunityDto | null;
  creator?: IdentityUserDto | null;
}
