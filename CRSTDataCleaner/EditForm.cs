using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRSTDataCleaner
{
    public partial class EditForm : Form
    {
        //Connection String
        const string connectionString = @"Data Source=(localdb)\Rules;Initial Catalog=Rules;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        int id1; //Holds the id passed to the form

        public EditForm(int id) //New constructor to accept the value of Id
        {
            id1 = id; //Sets the value of Id to the global value for use later
            InitializeComponent();
        }

        public EditForm()
        {
            InitializeComponent();
        }

        //Button to close the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Button to initiate the query
        private void btnFinished_Click(object sender, EventArgs e)
        {
            updateData();
            this.Close();
        }

        //Function to send the update query
        private void updateData()
        {
            // Variables to hold the text in each textBox
            string replace = txtReplace.Text; 
            string replaceWith = txtNew.Text;

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (var update = new SqlCommand("UPDATE [dbo].[Rule] SET Replace = @Replace, ReplaceWith = @ReplaceWith WHERE Id = @Id", cn))
                {
                    update.Parameters.AddWithValue("@Replace", replace); //Gives the update query the value of Replace
                    update.Parameters.AddWithValue("@ReplaceWith", replaceWith); //Gives the update query the value of ReplaceWith
                    update.Parameters.AddWithValue("@Id", id1); //Gives the update query the value of Id

                    update.ExecuteNonQuery(); //Execute the query
                }
            }

        }
    }
}
