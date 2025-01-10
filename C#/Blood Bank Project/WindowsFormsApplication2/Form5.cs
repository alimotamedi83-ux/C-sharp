using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("نام کاربری را وارد کنید");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("رمزعبور را وارد کنید");
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;data source=bloodbank.accdb";
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.CommandText = "select count(*) from[manage] where code=? and password=?";
                com.Parameters.AddWithValue("@code", textBox1.Text);
                com.Parameters.AddWithValue("@password",textBox2.Text);
                com.Connection = con;   
                int count=(int)com.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("ورود موفیقت آمیز بود");
                    con.Close();
                    Form3 form = new Form3();
                    this.Hide();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("مشکلی پیش آمده بعدا تلاش کنید");
                    con.Close ();
                }
            }
        }
    }
}
