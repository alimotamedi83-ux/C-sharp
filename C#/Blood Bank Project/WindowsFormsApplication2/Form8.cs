using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
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
                con.Close();
                Form3 form3 = new Form3();
                this.Hide();
                form3.ShowDialog();

            }
            else
            {
                MessageBox.Show("مشکلی پیش آمده بعدا تلاش کنید");
                con.Close();
                Application.Exit();
            }
        }
    }
}
