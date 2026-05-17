import type { CreateUpdateNoteDto, NoteDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class NotesService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateNoteDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoteDto>({
      method: 'POST',
      url: '/api/app/notes',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/notes/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoteDto>({
      method: 'GET',
      url: `/api/app/notes/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getForAccountByAccountId = (AccountId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoteDto[]>({
      method: 'GET',
      url: `/api/app/notes/for-account/${AccountId}`,
    },
    { apiName: this.apiName,...config });
  

  getForContactByContactId = (contactId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoteDto[]>({
      method: 'GET',
      url: `/api/app/notes/for-contact/${contactId}`,
    },
    { apiName: this.apiName,...config });
  

  getForLeadByLeadId = (leadId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoteDto[]>({
      method: 'GET',
      url: `/api/app/notes/for-lead/${leadId}`,
    },
    { apiName: this.apiName,...config });
  

  getForOpportunityByOpportunityId = (OpportunityId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoteDto[]>({
      method: 'GET',
      url: `/api/app/notes/for-opportunity/${OpportunityId}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<NoteDto>>({
      method: 'GET',
      url: '/api/app/notes',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateNoteDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, NoteDto>({
      method: 'PUT',
      url: `/api/app/notes/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}