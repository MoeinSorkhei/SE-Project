using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAD.DAO_Layer
{
    public class LawDAO
    {
        public List<Law> GetLaws()
        {
            List<Law> laws = new List<Law>();
            string query = "select * from dbo.Law";
            DBConnection dbConnection = new DBConnection();
            List<List<Object>> queryResults = new List<List<Object>>();
            queryResults = dbConnection.RunSelectQuery(query);

            for (int i = 0; i < queryResults.Count; i++)
            {
                //MessageBox.Show(Convert.ToString(queryResults[i][1]));
                //MessageBox.Show(String.IsNullOrEmpty(Convert.ToString(queryResults[i][1])).ToString());
                //MessageBox.Show(DateTime.MaxValue.ToString());
                DateTime startDate = String.IsNullOrEmpty(queryResults[i][1].ToString()) ? DateTime.MinValue 
                                    : Convert.ToDateTime(queryResults[i][1]);
                DateTime finishDate = String.IsNullOrEmpty(queryResults[i][2].ToString()) ? DateTime.MaxValue
                                    : Convert.ToDateTime(queryResults[i][2]);
                double minUnitPrice = String.IsNullOrEmpty(queryResults[i][3].ToString()) ? double.MinValue
                                    : Convert.ToDouble(queryResults[i][3]);
                double maxUnitPrice = String.IsNullOrEmpty(queryResults[i][4].ToString()) ? double.MaxValue
                                    : Convert.ToDouble(queryResults[i][4]);
                int minCount = String.IsNullOrEmpty(queryResults[i][5].ToString()) ? int.MinValue
                                    : Convert.ToInt32(queryResults[i][5]);
                string country = Convert.ToString(queryResults[i][6]);
                string kindOfImport = Convert.ToString(queryResults[i][7]);
                double minTotalPrice = String.IsNullOrEmpty(queryResults[i][8].ToString()) ? double.MinValue
                                    : Convert.ToDouble(queryResults[i][8]);
                string merchandises = String.IsNullOrEmpty(queryResults[i][9].ToString()) ? ""
                                    : Convert.ToString(queryResults[i][9]);
                //MessageBox.Show(String.IsNullOrEmpty(queryResults[i][10].ToString()).ToString());
                string companies = String.IsNullOrEmpty(queryResults[i][10].ToString()) ? "" :
                    Convert.ToString(queryResults[i][10]);
                string licenses = String.IsNullOrEmpty(queryResults[i][11].ToString()) ? "" 
                    : Convert.ToString(queryResults[i][11]);

                string[] merchandiseList = merchandises.Split('#');
                //MessageBox.Show("String to be splitted: " + companies.Length);
                string[] companiesList = companies.Split('#');
                MessageBox.Show("in dao: company array count: " + companiesList.Length);
                string[] licensesNeeded = licenses.Split('#');
                laws.Add(new Law(startDate, finishDate, minCount, maxUnitPrice, minCount, country, kindOfImport,
                    minCount, new List<string>(merchandiseList), new List<string>(companiesList), new List<string>(licensesNeeded)));
            }
            //MessageBox.Show("laws count in DB: " + laws.Count.ToString());
            //foreach (Law l in laws)
                //MessageBox.Show("in DAO--- Laws: " + l.GetStartDate().ToString() + "\n" + l.GetFinishDate().ToString() + "\n" + l.GetMinCount().ToString() + "\n" + l.GetMerchandiseList().ToString() + " \n" + l.GetLicenses().ToString());
            //MessageBox.Show("in LawDAO: all Laws:" + String.Join("\n", laws));
            return laws;
        }
        public void AddNewLaw(Law law)
        {
            string merchadises = String.Join("#", law.GetMerchandiseList().ToArray());
            string companies = String.Join("#", law.GetCompanies().ToArray());
            string licenses = String.Join("#", law.GetLicenses().ToArray());

            //for (int i = 0; i < law.GetMerchandiseList().Count; i++)
            //{
            //    merchadises += law.GetMerchandiseList()[i];
            //    if (i != law.GetMerchandiseList().Count - 1)
            //        merchadises += '#';
            //}

            //for (int i = 0; i < law.GetCompanies().Count; i++)
            //{
            //    companies += law.GetCompanies()[i];
            //    if (i != law.GetCompanies().Count - 1)
            //        companies += '#';
            //}

            //for (int i = 0; i < law.GetLicenses().Count; i++)
            //{
            //    licenses += law.GetLicenses()[i];
            //    if (i != law.GetLicenses().Count - 1)
            //        licenses += '#';
            //}

            string query = "insert into dbo.Law values" + "('" + Convert.ToString(law.GetStartDate()) + "', '"
                           + Convert.ToString(law.GetFinishDate()) + "', '" + Convert.ToString(law.GetMinUnitPrice()) + "', '"
                           + Convert.ToString(law.GetMaxUnitPrice()) + "', '" + Convert.ToString(law.GetMinCount()) + "', N'"
                           + Convert.ToString(law.GetCountry()) + "', N'" + Convert.ToString(law.GetImportType()) + "', '"
                           + Convert.ToString(law.GetMinTotalPrice()) + "', N'" + merchadises + "', N'" + companies + "', N'" + licenses + "')";
            MessageBox.Show("in in LawDAO: new law added successfully");
        }
    }
}
