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

        public static List<IndustryGroup> GetIndustryGroups()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.IndustryGroups.ToList();
            }
        }

        public static List<Company> GetCompanies()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.Companies.ToList();
            }
        }

        public static List<EndOfDay> GetEndOfDays()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.EndOfDays.ToList();
            }
        }
    }
}