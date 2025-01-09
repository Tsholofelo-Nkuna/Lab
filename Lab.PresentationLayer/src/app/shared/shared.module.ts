import { CommonModule, DatePipe } from "@angular/common";
import { NgModule } from "@angular/core";
import { TableComponent } from "./components/table/table.component";
import { TableConfig } from "./components/table/table.config";
import { ModalComponent } from './components/modal/modal.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
  imports: [
  CommonModule,
  FormsModule,
  ReactiveFormsModule
  ],
  declarations: [
    TableComponent,
    ModalComponent
  ],
  exports:[
    TableComponent,
    ModalComponent
  ],
  providers:[
    DatePipe
  ]
})
export class SharedModule{

}
