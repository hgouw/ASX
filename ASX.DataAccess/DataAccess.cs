using System.Collections.Generic;
using System.Linq;
using ASX.BusinessLayer;

namespace ASX.DataAccess
{
    public static class DataAccess
    {
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
    }
}