using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ASX.BusinessLayer;

namespace ASX.DataAccess
{
    public class ASXDbContext : DbContext
    {
        public ASXDbContext()
        {
            this.Configuration.ProxyCreationEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["LazyLoadingEnabled"]);
        }

        public DbSet<IndustryGroup> IndustryGroups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<EndOfDay> EndOfDays { get; set; }

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

        public static IList<WatchList> GetWatchLists()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.WatchLists.ToList();
            }
        }

        public static IList<EndOfDay> GetEndOfDays()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return dbContext.EndOfDays.ToList();
            }
        }

        public static async Task<IList<IndustryGroup>> GetIndustryGroupsAsync()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return await dbContext.IndustryGroups.ToListAsync();
            }
        }

        public static async Task<IList<Company>> GetCompaniesAsync()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return await dbContext.Companies.ToListAsync();
            }
        }

        public static async Task<IList<WatchList>> GetWatchListsAsync()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return await dbContext.WatchLists.ToListAsync();
            }
        }

        public static async Task<IList<EndOfDay>> GetEndOfDaysAsync()
        {
            using (ASXDbContext dbContext = new ASXDbContext())
            {
                return await dbContext.EndOfDays.ToListAsync();
            }
        }
    }
}