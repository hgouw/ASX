using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ASX.BusinessLayer;

namespace ASX.DataAccess
{
    public class ASXDbContext : DbContext
    {
        public DbSet<IndustryGroup> IndustryGroups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EndOfDay> EndOfDays { get; set; }
    }
}