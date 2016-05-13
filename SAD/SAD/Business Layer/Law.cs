using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class Law
    {
        int kindOfImport;
        string startDate;   //date type?
        string finishDate;  //date type?
        string minPrice;
        string maxPrice;
        string country;
        List<string> companies;
        List<string> licenses;  // not like in domain model

        public Law(int KindOfImport, string StartDate, string FinishDate, string MinPrice, 
                   string MaxPrice, string Country, List<string> Companies)
        {
            kindOfImport = KindOfImport;
            startDate = StartDate;
            finishDate = FinishDate;
            minPrice = MinPrice;
            maxPrice = MaxPrice;
            country = Country;
            companies = new List<string>(Companies);
        }
    }
}
