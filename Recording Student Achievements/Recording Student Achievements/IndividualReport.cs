using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\2016.accdb;Persist Security Info=False;"; //For not Alex's laptop

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
                cmd = new OleDbCommand("SELECT [s.Family Name Legal], [s.Preferred Name], [s.Room Number], [s.Gender], [r.Final Assessment Method], "
                + "[r.Final Assessment Level], [w.Overall Assessment], [m.KF1], [m.KF2], [m.NS1], "
                + "[m.NS2], [se.General Comment], [se.Next Room Number], [m.Overall Assessment], [w.Initial Assessment], "
                + " [w.Final Assessment] "
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
                cmd = new OleDbCommand("SELECT [s.Family Name Legal], [s.Preferred Name], [s.Room Number], [s.Gender], [r.Final Assessment Method], "
                + "[r.Final Assessment Level], [w.Overall Assessment], [m.KF1], [m.KF2], [m.NS1], "
                + "[m.NS2], [se.General Comment], [se.Next Room Number], [se.General Comment], [se.General Comment], "
                + "[m.Overall Assessment], [w.Initial Assessment], [w.Final Assessment] "
                + "FROM (((([Student] s "
                + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "
                + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN"
                + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"
                + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "

                + "WHERE [NSN] = '" + Int32.Parse(nsn) + "'; ");
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
                        mailMerge(reader);
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

        private void mailMerge(OleDbDataReader reader)
        {
            string familyName = "";
            string firstName, room = "";
            string readingFinalAssessmentMethod, readingFinalAssessmentLevel, writingOverallAssessment = "";
            string mathKF1, mathKF2, mathNS1 = "";
            string mathNS2, generalComment, nextRoom = "";
            string mathOverallAssessment, writingInitialAssessment = "";

            string hisHer = "";
            string a = "";

            while(reader.Read())
            {
                int currentYear = DateTime.Now.Year;
                int nextYear = currentYear + 1;

                

                for(int i = 0; i < reader.FieldCount; i++) {
                    switch(i) {
                        case 0 :
                            familyName = reader.GetString(i);
                            break;
                        case 1 :
                            firstName = reader.GetString(i);
                            break;
                        case 2 :
                            room = reader.GetString(i);
                            break;
                        case 3 :
                            if (reader.GetString(i) == "Male")
                            {
                                hisHer = "his";
                            }
                            else if (reader.GetString(i) == "Female")
                            {
                                hisHer = "her";
                            }
                            break;
                        case 4:
                            readingFinalAssessmentLevel = reader.GetString(i);
                            break;
                        case 5:
                            writingOverallAssessment = reader.GetString(i);
                            break;
                        case 6:
                            mathKF1 = reader.GetString(i);
                            break;
                        case 7:
                            mathKF2 = reader.GetString(i);
                            break;
                        case 8:
                            mathNS1 = reader.GetString(i);
                            break;
                        case 9:
                            mathNS2 = reader.GetString(i);
                            break;
                        case 10:
                            generalComment = reader.GetString(i);
                            break;
                        case 11:
                            nextRoom = reader.GetString(i);
                            break;
                        case 12:
                            mathOverallAssessment = reader.GetString(i);
                            break;
                        case 13:
                            writingInitialAssessment = reader.GetString(i);
                            break;
                        case 14:
                            a = reader.GetString(i);
                            break;
                    }
                    //switch end
                }
                //for end
            }
            //while end
            OleDbCommand cmd = new OleDbCommand();

            cmd = new OleDbCommand("SELECT [KF1], [KF2], [NS1], [NS2]"
            + "FROM [Reading National Standards]"
            + "WHERE [Assessment] = '" + familyName + "'; ");



            cmd.Connection = conn;
        }
        //method end
    }

}
