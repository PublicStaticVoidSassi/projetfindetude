import { mapEnumToOptions } from '@abp/ng.core';

export enum EmailStatus {
  Draft = 0,
  Sending = 1,
  Sent = 2,
  Archived = 3,
  Failed = 4,
}

export const emailStatusOptions = mapEnumToOptions(EmailStatus);
