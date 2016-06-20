using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD.Business_Layer;
using System.Windows.Forms;

namespace SAD
{
    public class Law
    {
        private DateTime startDate;
        private DateTime finishDate;
        private double minUnitPrice;
        private double maxUnitPrice;
        private int minCount;
        //private int maxCount;
        private string country;
        private string kindOfImport;
        private double minTotalPrice;
        private List<string> merchandiseList;
        private List<string> companies;
        private List<string> licensesNeeded;

        public Law(DateTime startDate, DateTime finishDate, double minUnitPrice, 
                   double maxUnitPrice, int minCount/*, int maxCount*/, string country, string kindOfImport
                   , double minTotalPrice, List<string> merchandiseList, List<string> companies, List<string> licensesNeeded)
        {
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.minUnitPrice = minUnitPrice;
            this.maxUnitPrice = maxUnitPrice;
            this.minCount = minCount;
            //this.maxCount = maxCount;
            this.country = country;
            this.kindOfImport = kindOfImport;
            this.merchandiseList = merchandiseList;
            this.companies = companies;
            this.licensesNeeded = licensesNeeded;
            this.minTotalPrice = minTotalPrice;
        }

        public bool ConditionsMatched(Statement statement)
        {
            //licensesNeeded.Clear(); // This List Sould Not Be HERE AT ALLLLLLLL!!!!
            //List<string> licenses = new List<string>();
            //List<string> merchandises = new List<string>();
            //List<string> companies = new List<string>();

            //merchandises.Add("گازوییل");
            //merchandises.Add("بنزین");
            //merchandises.Add("قیر");
            //licenses.Add("مجوز واردات فرآورده های نفتی");
            //CreateNewLaw(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue,
            //             String.Empty, double.MinValue, String.Empty, merchandises, companies, licenses);
            //licenses = new List<string>();
            //merchandises = new List<string>();
            //companies = new List<string>();

            //merchandises.Add("بشکه");
            //merchandises.Add("ورق آهن");
            //merchandises.Add("میلگرد");
            //merchandises.Add("تیرآهن");
            //licenses.Add("مجوز واردات کالای خارجی تولید داخل");
            //licenses.Add("مجوز واردات کالاهای فلزی");
            //CreateNewLaw(DateTime.MinValue, DateTime.MaxValue, 100, 10000, 100,
            //             String.Empty, double.MinValue, String.Empty, merchandises, companies, licenses);
            //licenses = new List<string>();
            //merchandises = new List<string>();
            //companies = new List<string>();


            //merchandises.Add("شامپو");
            //merchandises.Add("کرم");
            //licenses.Add("مجوز سلامت بهداشتی کالا های متفرقه");
            //CreateNewLaw(new DateTime(2010, 1, 1), DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue,
            //             "چین", double.MinValue, String.Empty, merchandises, companies, licenses);
            //licenses = new List<string>();
            //merchandises = new List<string>();
            //companies = new List<string>();


            //companies.Add("هیوندای");
            //companies.Add("کیا");
            //licenses.Add("مجوز  واردات خودرو های خارجی");
            //CreateNewLaw(DateTime.MinValue, DateTime.MaxValue, double.MinValue, double.MaxValue, int.MinValue,
            //            String.Empty, 1000000, String.Empty, merchandises, companies, licenses);
            //licenses = new List<string>();
            //merchandises = new List<string>();
            //companies = new List<string>();


            //licenses.Add("مجوز واردات کالاهای لوکس");
            //licenses.Add("مجوز سلامت فیزیکی کالاها");
            //licenses.Add("عدم مغایرت با اهداف اقتصاد مقاومتی");
            //CreateNewLaw(new DateTime(2014, 1, 1), new DateTime(2017, 1, 1), 100000, 1000000, int.MinValue,
            //             "سوئیس", double.MinValue, "هوایی", merchandises, companies, licenses);
            //licenses = new List<string>();
            //merchandises = new List<string>();
            //companies = new List<string>();

            ////MessageBox.Show("law size: " + laws.Count);
            if (statement.GetIssuanceDate() > startDate && statement.GetIssuanceDate() < finishDate
                && (String.IsNullOrEmpty(country) ? true : (statement.GetCountry() == country))
                && (String.IsNullOrEmpty(kindOfImport) ? true : statement.GetKindOfImport() == kindOfImport)
                && (this.minTotalPrice <= statement.GetWholeValue()))
            {
                bool minCountIsLimited;
                bool minUnitPriceIsLimted;
                bool companyIsLimited;

                if (this.merchandiseList.Count == 0) // no limitation for name of goods
                {
                    foreach (MerchandiseInStatement statementMerchandise in statement.GetMerchandiseList())
                    {
                        minCountIsLimited = false/*true*/;
                        minUnitPriceIsLimted = false /*true*/;
                        companyIsLimited = false /*true*/;

                        if (statementMerchandise.GetUnitPrice() > minUnitPrice
                            && statementMerchandise.GetUnitPrice() < maxUnitPrice)
                            minUnitPriceIsLimted = true /*false*/;
                        //MessageBox.Show("false because unit price of: " + statementMerchandise.GetName());
                        //statementMerchandise.GetUnitPrice().ToString() + " " + law.GetMinUnitPrice().ToString());

                        if (statementMerchandise.GetCount() > minCount
                           /*&& statementMerchandise.GetCount() <= law.GetMaxCount()*/)
                            minCountIsLimited = true;

                        if (companies.Count == 0) // law states no company
                            companyIsLimited = true;
                        else if (companies.Contains(statementMerchandise.GetCompany())) // law states companies
                            companyIsLimited = true;

                        MessageBox.Show("flags: " + minUnitPriceIsLimted.ToString() + " " + minCountIsLimited.ToString() + " " + companyIsLimited.ToString());
                        if (minUnitPriceIsLimted && minCountIsLimited && companyIsLimited)
                            return true;
                    }
                }
                else
                {
                    foreach (string lawMerchandiseName in merchandiseList)
                    {
                        if (statement.hasMerchandiseWithName(lawMerchandiseName))
                        {
                            minCountIsLimited = false/*true*/;
                            minUnitPriceIsLimted = false /*true*/;
                            companyIsLimited = false /*true*/;

                            MerchandiseInStatement currentmerchandise = statement.getMerchandiseWithName(lawMerchandiseName);
                            MessageBox.Show("Got one equal name");
                            if (currentmerchandise.GetUnitPrice() > minUnitPrice
                                && currentmerchandise.GetUnitPrice() < maxUnitPrice)
                                minUnitPriceIsLimted = true;
                            if (currentmerchandise.GetCount() > minCount
                                /*&& statementMerchandise.GetCount() <= law.GetMaxCount()*/)
                                minCountIsLimited = true;

                            //MessageBox.Show(companies.Count.ToString());
                            //MessageBox.Show(companies[0].ToString());
                            //MessageBox.Show("join: " + String.IsNullOrEmpty(String.Join("", companies)).ToString());
                            //MessageBox.Show(companies.ToString());
                            //if (companies.Count == 0)
                            if (String.IsNullOrEmpty(String.Join("", companies)))
                                companyIsLimited = true;
                            else if (companies.Contains(currentmerchandise.GetCompany()))
                                companyIsLimited = true;
                            MessageBox.Show("flags: " + minUnitPriceIsLimted.ToString() + " " + minCountIsLimited.ToString() + " " + companyIsLimited.ToString());
                            if (minUnitPriceIsLimted && minCountIsLimited && companyIsLimited)
                                return true;
                        }
                    }
                }
                //MessageBox.Show("condition checking: priceLimited: " + minUnitPriceIsLimted.ToString() + "      minCountLimited: " + minCountIsLimited.ToString() + "       companyLimited: " + companyIsLimited.ToString());
                //if (minUnitPriceIsLimted && minCountIsLimited && companyIsLimited)
                    //return true;
            }
            //MessageBox.Show("not matched at first");
            return false;
        }
        public bool HasEnyMerchandiseWithNames(List<MerchandiseInStatement> merchandiseItems)
        {
            foreach(MerchandiseInStatement item in merchandiseItems)
            {
                if (merchandiseList.Contains(item.GetName()))
                    return true;
            }
            return false;
        }
        public DateTime GetStartDate()
        {
            return this.startDate;
        }

        public DateTime GetFinishDate()
        {
            return this.finishDate;
        }

        public double GetMinUnitPrice()
        {
            return this.minUnitPrice;
        }

        public double GetMaxUnitPrice()
        {
            return this.maxUnitPrice;
        }

        public int GetMinCount()
        {
            return this.minCount;
        }

        //public int GetMaxCount()
        //{
        //    return this.maxCount;
        //}

        public string GetCountry()
        {
            return this.country;
        }

        public string GetImportType()
        {
            return this.kindOfImport;
        }

        public double GetMinTotalPrice()
        {
            return this.minTotalPrice;
        }

        public List<string> GetLicenses()
        {
            return this.licensesNeeded;
        }

        public List<string> GetCompanies()
        {
            return this.companies;
        }

        public List<string> GetMerchandiseList()
        {
            return this.merchandiseList;
        }
    }
}
