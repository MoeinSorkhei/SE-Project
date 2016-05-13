using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class User
    {
        private string username;
        private string password;
        private string ssn;
        private string name;
        private string familyname;

        public User(string userName, string passWord,
               string SSN, string Name, string familyName)
        {
            username = userName;
            password = passWord;
            ssn = SSN;
            name = Name;
            familyname = familyName;
        }

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }

        public string getSSN()
        {
            return ssn;
        }

        public string getName()
        {
            return name;
        }

        public string getFamilyName()
        {
            return familyname;
        }

        
    }
}
