using System;
using System.Collections;
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


        Dictionary<string, string> curDict;
        string curiosity1, curiosity1Statement;
        string curiosity2, curiosity2Statement;
        string curiosity3, curiosity3Statement;
        string curiosity4, curiosity4Statement;
        string curiosity5, curiosity5Statement;
        string curiosity6, curiosity6Statement;
        Dictionary<string, string> creDict;
        string creativity1, creativity1Statement;
        string creativity2, creativity2Statement;
        string creativity3, creativity3Statement;
        string creativity4, creativity4Statement;
        string creativity5, creativity5Statement;
        string creativity6, creativity6Statement;
        Dictionary<string, string> comDict;
        string community1, community1Statement;
        string community2, community2Statement;
        string community3, community3Statement;
        string community4, community4Statement;
        string community5, community5Statement;
        string community6, community6Statement;
        Dictionary<string, string> susDict;
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
        Dictionary<string, string> generalDict;
        string teacherThisYear;
        string schoolYearOrdinal;
        string nextTeacher;
        string placementStatement;
        string nextRoomStatement;
        string heShe, hisHer, himHer;
        string generalCommentLength;

        Dictionary<string, string> readingDict;
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
        string readingEffortStatement;
        string readingCommentLength;


        Dictionary<string, string> writingDict; 
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
        string writingEffortStatement;
        string writingCommentLength;

        Dictionary<string, string> mathDict;
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

        string connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;";

        public Calculations()
        {
            conn.ConnectionString = connectionStr; //For not Alex's laptop

        }

        //Checked
        private void readingCalculations()
        {
            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>(); 

            // Reading Initial Statement
            OleDbCommand cmd = new OleDbCommand("SELECT [Colour]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingInitialAssessment + "'; ");
            d["readingInitialStatement"] = cmd;

            cmd = new OleDbCommand("SELECT [Colour]"
           + " FROM [Reading National Standards]"
           + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            d["readingFinalStatement"] = cmd;

            cmd = new OleDbCommand("SELECT [KF 1]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            d["readingKF1"] = cmd;

            cmd = new OleDbCommand("SELECT [KF 2]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            d["readingKF2"] = cmd;

            cmd = new OleDbCommand("SELECT [NS 1]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            d["readingNS1"] = cmd;

            cmd = new OleDbCommand("SELECT [NS 2]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            d["readingNS2"] = cmd;

            cmd = new OleDbCommand("SELECT [Timeframe]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            d["readingNSAchievementTimeframe"] = cmd;

            cmd = new OleDbCommand("SELECT [Standard]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            d["readingNSAchievementStatement"] = cmd;

            cmd = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + readingNSAchievementCode + "'; ");
            d["readingNSAchievementOTJ"] = cmd;

            cmd = new OleDbCommand("SELECT [" + NSAchieve + "]"
           + " FROM [Reading National Standards]"
           + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            d["readingNSAchievementComp"] = cmd;

            cmd = new OleDbCommand("SELECT [Timeframe]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            d["readingNSProgressTimeframe"] = cmd;

            cmd = new OleDbCommand("SELECT [Standard]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            d["readingNSProgressStatement"] = cmd;

            cmd = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + readingNSProgressCode + "'; ");
            d["readingNSProgressOTJ"] = cmd;

            cmd = new OleDbCommand("SELECT [" + readingNSAchievementCode + "]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            d["readingNSProgressComp"] = cmd;

            cmd = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + readingEffort + "'; ");
            d["readingNSProgressOTJVsComp"] = cmd;

            readingDict = new Dictionary<string, string>();
            foreach(KeyValuePair<string, OleDbCommand> pair in d)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    
                    dbCmd.Connection = conn;
                    OleDbDataReader reader = dbCmd.ExecuteReader();
                    reader.Read();
                    readingDict[v] = reader.GetString(0);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                }
            }
            if (readingInitialAssessmentMethod.Equals("PROBE"))
            {
                readingDict["readingInitialStatement"] = "Reading Age " + readingDict["readingInitialStatement"] + " Years";
                readingDict["readingFinalStatement"] = "Reading Age " + readingDict["readingFinalStatement"] + " Years";
            }
            else
            {
                readingDict["readingInitialStatement"] += " - Level " + readingDict["readingInitialStatement"];
                readingDict["readingFinalStatement"] += " - Level " + readingDict["readingFinalStatement"];
            }
            readingDict["readingNSAchieveLevel"] = "EMPTY";

            // NS Achieve Level
            switch (readingNSAchievementCode)
            {
                case "1":
                    readingDict["readingNSAchieveLevel"] = "Well Below";
                    break;
                case "2":
                    readingDict["readingNSAchieveLevel"] = "Below";
                    break;
                case "3":
                    readingDict["readingNSAchieveLevel"] = "At";
                    break;
                case "4":
                    readingDict["readingNSAchieveLevel"] = "Above";
                    break;
                case "5":
                    readingDict["readingNSAchieveLevel"] = "Well Above";
                    break;
            }


            // NS Achievement OTJ vs COMP
            if (readingDict["readingNSAchievementOTJ"].Equals(readingDict["readingNSAchievementComp"]))
            {
                readingDict["readingNSAchievementOTJVsComp"] = "1";
            }
            else
            {
                readingDict["readingNSAchievementOTJVsComp"] = "0";
            }
            readingDict["readingNSProgressLevel"] = "EMPTY";
            // NS Progress Level
            switch (readingNSProgressCode)
            {
                case "1":
                    readingDict["readingNSProgressLevel"] = "Below";
                    break;
                case "2":
                    readingDict["readingNSProgressLevel"] = "At";
                    break;
                case "3":
                    readingDict["readingNSProgressLevel"] = "Above";
                    break;
            }

            if (readingDict["readingNSProgressOTJ"].Equals(readingDict["readingNSProgressComp"]))
            {
                readingDict["readingNSProgressOTJVsComp"] = "1";
            }
            else
            {
                readingDict["readingNSProgressOTJVsComp"] = "0";
            }

            readingDict["readingEffortStatement"] = "EMPTY";
            //Reading Effort Level
            switch (readingEffort)
            {
                case "1":
                    readingDict["readingEffortStatement"] = "Below";
                    break;
                case "2":
                    readingDict["readingEffortStatement"] = "At";
                    break;
                case "3":
                    readingDict["readingEffortStatement"] = "Above";
                    break;
            }

            //Reading Comment Length
            readingDict["readingCommentLength"] = readingComment.Length.ToString();


        }

        //Checked
        private void writingCalculations()
        {
            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>();
            writingDict = new Dictionary<string, string>();
            //Initial Grade
            OleDbCommand cmd = new OleDbCommand("SELECT [Grade]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingInitialAssessment + "'; ");
            cmd.Connection = conn;
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            writingDict["writingInitialGrade"] = reader.GetString(0);

            //Final Grade
            cmd = new OleDbCommand("SELECT [Grade]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            cmd.Connection = conn;
            reader = cmd.ExecuteReader();
            reader.Read();
            writingDict["writingFinalGrade"] = reader.GetString(0);

            if (Int32.Parse(writingDict["writingInitialGrade"]) < Int32.Parse(writingDict["writingFinalGrade"]))
            {
                writingDict["writingOverallGrade"] = writingDict["writingFinalGrade"];
            }
            else
            {
                writingDict["writingOverallGrade"] = writingDict["writingInitialGrade"];
            }

            //Overall Writing Assessment
            cmd = new OleDbCommand("SELECT [Writing Level]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Grade] = '" + writingDict["writingOverallGrade"] + "'; ");
            cmd.Connection = conn;
            reader = cmd.ExecuteReader();
            reader.Read();
            writingDict["writingOverallAssessment"] = reader.GetString(0);

            //KF 1 2, NS 1, 2
            cmd = new OleDbCommand("SELECT [KF 1]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingDict["writingOverallAssessment"] + "'; ");
            d["writingKF1"] = cmd;
            cmd = new OleDbCommand("SELECT [KF 2]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingDict["writingOverallAssessment"] + "'; ");
            d["writingKF2"] = cmd;
            cmd = new OleDbCommand("SELECT [NS 1]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingDict["writingOverallAssessment"] + "'; ");
            d["writingNS1"] = cmd;
            cmd = new OleDbCommand("SELECT [NS 2]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingDict["writingOverallAssessment"] + "'; ");
            d["writingNS2"] = cmd;

            //NS3 Statement
            cmd = new OleDbCommand("SELECT [Comment]"
                    + " FROM [Writing Year Standards]"
                    + " WHERE [Code] = '" + writingNS3Code + "'; ");
            d["writingNS3Statement"] = cmd;

            // NS Timeframe Writing Achieve
            cmd = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Writing Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            d["writingNSAchievementTimeframe"] = cmd;
            cmd = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Writing Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            d["writingNSAchievementStatement"] = cmd;

            // NS Writing Achievemet (OTJ)
            cmd = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + writingNSAchievementCode + "'; ");
            d["writingNSAchievementOTJ"] = cmd;

            // NS Writing Achievemet (Comp)
            cmd = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Writing National Standards]"
            + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            d["writingNSAchievementComp"] = cmd;

            // NS Timeframe Writing Progress
            cmd = new OleDbCommand("SELECT [Timeframe]"
            + " FROM [Writing Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            d["writingNSProgressTimeframe"] = cmd;
            cmd = new OleDbCommand("SELECT [Standard]"
            + " FROM [Writing Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            d["writingNSProgressStatement"] = cmd;

            // NS Writing Progress (OTJ)
            cmd = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + writingNSProgressCode + "'; ");
            d["writingNSProgressOTJ"] = cmd;

            // NS Writing Progress (Comp)
            cmd = new OleDbCommand("SELECT [" + writingNSAchievementCode + "]"
            + " FROM [Writing National Standards]"
            + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            d["writingNSProgressComp"] = cmd;

            // Effort Statement
            cmd = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + writingEffort + "'; ");
            d["writingEffortStatement"] = cmd;

            foreach (KeyValuePair<string, OleDbCommand> pair in d)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    
                    dbCmd.Connection = conn;
                    OleDbDataReader r = dbCmd.ExecuteReader();
                    r.Read();
                    writingDict[v] = r.GetString(0);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "Value is: " + pair.Value +"\n\n Here is message " + e);
                }
            }

            //Overall Grade

            writingDict["writingNSAchieveLevel"] = "EMPTY";
            // NS Achieve Level
            switch (writingNSAchievementCode)
            {
                case "1":
                    writingDict["writingNSAchieveLevel"] = "Well Below";
                    break;
                case "2":
                    writingDict["writingNSAchieveLevel"] = "Below";
                    break;
                case "3":
                    writingDict["writingNSAchieveLevel"] = "At";
                    break;
                case "4":
                    writingDict["writingNSAchieveLevel"] = "Above";
                    break;
                case "5":
                    writingDict["writingNSAchieveLevel"] = "Well Above";
                    break;
            }

            // NS Achievement OTJ vs COMP
            if (writingDict["writingNSAchievementOTJ"].Equals(writingDict["writingNSAchievementComp"]))
            {
                writingDict["writingNSAchievementOTJVsComp"] = "1";
            }
            else
            {
                writingDict["writingNSAchievementOTJVsComp"] = "0";
            }
            writingDict["writingNSProgressLevel"] = "EMPTY";
            // NS Progress Level
            switch (writingNSProgressCode)
            {
                case "1":
                    writingDict["writingNSProgressLevel"] = "Below";
                    break;
                case "2":
                    writingDict["writingNSProgressLevel"] = "At";
                    break;
                case "3":
                    writingDict["writingNSProgressLevel"] = "Above";
                    break;
            }

            // NS Progress OTJ vs COMP
            if (writingDict["writingNSProgressOTJ"].Equals(writingDict["writingNSProgressComp"]))
            {
                writingDict["writingNSProgressOTJVsComp"] = "1";
            }
            else
            {
                writingDict["writingNSProgressOTJVsComp"] = "0";
            }
            writingDict["writingEffortStatement"] = "EMPTY";
            //Writing Effort Level
            switch (writingEffort)
            {
                case "1":
                    writingDict["writingEffortStatement"] = "Below";
                    break;
                case "2":
                    writingDict["writingEffortStatement"] = "At";
                    break;
                case "3":
                    writingDict["writingEffortStatement"] = "Above";
                    break;
            }

            //Writing Comment Length
            writingDict["writingCommentLength"] = writingComment.Length.ToString();

        }

        //Checked
        private void mathCalculations()
        {
            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>();
            mathDict = new Dictionary<string, string>();
            //Stage Check
            OleDbCommand cmd = new OleDbCommand("SELECT [Position1]"
            + " FROM [Math Reverse Lookup]"
            + " WHERE [Stage] = '" + mathOverallAssessment + "'; ");
            cmd.Connection = conn;
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            mathDict["strMathFinalGrade"] = reader.GetString(0);

            // Math KF1
            cmd = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf1 + "'; ");
            d["mathKf1Statement"] = cmd;

            // Math KF1
            cmd = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf2 + "'; ");
            d["mathKf2Statement"] = cmd;

            // Math KF1
            cmd = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf3 + "'; ");
            d["mathKf3Statement"] = cmd;

            // Math KF1
            cmd = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf4 + "'; ");
            d["mathKf4Statement"] = cmd;

            // Math NS1
            cmd = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathNs1 + "'; ");
            d["mathNS1Statement"] = cmd;

            // Math NS1
            cmd = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathNs2 + "'; ");
            d["mathNS2Statement"] = cmd;

            

            cmd = new OleDbCommand("SELECT [Num Position1]"
            + " FROM [Math Reverse Lookup]"
            + " WHERE [Stage] = '" + mathOverallAssessment + "'; ");
            d["mathFinalGrade"] = cmd;

            cmd = new OleDbCommand("SELECT [Num Position2]"
            + " FROM [Math Reverse Lookup]"
            + " WHERE [Stage] = '" + mathOverallAssessment + "'; ");
            d["a"] = cmd;

            // NS Timeframe Math Achieve
            cmd = new OleDbCommand("SELECT [Timeframe]"
            + " FROM [Mathematics Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            d["mathNSAchievementTimeframe"] = cmd;

            cmd = new OleDbCommand("SELECT [Standard]"
            + " FROM [Mathematics Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            d["mathNSAchievementStatement"] = cmd;

            // NS Math Achievemet (OTJ)
            cmd = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + mathNSAchievementCode + "'; ");
            d["mathNSAchievementOTJ"] = cmd;

            // NS Math Achievemet (Comp)
            cmd = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Mathematics National Standards]"
            + " WHERE [Stage] = '" + mathDict["strMathFinalGrade"] + "'; ");
            d["mathNSAchievementComp"] = cmd;

            // NS Timeframe Math Progress
            cmd = new OleDbCommand("SELECT [Timeframe]"
            + " FROM [Mathematics Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            d["mathNSProgressTimeframe"] = cmd;

            cmd = new OleDbCommand("SELECT [Standard]"
            + " FROM [Mathematics Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            d["mathNSProgressStatement"] = cmd;

            // NS Math Progress (OTJ)
            cmd = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + mathNSProgressCode + "'; ");
            d["mathNSProgressOTJ"] = cmd;

            // NS Math Progress (Comp)

            cmd = new OleDbCommand("SELECT [" + mathNSAchievementCode + "]"
            + " FROM [Mathematics National Standards]"
            + " WHERE [Stage] = '" + mathDict["strMathFinalGrade"] + "'; ");            
            d["mathNSProgressComp"] = cmd;

            // Effort Statement
            cmd = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + mathEffort + "'; ");
            d["mathEffortStatement"] = cmd;

            foreach (KeyValuePair<string, OleDbCommand> pair in d)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    
                    dbCmd.Connection = conn;
                    OleDbDataReader r = dbCmd.ExecuteReader();
                    r.Read();
                    mathDict[v] = r.GetString(0);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                }
            }

            string mathNA1 = mathKf1.Substring(0, 1);
            string mathNA2 = mathKf2.Substring(0, 1);
            string mathNA3 = mathKf3.Substring(0, 1);
            string mathNA4 = mathKf4.Substring(0, 1);
            string mathNA5 = mathNs1.Substring(0, 1);
            string mathNA6 = mathNs2.Substring(0, 1);
            double n = (Int32.Parse(mathNA1) + Int32.Parse(mathNA2) + Int32.Parse(mathNA3) + Int32.Parse(mathNA4) + Int32.Parse(mathNA5) + Int32.Parse(mathNA6)) / 6;
            mathDict["mathNAAverage"] = n.ToString();
            mathDict["mathNARound"] = Math.Ceiling(n).ToString();
            int b = Int32.Parse(mathDict["a"]) - Int32.Parse(mathDict["mathNARound"]);
            if (b == 0)
            {
                mathDict["mathNAStageCheck"] = "1";
            }
            else
            {
                mathDict["mathNAStageCheck"] = "0";
            }

            mathDict.Remove("a");
            mathDict["mathNSAchieveLevel"] = "EMPTY";
            // NS Achieve Level
            switch (mathNSAchievementCode)
            {
                case "1":
                    mathDict["mathNSAchieveLevel"] = "Well Below";
                    break;
                case "2":
                    mathDict["mathNSAchieveLevel"] = "Below";
                    break;
                case "3":
                    mathDict["mathNSAchieveLevel"] = "At";
                    break;
                case "4":
                    mathDict["mathNSAchieveLevel"] = "Above";
                    break;
                case "5":
                    mathDict["mathNSAchieveLevel"] = "Well Above";
                    break;
            }

            // NS Achievement OTJ vs COMP
            if (mathDict["mathNSAchievementOTJ"].Equals(mathDict["mathNSAchievementComp"]))
            {
                mathDict["mathNSAchievementOTJVsComp"] = "1";
            }
            else
            {
                mathDict["mathNSAchievementOTJVsComp"] = "0";
            }
            mathDict["mathNSProgressLevel"] = "EMPTY";
            // NS Progress Level
            switch (mathNSProgressCode)
            {
                case "1":
                    mathDict["mathNSProgressLevel"] = "Below";
                    break;
                case "2":
                    mathDict["mathNSProgressLevel"] = "At";
                    break;
                case "3":
                    mathDict["mathNSProgressLevel"] = "Above";
                    break;
            }

            // NS Progress OTJ vs COMP
            if (mathDict["mathNSProgressOTJ"].Equals(mathDict["mathNSProgressComp"]))
            {
                mathDict["mathNSProgressOTJVsComp"] = "1";
            }
            else
            {
                mathDict["mathNSProgressOTJVsComp"] = "0";
            }
            mathDict["mathEffortStatement"] = "EMPTY";
            //Math Effort Level
            switch (mathEffort)
            {
                case "1":
                    mathDict["mathEffortStatement"] = "Below";
                    break;
                case "2":
                    mathDict["mathEffortStatement"] = "At";
                    break;
                case "3":
                    mathDict["mathEffortStatement"] = "Above";
                    break;
            }

            //Math Comment Length
            mathDict["mathCommentLength"] = mathComment.Length.ToString();


        }

        private void curiosity()
        {
            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity1 + "'; ");
            d["curiosity1Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity2 + "'; ");
            d["curiosity2Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity3 + "'; ");
            d["curiosity3Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity4 + "'; ");
            d["curiosity4Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity5 + "'; ");
            d["curiosity5Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity6 + "'; ");
            d["curiosity6Statement"] = cmd;

            curDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, OleDbCommand> pair in d)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    
                    dbCmd.Connection = conn;
                    OleDbDataReader reader = dbCmd.ExecuteReader();
                    reader.Read();
                    curDict[v] = reader.GetString(0);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                }
            }
        }

        private void creativity()
        {
            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity1 + "'; ");
            d["creativity1Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity2 + "'; ");
            d["creativity2Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity3 + "'; ");
            d["creativity3Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity4 + "'; ");
            d["creativity4Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity5 + "'; ");
            d["creativity5Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity6 + "'; ");
            d["creativity6Statement"] = cmd;

            creDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, OleDbCommand> pair in d)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    
                    dbCmd.Connection = conn;
                    OleDbDataReader reader = dbCmd.ExecuteReader();
                    reader.Read();
                    creDict[v] = reader.GetString(0);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                }
            }
        }

        private void community()
        {
            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community1 + "'; ");
            d["community1Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community2 + "'; ");
            d["community2Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community3 + "'; ");
            d["community3Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community4 + "'; ");
            d["community4Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community5 + "'; ");
            d["community5Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community6 + "'; ");
            d["community6Statement"] = cmd;

            comDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, OleDbCommand> pair in d)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    
                    dbCmd.Connection = conn;
                    OleDbDataReader reader = dbCmd.ExecuteReader();
                    reader.Read();
                    comDict[v] = reader.GetString(0);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                }
            }
        }

        private void sustainability()
        {
            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability1 + "'; ");
            d["sustainability1Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability2 + "'; ");
            d["sustainability2Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability3 + "'; ");
            d["sustainability3Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability4 + "'; ");
            d["sustainability4Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability5 + "'; ");
            d["sustainability5Statement"] = cmd;

            cmd = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability6 + "'; ");
            d["sustainability6Statement"] = cmd;

            susDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, OleDbCommand> pair in d)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    
                    dbCmd.Connection = conn;
                    OleDbDataReader reader = dbCmd.ExecuteReader();
                    reader.Read();
                    susDict[v] = reader.GetString(0);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                }
            }
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
            if (Int32.Parse(writingDict["writingInitialGrade"]) < Int32.Parse(writingDict["writingFinalGrade"]))
            {
                writingProgressCheck = "1";

            }
            if (Int32.Parse(generalDict["mathInitialGrade"]) < Int32.Parse(mathDict["mathFinalGrade"]))
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
                    studentsWellBelow += "XX";
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
                    studentsBelow += "XX";
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
                    studentsAt += "XX";
                }
            }
            else if (readingCode == 4)
            {
                studentsAbove = "1";
                if (writingCode == 1)
                {
                    studentsAbove += "1";
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
                    studentsAbove += "XX";
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
                    studentsWellAbove += "XX";
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
            conn.Open();
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                try
                {
                    OleDbCommand allStudents = new OleDbCommand("SELECT [NSN]"
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


                            Dictionary<string, OleDbCommand> d = new Dictionary<string, OleDbCommand>();

                            //Current Teacher
                            OleDbCommand generalCmd = new OleDbCommand("SELECT [Current Teacher]"
                            + " FROM [Room]"
                            + " WHERE [Room No] = '" + room + "'; ");
                            d["teacherThisYear"] = generalCmd;

                            //School Year Ordinal
                            generalCmd = new OleDbCommand("SELECT [Achievement Ordinal]"
                            + " FROM [National Standard Codes]"
                            + " WHERE [National Standard Code] = '" + NSAchieve + "'; ");
                            d["schoolYearOrdinal"] = generalCmd;

                            //Next Teacher
                            generalCmd = new OleDbCommand("SELECT [Next Year Teacher]"
                            + " FROM [Room]"
                            + " WHERE [Room No] = '" + nextRoom + "'; ");
                            d["nextTeacher"] = generalCmd;

                            generalCmd = new OleDbCommand("SELECT [Reading Code]"
                            + " FROM [Reading National Standards]"
                            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
                            d["readingFinalCode"] = generalCmd;

                            generalCmd = new OleDbCommand("SELECT [Num Position1]"
                            + " FROM [Math Reverse Lookup]"
                            + " WHERE [Stage] = '" + mathInitialAssessmentLevel + "'; ");
                            d["mathInitialGrade"] = generalCmd;

                            generalDict = new Dictionary<string, string>();
                            foreach (KeyValuePair<string, OleDbCommand> pair in d)
                            {
                                try
                                {
                                    string v = pair.Key;
                                    OleDbCommand dbCmd = pair.Value;

                                    dbCmd.Connection = conn;
                                    OleDbDataReader reader = dbCmd.ExecuteReader();
                                    reader.Read();
                                    generalDict[v] = reader.GetString(0);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                                }
                            }

                            //Placement Statement
                            if (generalDict["nextTeacher"].Equals("Leaving"))
                            {
                                generalDict["placementStatement"] = "Our records show that " + firstName + " will be leaving Laingholm Primary School - "
                                    + "'The Greatest Little School in the Universe' - at the end of this year. As a school we would like "
                                    + "to take the opportunity to wish " + firstName + " well for the future in the belief that "
                                    + firstName + " will continue to 'Reach for the Stars'.";
                            }
                            else
                            {
                                generalDict["placementStatement"] = "Over the past few months we have given very careful consideration to "
                                    + firstName + "’s classroom placement for 2016. As a school we endeavour to personalise "
                                    + "the learning for each student. We take into account academic performance, friendship "
                                    + " groups and a number of other factors when placing a student in a particular class.";
                            }

                            // Next Room Statement
                            if (nextRoom.Equals("99"))
                            {
                                generalDict["nextRoomStatement"] = "Best wishes from all the staff and students at Laingholm Primary School, "
                                    + "'The Greatest Little School in the Universe'. Ko te pae tawhiti whaaia kia tata, ko te pae tata whakamaua kia tiina.";
                            }
                            else
                            {
                                generalDict["nextRoomStatement"] = "In 2016 " + firstName + "  will be in Room " + nextRoom + "  with " + generalDict["nextTeacher"];
                            }

                            // He/She

                            if (gender.Equals("Male"))
                            {
                                generalDict["heShe"] = "he";
                                generalDict["hisHer"] = "his";
                                generalDict["himHer"] = "him";
                            }
                            else
                            {
                                generalDict["heShe"] = "she";
                                generalDict["hisHer"] = "her";
                                generalDict["himHer"] = "her";
                            }

                            generalCommentLength = generalComment.Length.ToString();

                            allCalculations();

                            generalDict["overallAcademic"] = ((Double.Parse(generalDict["readingFinalCode"]) / 2)
                                + (Double.Parse(writingDict["writingOverallGrade"])) + (Double.Parse(mathDict["mathFinalGrade"]) * 2)).ToString();

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

                            generalDict["numActivitiesStr"] = numActivities.ToString();


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
                            generalDict["sportsActivitiesStr"] = sportsActivities.ToString();

                            //Teachers Cup
                            generalDict["teachersCup"] = ((Double.Parse(generalDict["readingFinalCode"]) / 2) +
                                Double.Parse(writingDict["writingFinalGrade"]) +
                                (Double.Parse(mathDict["mathFinalGrade"]) * 2) +
                                (Double.Parse(generalDict["sportsActivitiesStr"]) * 2) +
                                (Double.Parse(generalDict["numActivitiesStr"]) - Double.Parse(generalDict["sportsActivitiesStr"]))).ToString();
                            /*
                             * Updating Table
                             * */
                            updateTable(NSN);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                    conn.Close();
                }


            }
            conn.Close();
        }

        

        private void updateTable(string NSN)
        {
            // Generate Update statement
            string insert1 = "INSERT INTO [Calculated] (";
            int i = 0;
            Dictionary<string, string> dict = createDictionary(NSN);
            int len = dict.Count / 2;
            foreach (KeyValuePair<string, string> pair in dict)
            {
                string field = pair.Key;
                string value = pair.Value;

                if (i == (len - 1))
                {
                    insert1 += "[" + field + "])";
                    break;
                }
                else
                {
                    insert1 += "[" + field + "], ";
                }
                
                i++;
            }
            insert1 += " VALUES (";
            i = 0;
            foreach (KeyValuePair<string, string> pair in dict)
            {
                string field = pair.Key;
                string value = pair.Value;

                if (i == len - 1)
                {
                    insert1 += "'" +  value + "')";
                    break;
                }
                else
                {
                    insert1 += "'" + value + "', ";
                }
                
                i++;
            }


            // Generate Update statement
            string update = "UPDATE [Calculated] SET";
            int currentPos = i;
            len = dict.Count;
            foreach (KeyValuePair<string, string> pair in dict.Skip(len/2 - 1))
            {
                string field = pair.Key;
                string value = pair.Value;

                if (i == len - 1)
                {
                    update += "[" + field + "] = '" + value + "' ";
                    break;
                }
                else
                {
                    update += "[" + field + "] = '" + value + "', ";
                }
                //Console.WriteLine(field);
                i++;
            }
            update += " WHERE [NSN] = '" + NSN + "';";

            //Console.WriteLine("Insert1: " + insert1);
            Console.WriteLine("Update: " + update);

            Dictionary<string, OleDbCommand> insertCmd = new Dictionary<string, OleDbCommand>();
            insertCmd["insert1"] = new OleDbCommand(insert1);
            insertCmd["insert2"] = new OleDbCommand(update);
            foreach (KeyValuePair<string, OleDbCommand> pair in insertCmd)
            {
                try
                {
                    string v = pair.Key;
                    OleDbCommand dbCmd = pair.Value;

                    dbCmd.Connection = conn;
                    int rowAffected = dbCmd.ExecuteNonQuery();

                    if (rowAffected < 1)
                    {
                        MessageBox.Show("Inserting Data Failed");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at " + pair.Key + "\n\n Here is message " + e);
                }
            }
            


        }

        private Dictionary<string, string> createDictionary(string NSN)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["NSN"] = NSN;
            dict["Teacher This Year"] = generalDict["teacherThisYear"];
            dict["School Year Ordinal"] = generalDict["schoolYearOrdinal"];
            dict["Next Teacher"] = generalDict["nextTeacher"];
            dict["Placement Statement"] = generalDict["placementStatement"];
            dict["Next Room Statement"] = generalDict["nextRoomStatement"];
            dict["HeShe"] = generalDict["heShe"];
            dict["HisHer"] = generalDict["hisHer"];
            dict["HimHer"] = generalDict["himHer"];
            dict["Reading Final Code"] = generalDict["readingFinalCode"];
            dict["Math Initial Grade"] = generalDict["mathInitialGrade"];

            dict["General Comment Length"] = generalCommentLength;

            dict["Reading Initial Statement"] = readingDict["readingInitialStatement"];
            dict["Reading Final Statement"] = readingDict["readingFinalStatement"];
            dict["Reading KF1"] = readingDict["readingKF1"];
            dict["Reading KF2"] = readingDict["readingKF2"];
            dict["Reading NS1"] = readingDict["readingNS1"];
            dict["Reading NS2"] = readingDict["readingNS2"];
            dict["Reading NS Achievement Timeframe"] = readingDict["readingNSAchievementTimeframe"];
            dict["Reading NS Achievement Statement"] = readingDict["readingNSAchievementStatement"];
            dict["Reading NS Achieve Level"] = readingDict["readingNSAchieveLevel"];
            dict["Reading NS Achievement OTJ"] = readingDict["readingNSAchievementOTJ"];
            dict["Reading NS Achievement Comp"] = readingDict["readingNSAchievementComp"];
            dict["Reading NS Achievement OTJ vs Comp"] = readingDict["readingNSAchievementOTJVsComp"];
            dict["Reading NS Progress Timeframe"] = readingDict["readingNSProgressTimeframe"];
            dict["Reading NS Progress Statement"] = readingDict["readingNSProgressStatement"];
            dict["Reading NS Progress Level"] = readingDict["readingNSProgressLevel"];
            dict["Reading NS Progress OTJ"] = readingDict["readingNSProgressOTJ"];
            dict["Reading NS Progress Comp"] = readingDict["readingNSProgressComp"];
            dict["Reading NS Progress OTJ vs Comp"] = readingDict["readingNSProgressOTJVsComp"];
            dict["Reading Effort Statement"] = readingDict["readingEffortStatement"];
            dict["Reading Comment Length"] = readingDict["readingCommentLength"];
            
            dict["Writing Initial Grade"] = writingDict["writingInitialGrade"];
            dict["Writing Final Grade"] = writingDict["writingFinalGrade"];
            dict["Writing Overall Grade"] = writingDict["writingOverallGrade"];
            dict["Writing Overall Assessment"] = writingDict["writingOverallAssessment"];
            dict["Writing KF1"] = writingDict["writingKF1"];
            dict["Writing KF2"] = writingDict["writingKF2"];
            dict["Writing NS1"] = writingDict["writingNS1"];
            dict["Writing NS2"] = writingDict["writingNS2"];
            dict["Writing NS3 Statement"] = writingDict["writingNS3Statement"];
            dict["Writing NS Achievement Timeframe"] = writingDict["writingNSAchievementTimeframe"];
            dict["Writing NS Achievement Statement"] = writingDict["writingNSAchievementStatement"];
            dict["Writing NS Achieve Level"] = writingDict["writingNSAchieveLevel"];
            dict["Writing NS Achievement OTJ"] = writingDict["writingNSAchievementOTJ"];
            dict["Writing NS Achievement Comp"] = writingDict["writingNSAchievementComp"];
            dict["Writing NS Achievement OTJ vs Comp"] = writingDict["writingNSAchievementOTJVsComp"];
            dict["Writing NS Progress Timeframe"] = writingDict["writingNSProgressTimeframe"];
            dict["Writing NS Progress Statement"] = writingDict["writingNSProgressStatement"];
            dict["Writing NS Progress Level"] = writingDict["writingNSProgressLevel"];
            dict["Writing NS Progress OTJ"] = writingDict["writingNSProgressOTJ"];
            dict["Writing NS Progress Comp"] = writingDict["writingNSProgressComp"];
            dict["Writing NS Progress OTJ vs Comp"] = writingDict["writingNSProgressOTJVsComp"];
            dict["Writing Effort Statement"] = writingDict["writingEffortStatement"];
            dict["Writing Comment Length"] = writingDict["writingCommentLength"];

            dict["Math KF1 Statement"] = mathDict["mathKf1Statement"];
            dict["Math KF2 Statement"] = mathDict["mathKf2Statement"];
            dict["Math KF3 Statement"] = mathDict["mathKf3Statement"];
            dict["Math KF4 Statement"] = mathDict["mathKf4Statement"];
            dict["Math NS1 Statement"] = mathDict["mathNS1Statement"];
            dict["Math NS2 Statement"] = mathDict["mathNS2Statement"];
            dict["Math NA Stage Check"] = mathDict["mathNAStageCheck"];
            dict["Math NA Average"] = mathDict["mathNAAverage"];
            dict["Math NA Round"] = mathDict["mathNARound"];
            dict["Math NS Achievement Timeframe"] = mathDict["mathNSAchievementTimeframe"];
            dict["Math NS Achievement Statement"] = mathDict["mathNSAchievementStatement"];
            dict["Math NS Achieve Level"] = mathDict["mathNSAchieveLevel"];
            dict["Math NS Achievement OTJ"] = mathDict["mathNSAchievementOTJ"];
            dict["Math NS Achievement Comp"] = mathDict["mathNSAchievementComp"];
            dict["Math NS Achievement OTJ vs Comp"] = mathDict["mathNSAchievementOTJVsComp"];
            dict["Math NS Progress Timeframe"] = mathDict["mathNSProgressTimeframe"];
            dict["Math NS Progress Statement"] = mathDict["mathNSProgressStatement"];
            dict["Math NS Progress Level"] = mathDict["mathNSProgressLevel"];
            dict["Math NS Progress OTJ"] = mathDict["mathNSProgressOTJ"];
            dict["Math NS Progress Comp"] = mathDict["mathNSProgressComp"];
            dict["Math NS Progress OTJ vs Comp"] = mathDict["mathNSProgressOTJVsComp"];
            dict["Math Effort Statement"] = mathDict["mathEffortStatement"];
            dict["Math Comment Length"] = mathDict["mathCommentLength"];
            dict["Math Final Grade"] = mathDict["mathFinalGrade"];
            

            dict["Curiosity 1 Statement"] = curDict["curiosity1Statement"];
            dict["Curiosity 2 Statement"] = curDict["curiosity2Statement"];
            dict["Curiosity 3 Statement"] = curDict["curiosity3Statement"];
            dict["Curiosity 4 Statement"] = curDict["curiosity4Statement"];
            dict["Curiosity 5 Statement"] = curDict["curiosity5Statement"];
            dict["Curiosity 6 Statement"] = curDict["curiosity6Statement"];

            dict["Creativity 1 Statement"] = creDict["creativity1Statement"];
            dict["Creativity 2 Statement"] = creDict["creativity2Statement"];
            dict["Creativity 3 Statement"] = creDict["creativity3Statement"];
            dict["Creativity 4 Statement"] = creDict["creativity4Statement"];
            dict["Creativity 5 Statement"] = creDict["creativity5Statement"];
            dict["Creativity 6 Statement"] = creDict["creativity6Statement"];

            dict["Community 1 Statement"] = comDict["community1Statement"];
            dict["Community 2 Statement"] = comDict["community2Statement"];
            dict["Community 3 Statement"] = comDict["community3Statement"];
            dict["Community 4 Statement"] = comDict["community4Statement"];
            dict["Community 5 Statement"] = comDict["community5Statement"];
            dict["Community 6 Statement"] = comDict["community6Statement"];

            dict["Sustainability 1 Statement"] = susDict["sustainability1Statement"];
            dict["Sustainability 2 Statement"] = susDict["sustainability2Statement"];
            dict["Sustainability 3 Statement"] = susDict["sustainability3Statement"];
            dict["Sustainability 4 Statement"] = susDict["sustainability4Statement"];
            dict["Sustainability 5 Statement"] = susDict["sustainability5Statement"];
            dict["Sustainability 6 Statement"] = susDict["sustainability6Statement"];

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

            dict["Activities Count"] = generalDict["numActivitiesStr"];
            dict["Sports Count"] = generalDict["sportsActivitiesStr"];
            dict["Overall Academic"] = generalDict["overallAcademic"];
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
 + "\nReading Effort Level: " + readingEffortStatement
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
 + "\nWriting Effort Level: " + writingEffortStatement
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
 + "\nMath Effort Level: " + mathEffortStatement
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
