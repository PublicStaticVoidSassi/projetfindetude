import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';
import type { Currency } from '../money/currency.enum';
import type { OpportunityStage } from './opportunity-stage.enum';
import type { OpportunityType } from './opportunity-type.enum';
import type { SaleStage } from './sale-stage.enum';
import type { IdentityUserDto } from '../volo/abp/identity/models';
import type { LeadDto } from '../leads/models';
import type { AccountDto } from '../accounts/models';
import type { ContactDto } from '../contacts/models';

export interface CreateUpdateOpportunityDto extends EntityDto<string> {
  name?: string | null;
  description?: string | null;
  amountCurrency?: Currency | null;
  amountValue?: number | null;
  stage?: OpportunityStage | null;
  type?: OpportunityType | null;
  saleStage?: SaleStage | null;
  probability?: number;
  nextStep?: string | null;
  closedAt?: string | null;
  userID?: string | null;
  leadID?: string | null;
  accountID?: string | null;
  contactID?: string | null;
}

export interface OpportunityDto extends FullAuditedEntityDto<string> {
  name?: string | null;
  description?: string | null;
  amountCurrency?: Currency | null;
  amountValue?: number | null;
  stage?: OpportunityStage | null;
  type?: OpportunityType | null;
  saleStage?: SaleStage | null;
  probability?: number;
  nextStep?: string | null;
  closedAt?: string | null;
  userID?: string | null;
  user?: IdentityUserDto | null;
  leadID?: string | null;
  lead?: LeadDto | null;
  accountID?: string | null;
  account?: AccountDto | null;
  contactID?: string | null;
  contact?: ContactDto | null;
}
