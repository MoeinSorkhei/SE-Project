using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\monsieur maaz\Documents\Visual Studio 2010\Projects\SAD\SAD\DB.txt");
            foreach(string line in lines)
            {
                string[] words = line.Split(' ');
                users.Add(new KeyValuePair<string, string>(words[0], words[1]));
            }
            //users.Add(new KeyValuePair<string, string>("sefid", "123"));
            //users.Add(new KeyValuePair<string, string>("moein", "456"));
            //users.Add(new KeyValuePair<string, string>("maaz", "789"));

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(users));
            //Application.;
        }
    }
}
