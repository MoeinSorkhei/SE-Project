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
    public partial class SuccessMessage : Form
    {
        public SuccessMessage()
        {
            InitializeComponent();
        }

        private void SuccessMessage_Load(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
