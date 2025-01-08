using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccessLayer
{
    public class JsonRepositoryOptions<TEntity>
    {
        public string FilePath { get; set; } = string.Empty;
        public List<TEntity>? SeedData { get; set; };

    }
}
