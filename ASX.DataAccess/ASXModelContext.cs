using System.Data.Entity;
using ASX.BusinessLayer;

namespace ASX.DataAccess
{
    public class ASXModelContext : DbContext
    {
        public DbSet<IndustryGroup> IndustryGroups { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<History> Historys { get; set; }
    }
}