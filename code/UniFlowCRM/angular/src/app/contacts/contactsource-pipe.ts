import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'contactsourcepipe',
})
export class ContactsourcePipe implements PipeTransform {

  transform(value: number): string {
    return `::Contact:Source:${value}`;
  }

}
