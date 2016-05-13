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
    public partial class MainWindow : Form
    {
        private List<KeyValuePair<string, string>> users;
        public MainWindow(List< KeyValuePair<string, string> > Users)
        {
            InitializeComponent();
            users = Users;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginWindow LW = new LoginWindow(users, 1);
            LW.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginWindow LW = new LoginWindow(users, 2);
            LW.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginWindow LW = new LoginWindow(users, 3);
            LW.Show();
            this.Hide();
        }
    }
}
