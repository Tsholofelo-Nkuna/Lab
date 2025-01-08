using Lab.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Entities
{
    public class RequisitionEntity : BaseEntity<int>
    {
        public string RequisitionId => $"{base.Id}:D4";
        public DateTime? TimeSampleTaken { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                if (DateOfBirth.HasValue)
                {
                    var today = DateTime.Today;
                    var age = today.Year - DateOfBirth.Value.Year;
                    if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;
                    return age;
                }
                else
                {
                    return 0;
                }
            }
        }
        public string MobileNumber {  get; set; } = string.Empty ;
        public IEnumerable<int> RequestedTestIdentifiers { get; set; } = Enumerable.Empty<int>();
    }
}
