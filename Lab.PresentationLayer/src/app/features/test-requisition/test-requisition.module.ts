import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RequisitionListComponent } from './components/requisition-list/requisition-list.component';
import { SharedModule } from '../../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';

let route: Routes = [
  {
    path:"",
    component: RequisitionListComponent,
    children:[
     
    ]
  }
]

@NgModule({
  declarations: [
    RequisitionListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(route)
  ]
})
export class TestRequisitionModule { }
