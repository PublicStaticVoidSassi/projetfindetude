import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'leadsourcepipe',
})
export class LeadsourcePipe implements PipeTransform {

  transform(value: number): string {
    return `::Lead:Source:${value}`;
  }

}
