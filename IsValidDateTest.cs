using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAD;
using SAD.Business_Layer;
using System.Collections.Generic;

namespace LawGetMatchedConditionTest
{
    [TestClass]
    public class IsValidDateTest
    {
        [TestMethod]
        public void CheckIsValidDate_startDateBoundary() //boundary issuance date of statement
        {
            DateTime StartDate = new DateTime(2015, 1, 18);
            DateTime FinishDate = new DateTime(2016, 1, 18);
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            //stub
            bool expected = true;
            //drivers
            Law lawTest = new Law(StartDate, FinishDate, double.MinValue, double.MaxValue, int.MinValue
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded );
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 0, "", "");
            Assert.AreEqual(lawTest.IsValidDate(statement), expected, "boundary limit isn't correctly coded!");
            
        }
        [TestMethod]
        public void CheckIsValidDate_finishDateBoundary() //boundary issuance date of statement
        {
            DateTime StartDate = new DateTime(2015, 1, 18);
            DateTime FinishDate = new DateTime(2016, 1, 18);
            DateTime issuanceDate = new DateTime(2016, 1, 18);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            //stub
            bool expected = false;
            //drivers
            Law lawTest = new Law(StartDate, FinishDate, double.MinValue, double.MaxValue, int.MinValue
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 0, "", "");
            Assert.AreEqual(lawTest.IsValidDate(statement), expected, "boundary limit isn't correctly coded!");

        }
        [TestMethod]
        public void CheckIsValidDate_outOfDate() //boundary issuance date of statement
        {
            DateTime StartDate = new DateTime(2015, 1, 18);
            DateTime FinishDate = new DateTime(2016, 1, 18);
            DateTime issuanceDate = new DateTime(2014, 1, 18);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            bool expected = false;
            //drivers
            Law lawTest = new Law(StartDate, FinishDate, double.MinValue, double.MaxValue, int.MinValue
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 0, "", "");
            Assert.AreEqual(lawTest.IsValidDate(statement), expected, "boundary limit isn't correctly coded!");

        }

    }
}
