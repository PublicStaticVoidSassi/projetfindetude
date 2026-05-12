import { mapEnumToOptions } from '@abp/ng.core';

export enum ContactStatus {
  New = 0,
  Active = 1,
  Inactive = 2,
  Engaged = 3,
  DoNotContact = 4,
  Converted = 5,
  Archived = 6,
}

export const contactStatusOptions = mapEnumToOptions(ContactStatus);
