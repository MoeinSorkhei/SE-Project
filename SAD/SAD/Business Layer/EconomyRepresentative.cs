using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class EconomyRepresentative : User
    {
        public EconomyRepresentative(string userName, string passWord,
              string SSN, string Name, string familyName)
            : base(userName, passWord, SSN, Name, familyName)
        { 
            
        }

    }
}
