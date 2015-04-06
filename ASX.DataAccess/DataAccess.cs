using System.Collections.Generic;
using System.Linq;
using ASX.BusinessLayer;

namespace ASX.DataAccess
{
    public static class DataAccess
    {
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