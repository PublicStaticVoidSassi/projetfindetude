import type { AnalyticsDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';
import type { DashboardDto, IncomeDto } from '../dashboards/models';

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
      { apiName: this.apiName, ...config });


  getDashboard = (ct?: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DashboardDto>({
      method: 'GET',
      url: '/api/app/analytics/dashboard',
    },
      { apiName: this.apiName, ...config });


  getIncome = (ct?: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncomeDto>({
      method: 'GET',
      url: '/api/app/analytics/income',
    },
      { apiName: this.apiName, ...config });
}
