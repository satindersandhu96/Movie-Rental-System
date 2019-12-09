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
    public partial class Update_Movies : Form
    {
        public Update_Movies()
        {
            InitializeComponent();
        }

        private void Update_Movies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movie_RentalDataSet7.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.movie_RentalDataSet7.Movies);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Code to update movie details
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("update Movies set Title=@a, Rating=@b, Release_Date=@c, Rental_Cost=@d, Genre=@e, Copies=@f where Movies_ID=@g", con);
                com.Parameters.AddWithValue("@g", comboBox1.GetItemText(comboBox1.SelectedItem));
                com.Parameters.AddWithValue("@a", richTextBox1.Text);
                com.Parameters.AddWithValue("@b", textBox2.Text);
                com.Parameters.AddWithValue("@c", Convert.ToDateTime(textBox3.Text));
                com.Parameters.AddWithValue("@d", textBox1.Text);
                com.Parameters.AddWithValue("@e", textBox5.Text);
                com.Parameters.AddWithValue("@f", textBox4.Text);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Movie Details are Updated Successfully");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Code to fetch movie details for updating purpose
             string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("select Rating,Title,Release_Date,Rental_Cost,Copies,Genre from Movies where Movies_ID=@a", con);
                com.Parameters.AddWithValue("@a", comboBox1.GetItemText(comboBox1.SelectedItem));
                SqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    richTextBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[0].ToString();
                    textBox3.Text = reader[2].ToString();
                    textBox1.Text = reader[3].ToString();
                    textBox5.Text = reader[5].ToString();
                    textBox4.Text = reader[4].ToString();
                }
                reader.Close();
                con.Close();
            }
        }
    }
}
