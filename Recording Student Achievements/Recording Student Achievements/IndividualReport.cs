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
                cmd = new OleDbCommand("SELECT [s.Family Name Legal], [s.Preferred Name], [s.Room Number], [s.Gender], "
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
                cmd = new OleDbCommand("SELECT [s.Family Name Legal], [s.Preferred Name], [s.Room Number], [s.Gender], "
                + "[r.Final Assessment Level], [m.KF1], [m.KF2], [m.NS1], "
                + "[m.NS2], [se.General Comment], [se.Next Room Number], [se.General Comment], [se.General Comment], "
                + "[m.Overall Assessment], [w.Initial Assessment], [w.Final Assessment], [m.Final Assessment Method], "
                + "[r.Final Assessment Method] "
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
            string familyName = "";
            string firstName = "";
            string room = "";
            string writingOverallAssessment = "";
            string mathKf1 = "";
            string mathKf2 = "";
            string mathNs1 = "";
            string mathNs2 = "";
            string nextRoom = "";
            string generalComment = "";
            string mathOverallAssessment = "";
            string writingInitialAssessment = "";
            string hisHer = "";
            string writingFinalAssessment = "";
            int currentYear = DateTime.Now.Year;
            int nextYear = currentYear + 1;
            string readingFinalAssessmentLevel = "";
            string readingFinalAssessmentMethod = "";
            string mathFinalAssessmentMethod = "";
            string readingKf1 = "";
            string readingKf2 = "";
            string readingNs1 = "";
            string readingNs2 = "";
            string writingKf1 = "";
            string writingKf2 = "";
            string writingNs1 = "";
            string writingNs2 = "";
            string nextTeacher = "";
            string placementFormula = "";
            string readingReportStatement = "";
            int readingInitialGrade = 0;
            int readingFinalGrade = 0;
            int readingOverallGrade = 0;


            while (reader.Read())
            {
                familyName = reader.GetString(0);
                firstName = reader.GetString(1);
                room = reader.GetString(2);
                if (reader.GetString(3) == "Male")
                {
                    hisHer = "his";
                }
                else if (reader.GetString(4) == "Female")
                {
                    hisHer = "her";
                }
                readingFinalAssessmentLevel = reader.GetString(5);

                mathKf1 = reader.GetString(6);
                mathKf2 = reader.GetString(7);
                mathNs1 = reader.GetString(8);
                mathNs2 = reader.GetString(9);
                generalComment = reader.GetString(10);
                nextRoom = reader.GetString(11);
                mathOverallAssessment = reader.GetString(12);
                writingInitialAssessment = reader.GetString(13);
                writingFinalAssessment = reader.GetString(14);
                readingFinalAssessmentMethod = reader.GetString(15);
                mathFinalAssessmentMethod = reader.GetString(16);
            }
            reader.Close();
            //while end
            OleDbCommand cmdReadingKfNs = new OleDbCommand();
            OleDbCommand cmdWritingKfNs = new OleDbCommand();
            OleDbCommand cmdMathKf1 = new OleDbCommand();
            OleDbCommand cmdMathKf2 = new OleDbCommand();
            OleDbCommand cmdMathNs1 = new OleDbCommand();
            OleDbCommand cmdMathNs2 = new OleDbCommand();
            OleDbCommand cmdNextTeacher = new OleDbCommand();
            OleDbCommand cmdReadingReportStatement = new OleDbCommand();
            OleDbCommand cmdWritingInitialGrade = new OleDbCommand();
            OleDbCommand cmdWritingFinalGrade = new OleDbCommand();


            cmdReadingKfNs = new OleDbCommand("SELECT [KF1], [KF2], [NS1], [NS2]"
            + "FROM [Reading National Standards]"
            + "WHERE [Assessment] = '" + readingFinalAssessmentLevel + "'; ");
            cmdReadingKfNs.Connection = conn;

            cmdWritingKfNs = new OleDbCommand("SELECT [Statement]"
            + "FROM [Mathematics Level Statements]"
            + "WHERE [Maths Code] = '" + mathKf1 + "'; ");
            cmdWritingKfNs.Connection = conn;

            cmdMathKf1 = new OleDbCommand("SELECT [Statement] FROM [Mathematics Level Statements]"
            + "WHERE [Maths Code] = '" + mathKf1 + "'; ");
            cmdMathKf1.Connection = conn;

            cmdMathKf2 = new OleDbCommand("SELECT [Statement] FROM [Mathematics Level Statements]"
            + "WHERE [Maths Code] = '" + mathKf2 + "'; ");
            cmdMathKf2.Connection = conn;

            cmdMathNs1 = new OleDbCommand("SELECT [Statement] FROM [Mathematics Level Statements] "
            + "WHERE [Maths Code] = '" + mathNs1 + "'; ");
            cmdMathNs1.Connection = conn;

            cmdMathNs2 = new OleDbCommand("SELECT [Statement] FROM [Mathematics Level Statements]"
            + "WHERE [Maths Code] = '" + mathNs2 + "'; ");
            cmdMathNs2.Connection = conn;

            if (readingFinalAssessmentMethod == "PROBE Test")
            {
                readingReportStatement = "Reading Age " + readingFinalAssessmentLevel + " Years";
            }
            else
            {
                cmdReadingReportStatement = new OleDbCommand("SELECT [Colour] FROM [Reading National Standards]"
                + "WHERE [Reading Code] = '" + readingFinalAssessmentLevel + "'; ");
                cmdReadingReportStatement.Connection = conn;
            }
            cmdNextTeacher = new OleDbCommand("SELECT [Next Year Teacher] FROM [Room] WHERE [Room No] = '" + nextRoom + "'; ");
            cmdNextTeacher.Connection = conn;

            cmdWritingInitialGrade = new OleDbCommand("SELECT [Grade] FROM [Writing National Standards] "
            + "WHERE [Writing Level] = '" + writingInitialAssessment + "'; ");
            cmdWritingInitialGrade.Connection = conn;

            cmdWritingFinalGrade = new OleDbCommand("SELECT [Grade] FROM [Writing National Standards] "
            + "WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            cmdWritingFinalGrade.Connection = conn;

            if (conn.State == ConnectionState.Open)
            {
                OleDbDataReader writingInitialGradeReader = cmdWritingInitialGrade.ExecuteReader();
                OleDbDataReader writingFinalGradeReader = cmdWritingFinalGrade.ExecuteReader();
                // Get Reading Overall Grade
                while (writingInitialGradeReader.Read())
                {
                    readingInitialGrade = writingInitialGradeReader.GetInt16(0);
                }
                while (writingFinalGradeReader.Read())
                {
                    readingFinalGrade = writingFinalGradeReader.GetInt16(0);
                }
                if (readingInitialGrade > readingFinalGrade)
                {
                    readingOverallGrade = readingInitialGrade;
                }
                else
                {
                    readingOverallGrade = readingInitialGrade;
                }

            }
            OleDbCommand cmdOverallWritingAssessment = new OleDbCommand();
            cmdOverallWritingAssessment = new OleDbCommand("SELECT [Writing Level] FROM [Writing National Standards] "
            + "WHERE [Grade] = '" + readingOverallGrade + "'; ");
            cmdOverallWritingAssessment.Connection = conn;


            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    OleDbDataReader readingKfNsReader = cmdReadingKfNs.ExecuteReader();
                    OleDbDataReader writingKfNsReader = cmdWritingKfNs.ExecuteReader();
                    OleDbDataReader mathKf1Reader = cmdMathKf1.ExecuteReader();
                    OleDbDataReader mathKf2Reader = cmdMathKf2.ExecuteReader();
                    OleDbDataReader mathNs1Reader = cmdMathNs1.ExecuteReader();
                    OleDbDataReader mathNs2Reader = cmdMathNs2.ExecuteReader();
                    OleDbDataReader nextTeacherReader = cmdNextTeacher.ExecuteReader();
                    OleDbDataReader readingReportStatementReader = cmdReadingReportStatement.ExecuteReader();
                    OleDbDataReader writingOverallAssessmentReader = cmdOverallWritingAssessment.ExecuteReader();

                    // Get Reading Overall Grade
                    while (writingOverallAssessmentReader.Read() && readingKfNsReader.Read() && writingKfNsReader.Read()
                        && mathKf1Reader.Read() && mathKf2Reader.Read() && mathNs1Reader.Read() && mathNs2Reader.Read()
                         && nextTeacherReader.Read() && readingReportStatementReader.Read() && writingOverallAssessmentReader.Read())
                    {
                        writingOverallAssessment = writingOverallAssessmentReader.GetString(0);

                        // Calculate Reading NS and KF
                        while (readingKfNsReader.Read())
                        {
                            readingKf1 = readingKfNsReader.GetString(0);
                            readingKf2 = readingKfNsReader.GetString(1);
                            readingNs1 = readingKfNsReader.GetString(2);
                            readingNs2 = readingKfNsReader.GetString(3);
                        }

                        // Calculate Writing NS and KF
                        while (writingKfNsReader.Read())
                        {
                            writingKf1 = writingKfNsReader.GetString(0);
                            writingKf2 = writingKfNsReader.GetString(1);
                            writingNs1 = writingKfNsReader.GetString(2);
                            writingNs2 = writingKfNsReader.GetString(3);
                        }

                        // Calculate Math NS and KF
                        while (mathKf1Reader.Read())
                        {
                            mathKf1 = reader.GetString(0);
                        }
                        while (mathKf2Reader.Read())
                        {
                            mathKf2 = reader.GetString(0);
                        }
                        while (mathNs1Reader.Read())
                        {
                            mathNs1 = reader.GetString(0);
                        }
                        while (mathNs2Reader.Read())
                        {
                            mathNs2 = reader.GetString(0);
                        }

                        // Get Reading Report Statement
                        while (readingReportStatementReader.Read())
                        {
                            readingReportStatement = readingReportStatementReader.GetString(0);
                        }




                        // Calculate Placement Formula
                        while (nextTeacherReader.Read())
                        {
                            nextTeacher = nextTeacherReader.GetString(0);
                        }
                        if (nextTeacher == "Leaving")
                        {
                            placementFormula = "Our records show that " + firstName
                            + " will be leaving Laingholm Primary School - "
                            + "'The Greatest Little School in the Universe' - "
                            + "at the end of this year. As a school we would like "
                            + "to take the opportunity to wish " + firstName + " well for "
                            + "the future in the belief that " + firstName + " will continue to 'Reach for the Stars";
                        }
                        else
                        {
                            placementFormula = "Over the past few months we have given "
                            + "very careful consideration to " + firstName + "’s classroom placement "
                            + "for 2016. As a school we endeavour to personalise the learning "
                            + "for each student. We take into account academic performance, "
                            + "friendship groups and a number of other factors when placing a student in a particular class.";
                        }


                        reader.Close();
                        conn.Close();
                    }
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

            //method end
        }


    }
}
