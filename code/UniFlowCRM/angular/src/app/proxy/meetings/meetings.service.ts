import type { CreateUpdateMeetingDto, MeetingDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';
import { LeadRequestDto } from '../leads';

@Injectable({
  providedIn: 'root',
})
export class MeetingsService {
  private restService = inject(RestService);
  apiName = 'Default';


  create = (input: CreateUpdateMeetingDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MeetingDto>({
      method: 'POST',
      url: '/api/app/meetings',
      body: input,
    },
    { apiName: this.apiName,...config });


  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/meetings/${id}`,
    },
    { apiName: this.apiName,...config });


  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MeetingDto>({
      method: 'GET',
      url: `/api/app/meetings/${id}`,
    },
    { apiName: this.apiName,...config });


  getList = (input: LeadRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<MeetingDto>>({
      method: 'GET',
      url: '/api/app/meetings',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });


  update = (id: string, input: CreateUpdateMeetingDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MeetingDto>({
      method: 'PUT',
      url: `/api/app/meetings/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}
