import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'replaceWith',
})
export class ReplaceWithPipe implements PipeTransform {

  transform(value: string, searchValue: string, replaceValue: string = ' '): string {

    if (!value) {
      return '';
    }
    if (!searchValue) {
      return value;
    }
    if (!replaceValue) {
      replaceValue = ' ';
    }

    // return value.replace(searchValue, replaceValue);
    return value.split(searchValue).join(replaceValue);
  }

}
