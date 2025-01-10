import { CommonModule, DatePipe } from "@angular/common";
import { NgModule } from "@angular/core";
import { TableComponent } from "./components/table/table.component";
import { TableConfig } from "./components/table/table.config";
import { ModalComponent } from './components/modal/modal.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { FormInputComponent } from './components/form-input/form-input.component';
import { HttpClient, HttpClientModule } from "@angular/common/http";

@NgModule({
  imports: [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
  HttpClientModule
  ],
  declarations: [
    TableComponent,
    ModalComponent,
    FormInputComponent
  ],
  exports:[
    TableComponent,
    ModalComponent,
    FormsModule,
    ReactiveFormsModule,
    FormInputComponent
  ],
  providers:[
    DatePipe,
    HttpClient
  ]
})
export class SharedModule{

}
