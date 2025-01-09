export class TableConfig<TRecord>{
  columnConfigurations: Array<TableColumnConfig<keyof(TRecord), object>>;
  constructor(colConfig: Array<TableColumnConfig<keyof(TRecord), object>>){
    this.columnConfigurations = colConfig;
    
  }

  getValue<TValue>(record: TRecord,key: keyof(TRecord)) : TValue{
    return <TValue>(record[key]);
  }
}

export class TableColumnConfig<TKey, TValue>{
  constructor(public key: TKey, value: TValue, label: string){}

}
