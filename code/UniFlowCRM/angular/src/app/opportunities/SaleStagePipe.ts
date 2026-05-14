import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'salestagepipe',
})
export class SaleStagePipe implements PipeTransform {

  transform(value: number): string {
    return `::Opportunity:SaleStage:${value}`;
  }

}
