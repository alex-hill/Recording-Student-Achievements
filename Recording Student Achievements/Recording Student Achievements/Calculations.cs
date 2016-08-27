using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording_Student_Achievements
{
    class Calculations
    {
        private OleDbConnection conn = new OleDbConnection();
        public Calculations()
        {

        }

        public void Calculate()
        {
            OleDbCommand allStudents = new OleDbCommand();

            allStudents = new OleDbCommand("SELECT [NSN]"
            + " FROM [Student]; ");
            allStudents.Connection = conn;

            
            OleDbDataAdapter da = new OleDbDataAdapter(allStudents);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                string NSN = dr["NSN"].ToString();

                OleDbCommand cmd = new OleDbCommand();

                cmd = new OleDbCommand("SELECT * "
                    + "FROM (((([Student] s "
                    + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "
                    + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN"
                    + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"
                    + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "
                    + "INNER JOIN [Cultural Activities] m ON m.[NSN] = s.[NSN]) "
                    + "INNER JOIN [Sports Activities] m ON m.[NSN] = s.[NSN]) "
                    + "INNER JOIN [Extra Activities] m ON m.[NSN] = s.[NSN]) "

                    + "WHERE s.[NSN] = '" + NSN + "'; ");

                OleDbDataAdapter daa = new OleDbDataAdapter(cmd);
                DataTable dtt = new DataTable();
                daa.Fill(dtt);

                foreach (DataRow drr in dtt.Rows)
                {
                    string familyName = drr["Family Name Legal"].ToString();
                    string firstName = drr["Preferred Name"].ToString();
                    string room = drr["Room Number"].ToString();
                    string generalComment = drr["General Comment"].ToString();
                    string NSAchieve = drr["National Standard Achieve"].ToString();
                    string nextRoom = drr["Next Room Number"].ToString();

                    string readingFinalAssessmentMethod = drr["Reading Final Assessment Method"].ToString();
                    string readingInitialAssessment = drr["Reading Initial Assessment Level"].ToString();
                    string readingFinalAssessmentLevel = drr["Reading Final Assessment Level"].ToString();
                    string NSReadingAchieve = drr["Reading NS Achievement Code"].ToString();
                    string NSProgress = drr["National Standard Progress"].ToString();
                    string readingNSProgress = drr["Reading NS Progress"].ToString();
                    string readingEffort = drr["Reading Effort"].ToString();

                    string writingInitialAssessment = drr["Writing Initial Assessment"].ToString();
                    string writingFinalAssessment = drr["Writing Final Assessment"].ToString();
                    string writingNS3Code = drr["Writing NS3"].ToString();
                    string writingNSAchievementCode = drr["Writing NS Achievement Code"].ToString();
                    string writingNSProgress = drr["Writing NS Progress"].ToString();
                    string writingEffort = drr["Writing Effort"].ToString();

                    string mathFinalAssessmentMethod = drr["Math Final Assessment Method"].ToString();
                    string mathOverallAssessment = drr["Math Overall Assessment"].ToString();
                    string mathKf1 = drr["Math KF1"].ToString();
                    string mathKf2 = drr["Math KF2"].ToString();
                    string mathKf3 = drr["Math KF3"].ToString();
                    string mathKf4 = drr["Math KF4"].ToString();
                    string mathNs1 = drr["Math NS1"].ToString();
                    string mathNs2 = drr["Math NS2"].ToString();
                    string mathNSAchievementCode = drr["Math NS Achievement Code"].ToString();
                    string mathEffort = drr["Math Effort"].ToString();
                    string mathInitialAssessmentLevel = drr["Math Initial Assessment Level"].ToString();

                    string curiosity1 = drr["Curiosity 1"].ToString();
                    string curiosity2 = drr["Curiosity 2"].ToString();
                    string curiosity3 = drr["Curiosity 3"].ToString();
                    string curiosity4 = drr["Curiosity 4"].ToString();
                    string curiosity5 = drr["Curiosity 5"].ToString();
                    string curiosity6 = drr["Curiosity 6"].ToString();
                    string creativity1 = drr["Creativity 1"].ToString();
                    string creativity2 = drr["Creativity 2"].ToString();
                    string creativity3 = drr["Creativity 3"].ToString();
                    string creativity4 = drr["Creativity 4"].ToString();
                    string creativity5 = drr["Creativity 5"].ToString();
                    string creativity6 = drr["Creativity 6"].ToString();
                    string community1 = drr["Community 1"].ToString();
                    string community2 = drr["Community 2"].ToString();
                    string community3 = drr["Community 3"].ToString();
                    string community4 = drr["Community 4"].ToString();
                    string community5 = drr["Community 5"].ToString();
                    string community6 = drr["Community 6"].ToString();
                    string sustainability1 = drr["Sustainability 1"].ToString();
                    string sustainability2 = drr["Sustainability 2"].ToString();
                    string sustainability3 = drr["Sustainability 3"].ToString();
                    string sustainability4 = drr["Sustainability 4"].ToString();
                    string sustainability5 = drr["Sustainability 5"].ToString();
                    string sustainability6 = drr["Sustainability 6"].ToString();


                }

            }


            while (reader.Read())
            {
                familyName = reader.GetString(0);
                firstName = reader.GetString(1);
                room = reader.GetString(2);
                if (reader.GetString(3) == "Male")
                {
                    hisHer = "his";
                }
                else if (reader.GetString(3) == "Female")
                {
                    hisHer = "her";
                }
                //Console.WriteLine(reader.GetValue(14).GetType());
                readingFinalAssessmentLevel = reader.GetString(4);

                mathKf1 = reader.GetString(5);
                mathKf2 = reader.GetString(6);
                mathNs1 = reader.GetString(7);
                mathNs2 = reader.GetString(8);
                generalComment = reader.GetString(9);
                nextRoom = reader.GetString(10);
                mathOverallAssessment = reader.GetString(11);
                writingInitialAssessment = reader.GetString(12);
                writingFinalAssessment = reader.GetString(13);
                readingFinalAssessmentMethod = reader.GetString(14);
                mathFinalAssessmentMethod = reader.GetString(15);
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


            cmdReadingKfNs = new OleDbCommand("SELECT [KF 1], [KF 2], [NS 1], [NS 2]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessmentLevel + "'; ");
            cmdReadingKfNs.Connection = conn;

            cmdWritingKfNs = new OleDbCommand("SELECT [KF 1], [KF 2], [NS 1], [NS 2]"
            + " FROM [Writing National Standards]"
            + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
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
                try
                {
                    OleDbDataReader writingInitialGradeReader = cmdWritingInitialGrade.ExecuteReader();
                    OleDbDataReader writingFinalGradeReader = cmdWritingFinalGrade.ExecuteReader();
                    OleDbDataReader readingKfNsReader = cmdReadingKfNs.ExecuteReader();
                    OleDbDataReader writingKfNsReader = cmdWritingKfNs.ExecuteReader();
                    OleDbDataReader mathKf1Reader = cmdMathKf1.ExecuteReader();
                    OleDbDataReader mathKf2Reader = cmdMathKf2.ExecuteReader();
                    OleDbDataReader mathNs1Reader = cmdMathNs1.ExecuteReader();
                    OleDbDataReader mathNs2Reader = cmdMathNs2.ExecuteReader();

                    OleDbDataReader nextTeacherReader = cmdNextTeacher.ExecuteReader();
                    OleDbDataReader readingReportStatementReader = cmdReadingReportStatement.ExecuteReader();
                    // Get Reading Overall Grade
                    while (writingInitialGradeReader.Read())
                    {
                        readingInitialGrade = writingInitialGradeReader.GetString(0);
                    }
                    while (writingFinalGradeReader.Read())
                    {
                        readingFinalGrade = writingFinalGradeReader.GetString(0);
                    }
                    if (Convert.ToInt32(readingInitialGrade) > Convert.ToInt32(readingFinalGrade))
                    {
                        readingOverallGrade = readingInitialGrade;
                    }
                    else
                    {
                        readingOverallGrade = readingInitialGrade;
                    }
                    while (readingKfNsReader.Read() && writingKfNsReader.Read()
                            && mathKf1Reader.Read() && mathKf2Reader.Read() && mathNs1Reader.Read() && mathNs2Reader.Read()
                             && nextTeacherReader.Read() && readingReportStatementReader.Read())
                    {


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




                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.StackTrace);
                    conn.Close();
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

                    OleDbDataReader writingOverallAssessmentReader = cmdOverallWritingAssessment.ExecuteReader();

                    // Get Reading Overall Grade
                    while (writingOverallAssessmentReader.Read())
                    {
                        writingOverallAssessment = writingOverallAssessmentReader.GetString(0);

                    }

                    conn.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.StackTrace);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
        }
    }
}
