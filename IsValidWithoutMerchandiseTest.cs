using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SAD;
using SAD.Business_Layer;

namespace LawGetMatchedConditionTest
{
    [TestClass]
    public class IsValidWithoutMerchandiseTest
    {
        [TestMethod]
        public void UnitPriceCountCompanyValidTestWithoutCompany()
        {
            double minUnitPrice = 0;
            double maxUnitPrice = 100;
            int minCount = 50;
            double wholeValue = 1000;
            string goodName = "gun";
            string company = "googoolParvar";
            double weight = 100;
            double unitPrice =20;
            int count = 50;
            DateTime issuanceDate = new DateTime(2015, 1, 20);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            bool expected = true;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, minUnitPrice, maxUnitPrice, minCount,
                                    "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, wholeValue, "", "");
            MerchandiseInStatement MIS = new MerchandiseInStatement(goodName, company, weight, count, unitPrice);
            statement.AddNewMerchandise(MIS);
            Assert.AreEqual(lawTest.IsValidWithoutMerchandise(statement), expected, "Wrong Check in ");
        }
        [TestMethod]
        public void UnitPriceCountCompanyValidTestWithCompany()
        {
            double minUnitPrice = 0;
            double maxUnitPrice = 100;
            int minCount = 50;
            double wholeValue = 1000;
            string goodName = "gun";
            string company = "googoolParvar";
            double weight = 100;
            double unitPrice = 20;
            int count = 50;
            DateTime issuanceDate = new DateTime(2015, 1, 20);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            companies.Add("googoolParvar");
            bool expected = true;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, minUnitPrice, maxUnitPrice, minCount,
                                    "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, wholeValue, "", "");
            MerchandiseInStatement MIS = new MerchandiseInStatement(goodName, company, weight, count, unitPrice);
            statement.AddNewMerchandise(MIS);
            Assert.AreEqual(lawTest.IsValidWithoutMerchandise(statement), expected, "Wrong Check in ");
        }
        [TestMethod]
        public void UnitPriceInvalidCountCompanyValidTest()
        {
            double minUnitPrice = 0;
            double maxUnitPrice = 100;
            int minCount = 50;
            double wholeValue = 7500;
            string goodName = "gun";
            string company = "googoolParvar";
            double weight = 100;
            double unitPrice = 150;
            int count = 50;
            DateTime issuanceDate = new DateTime(2015, 1, 20);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            companies.Add("googoolParvar");
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, minUnitPrice, maxUnitPrice, minCount,
                                    "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, wholeValue, "", "");
            MerchandiseInStatement MIS = new MerchandiseInStatement(goodName, company, weight, count, unitPrice);
            statement.AddNewMerchandise(MIS);
            Assert.AreEqual(lawTest.IsValidWithoutMerchandise(statement), expected, "Wrong Check in ");
        }
        [TestMethod]
        public void CountInvalidUnitPriceCompanyValidTest()
        {
            double minUnitPrice = 0;
            double maxUnitPrice = 100;
            int minCount = 51;
            double wholeValue = 7500;
            string goodName = "gun";
            string company = "googoolParvar";
            double weight = 100;
            double unitPrice = 50;
            int count = 50;
            DateTime issuanceDate = new DateTime(2015, 1, 20);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            companies.Add("googoolParvar");
            companies.Add("USI");
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, minUnitPrice, maxUnitPrice, minCount,
                                    "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, wholeValue, "", "");
            MerchandiseInStatement MIS = new MerchandiseInStatement(goodName, company, weight, count, unitPrice);
            statement.AddNewMerchandise(MIS);
            Assert.AreEqual(lawTest.IsValidWithoutMerchandise(statement), expected, "Wrong Check in ");
        }
        [TestMethod]
        public void CompanyInvalidCountUnitPriceValidTest()
        {
            double minUnitPrice = 0;
            double maxUnitPrice = 100;
            int minCount = 50;
            double wholeValue = 7500;
            string goodName = "gun";
            string company = "googoolParvar";
            double weight = 100;
            double unitPrice = 50;
            int count = 50;
            DateTime issuanceDate = new DateTime(2015, 1, 20);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            companies.Add("USI");
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, minUnitPrice, maxUnitPrice, minCount,
                                    "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, wholeValue, "", "");
            MerchandiseInStatement MIS = new MerchandiseInStatement(goodName, company, weight, count, unitPrice);
            statement.AddNewMerchandise(MIS);
            Assert.AreEqual(lawTest.IsValidWithoutMerchandise(statement), expected, "Wrong Check in ");
        }
        [TestMethod]
        public void CompanyCountUnitPriceValidUnionFlagsTest()
        {
            double minUnitPrice = 0;
            double maxUnitPrice = 100;
            int minCount = 10;
            double wholeValue = 7500;
            string goodName1 = "gun";
            string company1 = "googoolParvar";
            double weight1 = 100;
            double unitPrice1 = 50;
            int count1 = 9;
            string goodName2 = "WarMachine";
            string company2 = "googoolParvar";
            double weight2 = 1000;
            double unitPrice2 = 500;
            int count2 = 10;
            DateTime issuanceDate = new DateTime(2015, 1, 20);
            List<string> merchandises = new List<string>();
            List<string> companies = new List<string>();
            List<string> licenseNeeded = new List<string>();
            companies.Add("USI");
            companies.Add("googoolParvar");
            bool expected = false;
            //drivers
            Law lawTest = new Law(DateTime.MinValue, DateTime.MaxValue, minUnitPrice, maxUnitPrice, minCount,
                                    "", "", double.MinValue, merchandises, companies, licenseNeeded);
            Statement statement = new Statement();
            statement.SetParameters(issuanceDate, wholeValue, "", "");
            MerchandiseInStatement MIS1 = new MerchandiseInStatement(goodName1, company1, weight1, count1, unitPrice1);
            MerchandiseInStatement MIS2 = new MerchandiseInStatement(goodName2, company2, weight2, count2, unitPrice2);
            statement.AddNewMerchandise(MIS1);
            statement.AddNewMerchandise(MIS2);
            Assert.AreEqual(lawTest.IsValidWithoutMerchandise(statement), expected, "Wrong Check in ");
        }
    }
}
