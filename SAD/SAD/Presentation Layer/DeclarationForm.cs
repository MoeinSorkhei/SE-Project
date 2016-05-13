using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SAD
{
    public partial class DeclarationForm : Form
    {
        public DeclarationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MerchandiseInfo MI = new MerchandiseInfo();
            MI.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("اظهارنامه با موفقیت ثبت شد");
            //string[] lines = {textBox1.Text,
            //                  textBox2.Text,
            //                  textBox3.Text,
            //                  textBox4.Text,
            //                  textBox5.Text,
            //                  textBox6.Text,
            //                  textBox7.Text,
            //                  textBox8.Text,
            //                  textBox9.Text,
            //                  "$$$"};
            //System.IO.File.WriteAllLines(@"C:\Users\monsieur maaz\Documents\Visual Studio 2010\Projects\SAD\SAD\Declarations.txt", lines);
            string path = @"C:\Users\monsieur maaz\Documents\Visual Studio 2010\Projects\SAD\SAD\Declarations.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(textBox1.Text);
                sw.WriteLine(textBox2.Text);
                sw.WriteLine(textBox3.Text);
                sw.WriteLine(textBox4.Text);
                sw.WriteLine(textBox5.Text);
                sw.WriteLine(textBox6.Text);
                sw.WriteLine(textBox7.Text);
                sw.WriteLine(textBox8.Text);
                sw.WriteLine(textBox9.Text);
                sw.WriteLine("$$$");
            }
            this.Controls.Clear();
            this.InitializeComponent();
            // DeclarationForm DF = new DeclarationForm();
            // DF.Show();
        }

        private void DeclarationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
