import { Component, Input, input } from '@angular/core';
import { TableColumnConfig, TableConfig } from './table.config';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent<TRecord> {
  @Input({required: true}) tableConfiguration = new TableConfig<TRecord>([]);
}
