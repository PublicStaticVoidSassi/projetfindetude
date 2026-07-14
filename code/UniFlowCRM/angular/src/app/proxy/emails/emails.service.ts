import type { CreateUpdateEmailDto, EmailDto, EmailRequestDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EmailsService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateEmailDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmailDto>({
      method: 'POST',
      url: '/api/app/emails',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/emails/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmailDto>({
      method: 'GET',
      url: `/api/app/emails/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: EmailRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<EmailDto>>({
      method: 'GET',
      url: '/api/app/emails',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  sendEmail = (id: string, ct?: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/emails/${id}/send-email`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateEmailDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmailDto>({
      method: 'PUT',
      url: `/api/app/emails/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}