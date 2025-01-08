using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer.Entities.Base
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public virtual bool Validate()
        {
            return true;
        }
    }
}
