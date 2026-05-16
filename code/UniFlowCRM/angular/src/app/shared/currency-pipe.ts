import { inject, Pipe, PipeTransform } from '@angular/core';
import { Moneys } from '../proxy';
import {CurrencyPipe as originalCurrencyPipe} from '@angular/common';

@Pipe({
  name: 'mycurrency',
  standalone: true,
})
export class myCurrencyPipe implements PipeTransform {

  transform(value: number, symbol: number): string {
    return `${value} ${Moneys.Currency[symbol]}`;
  }

}
