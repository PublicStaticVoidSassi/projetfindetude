import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'opportunitystagepipe',
})
export class OpportunityStagePipe implements PipeTransform {

  transform(value: number): string {
    return `::Opportunity:Stage:${value}`;
  }

}
