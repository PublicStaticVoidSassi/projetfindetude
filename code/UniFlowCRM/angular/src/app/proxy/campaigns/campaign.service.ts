import type { CampaignDto, CampaignResultRequestDto, CreateUpdateCampaignDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CampaignService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  activate = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, boolean>({
      method: 'POST',
      url: `/api/app/campaign/${id}/activate`,
    },
    { apiName: this.apiName,...config });
  

  create = (input: CreateUpdateCampaignDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CampaignDto>({
      method: 'POST',
      url: '/api/app/campaign',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  deactivate = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, boolean>({
      method: 'POST',
      url: `/api/app/campaign/${id}/deactivate`,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/campaign/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CampaignDto>({
      method: 'GET',
      url: `/api/app/campaign/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: CampaignResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CampaignDto>>({
      method: 'GET',
      url: '/api/app/campaign',
      params: { name: input.name, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getLookup = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CampaignDto[]>({
      method: 'GET',
      url: '/api/app/campaign/lookup',
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateCampaignDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CampaignDto>({
      method: 'PUT',
      url: `/api/app/campaign/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}