import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { TaskStatus } from './task-status.enum';
import type { TaskPriority } from './task-priority.enum';
import type { IdentityUserDto } from '../volo/abp/identity/models';
import type { AccountDto } from '../accounts/models';
import type { ContactDto } from '../contacts/models';
import type { OpportunityDto } from '../opportunities/models';
import type { LeadDto } from '../leads/models';

export interface CreateUpdateTaskDto extends EntityDto<string> {
  name?: string;
  description?: string | null;
  status?: TaskStatus;
  priority?: TaskPriority;
  startTime?: string | null;
  endTime?: string | null;
  completedAt?: string | null;
  ownerID?: string | null;
  accountID?: string | null;
  contactID?: string | null;
  opportunityID?: string | null;
  leadID?: string | null;
}

export interface TaskDto extends FullAuditedEntityDto<string> {
  name?: string;
  description?: string | null;
  status?: TaskStatus;
  priority?: TaskPriority;
  startTime?: string | null;
  endTime?: string | null;
  completedAt?: string | null;
  owner?: IdentityUserDto | null;
  creator?: IdentityUserDto | null;
  modifier?: IdentityUserDto | null;
  account?: AccountDto | null;
  contact?: ContactDto | null;
  opportunity?: OpportunityDto | null;
  lead?: LeadDto | null;
}

export interface TaskRequestDto extends PagedAndSortedResultRequestDto {
  filter?: string | null;
}
