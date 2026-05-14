import { mapEnumToOptions } from '@abp/ng.core';

export enum ContactStatus {
  Inactive = 0,
  Active = 1,
}

export const contactStatusOptions = mapEnumToOptions(ContactStatus);
