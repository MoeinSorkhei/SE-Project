using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAD;
using SAD.Business_Layer;
using System.Collections.Generic;

namespace LawGetMatchedConditionTest
{
    [TestClass]
    public class IsValidPrerequisites
    {
        [TestMethod]
        public void nullCountryTest()
        {
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015,1,18);
            bool expected = true;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue
                                          , "", "sea", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 20, "sea", "china");
            Assert.AreEqual(lawTest.IsValidPrerequisites(statement), expected, "country is null not correctly checked");
        }
        [TestMethod]
        public void nullKindOfImportTest()
        {
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            bool expected = true;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue
                                          , "china", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 20, "sea", "china");
            Assert.AreEqual(lawTest.IsValidPrerequisites(statement), expected, "kind of import is null not correctly checked!");
        }
        [TestMethod]
        public void CountryEquality()
        {
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue
                                          , "China", "sea", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 20, "sea", "Dutchland");
            Assert.AreEqual(lawTest.IsValidPrerequisites(statement), expected, "Wrong Country Check!");
        }

        [TestMethod]
        public void KindOfImportEquality()
        {
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue
                                          , "Dutchland", "sea", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 20, "earth", "Dutchland");
            Assert.AreEqual(lawTest.IsValidPrerequisites(statement), expected, "Wrong Country Check!");
        }
        [TestMethod]
        public void MinValueCheck()
        {
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            bool expected = false;
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue
                                  , "Dutchland", "sea", 50, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 30, "sea", "Dutchland");
            Assert.AreEqual(lawTest.IsValidPrerequisites(statement), expected, "Wrong whole value Check!");
        }

    }
}
