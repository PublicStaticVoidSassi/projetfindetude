import type { CreateUpdateOpportunityDto, OpportunityDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OpportunitiesService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateOpportunityDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, OpportunityDto>({
      method: 'POST',
      url: '/api/app/opportunities',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/opportunities/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, OpportunityDto>({
      method: 'GET',
      url: `/api/app/opportunities/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<OpportunityDto>>({
      method: 'GET',
      url: '/api/app/opportunities',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateOpportunityDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, OpportunityDto>({
      method: 'PUT',
      url: `/api/app/opportunities/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}