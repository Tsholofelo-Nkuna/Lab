using Lab.DataAccessLayer.Entities;
using Lab.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Interfaces
{
    public interface ITestRepository: IJsonRepository<TestEntity, int>
    {
    }
}
