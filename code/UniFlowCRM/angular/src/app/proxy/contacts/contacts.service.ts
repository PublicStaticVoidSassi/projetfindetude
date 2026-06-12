import type { ContactDto, ContactRequestDto, CreateUpdateContactDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ContactsService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateContactDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ContactDto>({
      method: 'POST',
      url: '/api/app/contacts',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/contacts/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ContactDto>({
      method: 'GET',
      url: `/api/app/contacts/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: ContactRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ContactDto>>({
      method: 'GET',
      url: '/api/app/contacts',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateContactDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ContactDto>({
      method: 'PUT',
      url: `/api/app/contacts/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}