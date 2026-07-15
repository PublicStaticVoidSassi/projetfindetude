import { Component, inject, OnInit } from '@angular/core';
import { AuthService, LocalizationPipe, ConfigStateService, PermissionDirective } from '@abp/ng.core';
import { ChartModule } from 'primeng/chart';
import { AnalyticsDto, AnalyticsService } from '../proxy/analytics';
import { DashboardDto, IncomeDto } from '../proxy/dashboards/models';
import {Leadsource} from '../shared/analytics/leadsource/leadsource';
import {Accountindustry} from '../shared/analytics/accountindustry/accountindustry';
import {Accounttype} from '../shared/analytics/accounttype/accounttype';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  imports: [ChartModule, LocalizationPipe, Leadsource, Accounttype, Accountindustry, PermissionDirective]
})
export class HomeComponent implements OnInit {
  private authService = inject(AuthService);
  private analyticService = inject(AnalyticsService);
  private configState = inject(ConfigStateService);

  username: string | undefined = "";

  documentStyle = getComputedStyle(document.documentElement);
  leaddata: any = {}
  contactdata: any = {}
  opportunitydata: any = {}

  analytics: AnalyticsDto = {};
  dashboard: DashboardDto = {};
  income: IncomeDto = {};

  basicOptions = {
    plugins: {
      legend: {
        labels: {
          usePointStyle: true,
        }
      }
    }
  };





  ngOnInit() {
    this.loadAnalytics();
    let currentUser = this.configState.getOne('currentUser');
    this.username = currentUser.userName;
    console.log(currentUser);
  }
  loadLead() {
    this.leaddata = {
      labels: [
        'Prospects en attente',
        'Prospects perdus',
        'Prospects convertis'],
      datasets: [
        {
          data: [
            this.dashboard.pendingleads,
            this.dashboard.deadleads,
            this.dashboard.convertedleads
          ],
          backgroundColor: [
            getComputedStyle(document.documentElement).getPropertyValue('--bs-primary-bg-subtle'),
            this.documentStyle.getPropertyValue('--bs-gray'),
            this.documentStyle.getPropertyValue('--bs-primary'),
            ,
          ],
          // hoverBackgroundColor: [documentStyle.getPropertyValue('--p-cyan-400'), documentStyle.getPropertyValue('--p-orange-400'), documentStyle.getPropertyValue('--p-gray-400')]
        }
      ]
    };
  }

  loadContact() {
    this.contactdata = {
      labels: [
        'Contacts actives', 'Contacts inactives'],
      datasets: [
        {
          data: [
            this.dashboard.activecontacts,
            this.dashboard.inactivecontacts],
          backgroundColor: [
            this.documentStyle.getPropertyValue('--bs-success'),
            this.documentStyle.getPropertyValue('--bs-success-bg-subtle')
            ,
          ],
          // hoverBackgroundColor: [documentStyle.getPropertyValue('--p-cyan-400'), documentStyle.getPropertyValue('--p-orange-400'), documentStyle.getPropertyValue('--p-gray-400')]
        }
      ]
    };
  }
  loadOpportunity() {
    this.opportunitydata = {
      labels: [
        'opportunités gagnées',
        'opportunités en attentes',
        'opportunités perdues'],
      datasets: [
        {
          data: [
            this.dashboard.wondeals,
            this.dashboard.pendingdeals,
            this.dashboard.lostdeals,],
          backgroundColor: [
            this.documentStyle.getPropertyValue('--bs-warning'),
            this.documentStyle.getPropertyValue('--bs-warning-bg-subtle'),
            this.documentStyle.getPropertyValue('--bs-gray')
            ,
          ],
          // hoverBackgroundColor: [documentStyle.getPropertyValue('--p-cyan-400'), documentStyle.getPropertyValue('--p-orange-400'), documentStyle.getPropertyValue('--p-gray-400')]
        }
      ]
    };
  }
  loadAnalytics() {
    this.analyticService.getDashboard().subscribe((d) => {
      this.dashboard = d;
    });
    this.analyticService.getIncome().subscribe((d) => {
      this.income = d;
    });
    this.analyticService.get().subscribe((res) => {
      this.analytics = res;
      this.loadLead();
      this.loadContact();
      this.loadOpportunity();
    })
  }
}
