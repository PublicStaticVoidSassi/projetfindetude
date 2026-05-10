import type { CreateUpdateLeadDto, LeadDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LeadsService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateLeadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LeadDto>({
      method: 'POST',
      url: '/api/app/leads',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/leads/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LeadDto>({
      method: 'GET',
      url: `/api/app/leads/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LeadDto>>({
      method: 'GET',
      url: '/api/app/leads',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateLeadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LeadDto>({
      method: 'PUT',
      url: `/api/app/leads/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}