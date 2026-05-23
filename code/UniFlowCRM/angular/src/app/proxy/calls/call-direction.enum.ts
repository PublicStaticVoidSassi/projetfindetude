import { mapEnumToOptions } from '@abp/ng.core';

export enum CallDirection {
  Outbound = 0,
  Inbound = 1,
}

export const callDirectionOptions = mapEnumToOptions(CallDirection);
