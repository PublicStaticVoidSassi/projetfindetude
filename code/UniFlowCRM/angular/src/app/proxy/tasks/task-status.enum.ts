import { mapEnumToOptions } from '@abp/ng.core';

export enum TaskStatus {
  NotStarted = 0,
  InProgress = 1,
  Completed = 2,
  Deferred = 3,
  Cancelled = 4,
}

export const taskStatusOptions = mapEnumToOptions(TaskStatus);
