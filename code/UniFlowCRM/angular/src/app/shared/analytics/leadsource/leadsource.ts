import { LocalizationService } from '@abp/ng.core';
import { Component, OnInit,inject } from '@angular/core';
import { ChartModule } from 'primeng/chart';
import { AnalyticsService } from 'src/app/proxy/analytics';

@Component({
  selector: 'app-leadsource',
  imports: [ChartModule],
  template: `
  <div class="card shadow p-2">
    <p-chart
    type="bar"
    [data]="data"
    [options]="options"
    height="500">
    </p-chart></div>
    `
})
export class Leadsource implements OnInit{
private readonly analyticsService = inject(AnalyticsService);
private readonly l = inject(LocalizationService);
data: any;
options: any;

async ngOnInit() {
  const result = await this.analyticsService.getLeadsPerSource().toPromise() || [{}];


        this.data = {
            labels: result.map(x => this.l.instant("::Lead:Source:"+x.source)),
            datasets: [
                {
                    data: result.map(x => x.count),
                    backgroundColor: getComputedStyle(document.documentElement).getPropertyValue('--bs-primary-bg-subtle'),
                    borderColor: getComputedStyle(document.documentElement).getPropertyValue('--bs-primary'),
                    borderWidth: 5,
                    borderRadius: 6
                }
            ]
        };

       this.options = {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: {
        display: false
    },
            title: {
                display: true,
                text: 'Prospects par source'
            }
        },
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    precision: 0
                }
            }
        }
    };
    };

}
