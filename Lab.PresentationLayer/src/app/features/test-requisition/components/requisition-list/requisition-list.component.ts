import { AfterViewInit, ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { TableConfig } from '../../../../shared/components/table/table.config';
import { RequisitionDto } from '../../../../shared/models/requisition.dto';
import { RequisitionListConfig } from './requisition-list.config';
import { FormBuilder, FormControl, FormGroup, NgForm } from '@angular/forms';
import { ConfigurationService } from '../../../../shared/services/configuration.service';
import { HttpClient } from '@angular/common/http';
import { ResponseDto } from '../../../../shared/models/response.dto';
import { TestDto } from '../../../../shared/models/test.dto';

@Component({
  selector: 'app-requisition-list',
  templateUrl: './requisition-list.component.html',
  styleUrl: './requisition-list.component.css'
})
export class RequisitionListComponent implements OnInit{
    config = new RequisitionListConfig();
    requisitionTableConfig?: TableConfig<Partial<RequisitionDto>>;
    configService = inject(ConfigurationService);
    httpClient = inject(HttpClient);
    newReqForm? : any
    constructor(){
   
    }
   

    ngOnInit(){
      this.getData();
    }

    getData(){
       this.requisitionTableConfig = this.config.tableConfig;
       this.httpClient
      .get<ResponseDto<RequisitionDto[]>>(`${this.configService.apiBaseUrl}/api/TestRequisitions`)
      .subscribe(response => {
         let data =  <Partial<RequisitionDto>[]>(response.data ?? []);
         if(!!this.requisitionTableConfig){
           this.requisitionTableConfig.data = data;
         }
      });

        this.httpClient
      .get<ResponseDto<TestDto[]>>(`${this.configService.apiBaseUrl}/api/Tests`)
      .subscribe(response => {
         let data =  <Partial<TestDto>[]>(response.data ?? []);
         var testDropList = this.config.newRequistionFormConfig.filter(inputConfig => inputConfig.controlType === "select" && inputConfig.key === "requestedTestId");

         if(testDropList.length > 0){
           testDropList[0].options = data.map(test => ({key: test.id!.toString(), value: test.description ?? ""}));
          
         }
      });
    
    }
    onCreateNewRequisition(){
    // this.config.newRequistionFormConfig[0].validators[0].
      var submittedRecord = this.config.newRequistionFormConfig.reduce((carry, next)=> ({...carry,[next.key]:next.value}),<Partial<RequisitionDto>>{});
      submittedRecord.requestedTestIdentifiers  = submittedRecord.requestedTestIdentifiers ?? [];
      if(!isNaN(Number(submittedRecord.requestedTestId))){
        submittedRecord.requestedTestIdentifiers.push(Number(submittedRecord.requestedTestId));
      }
      this.httpClient
      .post<ResponseDto<RequisitionDto>>(`${this.configService.apiBaseUrl}/api/TestRequisitions`, submittedRecord)
      .subscribe(response => {
        if(!!response.data?.id){
          alert("Saved")
          this.config.showNewRequisitionModal = false;
          this.config.newRequistionFormConfig.forEach(x => x.value = undefined);
          this.getData();
        }
        else{
          alert("Save Failed");
        }
      });
    }
}
