import { Component, inject, OnInit } from '@angular/core';
import { TestResultsConfig } from './test-results.config';
import { ConfigurationService } from '../../../../shared/services/configuration.service';
import { HttpClient } from '@angular/common/http';
import { ResponseDto } from '../../../../shared/models/response.dto';
import { TestDto } from '../../../../shared/models/test.dto';
import { TestResultDto } from '../../../../shared/models/test-result.dto';

@Component({
  selector: 'app-test-results',
  templateUrl: './test-results.component.html',
  styleUrl: './test-results.component.css'
})
export class TestResultsComponent implements OnInit {
  configurationService = inject(ConfigurationService);
  httpClient = inject(HttpClient);
  config = new TestResultsConfig();
  ngOnInit(): void {
      this.getData();
  }
 
  getData(){
    this.httpClient
    .get<ResponseDto<TestDto[]>>(`${this.configurationService.apiBaseUrl}/api/tests`)
    .subscribe(response => {
      let testDropList = this.config.newTestResultFormConfig.filter(fConfig => fConfig.key === "testId" && fConfig.controlType === "select");
      if(testDropList.length > 0){
        let testDrop = testDropList[0];
        testDrop.options = response.data?.map(c => ({key: c.testId.toString(), value: c.description})) ?? []
      }
    });

      this.httpClient
     .get<ResponseDto<TestResultDto[]>>(`${this.configurationService.apiBaseUrl}/api/testresults`)
     .subscribe(response => {
       var dataSet = response.data ?? [];
       this.config.testResultsTableConfig.data = dataSet;
     });
  }
  public onCreateNewTestResult(){
     let testIdFConfig = this.config.newTestResultFormConfig.filter(fConfig => fConfig.key === "testId")?.[0]
     testIdFConfig.value = Number(testIdFConfig.value);
     let submitted : Partial<TestResultDto> = this.config.newTestResultFormConfig
     .reduce((carry, next) => ({...carry, [next.key]: next.value}), {});
     this.httpClient.post<ResponseDto<TestResultDto>>(`${this.configurationService.apiBaseUrl}/api/testResults`, submitted)
     .subscribe(response  => {
        if(!!response.data?.id){
          alert("Saved");
          this.config.showNewTestResultModal = false;
          this.config.newTestResultFormConfig.forEach(fConfig => {
            fConfig.value = undefined;
          });
          this.getData();
        }
        else{
          alert("Save Failed")
        }
     });
  }
}
