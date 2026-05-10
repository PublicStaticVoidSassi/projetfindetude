import { mapEnumToOptions } from '@abp/ng.core';

export enum Currency {
  DZD = 0,
  EUR = 1,
  USD = 2,
}

export const currencyOptions = mapEnumToOptions(Currency);
