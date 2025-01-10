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
    public partial class Form7 : Form
    {
        public string firstname {  get; set; }
        public string lastname {  get; set; }
        public string phone {  get; set; }
        public string type {  get; set; }
        public int ID {  get; set; }
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            textBox1.Text=firstname;
            textBox2.Text=lastname;
            textBox3.Text=type;
            textBox4.Text=phone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;data source=bloodbank.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "update [list] set [fname]=?,[lname]=?,[phon]=?,[type]=? where [ID]=?";
            com.Parameters.AddWithValue("@fname",textBox1.Text);
            com.Parameters.AddWithValue("@lname",textBox2.Text);
            com.Parameters.AddWithValue("@phon",textBox4.Text);
            com.Parameters.AddWithValue("@type",textBox3.Text);
            com.Parameters.AddWithValue("@ID",ID);
            com.Connection = con;
            com.ExecuteNonQuery();
            MessageBox.Show("انجام شد");
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();

        }
    }
}
