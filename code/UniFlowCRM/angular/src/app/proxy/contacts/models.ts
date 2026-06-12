import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ContactStatus } from './contact-status.enum';
import type { ContactSource } from './contact-source.enum';
import type { IdentityUserDto } from '../volo/abp/identity/models';
import type { LeadDto } from '../leads/models';
import type { AccountDto } from '../accounts/models';

export interface ContactDto extends FullAuditedEntityDto<string> {
  firstName?: string;
  middleName?: string | null;
  lastName?: string | null;
  description?: string | null;
  status?: ContactStatus;
  source?: ContactSource;
  phone?: string | null;
  fax?: string | null;
  email?: string | null;
  website?: string | null;
  country?: string | null;
  city?: string | null;
  street?: string | null;
  postalCode?: number | null;
  job?: string | null;
  departement?: string | null;
  userID?: string;
  owner?: IdentityUserDto | null;
  modifier?: IdentityUserDto | null;
  creator?: IdentityUserDto | null;
  leadID?: string | null;
  lead?: LeadDto | null;
  accountID?: string | null;
  account?: AccountDto | null;
}

export interface ContactRequestDto extends PagedAndSortedResultRequestDto {
  filter?: string | null;
}

export interface CreateUpdateContactDto extends EntityDto<string> {
  firstName?: string;
  middleName?: string | null;
  lastName?: string | null;
  description?: string | null;
  status?: ContactStatus;
  source?: ContactSource;
  phoneCode?: string | null;
  phoneNumber?: string | null;
  faxCode?: string | null;
  faxNumber?: string | null;
  email?: string | null;
  website?: string | null;
  country?: string | null;
  city?: string | null;
  street?: string | null;
  postalCode?: number | null;
  job?: string | null;
  departement?: string | null;
  userID?: string | null;
  leadID?: string | null;
  accountID?: string | null;
}
