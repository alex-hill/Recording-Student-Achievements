using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording_Student_Achievements
{
    public partial class IndividualReport : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public IndividualReport()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop

        }

        private void optionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (optionBox.SelectedIndex)
            {
                case 1:
                    userNSN.Visible = true;
                    nsnNumber.Visible = true;

                    userLastName.Visible = false;
                    userFirstName.Visible = false;
                    famName.Visible = false;
                    firName.Visible = false;

                    generateBttn.Visible = true;
                    break;
                case 2:
                    userNSN.Visible = false;
                    nsnNumber.Visible = false;

                    userLastName.Visible = true;
                    userFirstName.Visible = true;
                    famName.Visible = true;
                    firName.Visible = true;

                    generateBttn.Visible = true;
                    break;
            }
        }

        private void generateBttn_Click(object sender, EventArgs e)
        {
            String nsn, firstName, lastName = null;
            if (optionBox.SelectedIndex == 1)
            {
                if (!string.IsNullOrWhiteSpace(userNSN.Text))
                {
                    nsn = userNSN.Text;
                    checkValue(nsn, null, null);
                }
                else
                {
                    MessageBox.Show("Please enter an NSN number", "NSN error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (optionBox.SelectedIndex == 2)
            {
                if (!string.IsNullOrWhiteSpace(userLastName.Text) && !string.IsNullOrWhiteSpace(userFirstName.Text))
                {
                    firstName = userFirstName.Text;
                    lastName = userLastName.Text;
                    checkValue(null, firstName, lastName);
                }
                else
                {
                    MessageBox.Show("Please enter a first and family name", "Name error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkValue(String nsn, String firstName, String lastName)
        {
            OleDbCommand cmd = new OleDbCommand();
            // 1 means firstName and lastName being used
            // 2 means nsn being used
            int check = 0;

            if (firstName != null && lastName != null)
            {
                cmd = new OleDbCommand("SELECT [s.Family Name Legal], [s.Preferred Name], [s.Room Number], [s.Gender], "
                + "[r.Final Assessment Level], [m.KF1], [m.KF2], [m.NS1], "
                + "[m.NS2], [se.General Comment], [se.Next Room Number], [m.Overall Assessment], "
                + "[w.Initial Assessment], [w.Final Assessment], [m.Final Assessment Method], [r.Final Assessment Method]"
                + "FROM (((([Student] s "
                + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "
                + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN"
                + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"
                + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "

                + "WHERE [Family Name Legal] = '" + lastName + "' AND [First Name Legal] = '" + firstName + "'; ");
                cmd.Connection = conn;
                check = 1;
            }
            else if (nsnNumber != null)
            {
                cmd = new OleDbCommand("SELECT [s.Family Name Legal], [s.Preferred Name], [s.Room Number], [s.Gender], "
                + "[r.Final Assessment Level], [m.KF1], [m.KF2], [m.NS1], "
                + "[m.NS2], [se.General Comment], [se.Next Room Number], [m.Overall Assessment], "
                + "[w.Initial Assessment], [w.Final Assessment], [m.Final Assessment Method], [r.Final Assessment Method]"
                + "FROM (((([Student] s "

                        + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN])"

                        + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"

                        + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN])"

                + "WHERE s.[NSN] = '" + Int32.Parse(nsn) + "'; ");
                cmd.Connection = conn;
                check = 2;
            }

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    OleDbDataReader reader = cmd.ExecuteReader();
                    
                    if (!reader.HasRows)
                    {
                        if (check == 1)
                        {
                            MessageBox.Show("That Name does not exist", "Name does not exist",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (check == 2)
                        {
                            MessageBox.Show("That NSN does not exist", "NSN does not exist",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        accessDB(reader);
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }

            this.Close();
        }

        private void accessDB(OleDbDataReader reader)
        {

            ArrayList values = new ArrayList();


            // Write to word file

            //select template file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Word files (*.docx)|*.docx|All files (*)|*.*";
            openFileDialog1.InitialDirectory = "Desktop";
            string file = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
            }

            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();

            //gets the template file
            document = application.Documents.Add(Template: @file);

            //opens the document to see changes
            application.Visible = true;

            //iterates through each mergefield in the document
            Console.WriteLine(document.StoryRanges.Count);
            foreach (Microsoft.Office.Interop.Word.Range range in document.StoryRanges)
            {
                Console.WriteLine(range.Fields.Count);
                foreach (Microsoft.Office.Interop.Word.Field field in range.Fields)
                {
                    //checks the field name looking for correct field
                    if (field.Code.Text.Contains("First Name"))
                    {
                        //selects the field
                        field.Select();
                        //types the value (cannot be empty string)
                        application.Selection.TypeText("Tae");
                    }
                    else if (field.Code.Text.Contains("This Year"))
                    {
                        field.Select();
                        application.Selection.TypeText("2016");
                    }
                    else if (field.Code.Text.Contains("Next Year"))
                    {
                        field.Select();
                        application.Selection.TypeText("2017");
                    }
                    else if (field.Code.Text.Contains("General Comment"))
                    {
                        field.Select();
                        application.Selection.TypeText("This is the general comment");
                    }
                    else if (field.Code.Text.Contains("Placement Statement"))
                    {
                        field.Select();
                        application.Selection.TypeText("This is the placement formula");
                    }
                    else if (field.Code.Text.Contains("Next Room"))
                    {
                        field.Select();
                        application.Selection.TypeText("19");
                    }
                    else if (field.Code.Text.Contains("Teacher This Year"))
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT `Current Teacher` FROM Room WHERE `Room No` = `" + 7 + "`");
                        cmd.Connection = conn;
                        reader = cmd.ExecuteReader();
                        string currentTeacher = reader.GetString(0);
                        field.Select();
                        application.Selection.TypeText(currentTeacher);
                    }

                    /*
                    //way to do so doesn't matter if new fields
                    string mergeName = field.Code.Text;
                    string query = "SELECT tablename FROM Relations WHERE field = '" + mergeName + "'";
                    OleDbCommand cmd = new OleDbCommand(query);
                    cmd.Connection = conn;
                    // execute query, store string result of table name in field
                    OleDbDataReader etcReader = cmd.ExecuteReader();
                    string tableName = etcReader.GetString(0);
                    //Query to get actual value to replace mergefield with
                    string finalQuery = "SELECT '" + mergeName + "' FROM '" + tableName + "' WHERE ";
                    cmd.CommandText = finalQuery;
                    etcReader = cmd.ExecuteReader();
                    //execute finalQuery and store string result
                    string value = etcReader.GetString(0);

                    field.Select();
                    application.Selection.TypeText(value);
                    */
                }
            }

            //application.Visible = true;
            //prints the document
            //document.PrintOut();
            //method end


        }


    }
}
