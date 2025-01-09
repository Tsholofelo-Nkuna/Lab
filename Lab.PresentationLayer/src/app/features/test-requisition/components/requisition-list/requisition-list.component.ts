import { Component, OnInit } from '@angular/core';
import { TableConfig } from '../../../../shared/components/table/table.config';
import { RequisitionDto } from '../../../../shared/models/requisition.dto';
import { RequisitionListConfig } from './requisition-list.config';

@Component({
  selector: 'app-requisition-list',
  templateUrl: './requisition-list.component.html',
  styleUrl: './requisition-list.component.css'
})
export class RequisitionListComponent implements OnInit{
  config = new RequisitionListConfig();
  requisitionTableConfig: TableConfig<Partial<RequisitionDto>>;
  constructor(){
    this.requisitionTableConfig = this.config.tableConfig;
  }

  ngOnInit(){
    this.requisitionTableConfig.data = [
      {age:0, firstName:"Tsholofelo",gender:"U", TimeSampleTaken: new Date(),surname: "nkuna", mobileNumber:"762592125"}
    ]
  }
}
