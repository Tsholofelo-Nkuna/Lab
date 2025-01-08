using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer.Models.DataTransferObjects.Base
{
    public class DtoBase<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
