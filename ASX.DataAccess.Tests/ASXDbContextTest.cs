using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASX.DataAccess.Tests
{
    [TestClass()]
    public class ASXDbContextTest
    {     
        [TestMethod()]
        public void GetIndustryGroupsTest()
        {
            var industryGroups = ASXDbContext.GetIndustryGroups();
            Assert.IsTrue(industryGroups.Count == 26);
        }

        [TestMethod()]
        public void GetCompaniesTest()
        {
            var companies = ASXDbContext.GetCompanies();
            Assert.IsTrue(companies.Count == 2175);
        }

        [TestMethod()]
        public void GetEndOfDaysTest()
        {
            var endOfDays = ASXDbContext.GetEndOfDays();
            Assert.IsTrue(endOfDays.Count == 153640);
        }

        [TestMethod()]
        public void GetWatchListsTest()
        {
            var watchLists = ASXDbContext.GetWatchLists();
            Assert.IsTrue(watchLists.Count == 47);
        }
    }
}