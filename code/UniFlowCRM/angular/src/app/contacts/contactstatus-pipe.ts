import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'contactstatuspipe',
})
export class ContactstatusPipe implements PipeTransform {

  transform(value: number): string {
    return `::Contact:Status:${value}`;
  }

}
