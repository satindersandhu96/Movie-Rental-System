using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Movie_Rental_System
{
    public partial class Main_Page : Form
    {
        public Main_Page()
        {
            InitializeComponent();
        }
        string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movie_RentalDataSet10.Rented_Movies' table. You can move, or remove it, as needed.
            this.rented_MoviesTableAdapter.Fill(this.movie_RentalDataSet10.Rented_Movies);
            // TODO: This line of code loads data into the 'movie_RentalDataSet4.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.movie_RentalDataSet4.Customer);
            // TODO: This line of code loads data into the 'movie_RentalDataSet3.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter3.Fill(this.movie_RentalDataSet3.Movies);

           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text=="FirstName")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "FirstName";

                textBox1.ForeColor = Color.Silver;

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "LastName")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;

            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "LastName";

                textBox2.ForeColor = Color.Silver;

            }
        }

       

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Phone")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;

            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Phone";

                textBox3.ForeColor = Color.Silver;

            }

        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {

            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Address";

                richTextBox1.ForeColor = Color.Silver;

            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Address")
            {
                richTextBox1.Text = "";

                richTextBox1.ForeColor = Color.Black;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            //INserting New Customer in Customer Table Records in Database
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("insert into  customer values(@a,@b,@c,@d)", con);

                com.Parameters.AddWithValue("@a", textBox1.Text); //FirstName
                com.Parameters.AddWithValue("@b", textBox2.Text);   //LastName
                com.Parameters.AddWithValue("@c", richTextBox1.Text);  //Address
                com.Parameters.AddWithValue("@d", textBox3.Text);   //Phone Number
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer added successfully");
            }

            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customer", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Customer");
                dataGridView2.DataSource = ds.Tables["Customer"].DefaultView;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Customer uc = new Update_Customer();
            uc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Customer dc = new Delete_Customer();
            dc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Movie dm = new Delete_Movie();
            dm.Show();
        }
        int rating;
        private void button5_Click(object sender, EventArgs e) //Inserting new movie into database
        {
        //Code for Rating of Movie
            if(radioButton3.Checked)
            {
                rating = 1;
            }
            else if (radioButton4.Checked)
            {
                rating = 2;
            }
            else if (radioButton5.Checked)
            {
                rating = 3;
            }
            else if (radioButton6.Checked)
            {
                rating = 4;
            }
            else if (radioButton7.Checked)
            {
                rating = 5;
            }

            //Coding For Inserting New Movie Record in Database
            
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("insert into  Movies values(@a,@b,@c,@d,@e,@f)", con);

                com.Parameters.AddWithValue("@a", rating);  //Rating
                com.Parameters.AddWithValue("@b", richTextBox2.Text); //Movie Title
                com.Parameters.AddWithValue("@c", dateTimePicker1.Value);  //Release Date
                com.Parameters.AddWithValue("@d", textBox7.Text);     //Price
                com.Parameters.AddWithValue("@e", textBox6.Text); //Quantity
                com.Parameters.AddWithValue("@f", textBox4.Text);   //Genre
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Movie added successfully");

               
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Movies", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Movies");
                    dataGridView1.DataSource = ds.Tables["Movies"].DefaultView;
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Update_Movies um = new Update_Movies();
            um.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Issue_Movie im = new Issue_Movie();
            im.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                All_Rented_Movies ar = new All_Rented_Movies();
                ar.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            All_Rented_Movies ar = new All_Rented_Movies();
            ar.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Return_Movie rm = new Return_Movie();
            rm.Show();
        }

        private void Customer_Enter(object sender, EventArgs e)
        {
            //Fetching records using stored procedures
           
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand cmd;
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("customer1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds, "Customer");
                dataGridView2.DataSource = ds.Tables["Customer"].DefaultView;
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {

            //Fetching records using stored procedures
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand cmd;
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("Movies1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds, "Movies");
                dataGridView1.DataSource = ds.Tables["Movies"].DefaultView;
            }
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {

            //Fetching records using stored procedures
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlCommand cmd;
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("Rented_Movies1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds, "Rented_Movies");
                dataGridView3.DataSource = ds.Tables["Rented_Movies"].DefaultView;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Rented_Movies", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Rented_Movies");
                dataGridView3.DataSource = ds.Tables["Rented_Movies"].DefaultView;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Genre")
            {
                textBox4.Text = "";

                textBox4.ForeColor = Color.Black;

            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Genre";

                textBox4.ForeColor = Color.Silver;

            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Copies")
            {
                textBox6.Text = "";

                textBox6.ForeColor = Color.Black;

            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Copies";

                textBox6.ForeColor = Color.Silver;

            }
        }

        private void richTextBox2_Leave(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                richTextBox2.Text = "Title";

                richTextBox2.ForeColor = Color.Silver;

            }
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "Title")
            {
                richTextBox2.Text = "";

                richTextBox2.ForeColor = Color.Black;

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Price")
            {
                textBox7.Text = "";

                textBox7.ForeColor = Color.Black;

            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Price";

                textBox7.ForeColor = Color.Silver;

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM customer", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "customer");
                dataGridView3.DataSource = ds.Tables["customer"].DefaultView;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM movies", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "movies");
                dataGridView3.DataSource = ds.Tables["movies"].DefaultView;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Who_borrows_most wb = new Who_borrows_most();
            wb.Show();
        }
    }
}
