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
    public partial class Return_Movie : Form
    {
        public Return_Movie()
        {
            InitializeComponent();
        }
        string movieid;
        private void button1_Click(object sender, EventArgs e)
        {
            //Code to Return Movie
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("update Rented_Movies set Returned=@b where RMID=@a", con);
                com.Parameters.AddWithValue("@b", "Yes");
                com.Parameters.AddWithValue("@a", textBox1.Text);
               
                com.ExecuteNonQuery();

                //Code to fetch Movie Id
                SqlCommand com2 = new SqlCommand("select * from Rented_Movies where RMID=@a", con);
                com2.Parameters.AddWithValue("@a", textBox1.Text);
                SqlDataReader reader;
                reader = com2.ExecuteReader();
                while (reader.Read())
                {
                    movieid = reader[1].ToString();
                    //label2.Text = movieid;
                }
                reader.Close();
             
                //Code to update Number of copies available in database
                SqlCommand com1 = new SqlCommand("update Movies set Copies=Copies+1 where Movies_ID=@a", con);
                com1.Parameters.AddWithValue("@a", movieid);

                com1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Movie Returned Successfully");
            }

        }
    }
}
