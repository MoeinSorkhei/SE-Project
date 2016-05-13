using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class License
    {
        private List<string> companies;
        private List<string> countries;
        private double maxPrice;
        private double maxWeight;

        public License(List<string> companiesList,
                       List<string> countriesList, double price, double weight)
        {
            maxPrice = price;
            maxWeight = weight;
            companies = new List<string>(companiesList);
            countries = new List<string>(countriesList);
        }
    }
}
