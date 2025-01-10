import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
 {
   path:"requisitions",
   loadChildren: () => import("./features/test-requisition/test-requisition.module").then( m => m.TestRequisitionModule)
 },
 {
   path:"results",
   loadChildren: () => import("./features/test-result-list/test-result-list.module").then(m => m.TestResultListModule)
 }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
