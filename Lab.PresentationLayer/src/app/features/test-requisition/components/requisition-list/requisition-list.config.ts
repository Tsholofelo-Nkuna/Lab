import { TableColumnConfig, TableConfig } from "../../../../shared/components/table/table.config";
import { RequisitionDto } from "../../../../shared/models/requisition.dto";

export class RequisitionListConfig{
 tableConfig =  new TableConfig<Partial<RequisitionDto>>([
   new TableColumnConfig("firstName", "", "First Name"),
   new TableColumnConfig("surname", "", "Surname"),
   new TableColumnConfig("gender","U","Gender"),
   new TableColumnConfig("mobileNumber","U","Mobile No."),
   new TableColumnConfig("TimeSampleTaken",null,"Time Sample Taken")
 ])
 showNewRequisitionModal = false;
}
