using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SAD;
using SAD.Business_Layer;

namespace LawGetMatchedConditionTest
{
    [TestClass]
    public class IsValidPerMerchandiseTest
    {
        [TestMethod]
        public void check_low_with_a_merchandise_not_in_statement()
        {
            List<string> merchandises = new List<string>();
            merchandises.Add("berenj");
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            //stub
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 0, "", "");
            MerchandiseInStatement mis = new MerchandiseInStatement("gandom", "", 0, 0, 0);
            statement.AddNewMerchandise(mis);
            Assert.AreEqual(lawTest.IsValidPerMerchandise(statement), expected, "low with a merchandise not in Statement isn't correctly coded!");
        }
        [TestMethod]
        public void check_low_with_a_merchandise_with_unvalid_company()
        {
            List<string> merchandises = new List<string>();
            merchandises.Add("berenj");
            List<string> companies = new List<string>();
            companies.Add("golestan");
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            //stub
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, 200 , 5000 , 200
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 1000000, "", "");
            MerchandiseInStatement mis = new MerchandiseInStatement("berenj", "tabarok" , 0 , 1000, 1000);
            statement.AddNewMerchandise(mis);
            Assert.AreEqual(lawTest.IsValidPerMerchandise(statement), expected, "low with a merchandise with unvalid company isn't correctly coded!");

        }
        [TestMethod]
        public void check_low_with_a_merchandise_with_unvalid_count()
        {
            List<string> merchandises = new List<string>();
            merchandises.Add("berenj");
            List<string> companies = new List<string>();
            companies.Add("tabarok");
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            //stub
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, 200, 5000, 2000
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 1000000, "", "");
            MerchandiseInStatement mis = new MerchandiseInStatement("berenj", "tabarok", 0, 1000, 1000);
            statement.AddNewMerchandise(mis);
            Assert.AreEqual(lawTest.IsValidPerMerchandise(statement), expected, "low with a merchandise with unvaid count isn't correctly coded!");

        }
        [TestMethod]
        public void check_low_with_a_merchandise_with_unvalid_price()
        {
            List<string> merchandises = new List<string>();
            merchandises.Add("berenj");
            List<string> companies = new List<string>();
            companies.Add("tabarok");
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            //stub
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, 200, 5000, 200
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 6000000, "", "");
            MerchandiseInStatement mis = new MerchandiseInStatement("berenj", "tabarok", 0, 1000, 6000);
            statement.AddNewMerchandise(mis);
            Assert.AreEqual(lawTest.IsValidPerMerchandise(statement), expected, "low with a merchandise with unvalid price isn't correctly coded!");

        }
        [TestMethod]
        public void check_low_with_a_valid_merchandise_in_statement()
        {
            List<string> merchandises = new List<string>();
            merchandises.Add("berenj");
            List<string> companies = new List<string>();
            companies.Add("tabarok");
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            //stub
            bool expected = true;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, 200, 5000, 200
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 1000000 , "", "");
            MerchandiseInStatement mis = new MerchandiseInStatement("berenj", "tabarok", 0, 1000, 1000);
            statement.AddNewMerchandise(mis);
            Assert.AreEqual(lawTest.IsValidPerMerchandise(statement), expected, "low with a valid merchandise in statement isn't correctly coded!");

        }
        [TestMethod]
        public void check_low_with_two_unvalid_merchandise_in_statement()
        {
            List<string> merchandises = new List<string>();
            merchandises.Add("berenj");
            merchandises.Add("gandom");
            List<string> companies = new List<string>();
            companies.Add("tabarok");
            companies.Add("golestan");
            List<string> licenseNeeded = new List<string>();
            DateTime issuanceDate = new DateTime(2015, 1, 18);
            //stub
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, 200, 5000, 200
                                          , "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, 200000, "", "");
            MerchandiseInStatement mis = new MerchandiseInStatement("berenj", "tabarok", 0, 1000, 100);
            MerchandiseInStatement mis2 = new MerchandiseInStatement("gandom", "golestan", 0, 100, 1000);
            statement.AddNewMerchandise(mis);
            statement.AddNewMerchandise(mis2);
            Assert.AreEqual(lawTest.IsValidPerMerchandise(statement), expected, "low with tow unvalid merchandise in statement isn't correctly coded!");
            

        }

    }
}
