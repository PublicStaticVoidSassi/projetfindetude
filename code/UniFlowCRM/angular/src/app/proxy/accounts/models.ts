import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';
import type { AccountType } from './account-type.enum';
import type { AccountIndustry } from './account-industry.enum';
import type { Currency } from '../moneys/currency.enum';
import type { IdentityUserDto } from '../volo/abp/identity/models';

export interface AccountDto extends FullAuditedEntityDto<string> {
  name: string;
  description?: string | null;
  phone?: string | null;
  fax?: string | null;
  email?: string | null;
  website?: string | null;
  city?: string | null;
  street?: string | null;
  country?: string | null;
  postalCode?: number | null;
  type?: AccountType;
  industry?: AccountIndustry | null;
  revenueValue?: number | null;
  revenueCurrency?: Currency | null;
  employees?: number | null;
  userID?: string;
  owner?: IdentityUserDto | null;
  creator?: IdentityUserDto | null;
  modifier?: IdentityUserDto | null;
}

export interface CreateUpdateAccountDto extends EntityDto<string> {
  name: string;
  description?: string | null;
  phoneCode?: string | null;
  phoneNumber?: string | null;
  faxCode?: string | null;
  faxNumber?: string | null;
  email?: string | null;
  website?: string | null;
  city?: string | null;
  street?: string | null;
  country?: string | null;
  postalCode?: number | null;
  type?: AccountType;
  industry?: AccountIndustry | null;
  revenueAmount?: number | null;
  revenueCurrency?: Currency | null;
  employees?: number | null;
  userID?: string | null;
}
