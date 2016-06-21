using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace SAD.DAO_Layer
{
    public class LicenseDAO
    {
        public MerchantLicense GetLicenseWithNumber(string licenseNumber)
        {
            string query = "select * from dbo.MerchantLicense where number = '" + licenseNumber + "'";
            DBConnection dbConnection = new DBConnection();
            List<List<Object>> queryResult = new List<List<Object>>();
            queryResult = dbConnection.RunSelectQuery(query);

            if (queryResult.Count == 0)
            {
                MessageBox.Show("No MerchantLicense Found with licenseNumber: " + licenseNumber);
                return null;
            }
            int licenseNum = Convert.ToInt16(licenseNumber);
            string licenseName = Convert.ToString(queryResult[0][1]);
            string SSN = Convert.ToString(queryResult[0][2]);
            DateTime issuanceDate = Convert.ToDateTime(queryResult[0][3]);
            DateTime expirationDate = Convert.ToDateTime(queryResult[0][4]);
            double wholeValue = Convert.ToDouble(queryResult[0][5]);
            string weight = Convert.ToString(queryResult[0][6]); /*treated as company List */
            double maxUnitPrice = Convert.ToDouble(queryResult[0][7]);
            double maxUnitWeight = Convert.ToDouble(queryResult[0][8]);
            string importType = Convert.ToString(queryResult[0][9]);
            string country = Convert.ToString(queryResult[0][10]);

            MerchantLicense merchantLicense = new MerchantLicense();
            merchantLicense.SetLicenseNumber(licenseNum);
            merchantLicense.SetParameters(issuanceDate, expirationDate, licenseName, wholeValue, weight,
                            maxUnitPrice, maxUnitWeight, importType, country, SSN);
            //MessageBox.Show("in DAO; found merchant license for ssn: " + SSN);

            string queryToFindMerchandiseId = "select merchandiseid from dbo.LicenseHasMerchandise where licenseNumber = '"
                                                + licenseNumber + "'";
            List<List<Object>> merchandiseIdObjects = new List<List<Object>>();
            merchandiseIdObjects = dbConnection.RunSelectQuery(queryToFindMerchandiseId);

            List<string> merchandiseIDs = new List<string>();
            for (int i = 0; i < merchandiseIdObjects.Count; i++)
                merchandiseIDs.Add(Convert.ToString(merchandiseIdObjects[i][0]));
            //MessageBox.Show("in DAO: found merchanndise ids: " + String.Join("\n", merchandiseIDs.ToArray()));

            List<List<Object>> merhcandiseObjects = new List<List<Object>>();
            foreach (string merchandiseId in merchandiseIDs)
            {
                string queryToFindMerchandiseList = "select * from MerchandiseInfoInLicense where Id = '" + merchandiseId + "'";
                merchandiseIdObjects = dbConnection.RunSelectQuery(queryToFindMerchandiseList);

                string name = Convert.ToString(merchandiseIdObjects[0][1]);
                string company = Convert.ToString(merchandiseIdObjects[0][2]);
                double unitWeight = Convert.ToDouble(merchandiseIdObjects[0][3]);
                double unitPrice = Convert.ToDouble(merchandiseIdObjects[0][4]);
                double wholeWeight = Convert.ToDouble(merchandiseIdObjects[0][5]);
                double _maxUnitPrice = Convert.ToDouble(merchandiseIdObjects[0][6]);
                int count = Convert.ToInt32(merchandiseIdObjects[0][7]);
                MerchandiseInLicense merchandise = new MerchandiseInLicense(name, company, wholeWeight, _maxUnitPrice, unitWeight,
                                                    unitPrice, count);
                //MessageBox.Show("in DAO: found merchandise with id, name: " + merchandiseId + ", " + name);
                merchantLicense.AddNewMercahndise(merchandise);
                merchandiseIdObjects.Clear();
            }
            return merchantLicense;
        }
    }
}
