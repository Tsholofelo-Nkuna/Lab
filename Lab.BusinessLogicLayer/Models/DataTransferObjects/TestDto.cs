using Lab.BusinessLogicLayer.Models.DataTransferObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer.Models.DataTransferObjects
{
    public class TestDto : DtoBase<int>
    {
        public int TestId { get; set; }
        public string Mnemonic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
