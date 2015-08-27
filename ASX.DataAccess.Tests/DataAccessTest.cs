﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASX.DataAccess;

namespace ASX.DataAccess.Tests
{
    [TestClass()]
    public class DataAccessTest
    {
      
        [TestMethod()]
        public void GetIndustryGroupsTest()
        {
            var industryGroups = DataAccess.GetIndustryGroups();
            Assert.IsTrue(industryGroups.Count == 26);
        }

        [TestMethod()]
        public void GetCompaniesTest()
        {
            var companies = DataAccess.GetCompanies();
            Assert.IsTrue(companies.Count == 2171);
        }

        [TestMethod()]
        public void GetEndOfDaysTest()
        {
            var endOfDays = DataAccess.GetEndOfDays();
            Assert.IsTrue(endOfDays.Count == 0);
        }

        [TestMethod()]
        public void GetWatchListsTest()
        {
            var watchLists = DataAccess.GetWatchLists();
            Assert.IsTrue(watchLists.Count == 42);
        }
    }
}