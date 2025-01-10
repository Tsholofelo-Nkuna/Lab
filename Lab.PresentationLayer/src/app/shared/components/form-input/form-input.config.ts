import { ValidatorFn } from "@angular/forms";

export class FormInputConfig<TRecord, TValue>{
  options: Array<{key:string; value:string}> = [];
  constructor(
    public key: keyof(TRecord),
    public validators: Array<ValidatorFn>,
    public controlType:"text"|"select"|"date",
    public label: string,
    public value: TValue,
    options?:Array<{key:string; value:string}>
   ){
     this.options = options ?? this.options;
  }
}
