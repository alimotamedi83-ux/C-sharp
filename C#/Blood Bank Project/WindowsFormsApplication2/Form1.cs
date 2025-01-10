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
    public partial class Form1 : Form
    {
        public Form1()
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
            if (textBox1.Text == "")
            {
                MessageBox.Show("نام خود را وارد کنید");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("نام خانوادگی خود را وارد کتید");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("شماره تلفن خود را وارد کنید");
            }
            else if(textBox3.Text=="")
            {
                MessageBox.Show("گروه خونی خود را وارد کنید");
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=bloodbank.accdb";
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.CommandText = "insert into [list]([fname],[lname],[phon],[type]) values(?,?,?,?)";
                com.Parameters.AddWithValue("@fname", textBox1.Text);
                com.Parameters.AddWithValue("@lname", textBox2.Text);
                com.Parameters.AddWithValue("@phone", textBox4.Text);
                com.Parameters.AddWithValue("@type", textBox3.Text);
                com.Connection = con;
                int count = (int)com.ExecuteNonQuery();
                if (count == 1)
                {
                    MessageBox.Show("اطلاعات با موفیقت ثبت شد");
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.ShowDialog();
                    con.Close();
                    
                    
                }
                else
                {
                    MessageBox.Show("مشکلی پیش آمده بعدا تلاش کنید");
                    con.Close();
                }
            }
        }
    }
}
