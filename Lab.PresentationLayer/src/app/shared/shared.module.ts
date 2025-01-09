import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { TableComponent } from "./components/table/table.component";
import { TableConfig } from "./components/table/table.config";

@NgModule({
  imports: [
  CommonModule
  ],
  declarations: [
    TableComponent
  ],
  exports:[
    TableComponent
  ]
})
export class SharedModule{

}
