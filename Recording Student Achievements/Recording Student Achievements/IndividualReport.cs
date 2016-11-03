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
            string path = "C:\\Users\\Public\\Desktop\\";

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
            OleDbCommand cmd2 = new OleDbCommand();
            // 1 means firstName and lastName being used
            // 2 means nsn being used
            int check = 0;

            if (firstName != null && lastName != null)
            {
                cmd = new OleDbCommand("SELECT * "
                + "FROM ((((([Student] s "
                + "LEFT OUTER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "
                + "LEFT OUTER JOIN [Reading] r ON r.[NSN] = s.[NSN"
                + "LEFT OUTER JOIN [Writing] w ON w.[NSN] = s.[NSN])"
                + "LEFT OUTER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "
                + "LEFT OUTER JOIN [Calculated] c ON c.[NSN] = s.[NSN])"

                + "WHERE [Family Name Legal] = '" + lastName + "' AND [First Name Legal] = '" + firstName + "'; ");

                cmd2 = new OleDbCommand("SELECT * FROM [Sports Activities] sa WHERE [Family Name Legal] = '" + lastName + "' AND [First Name Legal] = '" + firstName + "'; ");
                cmd.Connection = conn;
                cmd2.Connection = conn;
                check = 1;
            }
            else if (nsnNumber != null)
            {
                cmd = new OleDbCommand("SELECT * "
                + "FROM ((((((([Student] s "

                + "LEFT OUTER JOIN [Extra Activities] ea on ea.[NSN] = s.[NSN])"

                + "LEFT OUTER JOIN [Cultural Activities] ca on ca.[NSN] = s.[NSN])"

                + "LEFT OUTER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "

                + "LEFT OUTER JOIN [Reading] r ON r.[NSN] = s.[NSN])"

                + "LEFT OUTER JOIN [Writing] w ON w.[NSN] = s.[NSN])"

                + "LEFT OUTER JOIN [Mathematics] m ON m.[NSN] = s.[NSN])"

                + "LEFT OUTER JOIN [Calculated] c ON c.[NSN] = s.[NSN])"

                + "WHERE s.[NSN] = '" + Int32.Parse(nsn) + "'; ");

                cmd2 = new OleDbCommand("SELECT * FROM [Sports Activities] sa WHERE sa.[NSN] = '" + Int32.Parse(nsn) + "';");

                cmd.Connection = conn;
                cmd2.Connection = conn;
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
                        reader.Close();
                        accessDB(cmd, cmd2);
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

        private void accessDB(OleDbCommand cmd, OleDbCommand cmd2)
        {
            OleDbDataAdapter daa = new OleDbDataAdapter(cmd);
            DataTable mainTable = new DataTable();
            daa.Fill(mainTable);
            OleDbDataAdapter extra = new OleDbDataAdapter(cmd2);
            DataTable extraTable = new DataTable();
            extra.Fill(extraTable);

            mainTable.Merge(extraTable);

            ArrayList values = new ArrayList();

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

            OleDbCommand merge = new OleDbCommand("SELECT * FROM [Merge]");
            
            //iterates through each mergefield in the document
            /*foreach (Microsoft.Office.Interop.Word.Shape shape in application.ActiveDocument.Shapes)
            {
                
                if(shape.Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                {
                    foreach (Microsoft.Office.Interop.Word.Field field in shape.TextFrame.TextRange.Fields)
                    {
                        merge.Connection = conn;
                        OleDbDataAdapter da = new OleDbDataAdapter(merge);
                        DataTable mergeTable = new DataTable();
                        da.Fill(mergeTable);
                        
                        foreach (DataRow drr in mainTable.Rows)
                        {
                            foreach (DataRow dr in mergeTable.Rows)
                            {
                                if (field.Code.Text.Contains(dr["Merge Field"].ToString()))
                                {
                                    Console.WriteLine("Merge Field: " + dr["Merge Field"].ToString());
                                    Console.WriteLine("Database Field: " + drr[dr["Database Field"].ToString()].ToString());
                                    field.Select();
                                    application.Selection.TypeText(drr[dr["Database Field"].ToString()].ToString());
                                }
                            }

                    }
                }*/


            merge.Connection = conn;
            OleDbDataAdapter da = new OleDbDataAdapter(merge);
            DataTable mergeTable = new DataTable();
            da.Fill(mergeTable);

            foreach (DataRow drr in mainTable.Rows)
            {
                foreach (DataRow dr in mergeTable.Rows)
                {
                    foreach (Microsoft.Office.Interop.Word.Shape shape in application.ActiveDocument.Shapes)
                    {

                        if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                        {
                            foreach (Microsoft.Office.Interop.Word.Field field in shape.TextFrame.TextRange.Fields)
                            {
                                if (field.Code.Text.Contains(dr["Merge Field"].ToString()))
                                {
                                    if(field.Code.Text.Contains("Kapa Haka") || field.Code.Text.Contains("Jump jam"))
                                    {
                                        Console.WriteLine("Merge Field: " + dr["Merge Field"].ToString());
                                        Console.WriteLine("Database Field: " + drr[dr["Database Field"].ToString()].ToString());
                                    }
                                    field.Select();
                                    application.Selection.TypeText(drr[dr["Database Field"].ToString()].ToString());
                                }
                                else if (field.Code.Text.Contains("This Year"))
                                {
                                    field.Select();
                                    application.Selection.TypeText(DateTime.Now.Year.ToString());
                                }
                                else if (field.Code.Text.Contains("Next Year"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((DateTime.Now.Year+1).ToString());
                                }
                                else if (field.Code.Text.Contains("Math Effort Below"))
                                {
                                    field.Select();
                                    if (drr["Math Effort Level"].Equals("2"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Math Effort At"))
                                {
                                    field.Select();
                                    if (drr["Math Effort Level"].Equals("3"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Math Effort Above"))
                                {
                                    field.Select();
                                    if (drr["Math Effort Level"].Equals("4"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Reading Effort Below"))
                                {
                                    field.Select();
                                    if (drr["Reading Effort Level"].Equals("2"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Reading Effort At"))
                                {
                                    field.Select();
                                    if (drr["Reading Effort Level"].Equals("3"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Reading Effort Above"))
                                {
                                    field.Select();
                                    if (drr["Reading Effort Level"].Equals("4"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Writing Effort Below"))
                                {
                                    field.Select();
                                    if (drr["Writing Effort Level"].Equals("2"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Writing Effort At"))
                                {
                                    field.Select();
                                    if (drr["Writing Effort Level"].Equals("3"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                                else if (field.Code.Text.Contains("Writing Effort Above"))
                                {
                                    field.Select();
                                    if (drr["Writing Effort Level"].Equals("4"))
                                    {
                                        application.Selection.TypeText("X");
                                    }
                                    else
                                    {
                                        application.Selection.TypeText(" ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Done merging");

            //application.Visible = true;
            //prints the document
            //document.PrintOut();
            //method end



        }


    }
}
