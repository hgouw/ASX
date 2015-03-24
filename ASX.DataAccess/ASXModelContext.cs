using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX.DataAccess
{
    public class ASXModelContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<History> Historys { get; set; }
    }
}