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
        public DbSet<WatchList> WatchLists { get; set; }

        public static IList<IndustryGroup> GetIndustryGroups()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.IndustryGroups.ToList();
            }
        }

        public static IList<Company> GetCompanies()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.Companies.ToList();
            }
        }

        public static IList<EndOfDay> GetEndOfDays()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.EndOfDays.ToList();
            }
        }

        public static IList<WatchList> GetWatchLists()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.WatchLists.ToList();
            }
        }
    }
}