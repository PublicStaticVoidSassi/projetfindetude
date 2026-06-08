import { Component, inject, OnInit } from '@angular/core';
import { AuthService, LocalizationPipe } from '@abp/ng.core';
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
  documentStyle = getComputedStyle(document.documentElement);
  data : any = {}
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




  analytics : AnalyticsDto = {};
  ngOnInit() {
    this.loadAnalytics();

  }
  loadLead(){
    this.data = {
      labels: [
         '::Lead:Converted', '::Lead:NotConvert'],
      datasets: [
        {
          data: [
            this.analytics.lead.converted,
            this.analytics.lead.total - this.analytics.lead.converted],
          backgroundColor: [
            this.documentStyle.getPropertyValue('--bs-pink'),
            this.documentStyle.getPropertyValue('--lpx-brand')
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
    })
  }
}
