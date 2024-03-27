using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prtokol_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int ID = 0;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LTDE9FF;Initial Catalog=Customer;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Table2";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-LTDE9FF;Initial Catalog=Customer;Integrated Security=True;Encrypt=False;"))
            {
                string sqlQuery = "insert into dbo.Table2 (firstName, lastName, city, address) values(@firstName, @lastName, @city, @address)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {

                 cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
                   cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
                   cmd.Parameters.AddWithValue("@city", textBox3.Text);
                    cmd.Parameters.AddWithValue("@address", textBox4.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                   con.Close();
                  if (i != 0)
                  {
                  MessageBox.Show( "Data Saved");
                  }
                    
                }
            }

        }


        private void DisplayData()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-LTDE9FF;Initial Catalog=Customer;Integrated Security=True;Encrypt=False;"))
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("select * from Table2", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            ID = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-LTDE9FF;Initial Catalog=Customer;Integrated Security=True;Encrypt=False;"))
                {
                    string query = "DELETE Table2 WHERE cusid=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted Successfully");
                        DisplayData();
                        ClearData();
                    }


                }
            
        }
        

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
