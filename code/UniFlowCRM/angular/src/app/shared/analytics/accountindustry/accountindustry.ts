import { LocalizationService } from '@abp/ng.core';
import { Component, inject, OnInit } from '@angular/core';
import { ChartModule } from 'primeng/chart';
import { AnalyticsService } from 'src/app/proxy/analytics';


@Component({
  selector: 'app-accountindustry',
  imports: [ChartModule],
  template: `
    <div class="card shadow p-2">
    <p-chart
    type="doughnut"
    [data]="data"
    [options]="options"
    height="500">
    </p-chart></div>
    `
})
export class Accountindustry implements OnInit {
data: any;
options: any;
private readonly analyticsService = inject(AnalyticsService);
private readonly l = inject(LocalizationService);

async ngOnInit() {
  const result = await this.analyticsService.getAccountPerIndustry().toPromise() || [{}];


        this.data = {
            labels: result.map(x => this.l.instant("::Account:Industry:"+x.industry)),
            datasets: [
                {
                    data: result.map(x => x.count),
                    backgroundColor:  result.map((_, i) => `hsl(${(i * 250) / result.length}, 80%, 70%)`),
                    // borderColor: getComputedStyle(document.documentElement).getPropertyValue('--lpx-brand'),
                    borderWidth: 2,
                    borderRadius: 0
                }
            ]
        };

       this.options = {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: {
        display: true,
        position: "right"
    },
            title: {
                display: true,
                text: 'Comptes Par Secteur'
            }
        }
       
    };
    };


}
