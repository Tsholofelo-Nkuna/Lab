using Lab.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Interfaces.Json
{
    public interface IRequisitionRepository : IJsonRepository<RequisitionEntity, int>
    {
    }
}
