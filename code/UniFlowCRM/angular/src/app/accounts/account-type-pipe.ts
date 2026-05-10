import { Pipe, PipeTransform } from '@angular/core';
import {Accounts as Acc} from '../proxy';
@Pipe({
  name: 'accountTypePipe',
})
export class AccountTypePipe implements PipeTransform {

  transform(value: number): string {
    return `::Accounts:Type:${value}`;
  }

}
