import type { CallDto, CreateUpdateCallDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CallsService {
  private restService = inject(RestService);
  apiName = 'Default';


  create = (input: CreateUpdateCallDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CallDto>({
      method: 'POST',
      url: '/api/app/calls',
      body: input,
    },
      { apiName: this.apiName, ...config });


  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/calls/${id}`,
    },
      { apiName: this.apiName, ...config });


  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CallDto>({
      method: 'GET',
      url: `/api/app/calls/${id}`,
    },
      { apiName: this.apiName, ...config });


  getList = (input: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CallDto>>({
      method: 'GET',
      url: '/api/app/calls',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
      { apiName: this.apiName, ...config });


  update = (id: string, input: CreateUpdateCallDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CallDto>({
      method: 'PUT',
      url: `/api/app/calls/${id}`,
      body: input,
    },
      { apiName: this.apiName, ...config });
}
