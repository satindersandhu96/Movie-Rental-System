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
    public partial class Delete_Customer : Form
    {
        public Delete_Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Data Source=.\SQLEXPRESS;Initial Catalog=Movie_Rental;Integrated Security=True
            //code to delete customer information
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("delete from customer where CustomerID=@e", con);
                com.Parameters.AddWithValue("@e", textBox1.Text);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Profile Deleted Successfully");
            }
        }
    }
}
