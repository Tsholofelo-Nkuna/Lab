import { Validators } from "@angular/forms";
import { FormInputConfig } from "../../../../shared/components/form-input/form-input.config";
import { TableColumnConfig, TableConfig } from "../../../../shared/components/table/table.config";
import { RequisitionDto } from "../../../../shared/models/requisition.dto";

export class RequisitionListConfig{
 tableConfig =  new TableConfig<Partial<RequisitionDto>>([
   new TableColumnConfig("firstName", "", "First Name"),
   new TableColumnConfig("surname", "", "Surname"),
   new TableColumnConfig("gender","U","Gender"),
   new TableColumnConfig("mobileNumber","U","Mobile No."),
   new TableColumnConfig("timeSampleTaken",null,"Time Sample Taken")
 ])
 showNewRequisitionModal = false;
 newRequistionFormConfig: Array<FormInputConfig<RequisitionDto, any>> = [
   new FormInputConfig("firstName", [], "text", "First Name", ""),
   new FormInputConfig("surname", [], "text", "Surname",""),
   new FormInputConfig("gender", [], "select", "Gender","U", [{key:"U", value:"U"}, {key:"F", value:"F"}, {key:"M", value:"M"}]),
   new FormInputConfig("mobileNumber", [], "text", "Mobile No.", ""),
   new FormInputConfig("timeSampleTaken",[], "date", "Time Sample Taken", null)
 ]
}
