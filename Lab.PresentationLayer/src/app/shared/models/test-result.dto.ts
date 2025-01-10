import { DtoBase } from "./dto-base.dto";

export class TestResultDto extends DtoBase<number>{
   testId =0;
   result ="";
   comment ="";
   testDescription = ""
}
