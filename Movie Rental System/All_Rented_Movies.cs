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
    public partial class All_Rented_Movies : Form
    {
        public All_Rented_Movies()
        {
            InitializeComponent();
        }

        private void All_Rented_Movies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movie_RentalDataSet11.Rented_Movies' table. You can move, or remove it, as needed.
            this.rented_MoviesTableAdapter.Fill(this.movie_RentalDataSet11.Rented_Movies);
           
            
            
            //code to display most viewed movie using group by and having clause

            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT Movies_Title,COUNT(*) FROM Rented_Movies GROUP BY Movies_Title HAVING COUNT(*) > 1", con);
                
                SqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    label2.Text= reader[0].ToString();
                    label3.Text = reader[1].ToString();

                }
                reader.Close();

               
            }
           
        }
    }
}
