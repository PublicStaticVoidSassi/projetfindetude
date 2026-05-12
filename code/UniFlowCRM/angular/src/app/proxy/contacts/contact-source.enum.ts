import { mapEnumToOptions } from '@abp/ng.core';

export enum ContactSource {
  Unset = 0,
  ExistingCustomer = 1,
  SelfGenerated = 2,
  Employee = 3,
  Partner = 4,
  PublicRelations = 5,
  DirectMail = 6,
  Conference = 7,
  TradeShow = 8,
  WebSite = 9,
  WordOfMouth = 10,
  Email = 11,
  Campaign = 12,
  ColdCall = 13,
  Other = 14,
}

export const contactSourceOptions = mapEnumToOptions(ContactSource);
