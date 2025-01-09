import { DtoBase } from "./dto-base.dto";

export class TestDto extends DtoBase<number>{
   testId = 0;
   mnemonic ="";
   description ="";
   isActive = false;
}
