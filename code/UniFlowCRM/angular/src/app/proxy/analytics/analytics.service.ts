import type { AnalyticsDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AnalyticsService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  get = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AnalyticsDto>({
      method: 'GET',
      url: '/api/app/analytics',
    },
    { apiName: this.apiName,...config });
}