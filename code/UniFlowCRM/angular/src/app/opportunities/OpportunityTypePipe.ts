import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'opportunitytypepipe',
})
export class OpportunityTypePipe implements PipeTransform {

  transform(value: number): string {
    return `::Opportunity:Type:${value}`;
  }

}
