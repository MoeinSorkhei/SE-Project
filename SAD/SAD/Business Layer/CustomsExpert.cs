using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    class CustomsExpert : User
    {
        public CustomsExpert(string userName, string passWord,
              string SSN, string Name, string familyName)
            : base(userName, passWord, SSN, Name, familyName)
        { 
            
        }
        public void IssueStatement(/*parameters*/)
        {
        }
    }
}
