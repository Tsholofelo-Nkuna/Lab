using Lab.BusinessLogicLayer.Models.DataTransferObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer.Models.DataTransferObjects
{
    public class TestResultDto : DtoBase<int>
    {
        public int TestId { get; set; }
        public string Result { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
    }
}
