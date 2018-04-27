using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CRSTDataCleaner
{
    public partial class MainForm : Form
    {
        const string connectionString = @"Data Source=(localdb)\Rules;Initial Catalog=Rules;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        int countyId; //Changes depending on combo box. Used for SQL Query for rules
        List<string> Temp = new List<string>();//Temporary list to convert database columns to proper arrays
        String[] Replace;//Holds Replace column from database
        String[] ReplaceWith;//Holds ReplaceWith column from database

        public MainForm()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen)); //Variable used to start the splash screen
            t.Start(); //Start splash screen
            Thread.Sleep(500); //How long splash screen will appear (milliseconds)
            InitializeComponent();
            t.Abort(); //Terminates splash screen
        }
        //Method to create splash screen
        public void SplashScreen()
        {
            Application.Run(new SplashScreen()); //Runs the splash screen
        }
        
        //Button to browse for files
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); //Opens the openFileDialog
            string fileName = openFileDialog.FileName; //String to hold the file path
            txtBoxPath.Text = fileName; //Puts the file path inside the text box
        }
        
        //Button to open the edit rules form
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ViewForm viewForm = new ViewForm();
            viewForm.ShowDialog();
        }
        
        //Assigns countyId values based upon selected text
        private void comboBoxCounty_SelectedIndexChanged(object sender, EventArgs e)
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
        }
        
        //Button to generate the file
        private void btnGenerate_Click(object sender, EventArgs e)
        {

            if (cmbCounty.Text == "County") //If user did not choose a county 
            {
                MessageBox.Show("Please choose a county!", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (txtBoxPath.Text == String.Empty) //If user did not choose a file
            {
                MessageBox.Show("Please choose a file!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to generate?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) //If user chooses yes
                {
                    cleanFile();
                }
                else
                    return;

            }
        }

        //Fills the Replace array with values
        private void fillReplace()
        {
            DataTable dt = new DataTable(); //Data Table created to hold rules
            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT Replace FROM [dbo].[Rule] WHERE CountyId IN (1,@CountyId)", cn))
                {
                    cmd.Parameters.AddWithValue("@CountyId", countyId); //Sets paramater for CountyId to the value of the variable
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader); //Loads each rule into the table
                    }
                    for (int i = 0; i < dt.Rows.Count; i++) //Iterates through each row in the table
                        Temp.Add(dt.Rows[i]["Replace"].ToString()); //Populates list with ReplaceWith rules
                    Replace = Temp.ToArray(); //Converts the list to an array and stores it
                    Temp.Clear(); //Clears the list for future use
                }
            }
        }

        //Fills the ReplaceWith with values
        private void fillReplaceWith()
        {
            DataTable dt = new DataTable();  //Will hold ReplaceWith Rules
            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open(); //Open connection to database
                using (var cmd = new SqlCommand("SELECT ReplaceWith FROM [dbo].[Rule] WHERE CountyId IN (1,@CountyId)", cn))
                {
                    cmd.Parameters.AddWithValue("@CountyId", countyId); //Sets the paramater for CountyId to the value of the variable
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader); //Loads rules into Data Table
                    }
                    for (int i = 0; i < dt.Rows.Count; i++) //Iterates through each row in the table
                        Temp.Add(dt.Rows[i]["ReplaceWith"].ToString()); //Adds each ReplaceWith rule into the list
                    ReplaceWith = Temp.ToArray(); //Converts the list to an array
                    Temp.Clear(); //Clears the list for any future use
                }
            }
        }

        //Cleans the file using the stored rules
        private void cleanFile()
        {
            fillReplace();
            fillReplaceWith();
            try
            {
                StreamReader sr = new StreamReader(txtBoxPath.Text); // Reads file that is in the location of the textbox
                DataTable final = new DataTable(); //Table to hold the final values
                string[] columnNames = sr.ReadLine().Split('\t'); //Get Column names from first line of file

                //Add columns based on the first row of the text file
                foreach (string c in columnNames)
                {
                    final.Columns.Add(c); //Adds each column heading
                }

                string newline; //Variable for the while loop condition
                TextInfo textInfo = new CultureInfo("en-us", false).TextInfo; //Variable used to make all text proper case
                while ((newline = sr.ReadLine()) != null) //While the StreamReader still has lines to read
                {
                    DataRow dr = final.NewRow(); //Where the rows will be stored
                    string[] values = newline.Split('\t'); //Holds each line of the text file
                    for (int i = 0; i < values.Length; i++)//Loop to add rows based on the newly fixed tokens in the array
                    {
                        values[i] = textInfo.ToTitleCase(values[i].ToLower()); //Sets all text to proper case
                        if (values[i].Contains(" ")) // If the current value has a space
                        {
                            var x = values[i].Split(' '); //Splits values at current position by space
                            for (int k = 0; k < x.Length; k++) //Iterates through each split values
                            {
                                for (int j = 0; j < Replace.Length; j++) //Loop to iterate through replace values
                                {
                                    if (x[k] == Replace[j]) //If a token equals a replace value
                                    {
                                        x[k] = ReplaceWith[j]; //Replace token with correct value
                                    }
                                }
                            }
                            values[i] = String.Join(" ", x); //Puts value back together
                        }
                        for (int j = 0; j < Replace.Length; j++) //Loop to iterate through replace values
                        {
                            if (values[i] == Replace[j]) //If a token equals a replace value
                            {
                                values[i] = ReplaceWith[j]; //Replace token with correct value
                            }
                        }
                        dr[i] = values[i];//Adds each row
                    }
                    final.Rows.Add(dr); //Add rows to the data table
                }

                DataColumn concat1 = new DataColumn("concatenated_address_1"); //Create new column for table
                concat1.Expression = string.Format("{0}+ ' '+{1}+' '+{2}+' '+{3}+' '+{4}+' '+{5}+' '+{6}", "mail_st_nbr", "prefix_dir", "mail_st_rte", "owner_mail_st_suff", "post_dir", "owner_unit_name", "owner_unit_nbr");
                final.Columns.Add(concat1);//Adds newly concatenated column
                concat1.SetOrdinal(13);//Sets the proper position

                DataColumn concat2 = new DataColumn("concatenated_address_2");
                concat2.Expression = "IIF([po_box]='', '','PO Box ') + [po_box]"; //If po_box is blank it will not add 'PO Box' to the row
                final.Columns.Add(concat2); //Adds newly made column
                concat2.SetOrdinal(14); //Sets proper position

                writeFile(columnNames, final);
            }
            catch (System.IO.IOException) //If the input file is being used by another process
            {
                MessageBox.Show("Input file being used by another process, could not generate", "Error", MessageBoxButtons.OK);

            }
        }

        //Writes file to new text file
        private void writeFile(string[] array,DataTable dt)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(txtBoxPath.Text + " CLEANED"))
                {
                    for (int i = 0; i < dt.Columns.Count - 1; i++)//Iterate through columns
                        sw.Write(dt.Columns[i].ColumnName + "\t");//Write column names to file
                    sw.WriteLine(); //Separate column headers from other ros
                    foreach (DataRow row in dt.Rows)//Iterate through each row
                    {
                        sw.WriteLine(String.Join("\t", row.ItemArray)); //Write each row to file
                    }
                }
                MessageBox.Show("File saved as: " + txtBoxPath.Text + " CLEANED in the same location as original file", "Result", MessageBoxButtons.OK);
                txtBoxPath.Text = String.Empty; //Resets text box
                cmbCounty.Text = "County"; //Resets County box
            }
            catch (System.IO.IOException) //If Output file is being used
            {
                MessageBox.Show("Output file being used by another process, could not generate", "Error", MessageBoxButtons.OK);
            }
        }
    }
}