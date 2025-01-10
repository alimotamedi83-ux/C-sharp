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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bloodbankDataSet1.list' table. You can move, or remove it, as needed.
            this.listTableAdapter1.Fill(this.bloodbankDataSet1.list);
            // TODO: This line of code loads data into the 'bloodbankDataSet.list' table. You can move, or remove it, as needed.
            this.listTableAdapter.Fill(this.bloodbankDataSet.list);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var qsl = MessageBox.Show("از این عمل اطمینان دارید؟", "warning", MessageBoxButtons.YesNo);
            if (qsl == DialogResult.Yes) 
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    OleDbConnection con = new OleDbConnection();
                    con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;data source=bloodbank.accdb";
                    con.Open();
                    OleDbCommand com = new OleDbCommand();
                    com.CommandText = "delete from [list] where [ID]=?";
                    com.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value);
                    com.Connection = con;   
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 edit = new Form7();
            edit.firstname=dataGridView1.CurrentRow.Cells["fname"].Value.ToString();
            edit.lastname=dataGridView1.CurrentRow.Cells["lname"].Value.ToString();
            edit.phone = dataGridView1.CurrentRow.Cells["phon"].Value.ToString();
            edit.type = dataGridView1.CurrentRow.Cells["type"].Value.ToString();
            edit.ID=(int)dataGridView1.CurrentRow.Cells["ID"].Value;
            this.Hide();
            edit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            this.Hide();
            form8.ShowDialog();
        }
    }
}
