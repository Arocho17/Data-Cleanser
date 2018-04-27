using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRSTDataCleaner
{
    public partial class ViewForm : Form
    {
        //Connection string
        const string connectionString = @"Data Source=(localdb)\Rules;Initial Catalog=Rules;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        int countyId =1; //Changes depending on combo box. Used for SQL Query for rules

        public ViewForm()
        {
            InitializeComponent();
        }

        //Upon the form loading
        private void Form2_Load(object sender, EventArgs e)
        {
            //Creates edit button inside dataGridView
            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            edit.UseColumnTextForButtonValue = true;
            edit.Text = "Edit";
            edit.Name = "Edit";
            dgvEditRules.Columns.Add(edit);

            //Creates delete button inside datagridview
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.UseColumnTextForButtonValue = true;
            delete.Text = "Delete";
            delete.Name = "Delete";
            dgvEditRules.Columns.Add(delete);

            loadData(); //Populates datagridview
            dgvEditRules.Columns[2].Visible = false; // Hides Id column
        }

        //Button to add new rules
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rdoState.Checked == false && rdoCounty.Checked == false) //If user does not select a radio button
            {
                MessageBox.Show("Please choose what kind of rule this is!","Error",MessageBoxButtons.OK); //Lets user know they have to check a radio button
                return;
            }
            if(cmbCounty.Text == String.Empty) //If user does not select a county
            {
                MessageBox.Show("Please choose what county this rule is for", "Error", MessageBoxButtons.OK); //Lets user know they have to choose a county
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to add this rule?", "Adding Rule", MessageBoxButtons.YesNo); //Makes sure user wants to add rule
            if (result == DialogResult.Yes) //If user clicks yes
            {
                insertData(); //Inserts rule
            }
            else
                return;
        }

        //Button to close this window
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Determines if the edit button or delete button was clicked
        private void dgvEditRules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dgvEditRules.Columns["Delete"].Index)) //If delete button was clicked
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this rule?", "Result", MessageBoxButtons.YesNo); //Confirm delete
                if (result == DialogResult.Yes) //If user presses yes
                {
                    deleteData(); //Function to send delete query to database
                    try
                    {
                        dgvEditRules.Rows.RemoveAt(dgvEditRules.CurrentRow.Index); //Remove row from dataGridView
                    }
                    catch(System.InvalidOperationException) //If user tries to delete last row
                    {
                        MessageBox.Show("Cannot delete last row!", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                    return; //If delete button was not clicked nothing happens
            }
            if (e.ColumnIndex == dgvEditRules.Columns["Edit"].Index) //If edit button was clicked
            {
                editData(); //Function to send update query to database
                if (rdoState.Checked) //If state radio button is checked
                {
                    loadCountyRules(1); //Reload the table with state rules
                }
                //loadData(); //Reload datagridview
                else if (rdoCounty.Checked) //If the county radio button is checked
                {
                    loadCountyRules(countyId); //Reload the table with the proper county showing
                }
                else //Nothing is checked
                    loadData(); //Load all the rules
            }

        }

        //Assigns a value to the variable CountyId based on text inside cmbCounty
        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCounty.Text)
            {
                case "Ulster":
                    countyId = 2;
                    break;
                case "Dutchess":
                    countyId = 3;
                    break;
                case "Sullivan":
                    countyId = 4;
                    break;
                case "Columbia":
                    countyId = 5;
                    break;
                case "Albany":
                    countyId = 1004;
                    break;
                case "Allegany":
                    countyId = 1005;
                    break;
                case "Broome":
                    countyId = 1006;
                    break;
                case "Cattaraugus":
                    countyId = 1007;
                    break;
                case "Chemung":
                    countyId = 1008;
                    break;
                case "Chenango":
                    countyId = 1009;
                    break;
                case "Clinton":
                    countyId = 1010;
                    break;
                case "Cortland":
                    countyId = 1011;
                    break;
                case "Delaware":
                    countyId = 1012;
                    break;
                case "Erie":
                    countyId = 1013;
                    break;
                case "Essex":
                    countyId = 1014;
                    break;
                case "Franklin":
                    countyId = 1015;
                    break;
                case "Fulton":
                    countyId = 1016;
                    break;
                case "Genesee":
                    countyId = 1017;
                    break;
                case "Greene":
                    countyId = 1018;
                    break;
                case "Hamilton":
                    countyId = 1019;
                    break;
                case "Herkimer":
                    countyId = 1020;
                    break;
                case "Jefferson":
                    countyId = 1021;
                    break;
                case "Lewis":
                    countyId = 1022;
                    break;
                case "Livingston":
                    countyId = 1023;
                    break;
                case "Madison":
                    countyId = 1024;
                    break;
                case "Monroe":
                    countyId = 1025;
                    break;
                case "Montgomery":
                    countyId = 1026;
                    break;
                case "Nassau":
                    countyId = 1027;
                    break;
                case "Niagara":
                    countyId = 1028;
                    break;
                case "New York City":
                    countyId = 1029;
                    break;
                case "Oneida":
                    countyId = 1030;
                    break;
                case "Onondaga":
                    countyId = 1030;
                    break;
                case "Ontario":
                    countyId = 1031;
                    break;
                case "Orange":
                    countyId = 1032;
                    break;
                case "Orleans":
                    countyId = 1033;
                    break;
                case "Oswego":
                    countyId = 1034;
                    break;
                case "Otsego":
                    countyId = 1035;
                    break;
                case "Putnam":
                    countyId = 1036;
                    break;
                case "Rensselaer":
                    countyId = 1037;
                    break;
                case "Rockland":
                    countyId = 1037;
                    break;
                case "Saint Lawrence":
                    countyId = 1038;
                    break;
                case "Saratoga":
                    countyId = 1039;
                    break;
                case "Schenectady":
                    countyId = 1040;
                    break;
                case "Schoharie":
                    countyId = 1041;
                    break;
                case "Schuyler":
                    countyId = 1042;
                    break;
                case "Seneca":
                    countyId = 1043;
                    break;
                case "Steuben":
                    countyId = 1044;
                    break;
                case "Suffolk":
                    countyId = 1045;
                    break;
                case "Tioga":
                    countyId = 1046;
                    break;
                case "Tompkins":
                    countyId = 1047;
                    break;
                case "Warren":
                    countyId = 1048;
                    break;
                case "Washington":
                    countyId = 1049;
                    break;
                case "Wayne":
                    countyId = 1050;
                    break;
                case "Westchester":
                    countyId = 1051;
                    break;
                case "Wyoming":
                    countyId = 1052;
                    break;
                case "Yates":
                    countyId = 1053;
                    break;
            }
            loadCountyRules(countyId); //Shows proper rule based on what is chosen inside combobox
        }

        //Determines if the comboBox is visible
        private void radioBtnCounty_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCounty.Checked)
                cmbCounty.Visible = true;
            else
                cmbCounty.Visible = false;
        }

        //Determines when state rules are loaded
        private void rdoState_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoState.Checked)
            {
                DataTable dt = new DataTable();
                using (var cn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("Select r.Id,County, r.[Replace], ReplaceWith FROM County as c, [Rule] as r where c.Id = r.CountyId AND CountyId = 1", cn))
                    {
                        cn.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader); //Loads table with state rules
                            dgvEditRules.DataSource = dt; //Sets source of datagridview to the datatable with the rules
                        }
                        cn.Close();
                    }
                }
                //Sets index of buttons
                dgvEditRules.Columns["Edit"].DisplayIndex = 5; 
                dgvEditRules.Columns["Delete"].DisplayIndex = 5;
                cmbCounty.Text = String.Empty;
            }
        }

        //Button to reload all rules to the table
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            loadData();
            rdoState.Checked = false; //Unchecks state radio button
            rdoCounty.Checked = false; //Unchecks county radio button
        }

        //Function to insert new rules
        private void insertData()
        {
            string Replace = txtBoxReplace.Text;
            string ReplaceWith = txtBoxWith.Text;
            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using(var insert = new SqlCommand("INSERT INTO [dbo].[Rule] (CountyId, Replace, ReplaceWith) VALUES (@CountyId, @Replace, @ReplaceWith)", cn))
                {
                    if (rdoCounty.Checked) //If county radio button is checked
                    {
                        switch (cmbCounty.Text) //Sets correct values to countyId
                        {
                            case "Ulster":
                                countyId = 2;
                                break;
                            case "Dutchess":
                                countyId = 3;
                                break;
                            case "Sullivan":
                                countyId = 4;
                                break;
                            case "Columbia":
                                countyId = 5;
                                break;
                            case "Albany":
                                countyId = 1004;
                                break;
                            case "Allegany":
                                countyId = 1005;
                                break;
                            case "Broome":
                                countyId = 1006;
                                break;
                            case "Cattaraugus":
                                countyId = 1007;
                                break;
                            case "Chemung":
                                countyId = 1008;
                                break;
                            case "Chenango":
                                countyId = 1009;
                                break;
                            case "Clinton":
                                countyId = 1010;
                                break;
                            case "Cortland":
                                countyId = 1011;
                                break;
                            case "Delaware":
                                countyId = 1012;
                                break;
                            case "Erie":
                                countyId = 1013;
                                break;
                            case "Essex":
                                countyId = 1014;
                                break;
                            case "Franklin":
                                countyId = 1015;
                                break;
                            case "Fulton":
                                countyId = 1016;
                                break;
                            case "Genesee":
                                countyId = 1017;
                                break;
                            case "Greene":
                                countyId = 1018;
                                break;
                            case "Hamilton":
                                countyId = 1019;
                                break;
                            case "Herkimer":
                                countyId = 1020;
                                break;
                            case "Jefferson":
                                countyId = 1021;
                                break;
                            case "Lewis":
                                countyId = 1022;
                                break;
                            case "Livingston":
                                countyId = 1023;
                                break;
                            case "Madison":
                                countyId = 1024;
                                break;
                            case "Monroe":
                                countyId = 1025;
                                break;
                            case "Montgomery":
                                countyId = 1026;
                                break;
                            case "Nassau":
                                countyId = 1027;
                                break;
                            case "Niagara":
                                countyId = 1028;
                                break;
                            case "New York City":
                                countyId = 1029;
                                break;
                            case "Oneida":
                                countyId = 1030;
                                break;
                            case "Onondaga":
                                countyId = 1030;
                                break;
                            case "Ontario":
                                countyId = 1031;
                                break;
                            case "Orange":
                                countyId = 1032;
                                break;
                            case "Orleans":
                                countyId = 1033;
                                break;
                            case "Oswego":
                                countyId = 1034;
                                break;
                            case "Otsego":
                                countyId = 1035;
                                break;
                            case "Putnam":
                                countyId = 1036;
                                break;
                            case "Rensselaer":
                                countyId = 1037;
                                break;
                            case "Rockland":
                                countyId = 1037;
                                break;
                            case "Saint Lawrence":
                                countyId = 1038;
                                break;
                            case "Saratoga":
                                countyId = 1039;
                                break;
                            case "Schenectady":
                                countyId = 1040;
                                break;
                            case "Schoharie":
                                countyId = 1041;
                                break;
                            case "Schuyler":
                                countyId = 1042;
                                break;
                            case "Seneca":
                                countyId = 1043;
                                break;
                            case "Steuben":
                                countyId = 1044;
                                break;
                            case "Suffolk":
                                countyId = 1045;
                                break;
                            case "Tioga":
                                countyId = 1046;
                                break;
                            case "Tompkins":
                                countyId = 1047;
                                break;
                            case "Warren":
                                countyId = 1048;
                                break;
                            case "Washington":
                                countyId = 1049;
                                break;
                            case "Wayne":
                                countyId = 1050;
                                break;
                            case "Westchester":
                                countyId = 1051;
                                break;
                            case "Wyoming":
                                countyId = 1052;
                                break;
                            case "Yates":
                                countyId = 1053;
                                break;
                        }
                    }
                    insert.Parameters.AddWithValue("@CountyId", countyId); //Gives value of CountyId to query
                    insert.Parameters.AddWithValue("@Replace", Replace); //Gives value of Replace to query
                    insert.Parameters.AddWithValue("@ReplaceWith", ReplaceWith); //Gives value of ReplaceWith to query

                    insert.ExecuteNonQuery(); //Executes the query

                    //Resets the text boxes
                    txtBoxReplace.Text = String.Empty;
                    txtBoxWith.Text = String.Empty;
                }
            }
            loadCountyRules(countyId); //Reload dataGridview to show new rule
        }
        //Function to load the data to the table
        private void loadData()
        {
            DataTable dt = new DataTable(); //DataTable to hold all rules

            using (var cn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT r.Id,County, r.[Replace], ReplaceWith FROM County as c, [Rule] as r where c.Id = r.CountyId", cn))//var cmd = new SqlCommand("Select * From [dbo].[Rule]", cn))
                {
                    cn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader); //Loads table with rules
                        dgvEditRules.DataSource = dt; //Sets source of dataGridView to the DataTable
                    }
                }
            }
            //Sets the index of delete and edit buttons
            dgvEditRules.Columns["Edit"].DisplayIndex = 5;
            dgvEditRules.Columns["Delete"].DisplayIndex = 5;
        }
        //Function to delete data from the database
        private void deleteData()
        {
            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (var delete = new SqlCommand("DELETE FROM [dbo].[Rule] WHERE Id = @Id", cn))
                {
                    delete.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = dgvEditRules.CurrentRow.Cells["Id"].Value; //Adds value for id to query
                    delete.ExecuteNonQuery(); //Execute query
                }
            }

        }
        //Function to edit the rules
        private void editData()
        {
            //Converts the value of Id in the table to an integer value
            int id = Convert.ToInt32(dgvEditRules.CurrentRow.Cells["Id"].Value.ToString());
            EditForm f3 = new EditForm(id); //New instance of EditForm to pass the value of Id
            f3.txtReplace.Text = dgvEditRules.CurrentRow.Cells["Replace"].Value.ToString(); //Sets the text of txtReplace to rule user clicked
            f3.txtNew.Text = dgvEditRules.CurrentRow.Cells["ReplaceWith"].Value.ToString(); //Sets the text of txtNew to rule user clicked
            f3.ShowDialog(); //Shows the form
        }
        //Function to load county rules based on comboBox
        private void loadCountyRules(int id)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("Select r.Id,County, r.[Replace], ReplaceWith FROM County as c, [Rule] as r where c.Id = r.CountyId AND CountyId = @CountyId", cn))
                {
                    cn.Open();
                    cmd.Parameters.AddWithValue("@CountyId", id); //Add value of CountyId variable to query
                    using (var reader = cmd.ExecuteReader())
                    {

                        dt.Load(reader); //Loads appropriate rules into DataTable
                        dgvEditRules.DataSource = dt; //Sets source of dataGridView to DataTable
                    }
                    cn.Close();
                }
            }
            //Sets the position of the edit and delete buttons
            dgvEditRules.Columns["Edit"].DisplayIndex = 5;
            dgvEditRules.Columns["Delete"].DisplayIndex = 5;
        }

    }
}
