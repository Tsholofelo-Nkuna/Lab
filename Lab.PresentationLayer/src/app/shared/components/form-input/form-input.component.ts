import { Component, Input } from '@angular/core';
import { FormInputConfig } from './form-input.config';

@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
  styleUrl: './form-input.component.css'
})
export class FormInputComponent<TRecord> {
  @Input({required: true})
  config? : FormInputConfig<TRecord, any>
}
