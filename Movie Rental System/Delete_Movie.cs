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
    public partial class Delete_Movie : Form
    {
        public Delete_Movie()
        {
            InitializeComponent();
        }

        private void Delete_Movie_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movie_RentalDataSet6.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.movie_RentalDataSet6.Movies);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //code to delete movie record
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("delete from Movies where Movies_ID=@e", con);
                com.Parameters.AddWithValue("@e", comboBox1.GetItemText(comboBox1.SelectedItem));
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Movie Deleted Successfully");
            }
        }
    }
}
