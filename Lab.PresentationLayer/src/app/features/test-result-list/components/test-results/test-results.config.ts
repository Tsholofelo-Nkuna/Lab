import { FormInputConfig } from "../../../../shared/components/form-input/form-input.config";
import { TableColumnConfig, TableConfig } from "../../../../shared/components/table/table.config";
import { TestResultDto } from "../../../../shared/models/test-result.dto";

export class TestResultsConfig{

  testResultsTableConfig = new TableConfig<TestResultDto>([]);
  newTestResultFormConfig: FormInputConfig<TestResultDto, any>[] = [
    new FormInputConfig<TestResultDto, any>("testId", [], "select", "Test", undefined),
    new FormInputConfig<TestResultDto, any>("result", [], "text", "Result", undefined),
    new FormInputConfig<TestResultDto, any>("comment", [], "text", "Comment", undefined)
  ]
  constructor(){
    this.testResultsTableConfig.columnConfigurations = [
      new TableColumnConfig("testDescription", null, "Test"),
      new TableColumnConfig("result", undefined, "Result"),
      new TableColumnConfig("comment", undefined, "Comment"),
      
    ]
  }

  showNewTestResultModal = false;
}
