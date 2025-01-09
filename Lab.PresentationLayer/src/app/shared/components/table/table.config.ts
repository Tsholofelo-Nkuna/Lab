export class TableConfig<TRecord>{
  columnConfigurations: Array<TableColumnConfig<keyof(TRecord), any>>;
  data: Array<TRecord> = [];
  constructor(colConfig: Array<TableColumnConfig<keyof(TRecord), any>>){
    this.columnConfigurations = colConfig;
    
  }

  getValue<TValue>(record: TRecord,key: keyof(TRecord)) : TValue{
    return <TValue>(record[key]);
  }
}

export class TableColumnConfig<TKey, TValue>{
  constructor(public key: TKey, public value: TValue, public label: string){}

}
