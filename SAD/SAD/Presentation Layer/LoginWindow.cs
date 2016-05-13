using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAD
{
    public partial class LoginWindow : Form
    {
        private string username;
        private string password;
        private int type;
        private List<KeyValuePair<string, string>> users;
        public LoginWindow(List<KeyValuePair<string, string>> Users, int t)
        {
            InitializeComponent();
            type = t;
            users = Users;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;

            if (users.Contains(new KeyValuePair<string,string> (username, password)))
            {
                if (type == 3)
                {
                    this.Close();
                    DeclarationForm DF = new DeclarationForm();
                    DF.Show();
                    // show form
                }
                else if (type == 2)
                {
                   SuccessMessage sm = new SuccessMessage();
                   this.Close();
                   sm.Show();
                   // other things later...
                }
                else
                {
                   SuccessMessage sm = new SuccessMessage();
                   this.Close();
                   sm.Show();
                   // other things later..
                }
            }
            else
            {
                MessageBox.Show("نام کاریری یا رمز عبور اشتباه است");
                this.Controls.Clear();
                this.InitializeComponent();
            }
        }
    }
}
