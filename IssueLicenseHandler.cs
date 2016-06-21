using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAD.DAO_Layer; 

namespace SAD.Business_Layer
{
    public class IssueLicenseHandler
    {
        private MerchantLicense merchantLicense;
        private IssueLicenseDAO licenseDAO;
        private List<string> companies;

        public IssueLicenseHandler()
        {
            merchantLicense = new MerchantLicense();
            licenseDAO = new IssueLicenseDAO(); // needed any more? it is created in function!!!
            companies = new List<string>();
        }

        public void AddNewMerchandiseToLicense(string name, string company, string maxWeight, string maxUnitPrice,
                                               string unitWeight, string unitPrice, string count)
        {
            double _maxUnitPrice = String.IsNullOrEmpty(maxUnitPrice) ? -1 : Convert.ToDouble(maxUnitPrice);
            double _maxWeight = String.IsNullOrEmpty(maxWeight) ? -1 : Convert.ToDouble(maxWeight);
            double _unitPrice = String.IsNullOrEmpty(unitPrice) ? -1 : Convert.ToDouble(unitPrice);
            double _unitWeight = String.IsNullOrEmpty(unitWeight) ? -1 : Convert.ToDouble(unitWeight);
            int _count =String.IsNullOrEmpty(count) ? -1 : Convert.ToInt32(count);

            MerchandiseInLicense newMerchandise = new MerchandiseInLicense(name, company, _maxWeight, _maxUnitPrice,
                                                         _unitWeight, _unitPrice, _count);
            merchantLicense.AddNewMercahndise(newMerchandise);
        }

        public int SetLicenseParameters(DateTime issuanceDate, DateTime expirationDate,
                             string licenseName, string maxTotalPrice, string weight /* treated as company list */, string maxUnitPrice,
                             string maxUnitWeight, string importType, string country, string SSN)
        {
            double _value = String.IsNullOrEmpty(maxTotalPrice) ? -1 : Convert.ToDouble(maxTotalPrice);
            string _weight = String.Join("#", companies.ToArray()); /* treated as company list */
            double _maxUnitPrice = String.IsNullOrEmpty(maxUnitPrice) ? -1 : Convert.ToDouble(maxUnitPrice);
            double _maxUnitWeight = String.IsNullOrEmpty(maxUnitWeight) ? -1 : Convert.ToDouble(maxUnitWeight);

            merchantLicense.SetParameters(issuanceDate, expirationDate, licenseName,
                                          _value, _weight, _maxUnitPrice, _maxUnitWeight,
                                          importType, country, SSN);

            IssueLicenseDAO licenseDAO = new IssueLicenseDAO();
            int licenseNumber = licenseDAO.InsertNewLicense(issuanceDate, expirationDate, licenseName, _value, _weight,
                                        _maxUnitPrice, _maxUnitWeight, importType, country, SSN);

            List<MerchandiseInLicense> merchandiseList = new List<MerchandiseInLicense>();
            merchandiseList = merchantLicense.GetMerchandiseList();

            foreach (MerchandiseInLicense merchandise in merchandiseList)
            {
                licenseDAO.AddMerchandiseToLicense(merchandise.GetName(), merchandise.GetCompany(),
                                                   merchandise.Getweight(), merchandise.GetMaxUnitPrice(),
                                                   merchandise.GetUnitWeight(), merchandise.GetUnitPrice(),
                                                   merchandise.GetNumber());
            }

            MessageBox.Show("in handler: " + "کاربر گرامی، مجوز با موفقیت ثبت گردید");
            merchandiseList.Clear();
            return licenseNumber;
        }
        public void AddItemToCompanyList(string item)
        {
            companies.Add(item);
        }
        public void ClearCompanyList()
        {
            companies.Clear();
        }
    }
}

