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
    public partial class Issue_Movie : Form
    {
        public Issue_Movie()
        {
            InitializeComponent();
        }

        private void Issue_Movie_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movie_RentalDataSet9.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.movie_RentalDataSet9.Customer);
            // TODO: This line of code loads data into the 'movie_RentalDataSet8.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.movie_RentalDataSet8.Movies);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            //using (SqlConnection con = new SqlConnection(con1))
            //{
            //    con.Open();
            //    SqlCommand com = new SqlCommand("select * from Movies where Movies_ID=@a", con);
            //    ;
            //    com.Parameters.AddWithValue("@a", comboBox1.GetItemText(comboBox1.SelectedItem));
            //    SqlDataReader reader;
            //    reader = com.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        label4.Text = reader[2].ToString();
            //    }
            //    //object x;
            //    //x = com.ExecuteScalar();
            //    //label4.Text = x.ToString();
            //    reader.Close();
            //    con.Close();

            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        int years;
        int charges;
        private void button2_Click(object sender, EventArgs e)
        {
            //code to fetch movie details for issuing movie
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("select * from Movies where Movies_ID=@a", con);
                
                com.Parameters.AddWithValue("@a", textBox1.Text);
                SqlDataReader reader;
                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    label4.Text = reader[2].ToString();
                    label6.Text = reader[3].ToString();
                    textBox2.Text=reader[5].ToString();
                  
                    label12.Text = DateTime.Now.AddDays(7).ToString();
                    
                    DateTime release_date=Convert.ToDateTime(label6.Text);

                    DateTime current_date=DateTime.Now;
                    TimeSpan t1 = current_date - release_date;
                    years = (current_date - release_date).Days / 365; // for calculating years
  
        // checking if release date is less than or equal to 5 years
                    if (years <= 5)
                    {
                        label7.Text = "Charges are $5 as movie is released only " + years + " years before";
                        charges = 5;
                    }
                    else
                    {
                        label7.Text = "Charges are $2 as movie is released " + years + " years before";
                        charges = 2;
                    }
                }
              
                reader.Close();
                con.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Code o insert rented movies in Rented_Movies table in Database
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("insert into  Rented_Movies values(@a,@b,@c,@d,@e,@f,@g,@h)", con);

                com.Parameters.AddWithValue("@a", textBox1.Text);
                com.Parameters.AddWithValue("@b", label4.Text);
                com.Parameters.AddWithValue("@c", dateTimePicker1.Value);
                com.Parameters.AddWithValue("@d", Convert.ToDateTime(label12.Text));
                com.Parameters.AddWithValue("@e", comboBox2.GetItemText(comboBox2.SelectedItem));
                com.Parameters.AddWithValue("@f", charges);
                com.Parameters.AddWithValue("@g", "No");
                com.Parameters.AddWithValue("@h", textBox2.Text);
                com.ExecuteNonQuery();

                SqlCommand com1 = new SqlCommand("update Movies set Copies=Copies-1 where Movies_ID=@a", con);
                com1.Parameters.AddWithValue("@a", textBox1.Text);

                com1.ExecuteNonQuery();
                

                con.Close();
                MessageBox.Show("Movie Issued to customer Successfully");




            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}

