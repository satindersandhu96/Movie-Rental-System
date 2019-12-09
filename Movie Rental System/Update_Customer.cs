using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Movie_Rental_System
{
    public partial class Update_Customer : Form
    {
        public Update_Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Code to update record of customer
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("update customer set FirstName=@a, LastName=@b, Address=@c, Phone=@d where CustomerID=@e", con);
                com.Parameters.AddWithValue("@a", textBox1.Text);
                com.Parameters.AddWithValue("@b", textBox2.Text);
                com.Parameters.AddWithValue("@c", richTextBox1.Text);
                com.Parameters.AddWithValue("@d", textBox3.Text);
                com.Parameters.AddWithValue("@e", textBox4.Text);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer profile Updated successfully");
            }
        }
        private void Update_Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movie_RentalDataSet5.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.movie_RentalDataSet5.Customer);

        }

       
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //code to fetch customer details
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("select FirstName,LastName,Address,Phone from customer  where customerID=@a", con);
                com.Parameters.AddWithValue("@a", textBox4.Text);
                SqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[0].ToString();
                    textBox2.Text = reader[1].ToString();
                    richTextBox1.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();

                }
                reader.Close();
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}