using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class Merchandise
    {
        private string name;
        private string country;
        private string company;
        private double unitWeight;
        private double unitPrice;
        public Merchandise(string merchandiseName, string countryName, string companyName, double weight, double price)
        {
            name = merchandiseName;
            country = countryName;
            company = companyName;
            unitWeight = weight;
            unitPrice = price;
        }
    }

   
}
