using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD.DAO_Layer;
using System.Windows.Forms;

namespace SAD.Business_Layer
{
    public class IssueStatementHandler
    {
        private Statement statement;
        private LicenseDAO licenseDAO;
        private IssueStatementDAO statementDAO;
        private LawDAO lawDAO;
        private List<string> licensesNeeded;
        private List<Law> laws;
        public IssueStatementHandler()
        {
            statement = new Statement();
            licenseDAO = new LicenseDAO();
            statementDAO = new IssueStatementDAO(); // needed any more? it is created in function!!!
            lawDAO = new LawDAO();
            licensesNeeded = new List<string>();
            laws = new List<Law>();
        }

        public void AddNewMerchandiseToStatement(string name, string company, string weight, string number, string price)
        {
            // these should not be empty
            double _weight = String.IsNullOrEmpty(weight) ? -1 : Convert.ToDouble(weight);
            int _number = String.IsNullOrEmpty(number) ? -1 : Convert.ToInt32(number);
            double _price = String.IsNullOrEmpty(price) ? -1 : Convert.ToDouble(price);

            MerchandiseInStatement merchandise = new MerchandiseInStatement(name, company, _weight, _number, _price);
            statement.AddNewMerchandise(merchandise);
        }

        public void SetStatementParameters(string SSN, string merchantName, string merchantFamily, DateTime issuanceDate,
                                          string wholeValue, string country, string kindOfImport)
        {
            MessageBox.Show("before set parameters: country = " + country);
            double _wholeValue = String.IsNullOrEmpty(wholeValue) ? -1 : Convert.ToDouble(wholeValue);
            statement.SetParameters(/*SSN, merchantName, merchantFamily, */issuanceDate, _wholeValue, kindOfImport, country);
            MessageBox.Show("after set parameters: country = " + statement.GetCountry());
            //licensesNeeded = new List<string>();
            // licensesNeeded = GetNeededLicenses(); // when uncommenting... some logs of the function will appear

            //string allLicensesNeeded = "";
            //foreach (string license in licensesNeeded)
            //{
            //    allLicensesNeeded += license + "\n";
            //}
            //// //MessageBox.Show(":مجوز های مورد نیاز" + "\n" + allLicensesNeeded);

            IssueStatementDAO statementDAO = new IssueStatementDAO();

            // if valid for all licenses neede
            /*statementDAO.InsertNewStatement(SSN, merchantName, merchantFamily, issuanceDate, _wholeValue, country, kindOfImport);
            foreach (MerchandiseInStatement merchandise in statement.GetMerchandiseList())
            {
                statementDAO.InsertNewMerchandiseForStatement(merchandise.GetName(), merchandise.GetCompany(),
                                                              merchandise.GetWeight(), merchandise.GetCount(), 
                                                              merchandise.GetUnitPrice());
                //// //MessageBox.Show("IN Handler: New Merchandise for Statement Added to DB...");
            }*/
            //statement.EmptyMerchandiseList();            
        }
        public void UpdateLicense(MerchantLicense license)
        {
            //bool isValid = true;
            List<MerchandiseInLicense> merchandiseList = new List<MerchandiseInLicense>();
            merchandiseList = statementDAO.GetMerchandiseListForLicense(license.GetLicenseNumber());

            if (license.GetExpirationDate() < statement.GetIssuanceDate())
                return;

            foreach (MerchandiseInStatement statementMerchandise in statement.GetMerchandiseList())
            {
                bool licenseHasMerchandise = false;
                foreach (MerchandiseInLicense licenseMerchandise in merchandiseList)
                {
                    if (licenseMerchandise.GetName() == statementMerchandise.GetName())
                    {
                        licenseHasMerchandise = true;
                        if (licenseMerchandise.GetUnitPrice() != -1 &&
                            licenseMerchandise.GetUnitPrice() == statementMerchandise.GetUnitPrice())
                        {
                            licenseMerchandise.SetCount(licenseMerchandise.GetNumber() -
                                statementMerchandise.GetCount());
                            break;
                        }
                        else if (licenseMerchandise.GetMaxUnitPrice() != -1 &&
                                licenseMerchandise.GetMaxUnitPrice() >= statementMerchandise.GetUnitPrice())
                        {
                            licenseMerchandise.SetCount(licenseMerchandise.GetNumber() -
                                statementMerchandise.GetCount());
                            break;
                        }
                        else if (licenseMerchandise.Getweight() >= statementMerchandise.GetWeight())
                        {
                            licenseMerchandise.SetWeight(licenseMerchandise.Getweight() -
                                statementMerchandise.GetWeight());
                            break;
                        }
                        else // kala darim, kam darim
                            break;
                    }
                }
                //if (!licenseHasMerchandise) // kollan kala to in mojavvez nist

            }
        }

        public bool IsLicenseValid(string licenseNumber)
        {
            MessageBox.Show((statement.GetCountry() == null).ToString());
            //MessageBox.Show((statement.GetIssuanceDate() == null).ToString());
            MerchantLicense license = new MerchantLicense();
            license = licenseDAO.GetLicenseWithNumber(licenseNumber);
            if (statement.GetIssuanceDate() <= license.GetExpirationDate() && String.IsNullOrEmpty(license.GetCountry()) ? true
                : (license.GetCountry() == statement.GetCountry()) && String.IsNullOrEmpty(license.GetImportType()) ? true
                : (license.GetImportType() == statement.GetKindOfImport()))
            {
                if (license.GetMerchandiseList().Count == 0) /* with no merchandise */
                {
                    if (license.GetValue() > 0)
                    {
                        if (String.IsNullOrEmpty(license.GetWeight())) /* weight treated as company List */
                        {
                            MessageBox.Show("type 1: returning " + (statement.GetWholeValue() <= license.GetValue()).ToString());
                            return statement.GetWholeValue() <= license.GetValue(); /* type 1 */
                        }
                        else /* type 2 */
                        {
                            if (statement.GetWholeValue() > license.GetValue())
                            {
                                MessageBox.Show("type 2: returning " + (statement.GetWholeValue() > license.GetValue()).ToString());
                                return false;
                            }

                            string[] temp = license.GetWeight().Split('#');
                            List<string> licenseCompanies = new List<string>(temp);
                            double totalPriceWithliceCompanies = 0;
                            foreach (MerchandiseInStatement merchandise in statement.GetMerchandiseList())
                            {
                                if (licenseCompanies.Contains(merchandise.GetName()))
                                    totalPriceWithliceCompanies += merchandise.GetUnitPrice() * merchandise.GetCount();
                            }
                            MessageBox.Show("type 2: returning " + (license.GetValue() >= totalPriceWithliceCompanies).ToString());
                            return license.GetValue() >= totalPriceWithliceCompanies;
                        }
                    }
                    else /* type 3 */
                    {
                        foreach (MerchandiseInStatement merchandise in statement.GetMerchandiseList())
                        {
                            if (merchandise.GetWeight() > license.GetMaxUnitWeight() || merchandise.GetUnitPrice() > license.GetMaxUnitPrice())
                            {
                                MessageBox.Show("type 3: returning false");
                                return false;
                            }
                        }
                        MessageBox.Show("type 3: returning false");
                        return true;
                    }
                }
                else /* with some merchandise */
                {
                    foreach (MerchandiseInStatement statementGood in statement.GetMerchandiseList())
                    {
                        foreach (MerchandiseInLicense licenseGood in license.GetMerchandiseList())
                        {
                            if (licenseGood.GetName() == statementGood.GetName())
                            {
                                if (licenseGood.Getweight() > 0) /* type 4 */
                                {
                                    if (statementGood.GetCompany() == licenseGood.GetCompany()
                                            && statementGood.GetWeight() <= licenseGood.Getweight())
                                    {
                                        MessageBox.Show("type 4: returning true");
                                        return true;
                                    }
                                }
                                else if (licenseGood.GetNumber() > 0)
                                {
                                    if (licenseGood.GetUnitPrice() < 0 && licenseGood.GetMaxUnitPrice() < 0) /* type 5 */
                                    {
                                        MessageBox.Show("type 5; returning " + (statementGood.GetCount() <= licenseGood.GetNumber()).ToString());
                                        return statementGood.GetCount() <= licenseGood.GetNumber();
                                    }
                                    else if (licenseGood.GetUnitPrice() > 0 && licenseGood.GetMaxUnitPrice() < 0) /* type 6 */
                                    {
                                        MessageBox.Show("type 6: returning " + (statementGood.GetCount() <= licenseGood.GetNumber()
                                                && statementGood.GetUnitPrice() == licenseGood.GetUnitPrice()).ToString());
                                        return (statementGood.GetCount() <= licenseGood.GetNumber()
                                                && statementGood.GetUnitPrice() == licenseGood.GetUnitPrice());
                                    }
                                    else if (licenseGood.GetUnitPrice() < 0 && licenseGood.GetMaxUnitPrice() > 0) /* type 7 */
                                    {
                                        MessageBox.Show("type 7: returning " + (statementGood.GetCount() <= licenseGood.GetNumber()
                                                && statementGood.GetUnitPrice() <= licenseGood.GetMaxUnitPrice()).ToString());
                                        return (statementGood.GetCount() <= licenseGood.GetNumber()
                                                && statementGood.GetUnitPrice() <= licenseGood.GetMaxUnitPrice());
                                    }
                                }
                                else /* type 8 */
                                {
                                    MessageBox.Show("type 8: no limitations - returning true");
                                    return true;
                                }
                            }
                        }
                    }
                    MessageBox.Show("no types matched. returning false");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("primary conditions not valid. " + (statement.GetIssuanceDate() <= license.GetExpirationDate()).ToString() + " " +
                    (String.IsNullOrEmpty(license.GetCountry()) ? true
                : (license.GetCountry() == statement.GetCountry())).ToString() + " " 
                + (String.IsNullOrEmpty(license.GetImportType()) ? true
                : (license.GetImportType() == statement.GetKindOfImport())).ToString());
                MessageBox.Show("license: " + license.GetCountry() + " " + license.GetCountry().Length);
                MessageBox.Show("statement: " + statement.GetCountry() + " " + statement.GetCountry().Length);
                return false;
            }
        }

        //public bool ValidateLicenses(string SSN)
        //{
        //    List<MerchantLicense> licenses = new List<MerchantLicense>();
        //    licenses = statementDAO.GetMerchantLicenses(SSN);
        //    List<string> licenseNames = new List<string>();

        //    licensesNeeded.Distinct().ToList()
        //    licenseNames = GetNeededLicenses();

        //    List<string> neededLicenseNames = new List<string>();
        //    foreach (string licenseName in licenseNames)
        //    {
        //        bool merchantHasLicense = false;
        //        foreach (MerchantLicense merchantLicense in licenses)
        //        {
        //            if (merchantLicense.GetLicenseName() == licenseName)
        //                merchantHasLicense = true;
        //        }
        //        if (!merchantHasLicense)
        //            neededLicenseNames.Add(licenseName);
        //    }

        //    string licensesNotValidated = "";
        //    foreach(string nameOflicense in neededLicenseNames)
        //    {
        //        licensesNotValidated += nameOflicense + "\n";
        //    }
        //    // //MessageBox.Show("مجوز های مورد نیاز" + ":\n" + licensesNotValidated);

        //    if (neededLicenseNames.Count == 0)
        //        return true;
        //    return false;
        //}
        public string GetLicensesAsString()
        {
            List<Law> allLaws = new List<Law>();
            allLaws = lawDAO.GetLaws();
            string allLicensesNeeded = "";
            //int count = 0;
            foreach (Law law in allLaws)
            {
                //MessageBox.Show("in st handler: considering law " + count);
                //count++;
                string temp = "";
                if (law.ConditionsMatched(statement))
                {
                    //MessageBox.Show("in statement handler: one match");
                    temp = String.Join("\n", law.GetLicenses());
                }
                allLicensesNeeded += temp + "\n";
            }
            return allLicensesNeeded;
        }
    }
}
