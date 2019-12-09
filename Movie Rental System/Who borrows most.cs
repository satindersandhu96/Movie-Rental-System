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
    public partial class Who_borrows_most : Form
    {
        public Who_borrows_most()
        {
            InitializeComponent();
        }

        private void Who_borrows_most_Load(object sender, EventArgs e)
        {
            string con1 = ConfigurationManager.ConnectionStrings["Movie_Rental_System.Properties.Settings.Movie_RentalConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(con1))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Customer_IDFK as Customer_Id,COUNT(Customer_IDFK) as No_of_Times FROM Rented_Movies GROUP BY Customer_IDFK HAVING COUNT(*) > 1", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "customer");
                dataGridView1.DataSource = ds.Tables["customer"].DefaultView;

                con.Close();
            }
        }
    }
}
