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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("نام خود را وارد کنید");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("نام خانوادگی خود را وارد کنید");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("شماره تلفن خود را وارد کنید");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("کد پرسنلی خود را وارد کنید");
            }
            else if(textBox6.Text == "")
            {
                MessageBox.Show("رمزعبور خود را وارد کنید");
            }
            else if(textBox7.Text == "")
            {
                MessageBox.Show("تکرار رمزعبور را وارد کنید");
            }
            else if (textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("تکرار پسورد صحیح نیست");
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;data source=bloodbank.accdb";
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "insert into [manage]([fname],[lname],[phon],[code],[password]) values(?,?,?,?,?)";
                cmd.Parameters.AddWithValue("@fname",textBox1.Text);
                cmd.Parameters.AddWithValue("@lname",textBox2.Text);
                cmd.Parameters.AddWithValue("@phon",textBox4.Text);
                cmd.Parameters.AddWithValue("@code",textBox5.Text);
                cmd.Parameters.AddWithValue("@password",textBox7.Text);
                cmd.Connection = con;
                int count=(int)cmd.ExecuteNonQuery();
                if (count > 0) 
                {
                    MessageBox.Show("اطلاعات ثبت شد");
                    con.Close();
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.ShowDialog();
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
