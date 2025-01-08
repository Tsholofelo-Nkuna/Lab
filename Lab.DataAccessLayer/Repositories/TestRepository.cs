﻿using Lab.DataAccessLayer.Entities;
using Lab.DataAccessLayer.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Repositories
{
    public class TestRepository : JsonRepository<TestEntity>, ITestRepository
    {
        public TestRepository(IOptions<JsonRepositoryOptions<TestEntity>> options) : base(options)
        {
        }
    }
}
