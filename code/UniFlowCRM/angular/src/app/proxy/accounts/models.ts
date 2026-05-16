import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';
import type { AccountType } from './account-type.enum';
import type { AccountIndustry } from './account-industry.enum';
import type { Currency } from '../moneys/currency.enum';

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
  username?: string | null;
  creatorName?: string | null;
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
