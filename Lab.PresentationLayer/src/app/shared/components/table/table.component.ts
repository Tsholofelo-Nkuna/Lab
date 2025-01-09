import { Component, Input } from '@angular/core';
import { TableConfig } from './table.config';
import { DatePipe } from '@angular/common';
import { inject } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent<TRecord> {
  @Input({required: true}) tableConfiguration = new TableConfig<TRecord>([]);
  private _datePipe = inject(DatePipe)

  display(record: TRecord,key: keyof(TRecord)): string{
    if(record[key] instanceof Date){
      return (this._datePipe.transform(<Date>record[key],"dd-MMM-yyyy hh:mm a")?? "");
    }
    else{
     return record[key]?.toString() ?? "";
    }
  }
}
