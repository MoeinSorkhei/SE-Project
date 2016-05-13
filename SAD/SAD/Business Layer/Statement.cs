using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class Statement
    {
        DateTime date; 
        double wholeValue;
        int kindOfImport;
        

        public Statement(DateTime Date, double value, int KindOfImport)
        {
            date = Date;
            wholeValue = value;
            kindOfImport = KindOfImport;
        }
    }
}
