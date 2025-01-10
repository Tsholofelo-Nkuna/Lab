import { FormControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export class FormInputConfig<TRecord, TValue>{
  options: Array<{key:string; value:string}> = [];
  constructor(
    public key: keyof(TRecord),
    public validators: Array<ValidatorFn>,
    public controlType:"text"|"select"|"date"|"tel",
    public label: string,
    public value: TValue,
    options?:Array<{key:string; value:string}>
   ){
     this.options = options ?? this.options;
  }

  validate(): ValidationErrors | null{
    let control = new FormControl(this.value);
    var validationResult = this.validators.map(v => v(control))
    var isValid = validationResult.every(x => x == null) || this.validators.length == 0;
    if(!isValid){
      return validationResult[0];
    }
    else{
      return null;
    }
  }
}
