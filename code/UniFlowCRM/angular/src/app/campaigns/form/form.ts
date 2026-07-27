import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { CampaignService, CampaignStatus, campaignStatusOptions } from '../../proxy/campaigns';
import { Currency, currencyOptions } from '../../proxy/moneys';
import { LocalizationPipe } from '@abp/ng.core';
import { UsersLookup } from '../../shared/lookup-components';
import { ToasterService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-form',
  imports: [
    ReactiveFormsModule,
    LocalizationPipe,
    UsersLookup
  ],
  templateUrl: './form.html',
  styleUrl: './form.scss',
})
export class Form implements OnInit{
  readonly fb = inject(FormBuilder);
  readonly toaster = inject(ToasterService);
  readonly campagneService = inject(CampaignService);

  statuses = campaignStatusOptions;
  currencies = currencyOptions;

  form = this.fb.group({
    name: ['', Validators.required],
    description: [''],
    status: [CampaignStatus.planned, Validators.required],

    budgetValue: [0],
    budgetCurrency: [Currency.DZD ],

    costSoFarValue: [0],
    costSoFarCurrency: [Currency.DZD ],

    expectedAccounts: [0],
    expectedLeads: [0],
    expectedContacts: [0],
    expectedOpportunities: [0],

    startDate: [null,Validators.required],
    endDate: [null,Validators.required],

    assignedTo: [null,Validators.required]
  });


  ngOnInit(): void {
    return
  }

  submit() {
    console.log(this.form.value);
    // check same currency
    if (this.form.get("budgetCurrency")?.value != this.form.get("costSoFarCurrency")?.value){
      this.toaster.error("Les devises de la budget et le cout doivent ètre les mème");
      return;
    }
    if (this.form.get("budgetValue")?.value < 0 || this.form.get("costSoFarValue")?.value < 0){
      this.toaster.error("Les montants de la budget et du cout doivent ètre toujours positive");
      return;

    }
    if (
      this.form.get("expectedAccounts")?.value < 0 ||
      this.form.get("expectedLeads")?.value < 0 ||
      this.form.get("expectedContacts")?.value < 0 ||
      this.form.get("expectedOpportunities")?.value < 0
    ){
      this.toaster.error("toutes les attentes doivent ètre positive");
      return;

    }
    this.campagneService.create(this.form.value).subscribe(r=>{
      if (r.id!=null){
        this.toaster.success("le campagne a été crée avec succés");
      }
    });
  }
}
