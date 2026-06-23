import { Component, inject, OnInit } from '@angular/core';
import { AuthService, LocalizationPipe,ConfigStateService } from '@abp/ng.core';
import { ChartModule } from 'primeng/chart';
import { AnalyticsDto, AnalyticsService } from '../proxy/analytics';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  imports: [ChartModule,LocalizationPipe]
})
export class HomeComponent implements OnInit {
  private authService = inject(AuthService);
  private analyticService = inject(AnalyticsService);

  private configState = inject(ConfigStateService);
  
  username: string | undefined = "";

  documentStyle = getComputedStyle(document.documentElement);
  leaddata : any = {}
  basicOptions = {
    plugins: {
      legend: {
        labels: {
          usePointStyle: true,
          // color: textColor
        }
      }
    }
  };
contactdata : any = {}
opportunitydata: any = {}




  analytics : AnalyticsDto = {};
  ngOnInit() {
    this.loadAnalytics();
    let currentUser = this.configState.getOne('currentUser');
    this.username = currentUser.userName;
    console.log(currentUser);
  }
  loadLead(){
    if (!this.analytics.lead||!this.analytics.lead.total||!this.analytics.lead.converted){
      return;
    }
    this.leaddata = {
      labels: [
         'Prospects convertis', 'Prospects non convertis'],
      datasets: [
        {
          data: [
            this.analytics.lead.converted,
            this.analytics.lead.total - this.analytics.lead.converted],
          backgroundColor: [
            this.documentStyle.getPropertyValue('--bs-primary'),
            this.documentStyle.getPropertyValue('--bs-primary-bg-subtle')
            ,
          ],
          // hoverBackgroundColor: [documentStyle.getPropertyValue('--p-cyan-400'), documentStyle.getPropertyValue('--p-orange-400'), documentStyle.getPropertyValue('--p-gray-400')]
        }
      ]
    };
  }

  loadContact(){
    if (!this.analytics.contact?.total || !this.analytics.contact?.active)
    {
      return ;
    }
    this.contactdata = {
      labels: [
         'Contacts actives', 'Contacts inactives'],
      datasets: [
        {
          data: [
            this.analytics.contact?.active,
            this.analytics.contact.total - this.analytics.contact.active],
          backgroundColor: [
            this.documentStyle.getPropertyValue('--bs-secondary'),
            this.documentStyle.getPropertyValue('--bs-secondary-bg-subtle')
            ,
          ],
          // hoverBackgroundColor: [documentStyle.getPropertyValue('--p-cyan-400'), documentStyle.getPropertyValue('--p-orange-400'), documentStyle.getPropertyValue('--p-gray-400')]
        }
      ]
    };
  }
loadOpportunity(){
    if (!this.analytics.contact?.total || !this.analytics.contact?.active)
    {
      return ;
    }
    this.opportunitydata = {
      labels: [
         'opportunités gagnées', 'opportunités perdues'],
      datasets: [
        {
          data: [
            this.analytics.opportunity?.won,
            this.analytics.opportunity?.lost],
          backgroundColor: [
            this.documentStyle.getPropertyValue('--bs-warning'),
            this.documentStyle.getPropertyValue('--bs-warning-bg-subtle')
            ,
          ],
          // hoverBackgroundColor: [documentStyle.getPropertyValue('--p-cyan-400'), documentStyle.getPropertyValue('--p-orange-400'), documentStyle.getPropertyValue('--p-gray-400')]
        }
      ]
    };
  }
  loadAnalytics () {
    this.analyticService.get().subscribe((res) => {
      this.analytics = res;
      this.loadLead();
      this.loadContact();
      this.loadOpportunity();
    })
  }
}
