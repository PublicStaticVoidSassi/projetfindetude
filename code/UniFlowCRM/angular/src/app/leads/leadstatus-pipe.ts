import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'leadstatuspipe',
})
export class LeadstatusPipe implements PipeTransform {

  transform(value: number): string {
    return `::Lead:Status:${value}`;
  }

}
