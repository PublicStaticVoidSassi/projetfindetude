import { mapEnumToOptions } from '@abp/ng.core';

export enum MeetingStatus {
  Planned = 0,
  Held = 1,
  NotHeld = 2,
  Cancelled = 3,
}

export const meetingStatusOptions = mapEnumToOptions(MeetingStatus);
