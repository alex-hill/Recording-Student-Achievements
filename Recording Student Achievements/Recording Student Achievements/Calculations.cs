using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording_Student_Achievements
{
    class Calculations
    {
        private OleDbConnection conn = new OleDbConnection();
        string firstName;
        string gender;
        string room;
        string NSAchieve;
        string NSProgress;
        string nextRoom;
        string generalComment;


        string readingInitialAssessmentMethod;
        string readingFinalAssessmentMethod;
        string readingInitialAssessment;
        string readingFinalAssessment;
        string readingNSAchievementCode;
        string readingNSProgressCode;
        string readingEffort;
        string readingComment;

        string writingInitialAssessment;
        string writingFinalAssessment;
        string writingNS3Code;
        string writingNSAchievementCode;
        string writingNSProgressCode;
        string writingEffort;
        string writingComment;

        string mathFinalAssessmentMethod;
        string mathOverallAssessment;
        string mathKf1;
        string mathKf2;
        string mathKf3;
        string mathKf4;
        string mathNs1;
        string mathNs2;
        string mathNSAchievementCode;
        string mathEffort;
        string mathInitialAssessmentLevel;
        string mathNSProgressCode;
        string mathComment;

        string curiosity1, curiosity1Statement;
        string curiosity2, curiosity2Statement;
        string curiosity3, curiosity3Statement;
        string curiosity4, curiosity4Statement;
        string curiosity5, curiosity5Statement;
        string curiosity6, curiosity6Statement;
        string creativity1, creativity1Statement;
        string creativity2, creativity2Statement;
        string creativity3, creativity3Statement;
        string creativity4, creativity4Statement;
        string creativity5, creativity5Statement;
        string creativity6, creativity6Statement;
        string community1, community1Statement;
        string community2, community2Statement;
        string community3, community3Statement;
        string community4, community4Statement;
        string community5, community5Statement;
        string community6, community6Statement;
        string sustainability1, sustainability1Statement;
        string sustainability2, sustainability2Statement;
        string sustainability3, sustainability3Statement;
        string sustainability4, sustainability4Statement;
        string sustainability5, sustainability5Statement;
        string sustainability6, sustainability6Statement;
        string honesty, excellence, aroha, respect, trust;
        /*
         * Calculated Variables
         * 
         * */

        string teacherThisYear;
        string schoolYearOrdinal;
        string nextTeacher;
        string placementStatement;
        string nextRoomStatement;
        string heShe, hisHer, himHer;
        string generalCommentLength;
        //Reading

        string readingInitialStatement;
        string readingFinalStatement;
        string readingKF1;
        string readingKF2;
        string readingNS1;
        string readingNS2;
        string readingFinalCode;
        // Achievement
        string readingNSAchievementTimeframe;
        string readingNSAchievementStatement;
        string readingNSAchieveLevel;
        string readingNSAchievementOTJ;
        string readingNSAchievementComp;
        string readingNSAchievementOTJVsComp;
        //Progress
        string readingNSProgressTimeframe;
        string readingNSProgressStatement;
        string readingNSProgressLevel;
        string readingNSProgressOTJ;
        string readingNSProgressComp;
        string readingNSProgressOTJVsComp;
        // Rest
        string readingEffortLevel;
        string readingEffortStatement;
        string readingCommentLength;

        //Writing 
        string writingInitialGrade;
        string writingFinalGrade;
        string writingOverallGrade;
        string writingOverallAssessment;
        string writingKF1;
        string writingKF2;
        string writingNS1;
        string writingNS2;
        string writingNS3Statement;
        //Achieve
        string writingNSAchievementTimeframe;
        string writingNSAchievementStatement;
        string writingNSAchieveLevel;
        string writingNSAchievementOTJ;
        string writingNSAchievementComp;
        string writingNSAchievementOTJVsComp;
        //Progress
        string writingNSProgressTimeframe;
        string writingNSProgressStatement;
        string writingNSProgressLevel;
        string writingNSProgressOTJ;
        string writingNSProgressComp;
        string writingNSProgressOTJVsComp;
        //Rest
        string writingEffortLevel;
        string writingEffortStatement;
        string writingCommentLength;

        //Math
        string mathKf1Statement;
        string mathKf2Statement;
        string mathKf3Statement;
        string mathKf4Statement;
        string mathNS1Statement;
        string mathNS2Statement;
        string mathNAStageCheck;
        string mathNAAverage;
        string mathNARound;
        //Achieve
        string mathNSAchievementTimeframe;
        string mathNSAchievementStatement;
        string mathNSAchieveLevel;
        string mathNSAchievementOTJ;
        string mathNSAchievementComp;
        string mathNSAchievementOTJVsComp;
        //Progress
        string mathNSProgressTimeframe;
        string mathNSProgressStatement;
        string mathNSProgressLevel;
        string mathNSProgressOTJ;
        string mathNSProgressComp;
        string mathNSProgressOTJVsComp;
        //Rest 
        string mathEffortLevel;
        string mathEffortStatement;
        string mathCommentLength;
        string mathFinalGrade;
        string strMathFinalGrade;
        string mathInitialGrade;
        string strMathInitialGrade;

        string managingSelf, managingSelfPercent, managingSelfStatement;
        string relationToOthers, relationToOthersPercent, relationToOthersStatement;
        string participatingContributing, participatingContributingPercent, participatingContributingStatement;
        string thinking, thinkingPercent, thinkingStatement;
        string lst, lstPercent, lstStatement;

        string numActivitiesStr, sportsActivitiesStr;

        

        string overallAcademic;
        string teachersCup;
        string yesHumanValues;
        string totalHumanValues;

        string readingProgressCheck, writingProgressCheck, mathProgressCheck;

        string dataSummary;
        string checkSums;

        string studentsWellBelow, studentsBelow, studentsAt, studentsAbove, studentsWellAbove;

        

        public Calculations()
        {
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop

        }

        //Checked
        private void readingCalculations()
        {
            // Reading Initial Statement
            OleDbCommand cmdReadingInitialStatement = new OleDbCommand("SELECT [Colour]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingInitialAssessment + "'; ");
            cmdReadingInitialStatement.Connection = conn;
            OleDbDataReader reader = cmdReadingInitialStatement.ExecuteReader();
            reader.Read();
            readingInitialStatement = reader.GetString(0);
            if (readingInitialAssessmentMethod.Equals("PROBE"))
            {
                readingInitialStatement = "Reading Age " + readingInitialAssessment + " Years";
            }
            else
            {
                readingInitialStatement += " - Level " + readingInitialAssessment;
            }

            // Reading Final Statement
            OleDbCommand cmdReadingFinalStatement = new OleDbCommand("SELECT [Colour]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            cmdReadingFinalStatement.Connection = conn;
            reader = cmdReadingFinalStatement.ExecuteReader();
            reader.Read();
            readingFinalStatement = reader.GetString(0);
            if (readingFinalAssessmentMethod.Equals("PROBE"))
            {
                readingFinalStatement = "Reading Age " + readingFinalAssessment + " Years";
            }
            else
            {
                readingFinalStatement += " - Level " + readingFinalAssessment;
            }

            // Reading KF1/2, NS1/2
            OleDbCommand cmdReadingKF1 = new OleDbCommand("SELECT [KF 1], [KF 2], [NS 1], [NS 2]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            cmdReadingKF1.Connection = conn;
            reader = cmdReadingKF1.ExecuteReader();
            reader.Read();
            readingKF1 = reader.GetString(0);
            readingKF2 = reader.GetString(1);
            readingNS1 = reader.GetString(2);
            readingNS2 = reader.GetString(3);

            // Achieve

            // NS Timeframe Reading Achieve
            OleDbCommand cmdReadingNSTimeframeAchieve = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            cmdReadingNSTimeframeAchieve.Connection = conn;
            reader = cmdReadingNSTimeframeAchieve.ExecuteReader();
            reader.Read();
            readingNSAchievementTimeframe = reader.GetString(0);
            readingNSAchievementStatement = reader.GetString(1);

            // NS Achieve Level
            switch (readingNSAchievementCode)
            {
                case "1":
                    readingNSAchieveLevel = "Well Below";
                    break;
                case "2":
                    readingNSAchieveLevel = "Below";
                    break;
                case "3":
                    readingNSAchieveLevel = "At";
                    break;
                case "4":
                    readingNSAchieveLevel = "Above";
                    break;
                case "5":
                    readingNSAchieveLevel = "Well Above";
                    break;
            }

            // NS Reading Achievemet (OTJ)
            OleDbCommand cmdReadingNSAchievementOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + readingNSAchievementCode + "'; ");
            cmdReadingNSAchievementOTJ.Connection = conn;
            reader = cmdReadingNSAchievementOTJ.ExecuteReader();
            reader.Read();
            readingNSAchievementOTJ = reader.GetString(0);

            // NS Reading Achievemet (Comp)
            OleDbCommand cmdReadingNSAchievementComp = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            cmdReadingNSAchievementComp.Connection = conn;
            reader = cmdReadingNSAchievementComp.ExecuteReader();
            reader.Read();
            readingNSAchievementComp = reader.GetString(0);

            // NS Achievement OTJ vs COMP
            if (readingNSAchievementOTJ.Equals(readingNSAchievementComp))
            {
                readingNSAchievementOTJVsComp = "1";
            }
            else
            {
                readingNSAchievementOTJVsComp = "0";
            }

            // Progress

            // NS Timeframe Reading Progress
            OleDbCommand cmdReadingNSTimeframeProgress = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            cmdReadingNSTimeframeProgress.Connection = conn;
            reader = cmdReadingNSTimeframeProgress.ExecuteReader();
            reader.Read();
            readingNSProgressTimeframe = reader.GetString(0);
            readingNSProgressStatement = reader.GetString(1);

            // NS Progress Level
            switch (readingNSProgressCode)
            {
                case "1":
                    readingNSProgressLevel = "Below";
                    break;
                case "2":
                    readingNSProgressLevel = "At";
                    break;
                case "3":
                    readingNSProgressLevel = "Above";
                    break;
            }

            // NS Reading Progress (OTJ)
            OleDbCommand cmdReadingNSProgressOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + readingNSProgressCode + "'; ");
            cmdReadingNSProgressOTJ.Connection = conn;
            reader = cmdReadingNSProgressOTJ.ExecuteReader();
            reader.Read();
            readingNSProgressOTJ = reader.GetString(0);

            // NS Reading Progress (Comp)
            OleDbCommand cmdReadingNSProgressComp = new OleDbCommand("SELECT [" + readingNSAchievementCode + "]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            cmdReadingNSProgressComp.Connection = conn;
            reader = cmdReadingNSProgressComp.ExecuteReader();
            reader.Read();
            readingNSProgressComp = reader.GetString(0);

            // NS Progress OTJ vs COMP
            if (readingNSProgressOTJ.Equals(readingNSProgressComp))
            {
                readingNSProgressOTJVsComp = "1";
            }
            else
            {
                readingNSProgressOTJVsComp = "0";
            }

            //Reading Effort Level
            switch (readingEffort)
            {
                case "1":
                    readingEffortLevel = "Below";
                    break;
                case "2":
                    readingEffortLevel = "At";
                    break;
                case "3":
                    readingEffortLevel = "Above";
                    break;
            }

            // Effort Statement
            OleDbCommand cmdReadingEffortStatement = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + readingEffort + "'; ");
            cmdReadingEffortStatement.Connection = conn;
            reader = cmdReadingEffortStatement.ExecuteReader();
            reader.Read();
            readingEffortStatement = reader.GetString(0);

            //Reading Comment Length
            readingCommentLength = readingComment.Length.ToString();


        }

        //Checked
        private void writingCalculations()
        {
            //Initial Grade
            OleDbCommand cmdWritingInitialGrade = new OleDbCommand("SELECT [Grade]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingInitialAssessment + "'; ");
            cmdWritingInitialGrade.Connection = conn;
            OleDbDataReader reader = cmdWritingInitialGrade.ExecuteReader();
            reader.Read();
            writingInitialGrade = reader.GetString(0);

            //Final Grade
            OleDbCommand cmdWritingFinalGrade = new OleDbCommand("SELECT [Grade]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            cmdWritingFinalGrade.Connection = conn;
            reader = cmdWritingFinalGrade.ExecuteReader();
            reader.Read();
            writingFinalGrade = reader.GetString(0);

            //Overall Grade
            if (Int32.Parse(writingInitialGrade) < Int32.Parse(writingFinalGrade))
            {
                writingOverallGrade = writingFinalGrade;
            }
            else
            {
                writingOverallGrade = writingInitialGrade;
            }

            //Overall Writing Assessment
            OleDbCommand cmdWritingOverallAssessment = new OleDbCommand("SELECT [Writing Level]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Grade] = '" + writingOverallGrade + "'; ");
            cmdWritingOverallAssessment.Connection = conn;
            reader = cmdWritingOverallAssessment.ExecuteReader();
            reader.Read();
            writingOverallAssessment = reader.GetString(0);

            //KF 1 2, NS 1, 2
            OleDbCommand cmdWritingKF1 = new OleDbCommand("SELECT [KF 1], [KF 2], [NS 1], [NS 2]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingOverallAssessment + "'; ");
            cmdWritingKF1.Connection = conn;
            reader = cmdWritingKF1.ExecuteReader();
            reader.Read();
            writingKF1 = reader.GetString(0);
            writingKF2 = reader.GetString(1);
            writingNS1 = reader.GetString(2);
            writingNS2 = reader.GetString(3);

            //NS3 Statement
            OleDbCommand cmdWritingNS3Statement = new OleDbCommand("SELECT [Comment]"
                    + " FROM [Writing Year Standards]"
                    + " WHERE [Code] = '" + writingNS3Code + "'; ");
            cmdWritingNS3Statement.Connection = conn;
            reader = cmdWritingNS3Statement.ExecuteReader();
            reader.Read();
            writingNS3Statement = reader.GetString(0);

            //Achieve

            // NS Timeframe Writing Achieve
            OleDbCommand cmdWritingNSTimeframeAchieve = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Writing Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            cmdWritingNSTimeframeAchieve.Connection = conn;
            reader = cmdWritingNSTimeframeAchieve.ExecuteReader();
            reader.Read();
            writingNSAchievementTimeframe = reader.GetString(0);
            writingNSAchievementStatement = reader.GetString(1);

            // NS Achieve Level
            switch (writingNSAchievementCode)
            {
                case "1":
                    writingNSAchieveLevel = "Well Below";
                    break;
                case "2":
                    writingNSAchieveLevel = "Below";
                    break;
                case "3":
                    writingNSAchieveLevel = "At";
                    break;
                case "4":
                    writingNSAchieveLevel = "Above";
                    break;
                case "5":
                    writingNSAchieveLevel = "Well Above";
                    break;
            }

            // NS Writing Achievemet (OTJ)
            OleDbCommand cmdWritingNSAchievementOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + writingNSAchievementCode + "'; ");
            cmdWritingNSAchievementOTJ.Connection = conn;
            reader = cmdWritingNSAchievementOTJ.ExecuteReader();
            reader.Read();
            writingNSAchievementOTJ = reader.GetString(0);

            // NS Writing Achievemet (Comp)
            OleDbCommand cmdWritingNSAchievementComp = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Writing National Standards]"
            + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            cmdWritingNSAchievementComp.Connection = conn;
            reader = cmdWritingNSAchievementComp.ExecuteReader();
            reader.Read();
            writingNSAchievementComp = reader.GetString(0);

            // NS Achievement OTJ vs COMP
            if (writingNSAchievementOTJ.Equals(writingNSAchievementComp))
            {
                writingNSAchievementOTJVsComp = "1";
            }
            else
            {
                writingNSAchievementOTJVsComp = "0";
            }

            // NS Timeframe Writing Progress
            OleDbCommand cmdWritingNSTimeframeProgress = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Writing Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            cmdWritingNSTimeframeProgress.Connection = conn;
            reader = cmdWritingNSTimeframeProgress.ExecuteReader();
            reader.Read();
            writingNSProgressTimeframe = reader.GetString(0);
            writingNSProgressStatement = reader.GetString(1);

            // NS Progress Level
            switch (writingNSProgressCode)
            {
                case "1":
                    writingNSProgressLevel = "Below";
                    break;
                case "2":
                    writingNSProgressLevel = "At";
                    break;
                case "3":
                    writingNSProgressLevel = "Above";
                    break;
            }

            // NS Writing Progress (OTJ)
            OleDbCommand cmdWritingNSProgressOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + writingNSProgressCode + "'; ");
            cmdWritingNSProgressOTJ.Connection = conn;
            reader = cmdWritingNSProgressOTJ.ExecuteReader();
            reader.Read();
            writingNSProgressOTJ = reader.GetString(0);

            // NS Writing Progress (Comp)
            OleDbCommand cmdWritingNSProgressComp = new OleDbCommand("SELECT [" + writingNSAchievementCode + "]"
            + " FROM [Writing National Standards]"
            + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            cmdWritingNSProgressComp.Connection = conn;
            reader = cmdWritingNSProgressComp.ExecuteReader();
            reader.Read();
            writingNSProgressComp = reader.GetString(0);

            // NS Progress OTJ vs COMP
            if (writingNSProgressOTJ.Equals(writingNSProgressComp))
            {
                writingNSProgressOTJVsComp = "1";
            }
            else
            {
                writingNSProgressOTJVsComp = "0";
            }

            //Writing Effort Level
            switch (writingEffort)
            {
                case "1":
                    writingEffortLevel = "Below";
                    break;
                case "2":
                    writingEffortLevel = "At";
                    break;
                case "3":
                    writingEffortLevel = "Above";
                    break;
            }

            // Effort Statement
            OleDbCommand cmdWritingEffortStatement = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + writingEffort + "'; ");
            cmdWritingEffortStatement.Connection = conn;
            reader = cmdWritingEffortStatement.ExecuteReader();
            reader.Read();
            writingEffortStatement = reader.GetString(0);

            //Writing Comment Length
            writingCommentLength = writingComment.Length.ToString();

        }

        //Checked
        private void mathCalculations()
        {
            // Math KF1
            OleDbCommand cmdMathKf1 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf1 + "'; ");
            cmdMathKf1.Connection = conn;
            OleDbDataReader reader = cmdMathKf1.ExecuteReader();
            reader.Read();
            mathKf1Statement = reader.GetString(0);

            // Math KF1
            OleDbCommand cmdMathKf2 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf2 + "'; ");
            cmdMathKf2.Connection = conn;
            reader = cmdMathKf2.ExecuteReader();
            reader.Read();
            mathKf2Statement = reader.GetString(0);

            // Math KF1
            OleDbCommand cmdMathKf3 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf3 + "'; ");
            cmdMathKf3.Connection = conn;
            reader = cmdMathKf3.ExecuteReader();
            reader.Read();
            mathKf3Statement = reader.GetString(0);

            // Math KF1
            OleDbCommand cmdMathKf4 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf4 + "'; ");
            cmdMathKf4.Connection = conn;
            reader = cmdMathKf4.ExecuteReader();
            reader.Read();
            mathKf4Statement = reader.GetString(0);

            // Math NS1
            OleDbCommand cmdMathNS1 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathNs1 + "'; ");
            cmdMathNS1.Connection = conn;
            reader = cmdMathNS1.ExecuteReader();
            reader.Read();
            mathNS1Statement = reader.GetString(0);

            // Math NS1
            OleDbCommand cmdMathNS2 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathNs2 + "'; ");
            cmdMathNS2.Connection = conn;
            reader = cmdMathNS2.ExecuteReader();
            reader.Read();
            mathNS2Statement = reader.GetString(0);

            // Average and Rounding
            string mathNA1 = mathKf1.Substring(0, 1);
            string mathNA2 = mathKf2.Substring(0, 1);
            string mathNA3 = mathKf3.Substring(0, 1);
            string mathNA4 = mathKf4.Substring(0, 1);
            string mathNA5 = mathNs1.Substring(0, 1);
            string mathNA6 = mathNs2.Substring(0, 1);
            double n = (Int32.Parse(mathNA1) + Int32.Parse(mathNA2) + Int32.Parse(mathNA3) + Int32.Parse(mathNA4) + Int32.Parse(mathNA5) + Int32.Parse(mathNA6)) / 6;
            mathNAAverage = n.ToString();
            mathNARound = Math.Ceiling(n).ToString();

            //Stage Check
            OleDbCommand cmdMathPos2 = new OleDbCommand("SELECT [Position1], [Num Position1], [Num Position2]"
            + " FROM [Math Reverse Lookup]"
            + " WHERE [Stage] = '" + mathOverallAssessment + "'; ");
            cmdMathPos2.Connection = conn;
            reader = cmdMathPos2.ExecuteReader();
            reader.Read();

            //Math Final Grade
            strMathFinalGrade = reader.GetString(0);
            
            mathFinalGrade = reader.GetString(1);
            string a = reader.GetString(1);
            int b = Int32.Parse(a) - Int32.Parse(mathNARound);
            if (b == 0)
            {
                mathNAStageCheck = "1";
            }
            else
            {
                mathNAStageCheck = "0";
            }

            // NS Timeframe Math Achieve
            OleDbCommand cmdMathNSTimeframeAchieve = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Mathematics Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            cmdMathNSTimeframeAchieve.Connection = conn;
            reader = cmdMathNSTimeframeAchieve.ExecuteReader();
            reader.Read();
            mathNSAchievementTimeframe = reader.GetString(0);
            mathNSAchievementStatement = reader.GetString(1);

            // NS Achieve Level
            switch (mathNSAchievementCode)
            {
                case "1":
                    mathNSAchieveLevel = "Well Below";
                    break;
                case "2":
                    mathNSAchieveLevel = "Below";
                    break;
                case "3":
                    mathNSAchieveLevel = "At";
                    break;
                case "4":
                    mathNSAchieveLevel = "Above";
                    break;
                case "5":
                    mathNSAchieveLevel = "Well Above";
                    break;
            }

            // NS Math Achievemet (OTJ)
            OleDbCommand cmdMathNSAchievementOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + mathNSAchievementCode + "'; ");
            cmdMathNSAchievementOTJ.Connection = conn;
            reader = cmdMathNSAchievementOTJ.ExecuteReader();
            reader.Read();
            mathNSAchievementOTJ = reader.GetString(0);

            // NS Math Achievemet (Comp)
            OleDbCommand cmdMathNSAchievementComp = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Mathematics National Standards]"
            + " WHERE [Stage] = '" + strMathFinalGrade + "'; ");
            cmdMathNSAchievementComp.Connection = conn;
            reader = cmdMathNSAchievementComp.ExecuteReader();
            reader.Read();
            mathNSAchievementComp = reader.GetString(0);

            // NS Achievement OTJ vs COMP
            if (mathNSAchievementOTJ.Equals(mathNSAchievementComp))
            {
                mathNSAchievementOTJVsComp = "1";
            }
            else
            {
                mathNSAchievementOTJVsComp = "0";
            }

            // NS Timeframe Math Progress
            OleDbCommand cmdMathNSTimeframeProgress = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Mathematics Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            cmdMathNSTimeframeProgress.Connection = conn;
            reader = cmdMathNSTimeframeProgress.ExecuteReader();
            reader.Read();
            mathNSProgressTimeframe = reader.GetString(0);
            mathNSProgressStatement = reader.GetString(1);

            // NS Progress Level
            switch (mathNSProgressCode)
            {
                case "1":
                    mathNSProgressLevel = "Below";
                    break;
                case "2":
                    mathNSProgressLevel = "At";
                    break;
                case "3":
                    mathNSProgressLevel = "Above";
                    break;
            }

            // NS Math Progress (OTJ)
            OleDbCommand cmdMathNSProgressOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + mathNSProgressCode + "'; ");
            cmdMathNSProgressOTJ.Connection = conn;
            reader = cmdMathNSProgressOTJ.ExecuteReader();
            reader.Read();
            mathNSProgressOTJ = reader.GetString(0);

            // NS Math Progress (Comp)
            
            OleDbCommand cmdMathNSProgressComp = new OleDbCommand("SELECT [" + mathNSAchievementCode + "]"
            + " FROM [Mathematics National Standards]"
            + " WHERE [Stage] = '" + strMathFinalGrade + "'; ");
            cmdMathNSProgressComp.Connection = conn;
            reader = cmdMathNSProgressComp.ExecuteReader();
            reader.Read();
            
            mathNSProgressComp = reader.GetString(0);

            // NS Progress OTJ vs COMP
            if (mathNSProgressOTJ.Equals(mathNSProgressComp))
            {
                mathNSProgressOTJVsComp = "1";
            }
            else
            {
                mathNSProgressOTJVsComp = "0";
            }

            //Math Effort Level
            switch (mathEffort)
            {
                case "1":
                    mathEffortLevel = "Below";
                    break;
                case "2":
                    mathEffortLevel = "At";
                    break;
                case "3":
                    mathEffortLevel = "Above";
                    break;
            }

            // Effort Statement
            OleDbCommand cmdMathEffortStatement = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + mathEffort + "'; ");
            cmdMathEffortStatement.Connection = conn;
            reader = cmdMathEffortStatement.ExecuteReader();
            reader.Read();
            mathEffortStatement = reader.GetString(0);

            //Math Comment Length
            mathCommentLength = mathComment.Length.ToString();


        }

        private void curiosity()
        {

            OleDbCommand cmdCuriosity1 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity1 + "'; ");
            cmdCuriosity1.Connection = conn;
            OleDbDataReader reader = cmdCuriosity1.ExecuteReader();
            reader.Read();
            curiosity1Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity2 + "'; ");
            cmdCuriosity2.Connection = conn;
            reader = cmdCuriosity2.ExecuteReader();
            reader.Read();
            curiosity2Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity3 + "'; ");
            cmdCuriosity3.Connection = conn;
            reader = cmdCuriosity3.ExecuteReader();
            reader.Read();
            curiosity3Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity4 + "'; ");
            cmdCuriosity4.Connection = conn;
            reader = cmdCuriosity4.ExecuteReader();
            reader.Read();
            curiosity4Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity5 + "'; ");
            cmdCuriosity5.Connection = conn;
            reader = cmdCuriosity5.ExecuteReader();
            reader.Read();
            curiosity5Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity6 + "'; ");
            cmdCuriosity6.Connection = conn;
            reader = cmdCuriosity6.ExecuteReader();
            reader.Read();
            curiosity6Statement = reader.GetString(0);
        }

        private void creativity()
        {
            OleDbCommand cmdCreativity1 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity1 + "'; ");
            cmdCreativity1.Connection = conn;
            OleDbDataReader reader = cmdCreativity1.ExecuteReader();
            reader.Read();
            creativity1Statement = reader.GetString(0);

            OleDbCommand cmdCreativity2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity2 + "'; ");
            cmdCreativity2.Connection = conn;
            reader = cmdCreativity2.ExecuteReader();
            reader.Read();
            creativity2Statement = reader.GetString(0);

            OleDbCommand cmdCreativity3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity3 + "'; ");
            cmdCreativity3.Connection = conn;
            reader = cmdCreativity3.ExecuteReader();
            reader.Read();
            creativity3Statement = reader.GetString(0);

            OleDbCommand cmdCreativity4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity4 + "'; ");
            cmdCreativity4.Connection = conn;
            reader = cmdCreativity4.ExecuteReader();
            reader.Read();
            creativity4Statement = reader.GetString(0);

            OleDbCommand cmdCreativity5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity5 + "'; ");
            cmdCreativity5.Connection = conn;
            reader = cmdCreativity5.ExecuteReader();
            reader.Read();
            creativity5Statement = reader.GetString(0);

            OleDbCommand cmdCreativity6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity6 + "'; ");
            cmdCreativity6.Connection = conn;
            reader = cmdCreativity6.ExecuteReader();
            reader.Read();
            creativity6Statement = reader.GetString(0);
        }

        private void community()
        {

            OleDbCommand cmdCommunity1 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community1 + "'; ");
            cmdCommunity1.Connection = conn;
            OleDbDataReader reader = cmdCommunity1.ExecuteReader();
            reader.Read();
            community1Statement = reader.GetString(0);

            OleDbCommand cmdCommunity2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community2 + "'; ");
            cmdCommunity2.Connection = conn;
            reader = cmdCommunity2.ExecuteReader();
            reader.Read();
            community2Statement = reader.GetString(0);

            OleDbCommand cmdCommunity3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community3 + "'; ");
            cmdCommunity3.Connection = conn;
            reader = cmdCommunity3.ExecuteReader();
            reader.Read();
            community3Statement = reader.GetString(0);

            OleDbCommand cmdCommunity4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community4 + "'; ");
            cmdCommunity4.Connection = conn;
            reader = cmdCommunity4.ExecuteReader();
            reader.Read();
            community4Statement = reader.GetString(0);

            OleDbCommand cmdCommunity5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community5 + "'; ");
            cmdCommunity5.Connection = conn;
            reader = cmdCommunity5.ExecuteReader();
            reader.Read();
            community5Statement = reader.GetString(0);

            OleDbCommand cmdCommunity6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community6 + "'; ");
            cmdCommunity6.Connection = conn;
            reader = cmdCommunity6.ExecuteReader();
            reader.Read();
            community6Statement = reader.GetString(0);
        }

        private void sustainability()
        {

            OleDbCommand cmdsustainability1 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability1 + "'; ");
            cmdsustainability1.Connection = conn;
            OleDbDataReader reader = cmdsustainability1.ExecuteReader();
            reader.Read();
            sustainability1Statement = reader.GetString(0);

            OleDbCommand cmdsustainability2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability2 + "'; ");
            cmdsustainability2.Connection = conn;
            reader = cmdsustainability2.ExecuteReader();
            reader.Read();
            sustainability2Statement = reader.GetString(0);

            OleDbCommand cmdsustainability3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability3 + "'; ");
            cmdsustainability3.Connection = conn;
            reader = cmdsustainability3.ExecuteReader();
            reader.Read();
            sustainability3Statement = reader.GetString(0);

            OleDbCommand cmdsustainability4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability4 + "'; ");
            cmdsustainability4.Connection = conn;
            reader = cmdsustainability4.ExecuteReader();
            reader.Read();
            sustainability4Statement = reader.GetString(0);

            OleDbCommand cmdsustainability5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability5 + "'; ");
            cmdsustainability5.Connection = conn;
            reader = cmdsustainability5.ExecuteReader();
            reader.Read();
            sustainability5Statement = reader.GetString(0);

            OleDbCommand cmdsustainability6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability6 + "'; ");
            cmdsustainability6.Connection = conn;
            reader = cmdsustainability6.ExecuteReader();
            reader.Read();
            sustainability6Statement = reader.GetString(0);
        }

        private void lifeSkills()
        {
            int cur1 = Int32.Parse(curiosity1);
            int cur2 = Int32.Parse(curiosity2);
            int cur3 = Int32.Parse(curiosity3);
            int cur4 = Int32.Parse(curiosity4);
            int cur5 = Int32.Parse(curiosity5);
            int cur6 = Int32.Parse(curiosity6);

            int cre1 = Int32.Parse(creativity1);
            int cre2 = Int32.Parse(creativity2);
            int cre3 = Int32.Parse(creativity3);
            int cre4 = Int32.Parse(creativity4);
            int cre5 = Int32.Parse(creativity5);
            int cre6 = Int32.Parse(creativity6);

            int com1 = Int32.Parse(community1);
            int com2 = Int32.Parse(community2);
            int com3 = Int32.Parse(community3);
            int com4 = Int32.Parse(community4);
            int com5 = Int32.Parse(community5);
            int com6 = Int32.Parse(community6);

            int sus1 = Int32.Parse(sustainability1);
            int sus2 = Int32.Parse(sustainability2);
            int sus3 = Int32.Parse(sustainability3);
            int sus4 = Int32.Parse(sustainability4);
            int sus5 = Int32.Parse(sustainability5);
            int sus6 = Int32.Parse(sustainability6);

            managingSelf = (cur3 + cur6 + cre6 + com1 + com2 + com3 + com4 + sus2 + sus3 + sus4).ToString();
            double managingSelfDec = Math.Round(((Double.Parse(managingSelf) - 2)) / 40, 2);

            managingSelfPercent = ((managingSelfDec) * 100).ToString();
            if (managingSelfDec >= 0.25)
            {
                if (managingSelfDec >= 0.5)
                {
                    if (managingSelfDec >= 0.75)
                    {
                        managingSelfStatement = "Awesome";
                    }
                    else
                    {
                        managingSelfStatement = "Admirable";
                    }
                }
                else
                {
                    managingSelfStatement = "Acceptable";
                }
            }
            else
            {
                managingSelfStatement = "Awesome";
            }

            relationToOthers = (cre5 + com1 + com2 + com4 + com5 + com6).ToString();
            double relationToOthersDec = Math.Round((Double.Parse(relationToOthers) - 1) / 24, 2);
            relationToOthersPercent = ((relationToOthersDec) * 100).ToString();
            if (relationToOthersDec >= 0.25)
            {
                if (relationToOthersDec >= 0.5)
                {
                    if (relationToOthersDec >= 0.75)
                    {
                        relationToOthersStatement = "Awesome";
                    }
                    else
                    {
                        relationToOthersStatement = "Admirable";
                    }
                }
                else
                {
                    relationToOthersStatement = "Acceptable";
                }
            }
            else
            {
                relationToOthersStatement = "Awesome";
            }


            participatingContributing = (cur1 + cre3 + cre4 + com3 + com5 + com6 + sus1 + sus2 + sus4).ToString();
            double participatingContributingDec = Math.Round((Double.Parse(participatingContributing) - 2) / 36, 2);
            participatingContributingPercent = ((participatingContributingDec) * 100).ToString();
            if (participatingContributingDec >= 0.25)
            {
                if (participatingContributingDec >= 0.5)
                {
                    if (participatingContributingDec >= 0.75)
                    {
                        participatingContributingStatement = "Awesome";
                    }
                    else
                    {
                        participatingContributingStatement = "Admirable";
                    }
                }
                else
                {
                    participatingContributingStatement = "Acceptable";
                }
            }
            else
            {
                participatingContributingStatement = "Awesome";
            }

            thinking = (cur1 + cur2 + cur4 + cur5 + cur6 + cre1 + cre2 + cre6 + sus1 + sus3 + sus5 + sus6).ToString();
            double thinkingDec = Math.Round((Double.Parse(thinking) - 2) / 48, 2);
            thinkingPercent = ((thinkingDec) * 100).ToString();
            if (thinkingDec >= 0.25)
            {
                if (thinkingDec >= 0.5)
                {
                    if (thinkingDec >= 0.75)
                    {
                        thinkingStatement = "Awesome";
                    }
                    else
                    {
                        thinkingStatement = "Admirable";
                    }
                }
                else
                {
                    thinkingStatement = "Acceptable";
                }
            }
            else
            {
                thinkingStatement = "Awesome";
            }

            lst = (cur1 + cur3 + cur4 + cur5 + cre1 + cre2 + cre3 + cre4 + cre5 + sus5 + sus6).ToString();
            double lstDec = Math.Round(Double.Parse(lst) / 44, 2);
            lstPercent = ((lstDec) * 100).ToString();
            if (lstDec >= 0.25)
            {
                if (lstDec >= 0.5)
                {
                    if (lstDec >= 0.75)
                    {
                        lstStatement = "Awesome";
                    }
                    else
                    {
                        lstStatement = "Admirable";
                    }
                }
                else
                {
                    lstStatement = "Acceptable";
                }
            }
            else
            {
                lstStatement = "Awesome";
            }
        }

        private void humanValuesCount()
        {
            yesHumanValues = "0";
            if (honesty.Equals("1") && excellence.Equals("1") && aroha.Equals("1") && respect.Equals("1") && trust.Equals("1"))
            {
                yesHumanValues = "1";
            }
            else
            {
                totalHumanValues = (Int32.Parse(honesty) + Int32.Parse(excellence) + Int32.Parse(aroha) + Int32.Parse(respect) + Int32.Parse(trust)).ToString();
            }
        }

        private void progressCheck()
        {
            readingProgressCheck = writingProgressCheck = mathProgressCheck = "0";
            if (readingFinalAssessment.Equals(readingInitialAssessment))
            {
                readingProgressCheck = "1";
            }
            if (Int32.Parse(writingInitialGrade) < Int32.Parse(writingFinalGrade))
            {
                writingProgressCheck = "1";

            }
            if (Int32.Parse(mathInitialGrade) < Int32.Parse(mathFinalGrade))
            {
                mathProgressCheck = "1";
            }
        }

        private void misc()
        {

            int readingCode = Int32.Parse(readingNSAchievementCode);
            int writingCode = Int32.Parse(writingNSAchievementCode);
            int mathCode = Int32.Parse(mathNSAchievementCode);

            studentsWellBelow = studentsBelow = studentsAt = studentsAbove = studentsWellAbove = "XXX";

            dataSummary = readingNSAchievementCode + "R " + writingNSAchievementCode + "W " + mathNSAchievementCode + "M";
            checkSums = (readingCode + writingCode + mathCode).ToString();

            if (readingCode == 1)
            {
                studentsWellBelow = "1";
                if (writingCode == 1)
                {
                    studentsWellBelow += "1";
                    if (mathCode == 1)
                    {
                        studentsWellBelow += "1";
                    }
                    else
                    {
                        studentsWellBelow += "X";
                    }
                }
                else
                {
                    studentsWellBelow += "X";
                }
            }
            else if (readingCode == 2)
            {
                studentsBelow = "1";
                if (writingCode == 1)
                {
                    studentsBelow += "1";
                    if (mathCode == 1)
                    {
                        studentsBelow += "1";
                    }
                    else
                    {
                        studentsBelow += "X";
                    }
                }
                else
                {
                    studentsBelow += "X";
                }
            }
            else if (readingCode == 3)
            {
                studentsAt = "1";
                if (writingCode == 1)
                {
                    studentsAt += "1";
                    if (mathCode == 1)
                    {
                        studentsAt += "1";
                    }
                    else
                    {
                        studentsAt += "X";
                    }
                }
                else
                {
                    studentsAt += "X";
                }
            }
            else if (readingCode == 4)
            {
                studentsAbove = "1";
                if (writingCode == 1)
                {
                    studentsWellBelow += "1";
                    if (mathCode == 1)
                    {
                        studentsAbove += "1";
                    }
                    else
                    {
                        studentsAbove += "X";
                    }
                }
                else
                {
                    studentsAbove += "X";
                }
            }
            else if (readingCode == 5)
            {
                studentsWellAbove = "1";
                if (writingCode == 1)
                {
                    studentsWellAbove += "1";
                    if (mathCode == 1)
                    {
                        studentsWellAbove += "1";
                    }
                    else
                    {
                        studentsWellAbove += "X";
                    }
                }
                else
                {
                    studentsWellAbove += "X";
                }
            }

            

        }

        private void allCalculations()
        {
            readingCalculations();
            writingCalculations();
            mathCalculations();

            curiosity();
            creativity();
            community();
            sustainability();

            lifeSkills();
            humanValuesCount();
            progressCheck();
            misc();
        }

        public void Calculate()
        {
            try
            {
                conn.Open();
                OleDbCommand allStudents = new OleDbCommand();

                allStudents = new OleDbCommand("SELECT [NSN]"
                 + " FROM [Student]; ");

                allStudents.Connection = conn;

                OleDbDataAdapter allData = new OleDbDataAdapter(allStudents);
                DataTable allTable = new DataTable();
                allData.Fill(allTable);

                foreach (DataRow dr in allTable.Rows)
                {
                    string NSN = dr["NSN"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT * "
                        + "FROM (((([Student] s "
                        + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "
                        + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN])"
                        + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"
                        + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "

                        + "WHERE s.[NSN] = '" + NSN + "'; ");

                    

                    cmd.Connection = conn;
                    OleDbDataAdapter daa = new OleDbDataAdapter(cmd);
                    DataTable dtt = new DataTable();
                    daa.Fill(dtt);


                    foreach (DataRow drr in dtt.Rows)
                    {
                        firstName = drr["Preferred Name"].ToString();
                        gender = drr["Gender"].ToString();
                        room = drr["Room Number"].ToString();
                        NSAchieve = drr["National Standard Achieve"].ToString();
                        NSProgress = drr["National Standard Progress"].ToString();
                        nextRoom = drr["Next Room Number"].ToString();
                        generalComment = drr["General Comment"].ToString();

                        readingInitialAssessmentMethod = drr["Reading Initial Assessment Method"].ToString();
                        readingFinalAssessmentMethod = drr["Reading Final Assessment Method"].ToString();
                        readingInitialAssessment = drr["Reading Initial Assessment Level"].ToString();
                        readingFinalAssessment = drr["Reading Final Assessment Level"].ToString();
                        readingNSAchievementCode = drr["Reading NS Achievement Code"].ToString();
                        readingNSProgressCode = drr["Reading NS Progress"].ToString();
                        readingEffort = drr["Reading Effort"].ToString();
                        readingComment = drr["Reading Comment"].ToString();

                        writingInitialAssessment = drr["Writing Initial Assessment"].ToString();
                        writingFinalAssessment = drr["Writing Final Assessment"].ToString();
                        writingNS3Code = drr["Writing NS3 Code"].ToString();
                        writingNSAchievementCode = drr["Writing NS Achievement Code"].ToString();
                        writingNSProgressCode = drr["Writing NS Progress Code"].ToString();
                        writingEffort = drr["Writing Effort"].ToString();
                        writingComment = drr["Writing Comment"].ToString();

                        mathFinalAssessmentMethod = drr["Math Final Assessment Method"].ToString();
                        mathInitialAssessmentLevel = drr["Math Initial Assessment Level"].ToString();
                        mathOverallAssessment = drr["Math Overall Assessment"].ToString();
                        mathKf1 = drr["Math KF1"].ToString();
                        mathKf2 = drr["Math KF2"].ToString();
                        mathKf3 = drr["Math KF3"].ToString();
                        mathKf4 = drr["Math KF4"].ToString();
                        mathNs1 = drr["Math NS1"].ToString();
                        mathNs2 = drr["Math NS2"].ToString();
                        mathNSAchievementCode = drr["Math NS Achievement Code"].ToString();
                        mathNSProgressCode = drr["Math NS Progress Code"].ToString();
                        mathEffort = drr["Math Effort"].ToString();
                        mathComment = drr["Math Comment"].ToString();

                        curiosity1 = drr["Curiosity 1"].ToString();
                        curiosity2 = drr["Curiosity 2"].ToString();
                        curiosity3 = drr["Curiosity 3"].ToString();
                        curiosity4 = drr["Curiosity 4"].ToString();
                        curiosity5 = drr["Curiosity 5"].ToString();
                        curiosity6 = drr["Curiosity 6"].ToString();
                        creativity1 = drr["Creativity 1"].ToString();
                        creativity2 = drr["Creativity 2"].ToString();
                        creativity3 = drr["Creativity 3"].ToString();
                        creativity4 = drr["Creativity 4"].ToString();
                        creativity5 = drr["Creativity 5"].ToString();
                        creativity6 = drr["Creativity 6"].ToString();
                        community1 = drr["Community 1"].ToString();
                        community2 = drr["Community 2"].ToString();
                        community3 = drr["Community 3"].ToString();
                        community4 = drr["Community 4"].ToString();
                        community5 = drr["Community 5"].ToString();
                        community6 = drr["Community 6"].ToString();
                        sustainability1 = drr["Sustainability 1"].ToString();
                        sustainability2 = drr["Sustainability 2"].ToString();
                        sustainability3 = drr["Sustainability 3"].ToString();
                        sustainability4 = drr["Sustainability 4"].ToString();
                        sustainability5 = drr["Sustainability 5"].ToString();
                        sustainability6 = drr["Sustainability 6"].ToString();

                        honesty = drr["Honesty"].ToString();
                        excellence = drr["Excellence"].ToString();
                        aroha = drr["Aroha"].ToString();
                        respect = drr["Respect"].ToString();
                        trust = drr["Trust"].ToString();

                        //Current Teacher
                        OleDbCommand cmdTeacherThisYear = new OleDbCommand("SELECT [Current Teacher]"
                        + " FROM [Room]"
                        + " WHERE [Room No] = '" + room.ToString() + "'; ");
                        cmdTeacherThisYear.Connection = conn;
                        OleDbDataReader reader = cmdTeacherThisYear.ExecuteReader();
                        reader.Read();
                        teacherThisYear = reader.GetString(0);

                        //School Year Ordinal
                        OleDbCommand cmdSchoolYearOrdinal = new OleDbCommand("SELECT [Achievement Ordinal]"
                        + " FROM [National Standard Codes]"
                        + " WHERE [National Standard Code] = '" + NSAchieve + "'; ");
                        cmdSchoolYearOrdinal.Connection = conn;

                        reader = cmdSchoolYearOrdinal.ExecuteReader();
                        reader.Read();
                        schoolYearOrdinal = reader.GetString(0);

                        //Next Teacher
                        OleDbCommand cmdNextTeacher = new OleDbCommand("SELECT [Next Year Teacher]"
                        + " FROM [Room]"
                        + " WHERE [Room No] = '" + nextRoom + "'; ");
                        cmdNextTeacher.Connection = conn;
                        reader = cmdNextTeacher.ExecuteReader();
                        reader.Read();
                        nextTeacher = reader.GetString(0);

                        //Placement Statement

                        if (nextTeacher.Equals("Leaving"))
                        {
                            placementStatement = "Our records show that " + firstName + " will be leaving Laingholm Primary School - "
                                + "'The Greatest Little School in the Universe' - at the end of this year. As a school we would like "
                                + "to take the opportunity to wish " + firstName + " well for the future in the belief that "
                                + firstName + " will continue to 'Reach for the Stars'.";
                        }
                        else
                        {
                            placementStatement = "Over the past few months we have given very careful consideration to "
                                + firstName + "’s classroom placement for 2016. As a school we endeavour to personalise "
                                + "the learning for each student. We take into account academic performance, friendship "
                                + " groups and a number of other factors when placing a student in a particular class.";
                        }

                        // Next Room Statement

                        if (nextRoom.Equals("99"))
                        {
                            nextRoomStatement = "Best wishes from all the staff and students at Laingholm Primary School, "
                                + "'The Greatest Little School in the Universe'. Ko te pae tawhiti whaaia kia tata, ko te pae tata whakamaua kia tiina.";
                        }
                        else
                        {
                            nextRoomStatement = "In 2016 " + firstName + "  will be in Room " + nextRoom + "  with " + nextTeacher;
                        }

                        // He/She

                        if (gender.Equals("Male"))
                        {
                            heShe = "he";
                            hisHer = "his";
                            himHer = "him";
                        }
                        else
                        {
                            heShe = "she";
                            hisHer = "her";
                            himHer = "her";
                        }

                        generalCommentLength = generalComment.Length.ToString();

                        OleDbCommand cmdReadingFinalCode = new OleDbCommand("SELECT [Reading Code]"
                        + " FROM [Reading National Standards]"
                        + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
                        cmdReadingFinalCode.Connection = conn;
                        reader = cmdReadingFinalCode.ExecuteReader();
                        reader.Read();
                        readingFinalCode = reader.GetString(0);

                        OleDbCommand cmdMathInitialGrade = new OleDbCommand("SELECT [Num Position1], [Position1]"
                        + " FROM [Math Reverse Lookup]"
                        + " WHERE [Stage] = '" + mathInitialAssessmentLevel + "'; ");
                        cmdMathInitialGrade.Connection = conn;
                        reader = cmdMathInitialGrade.ExecuteReader();
                        reader.Read();
                        mathInitialGrade = reader.GetString(0);
                        strMathInitialGrade = reader.GetString(1);


                        allCalculations();

                        overallAcademic = ((Double.Parse(readingFinalCode) / 2) + (Double.Parse(writingOverallGrade)) + (Double.Parse(mathFinalGrade) * 2)).ToString();

                    }

                    int numActivities = 0;
                    int sportsActivities = 0;

                    // Cultural Activities
                    OleDbCommand cmdActivitiesCount = new OleDbCommand("SELECT * "
                    + "FROM (([Cultural Activities] ca "
                    + "INNER JOIN [Sports Activities] sa ON sa.[NSN] = ca.[NSN]) "
                    + "INNER JOIN [Extra Activities] ea ON ea.[NSN] = ca.[NSN]) "
                    + "WHERE ca.[NSN] = '" + NSN + "'; ");
                    cmdActivitiesCount.Connection = conn;
                    OleDbDataAdapter activitiesAdaptar = new OleDbDataAdapter(cmdActivitiesCount);
                    DataTable activitiesDT = new DataTable();
                    activitiesAdaptar.Fill(activitiesDT);

                    foreach (DataRow dtRow in activitiesDT.Rows)
                    {
                        foreach (DataColumn dtCol in activitiesDT.Columns)
                        {
                            if ((dtRow[dtCol].ToString()).Equals("1"))
                            {
                                numActivities++;
                            }
                        }
                    }

                    numActivitiesStr = numActivities.ToString();


                    // Sports Activities
                    OleDbCommand cmdSportsCount = new OleDbCommand("SELECT * "
                    + "FROM [Sports Activities] "
                    + "WHERE [NSN] = '" + NSN + "'; ");

                    cmdSportsCount.Connection = conn;
                    OleDbDataAdapter sportsAdapter = new OleDbDataAdapter(cmdSportsCount);
                    DataTable sportsDT = new DataTable();
                    sportsAdapter.Fill(sportsDT);

                    foreach (DataRow dtRow in sportsDT.Rows)
                    {
                        foreach (DataColumn dtCol in sportsDT.Columns)
                        {
                            if ((dtRow[dtCol].ToString()).Equals("1"))
                            {
                                sportsActivities++;
                            }
                        }
                    }
                    sportsActivitiesStr = sportsActivities.ToString();

                    //Teachers Cup
                    teachersCup = ((Double.Parse(readingFinalCode) / 2) +
                        Double.Parse(writingFinalGrade) +
                        (Double.Parse(mathFinalGrade) * 2) +
                        (Double.Parse(sportsActivitiesStr) * 2) +
                        (Double.Parse(numActivitiesStr) - Double.Parse(sportsActivitiesStr))).ToString();
                    /*
                     * Updating Table
                     * */
                    updateTable(NSN);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                conn.Close();
            }


        }

        private void updateTable(string NSN)
        {
            /*
            OleDbCommand deleteCmd = new OleDbCommand("DELETE FROM [Calculated] WHERE [NSN] = '" + NSN + "';");
            deleteCmd.Connection = conn;
            int deleteSuccess = deleteCmd.ExecuteNonQuery();

            if (deleteSuccess < 1)
            {
                MessageBox.Show("Deleting Database Failed");
            }
            else
            {
                MessageBox.Show("Database has been Successfully Deleted");
            }
            */

            // Use table that contains relationship between Calculated table and the variables here
            OleDbCommand relationshipCmd = new OleDbCommand("SELECT *"
                 + " FROM [Calculated]; ");

            relationshipCmd.Connection = conn;

            OleDbDataAdapter relationshipAdapter = new OleDbDataAdapter(relationshipCmd);
            DataTable relationshipTable = new DataTable();
            relationshipAdapter.Fill(relationshipTable);



            // Generate Update statement
            string update = "Update [Calculated] SET ";
            int i = 0;
            Dictionary<string, string> dict = createDictionary(NSN);
            int len = dict.Count;
            /*
            foreach (DataColumn drr in relationshipTable.Columns)
            {
                string calc = drr.ColumnName;

                Console.WriteLine(calc + ": " + dict[calc]);
                //var sys = drr["System Field"].ToString();
                if (i == len - 1)
                {
                    update += "[" + calc + "] = '" + dict[calc] + "' ";
                }
                else
                {
                    update += "[" + calc + "] = '" + dict[calc] + "', ";
                }
                i++;

            }
            */
            foreach (KeyValuePair<string, string> pair in dict)
            {
                string field = pair.Key;
                string value = pair.Value;

                if (i == len - 1)
                {
                    update += "[" + field + "] = '" + value + "' ";
                }
                else
                {
                    update += "[" + field + "] = '" + value + "', ";
                }
                Console.WriteLine(i);
                i++;
            }


            update += "WHERE NSN = '" + NSN + "';";
            Console.WriteLine(update);
            //Using Previous IF statement to create update statement
            OleDbCommand updateCmd = new OleDbCommand(update);

            //Manually updating

            updateCmd.Connection = conn;
            int rowCount = updateCmd.ExecuteNonQuery();

            if (rowCount < 1)
            {
                MessageBox.Show("Updating Database Failed");
            }
            else
            {
                MessageBox.Show("Database has been Successfully Updated");
            }

            
        }

        private Dictionary<string, string> createDictionary(string NSN)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["NSN"] = NSN;
            dict["Teacher This Year"] = teacherThisYear;
            dict["School Year Ordinal"] = schoolYearOrdinal;
            dict["Next Teacher"] = nextTeacher;
            dict["Placement Statement"] = placementStatement;
            dict["Next Room Statement"] = nextRoomStatement;
            dict["HeShe"] = heShe;
            dict["HisHer"] = hisHer;
            dict["HimHer"] = himHer;
            dict["General Comment Length"] = generalCommentLength;
            dict["Reading Initial Statement"] = readingInitialStatement;
            dict["Reading Final Statement"] = readingFinalStatement;
            dict["Reading KF1"] = readingKF1;
            dict["Reading KF2"] = readingKF2;
            dict["Reading NS1"] = readingNS1;
            dict["Reading NS2"] = readingNS2;
            dict["Reading Final Code"] = readingFinalCode;
            dict["Reading NS Achievement Timeframe"] = readingNSAchievementTimeframe;
            dict["Reading NS Achievement Statement"] = readingNSAchievementStatement;
            dict["Reading NS Achieve Level"] = readingNSAchieveLevel;
            dict["Reading NS Achievement OTJ"] = readingNSAchievementOTJ;
            dict["Reading NS Achievement Comp"] = readingNSAchievementComp;
            dict["Reading NS Achievement OTJ vs Comp"] = readingNSAchievementOTJVsComp;
            dict["Reading NS Progress Timeframe"] = readingNSProgressTimeframe;
            dict["Reading NS Progress Statement"] = readingNSProgressStatement;
            dict["Reading NS Progress Level"] = readingNSProgressLevel;
            dict["Reading NS Progress OTJ"] = readingNSProgressOTJ;
            dict["Reading NS Progress Comp"] = readingNSProgressComp;
            dict["Reading NS Progress OTJ vs Comp"] = readingNSProgressOTJVsComp;
            dict["Reading Effort Level"] = readingEffortLevel;
            dict["Reading Effort Statement"] = readingEffortStatement;
            dict["Reading Comment Length"] = readingCommentLength;
            /*
            dict["Writing Initial Grade"] = writingInitialGrade;
            dict["Writing Final Grade"] = writingFinalGrade;
            dict["Writing Overall Grade"] = writingOverallGrade;
            dict["Writing Overall Assessment"] = writingOverallAssessment;
            dict["Writing KF1"] = writingKF1;
            dict["Writing KF2"] = writingKF2;
            dict["Writing NS1"] = writingNS1;
            dict["Writing NS2"] = writingNS2;
            dict["Writing NS3 Statement"] = writingNS3Statement;
            dict["Writing NS Achievement Timeframe"] = writingNSAchievementTimeframe;
            dict["Writing NS Achievement Statement"] = writingNSAchievementStatement;
            dict["Writing NS Achieve Level"] = writingNSAchieveLevel;
            dict["Writing NS Achievement OTJ"] = writingNSAchievementOTJ;
            dict["Writing NS Achievement Comp"] = writingNSAchievementComp;
            dict["Writing NS Achievement OTJ vs Comp"] = writingNSAchievementOTJVsComp;
            dict["Writing NS Progress Timeframe"] = writingNSProgressTimeframe;
            dict["Writing NS Progress Statement"] = writingNSProgressStatement;
            dict["Writing NS Progress Level"] = writingNSProgressLevel;
            dict["Writing NS Progress OTJ"] = writingNSProgressOTJ;
            dict["Writing NS Progress Comp"] = writingNSProgressComp;
            dict["Writing NS Progress OTJ vs Comp"] = writingNSProgressOTJVsComp;
            dict["Writing Effort Level"] = writingEffortLevel;
            dict["Writing Effort Statement"] = writingEffortStatement;
            dict["Writing Comment Length"] = writingCommentLength;
            dict["Math KF1 Statement"] = mathKf1Statement;
            dict["Math KF2 Statement"] = mathKf2Statement;
            dict["Math KF3 Statement"] = mathKf3Statement;
            dict["Math KF4 Statement"] = mathKf4Statement;
            dict["Math NS1 Statement"] = mathNS1Statement;
            dict["Math NS2 Statement"] = mathNS2Statement;
            dict["Math NA Stage Check"] = mathNAStageCheck;
            dict["Math NA Average"] = mathNAAverage;
            dict["Math NA Round"] = mathNARound;
            dict["Math NS Achievement Timeframe"] = mathNSAchievementTimeframe;
            dict["Math NS Achievement Statement"] = mathNSAchievementStatement;
            dict["Math NS Achieve Level"] = mathNSAchieveLevel;
            dict["Math NS Achievement OTJ"] = mathNSAchievementOTJ;
            dict["Math NS Achievement Comp"] = mathNSAchievementComp;
            dict["Math NS Achievement OTJ vs Comp"] = mathNSAchievementOTJVsComp;
            dict["Math NS Progress Timeframe"] = mathNSProgressTimeframe;
            dict["Math NS Progress Statement"] = mathNSProgressStatement;
            dict["Math NS Progress Level"] = mathNSProgressLevel;
            dict["Math NS Progress OTJ"] = mathNSProgressOTJ;
            dict["Math NS Progress Comp"] = mathNSProgressComp;
            dict["Math NS Progress OTJ vs Comp"] = mathNSProgressOTJVsComp;
            dict["Math Effort Level"] = mathEffortLevel;
            dict["Math Effort Statement"] = mathEffortStatement;
            dict["Math Comment Length"] = mathCommentLength;
            dict["Math Final Grade"] = mathFinalGrade;
            dict["Math Final Initial Grade"] = mathInitialGrade;
            dict["Managing Self"] = managingSelf;
            dict["Managing Self Percent"] = managingSelfPercent;
            dict["Managing Self Statement"] = managingSelfStatement;
            dict["Relation To Others"] = relationToOthers;
            dict["Relation To Others Percent"] = relationToOthersPercent;
            dict["Relation To Others Statement"] = relationToOthersStatement;
            dict["Participating Contributing"] = participatingContributing;
            dict["Participating Contributing Percent"] = participatingContributingPercent;
            dict["Participating Contributing Statement"] = participatingContributingStatement;
            dict["Thinking"] = thinking;
            dict["Thinking Percent"] = thinkingPercent;
            dict["Thinking Statement"] = thinkingStatement;
            dict["LST"] = lst;
            dict["LST Percent"] = lstPercent;
            dict["LST Statement"] = lstStatement;
            dict["Activities Count"] = numActivitiesStr;
            dict["Sports Count"] = sportsActivitiesStr;
            dict["Overall Academic"] = overallAcademic;
            dict["All Human Values"] = yesHumanValues;
            dict["Total Human Values"] = totalHumanValues;
            dict["Reading Progress Check"] = readingProgressCheck;
            dict["Writing Progress Check"] = writingProgressCheck;
            dict["Math Progress Check"] = mathProgressCheck;
            dict["Data Summary"] = dataSummary;
            dict["Students Well Below"] = studentsWellBelow;
            dict["Students Below"] = studentsBelow;
            dict["Students At"] = studentsAt;
            dict["Students Above"] = studentsAbove;
            dict["Students Well Above"] = studentsWellAbove;
            dict["Check Sum"] = checkSums;
            */
            //debugging(NSN);
            
            return dict;
        }

       
        private void debugging(string NSN)
        {

            Console.WriteLine("NSN: " + NSN
 + "\nTeacher This Year: " + teacherThisYear
 + "\nSchool Year Ordinal: " + schoolYearOrdinal
 + "\nNext Teacher: " + nextTeacher
 + "\nPlacement Statement: " + placementStatement
 + "\nNext Room Statement: " + nextRoomStatement
 + "\nHeShe: " + heShe
 + "\nHisHer: " + hisHer
 + "\nHimHer: " + himHer
 + "\nGeneral Comment Length: " + generalCommentLength
 + "\nReading Initial Statement: " + readingInitialStatement
 + "\nReading Final Statement: " + readingFinalStatement
 + "\nReading KF1: " + readingKF1
 + "\nReading KF2: " + readingKF2
 + "\nReading NS1: " + readingNS1
 + "\nReading NS2: " + readingNS2
 + "\nReading Final Code: " + readingFinalCode
 + "\nReading NS Achievement Timeframe: " + readingNSAchievementTimeframe
 + "\nReading NS Achievement Statement: " + readingNSAchievementStatement
 + "\nReading NS Achieve Level: " + readingNSAchieveLevel
 + "\nReading NS Achievement OTJ: " + readingNSAchievementOTJ
 + "\nReading NS Achievement Comp: " + readingNSAchievementComp
 + "\nReading NS Achievement OTJ vs Comp: " + readingNSAchievementOTJVsComp
 + "\nReading NS Progress Timeframe: " + readingNSProgressTimeframe
 + "\nReading NS Progress Statement: " + readingNSProgressStatement
 + "\nReading NS Progress Level: " + readingNSProgressLevel
 + "\nReading NS Progress OTJ: " + readingNSProgressOTJ
 + "\nReading NS Progress Comp: " + readingNSProgressComp
 + "\nReading NS Progress OTJ vs Comp: " + readingNSProgressOTJVsComp
 + "\nReading Effort Level: " + readingEffortLevel
 + "\nReading Effort Statement: " + readingEffortStatement
 + "\nReading Comment Length: " + readingCommentLength
 + "\nWriting Initial Grade: " + writingInitialGrade
 + "\nWriting Final Grade: " + writingFinalGrade
 + "\nWriting Overall Grade: " + writingOverallGrade
 + "\nWriting Overall Assessment: " + writingOverallAssessment
 + "\nWriting KF1: " + writingKF1
 + "\nWriting KF2: " + writingKF2
 + "\nWriting NS1: " + writingNS1
 + "\nWriting NS2: " + writingNS2
 + "\nWriting NS3 Statement: " + writingNS3Statement
 + "\nWriting NS Achievement Timeframe: " + writingNSAchievementTimeframe
 + "\nWriting NS Achievement Statement: " + writingNSAchievementStatement
 + "\nWriting NS Achieve Level: " + writingNSAchieveLevel
 + "\nWriting NS Achievement OTJ: " + writingNSAchievementOTJ
 + "\nWriting NS Achievement Comp: " + writingNSAchievementComp
 + "\nWriting NS Achievement OTJ vs Comp: " + writingNSAchievementOTJVsComp
 + "\nWriting NS Progress Timeframe: " + writingNSProgressTimeframe
 + "\nWriting NS Progress Statement: " + writingNSProgressStatement
 + "\nWriting NS Progress Level: " + writingNSProgressLevel
 + "\nWriting NS Progress OTJ: " + writingNSProgressOTJ
 + "\nWriting NS Progress Comp: " + writingNSProgressComp
 + "\nWriting NS Progress OTJ vs Comp: " + writingNSProgressOTJVsComp
 + "\nWriting Effort Level: " + writingEffortLevel
 + "\nWriting Effort Statement: " + writingEffortStatement
 + "\nWriting Comment Length: " + writingCommentLength
 + "\nMath KF1 Statement: " + mathKf1Statement
 + "\nMath KF2 Statement: " + mathKf2Statement
 + "\nMath KF3 Statement: " + mathKf3Statement
 + "\nMath KF4 Statement: " + mathKf4Statement
 + "\nMath NS1 Statement: " + mathNS1Statement
 + "\nMath NS2 Statement: " + mathNS2Statement
 + "\nMath NA Stage Check: " + mathNAStageCheck
 + "\nMath NA Average: " + mathNAAverage
 + "\nMath NA Round: " + mathNARound
 + "\nMath NS Achievement Timeframe: " + mathNSAchievementTimeframe
 + "\nMath NS Achievement Statement: " + mathNSAchievementStatement
 + "\nMath NS Achieve Level: " + mathNSAchieveLevel
 + "\nMath NS Achievement OTJ: " + mathNSAchievementOTJ
 + "\nMath NS Achievement Comp: " + mathNSAchievementComp
 + "\nMath NS Achievement OTJ vs Comp: " + mathNSAchievementOTJVsComp
 + "\nMath NS Progress Timeframe: " + mathNSProgressTimeframe
 + "\nMath NS Progress Statement: " + mathNSProgressStatement
 + "\nMath NS Progress Level: " + mathNSProgressLevel
 + "\nMath NS Progress OTJ: " + mathNSProgressOTJ
 + "\nMath NS Progress Comp: " + mathNSProgressComp
 + "\nMath NS Progress OTJ vs Comp: " + mathNSProgressOTJVsComp
 + "\nMath Effort Level: " + mathEffortLevel
 + "\nMath Effort Statement: " + mathEffortStatement
 + "\nMath Comment Length: " + mathCommentLength
 + "\nMath Final Grade: " + mathFinalGrade
 + "\nMath Final Initial Grade: " + mathInitialGrade
 + "\nManaging Self: " + managingSelf
 + "\nManaging Self Percent: " + managingSelfPercent
 + "\nManaging Self Statement: " + managingSelfStatement
 + "\nRelation To Others: " + relationToOthers
 + "\nRelation To Others Percent: " + relationToOthersPercent
 + "\nRelation To Others Statement: " + relationToOthersStatement
 + "\nParticipating Contributing: " + participatingContributing
 + "\nParticipating Contributing Percent: " + participatingContributingPercent
 + "\nParticipating Contributing Statement: " + participatingContributingStatement
 + "\nThinking: " + thinking
 + "\nThinking Percent: " + thinkingPercent
 + "\nThinking Statement: " + thinkingStatement
 + "\nLST: " + lst
 + "\nLST Percent: " + lstPercent
 + "\nLST Statement: " + lstStatement
 + "\nActivities Count: " + numActivitiesStr
 + "\nSports Count: " + sportsActivitiesStr
 + "\nOverall Academic: " + overallAcademic
 + "\nAll Human Values: " + yesHumanValues
 + "\nTotal Human Values: " + totalHumanValues
 + "\nReading Progress Check: " + readingProgressCheck
 + "\nWriting Progress Check: " + writingProgressCheck
 + "\nMath Progress Check: " + mathProgressCheck
 + "\nData Summary: " + dataSummary
 + "\nStudents Well Below: " + studentsWellBelow
 + "\nStudents Below: " + studentsBelow
 + "\nStudents At: " + studentsAt
 + "\nStudents Above: " + studentsAbove
 + "\nStudents Well Above: " + studentsWellAbove
 + "\nCheck Sum: " + checkSums);

           
        }
        
    }
}
