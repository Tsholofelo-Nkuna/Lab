import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestResultsComponent } from './components/test-results/test-results.component';
import { SharedModule } from '../../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';


let routes: Routes = [
  {
    path: "",
    component: TestResultsComponent
  }
]

@NgModule({
  declarations: [
    TestResultsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports:[
    TestResultsComponent
  ]
})
export class TestResultListModule { }
