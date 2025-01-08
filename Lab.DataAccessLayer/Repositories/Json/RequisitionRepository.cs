using Lab.DataAccessLayer.Entities;
using Lab.DataAccessLayer.Interfaces.Json;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Repositories.Json
{
    public class RequisitionRepository : JsonRepository<RequisitionEntity>, IRequisitionRepository
    {
        public RequisitionRepository(IOptions<JsonRepositoryOptions<RequisitionEntity>> options) : base(options)
        {
        }
    }
}
