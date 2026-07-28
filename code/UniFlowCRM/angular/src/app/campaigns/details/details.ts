import { Component, inject, OnInit } from '@angular/core';
import { LocalizationPipe, RoutesService } from '@abp/ng.core';
import { ActivatedRoute } from '@angular/router';
import { CampaignDto, CampaignService, CampaignStatus } from '../../proxy/campaigns';
import { DatePipe, DecimalPipe } from '@angular/common';
import {Currency} from '../../proxy/moneys/currency.enum'
import { ToasterService } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-details',
  imports: [
    DatePipe,
    DecimalPipe,
    LocalizationPipe
  ],
  templateUrl: './details.html',
  styleUrl: './details.scss',
})
export class Details implements OnInit {
  Currency = Currency;
  readonly route = inject(ActivatedRoute);
  readonly campaignService = inject(CampaignService);
  campaign: CampaignDto = {};
  today= new Date();
  toaster = inject(ToasterService);
  load(){
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.campaignService.get(id).subscribe((data) => this.campaign = data);
    }
  }
  ngOnInit() {
    this.load()
  }

  protected readonly CampaignStatus = CampaignStatus;

  protected activate() {
    this.campaignService.activate(this.campaign.id).subscribe(r=>{
      if (r){
        this.toaster.success("le campagne à été activé");
      }else{
        this.toaster.error("échèc d'activation");
      }
      this.load()
    })
  }
  protected deactivate() {
    this.campaignService.deactivate(this.campaign.id).subscribe(r=>{
      if (r){
        this.toaster.success("le campagne à été disactivé");
      }else{
        this.toaster.error("échèc de disactivation");
      }
      this.load()
    })
  }
}
