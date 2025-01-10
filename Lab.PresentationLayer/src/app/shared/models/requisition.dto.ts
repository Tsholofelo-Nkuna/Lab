import { DtoBase } from "./dto-base.dto";
import { TestDto } from "./test.dto";

export class RequisitionDto extends DtoBase<number>{
        requisitionId:string = "";
        timeSampleTaken?:Date;
        firstName = "";
        surname ="";
        gender : "M"|"F"|"U" = "U";
        dateOfBirth?:Date;
        age = 0
        mobileNumber = "";
        requestedTestIdentifiers: Array<number> = [];
        requestedTests : Array<TestDto> = [];
}
