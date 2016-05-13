using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class OrganRepresentative : User
    {
        private string organName;
        public OrganRepresentative(string userName, string passWord,
               string SSN, string Name, string familyName, string nameOfOrgan)
               : base(userName, passWord, SSN, Name, familyName) 
        {
            organName = nameOfOrgan;
        }

        public void IssueLicense()
        {

        }
    }
}
