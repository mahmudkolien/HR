import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl } from '@angular/forms';

@Directive({
  // tslint:disable-next-line: directive-selector
  selector: '[validateEqual]',
  providers: [{
        provide: NG_VALIDATORS,
        useExisting: EqualValidatorDirective,
        multi: true,
    }],
})
export class EqualValidatorDirective implements Validator {

  constructor() { }

  @Input() validateEqual: string;

  validate(control: AbstractControl): {[key: string]: any} | null {

    const controlToCompare = control.parent.get(this.validateEqual);

    if (controlToCompare && controlToCompare !== control.value) {
      return {'validateEqual': true};
    }

    return null;

  }

}
