import { mapEnumToOptions } from '@abp/ng.core';

export enum NoteType {
  General = 0,
  Preference = 1,
  Demand = 2,
  Complaint = 3,
}

export const noteTypeOptions = mapEnumToOptions(NoteType);
