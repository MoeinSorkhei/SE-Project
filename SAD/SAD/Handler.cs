using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAD
{
    public class Handler
    {
        private List< KeyValuePair<string, string> > users;
        public Handler()
        {
            
        }

        public bool CheckUserPass(string username, string password)
        {
            foreach (KeyValuePair<string, string> kvp in users)
                if (kvp.Key == username && kvp.Value == password)
                    return true;
            return false;
        }

        public void AddUser(string username , string password)
        {
            KeyValuePair<string , string> user = new KeyValuePair<string,string>(username, password);
            users.Add(user);
        }
    }

}
