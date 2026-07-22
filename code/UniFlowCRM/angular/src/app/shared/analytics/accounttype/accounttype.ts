import { LocalizationService } from '@abp/ng.core';
import { Component, inject, OnInit } from '@angular/core';
import { ChartModule } from 'primeng/chart';
import { AnalyticsService } from 'src/app/proxy/analytics';


@Component({
  selector: 'app-accounttype',
  imports: [ChartModule],
  template: `
    <div class="card kpi-card p-2">
    <p-chart
    type="pie"
    [data]="data"
    [options]="options"
    height="500">
    </p-chart></div>
    `
})
export class Accounttype implements OnInit {
data: any;
options: any;
private readonly analyticsService = inject(AnalyticsService);
private readonly l = inject(LocalizationService);

async ngOnInit() {
  const result = await this.analyticsService.getAccountPerType().toPromise() || [{}];


        this.data = {
            labels: result.map(x => this.l.instant("::Account:Type:"+x.type)),
            datasets: [
                {
                    data: result.map(x => x.count),
                    backgroundColor: result.map((_, i) => `hsl(${(i * 50) / result.length}, 70%, 60%)`),
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
        position:"left"
    },
            title: {
                display: true,
                text: 'Comptes Par Type'
            }
        },
    };
    };


}
