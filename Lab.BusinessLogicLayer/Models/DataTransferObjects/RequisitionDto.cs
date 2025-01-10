using Lab.BusinessLogicLayer.Models.DataTransferObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer.Models.DataTransferObjects
{
    public class RequisitionDto : DtoBase<int>
    {
        public string RequisitionId => $"{base.Id:D4}";
        public DateTime? TimeSampleTaken { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public int Age { get;set;}
        public string MobileNumber { get; set; } = string.Empty;
        public IEnumerable<int> RequestedTestIdentifiers { get; set; } = Enumerable.Empty<int>();
        public List<TestDto> RequestedTests { get; set; } = new();
        public string RequestedTestId = string.Empty;
        public string RequestedTestsDescription { get; set; } = string.Empty;
    }
}
