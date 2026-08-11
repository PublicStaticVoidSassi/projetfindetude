import type { CreateUpdateLeadDto, LeadDto, LeadRequestDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LeadsService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  convert = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: `/api/app/leads/${id}/convert`,
    },
    { apiName: this.apiName,...config });
  

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
  

  getList = (input: LeadRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LeadDto>>({
      method: 'GET',
      url: '/api/app/leads',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  qualify = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/leads/${id}/qualify`,
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