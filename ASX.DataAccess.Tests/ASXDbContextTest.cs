using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASX.DataAccess;

namespace ASX.DataAccess.Tests
{
    [TestClass()]
    public class ASXDbContextTest
    {
        [TestMethod()]
        public void GetIndustryGroupsTest()
        {
            var industryGroups = ASXDbContext.GetIndustryGroups();
            Assert.IsTrue(industryGroups.Count > 0);
        }

        [TestMethod()]
        public void GetCompaniesTest()
        {
            var companies = ASXDbContext.GetCompanies();
            Assert.IsTrue(companies.Count > 0);
        }

        [TestMethod()]
        public void GetEndOfDaysTest()
        {
            var endOfDays = ASXDbContext.GetEndOfDays();
            Assert.IsTrue(endOfDays.Count == 0);
        }
    }
}