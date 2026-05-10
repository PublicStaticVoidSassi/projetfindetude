import { Pipe, PipeTransform } from '@angular/core';
import {Accounts as acc} from '../proxy';
@Pipe({
  name: 'accountIndustryPipe',
})
export class AccountIndustryPipe implements PipeTransform {

  transform(value: number): string {
    return `::Accounts:Industry:${value}`;
  }

}
