import type { AnalyticsDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';
import type { AccountPerIndustryDto, AccountPerTypeDto } from '../accounts/models';
import type { DashboardDto, IncomeDto } from '../dashboards/models';
import type { LeadsPerSourceDto } from '../leads/models';

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
  

  getAccountPerIndustry = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AccountPerIndustryDto[]>({
      method: 'GET',
      url: '/api/app/analytics/account-per-industry',
    },
    { apiName: this.apiName,...config });
  

  getAccountPerType = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AccountPerTypeDto[]>({
      method: 'GET',
      url: '/api/app/analytics/account-per-type',
    },
    { apiName: this.apiName,...config });
  

  getDashboard = (ct?: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DashboardDto>({
      method: 'GET',
      url: '/api/app/analytics/dashboard',
    },
    { apiName: this.apiName,...config });
  

  getIncome = (ct?: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncomeDto>({
      method: 'GET',
      url: '/api/app/analytics/income',
    },
    { apiName: this.apiName,...config });
  

  getLeadsPerSource = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, LeadsPerSourceDto[]>({
      method: 'GET',
      url: '/api/app/analytics/leads-per-source',
    },
    { apiName: this.apiName,...config });
}