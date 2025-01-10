import { AfterViewInit, ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { TableConfig } from '../../../../shared/components/table/table.config';
import { RequisitionDto } from '../../../../shared/models/requisition.dto';
import { RequisitionListConfig } from './requisition-list.config';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ConfigurationService } from '../../../../shared/services/configuration.service';
import { HttpClient } from '@angular/common/http';
import { ResponseDto } from '../../../../shared/models/response.dto';

@Component({
  selector: 'app-requisition-list',
  templateUrl: './requisition-list.component.html',
  styleUrl: './requisition-list.component.css'
})
export class RequisitionListComponent implements OnInit, AfterViewInit{
  config = new RequisitionListConfig();
  requisitionTableConfig?: TableConfig<Partial<RequisitionDto>>;
  configService = inject(ConfigurationService);
  httpClient = inject(HttpClient);
  constructor(){
   
  }
    ngAfterViewInit(): void {
       
    }

  ngOnInit(){
   this.getData();
  }

  getData(){
     this.requisitionTableConfig = this.config.tableConfig;
     this.requisitionTableConfig.data = [
      {age:0, firstName:"Tsholofelo",gender:"U", timeSampleTaken: new Date(),surname: "nkuna", mobileNumber:"762592125"}
    ]
  }
  onCreateNewRequisition(){
    var submittedRecord = this.config.newRequistionFormConfig.reduce((carry, next)=> ({...carry,[next.key]:next.value}), {})
    this.httpClient
    .post<ResponseDto<RequisitionDto>>(`${this.configService.apiBaseUrl}/api/TestRequisitions`, submittedRecord)
    .subscribe(response => {
      if(!!response.data?.id){
        alert("Saved")
      }
      else{
        alert("Save Failed");
      }
    });
  }
}
