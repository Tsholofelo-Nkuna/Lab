using Lab.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Entities
{
    public class TestEntity : BaseEntity<int>
    {
        public int TestId 
        {
            get => base.Id; 
        }

        public string Mnemonic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public bool IsActive { get; set; }
    }
}
