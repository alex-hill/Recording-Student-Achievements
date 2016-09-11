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
        string firstName;
        string gender;
        string room;
        string NSAchieve;
        string nextRoom;
        string generalComment;
        string generalCommentLength;
        string overallAcademic;
        string teachersCup;

        string readingInitialAssessmentMethod;
        string readingFinalAssessmentMethod;
        string readingInitialAssessment;
        string readingFinalAssessment;
        string NSReadingAchieve;
        string NSProgress;
        string NSReadingProgress;
        string readingEffort;
        string readingComment;
        string readingFinalCode;

        string writingInitialAssessment;
        string writingFinalAssessment;
        string writingNS3Code;
        string writingNSAchievementCode;
        string writingNSProgress;
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

        string teacherThisYear;
        string schoolYearOrdinal;
        string nextTeacher;
        string placementStatement;
        string nextRoomStatement;
        string heShe, hisHer, himHer;

        string readingInitialStatement;
        string readingFinalStatement;
        string readingKF1;
        string readingKF2;
        string readingNS1;
        string readingNS2;
        string readingNSAchievementTimeframe;
        string readingNSAchievementStatement;
        string readingAchieveWellBelow, readingAchieveBelow, readingAchieveAt, readingAchieveAbove, readingAchieveWellAbove;
        string readingNSAchievementOTJ;
        string readingNSAchievementComp;
        string readingNSAchievementOTJVsComp;
        string readingNSProgressTimeframe;
        string readingNSProgressStatement;
        string readingProgressBelow, readingProgressAt, readingProgressAbove = "";
        string readingNSProgressOTJ;
        string readingNSProgressComp;
        string readingNSProgressOTJVsComp;
        string readingEffortBelow, readingEffortAt, readingEffortAbove = "";
        string readingEffortStatement;
        string readingCommentLength;

        string writingInitialGrade;
        string writingFinalGrade;
        string writingOverallGrade;
        string writingOverallAssessment;
        string writingKF1;
        string writingKF2;
        string writingNS1;
        string writingNS2;
        string writingNS3Statement;
        string writingNSAchievementTimeframe;
        string writingNSAchievementStatement;
        string writingAchieveWellBelow, writingAchieveBelow, writingAchieveAt, writingAchieveAbove, writingAchieveWellAbove;
        string writingNSAchievementOTJ;
        string writingNSAchievementComp;
        string writingNSAchievementOTJVsComp;
        string writingNSProgressTimeframe;
        string writingNSProgressStatement;
        string writingProgressBelow, writingProgressAt, writingProgressAbove = "";
        string writingNSProgressOTJ;
        string writingNSProgressComp;
        string writingNSProgressOTJVsComp;
        string writingEffortBelow, writingEffortAt, writingEffortAbove = "";
        string writingEffortStatement;
        string writingCommentLength;

        string mathKf1Statement;
        string mathKf2Statement;
        string mathKf3Statement;
        string mathKf4Statement;
        string mathNS1Statement;
        string mathNS2Statement;
        string mathNA1, mathNA2, mathNA3, mathNA4, mathNA5, mathNA6;
        string mathNAAverage;
        string mathNAStageCheck;
        string mathNARound;
        string mathNSAchievementTimeframe;
        string mathNSAchievementStatement;
        string mathAchieveWellBelow, mathAchieveBelow, mathAchieveAt, mathAchieveAbove, mathAchieveWellAbove;
        string mathNSAchievementOTJ;
        string mathNSAchievementComp;
        string mathNSAchievementOTJVsComp;
        string mathNSProgressTimeframe;
        string mathNSProgressStatement;
        string mathProgressBelow, mathProgressAt, mathProgressAbove = "";
        string mathNSProgressOTJ;
        string mathNSProgressComp;
        string mathNSProgressOTJVsComp;
        string mathEffortBelow, mathEffortAt, mathEffortAbove = "";
        string mathEffortStatement;
        string mathCommentLength;
        string mathFinalGrade;
        string mathNSProgress;
        string mathComment;
        string mathInitialGrade;

        string managingSelf, managingSelfPercent, managingSelfStatement;
        string relationToOthers, relationToOthersPercent, relationToOthersStatement;
        string participatingContributing, participatingContributingPercent, participatingContributingStatement;
        string thinking, thinkingPercent, thinkingStatement;
        string lst, lstPercent, lstStatement;

        public Calculations()
        {

        }

        private void readingCalculations()
        {
            // Reading Initial Statement
            OleDbCommand cmdReadingInitialStatement = new OleDbCommand("SELECT [Colour]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingInitialAssessment + "'; ");
            cmdReadingInitialStatement.Connection = conn;
            OleDbDataReader reader = cmdReadingInitialStatement.ExecuteReader();
            readingInitialStatement = reader.GetString(0);
            if (readingInitialAssessmentMethod.Equals("PROBE"))
            {
                readingInitialStatement = "Reading Age " + readingInitialAssessment + " Years";
            }
            else
            {
                readingInitialStatement += " - Level " + readingFinalAssessment;
            }

            // Reading Final Statement
            OleDbCommand cmdReadingFinalStatement = new OleDbCommand("SELECT [Colour]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            cmdReadingFinalStatement.Connection = conn;
            reader = cmdReadingFinalStatement.ExecuteReader();
            readingFinalStatement = reader.GetString(0);
            if (readingFinalAssessmentMethod.Equals("PROBE"))
            {
                readingFinalStatement = "Reading Age " + readingInitialAssessment + " Years";
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
            readingKF1 = reader.GetString(0);
            readingKF2 = reader.GetString(1);
            readingNS1 = reader.GetString(2);
            readingNS2 = reader.GetString(3);

            // NS Timeframe Reading Achieve
            OleDbCommand cmdReadingNSTimeframeAchieve = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            cmdReadingNSTimeframeAchieve.Connection = conn;
            reader = cmdReadingNSTimeframeAchieve.ExecuteReader();
            readingNSAchievementTimeframe = reader.GetString(0);
            readingNSAchievementStatement = reader.GetString(1);

            // NS Achieve Level
            switch (NSAchieve)
            {
                case "1":
                    readingAchieveWellBelow = "P";
                    break;
                case "2":
                    readingAchieveBelow = "P";
                    break;
                case "3":
                    readingAchieveAt = "P";
                    break;
                case "4":
                    readingAchieveAbove = "P";
                    break;
                case "5":
                    readingAchieveWellAbove = "P";
                    break;
            }

            // NS Reading Achievemet (OTJ)
            OleDbCommand cmdReadingNSAchievementOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + NSReadingAchieve + "'; ");
            cmdReadingNSAchievementOTJ.Connection = conn;
            reader = cmdReadingNSAchievementOTJ.ExecuteReader();
            readingNSAchievementOTJ = reader.GetString(0);

            // NS Reading Achievemet (Comp)
            OleDbCommand cmdReadingNSAchievementComp = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            cmdReadingNSAchievementComp.Connection = conn;
            reader = cmdReadingNSAchievementComp.ExecuteReader();
            readingNSAchievementComp = reader.GetString(0);

            // NS Achievement OTJ vs COMP
            if(readingNSAchievementOTJVsComp.Equals(readingNSAchievementComp))
            {
                readingNSAchievementOTJVsComp = "1";
            }else
            {
                readingNSAchievementOTJVsComp = "0";
            }

            // NS Timeframe Reading Progress
            OleDbCommand cmdReadingNSTimeframeProgress = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Reading Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            cmdReadingNSTimeframeProgress.Connection = conn;
            reader = cmdReadingNSTimeframeProgress.ExecuteReader();
            readingNSProgressTimeframe = reader.GetString(0);
            readingNSProgressStatement = reader.GetString(1);

            // NS Progress Level
            switch (NSProgress)
            {
                case "1":
                    readingProgressBelow = "P";
                    break;
                case "2":
                    readingProgressAt = "P";
                    break;
                case "3":
                    readingProgressAbove = "P";
                    break;
            }

            // NS Reading Progress (OTJ)
            OleDbCommand cmdReadingNSProgressOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + NSReadingProgress + "'; ");
            cmdReadingNSProgressOTJ.Connection = conn;
            reader = cmdReadingNSProgressOTJ.ExecuteReader();
            readingNSProgressOTJ = reader.GetString(0);

            // NS Reading Progress (Comp)
            OleDbCommand cmdReadingNSProgressComp = new OleDbCommand("SELECT [" + NSProgress + "]"
            + " FROM [Reading National Standards]"
            + " WHERE [Assessment] = '" + readingFinalAssessment + "'; ");
            cmdReadingNSProgressComp.Connection = conn;
            reader = cmdReadingNSProgressComp.ExecuteReader();
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
                    readingEffortBelow = "P";
                    break;
                case "2":
                    readingEffortAt = "P";
                    break;
                case "3":
                    readingEffortAbove = "P";
                    break;
            }

            // Effort Statement
            OleDbCommand cmdReadingEffortStatement = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + readingEffort + "'; ");
            cmdReadingEffortStatement.Connection = conn;
            reader = cmdReadingEffortStatement.ExecuteReader();
            readingEffortStatement = reader.GetString(0);

            //Reading Comment Length
            readingCommentLength = readingComment.Length.ToString();

        }

        private void writingCalculations()
        {
            //Initial Grade
            OleDbCommand cmdWritingInitialGrade = new OleDbCommand("SELECT [Grade]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingInitialAssessment + "'; ");
            cmdWritingInitialGrade.Connection = conn;
            OleDbDataReader reader = cmdWritingInitialGrade.ExecuteReader();
            writingInitialGrade = reader.GetString(0);

            //Final Grade
            OleDbCommand cmdWritingFinalGrade = new OleDbCommand("SELECT [Grade]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingFinalAssessment + "'; ");
            cmdWritingFinalGrade.Connection = conn;
            reader = cmdWritingFinalGrade.ExecuteReader();
            writingFinalGrade = reader.GetString(0);

            //Overall Grade
            if(Int32.Parse(writingInitialGrade) < Int32.Parse(writingFinalGrade))
            {
                writingOverallGrade = writingFinalGrade;
            }else
            {
                writingOverallGrade = writingInitialGrade;
            }

            //Overall Writing Assessment
            OleDbCommand cmdWritingOverallAssessment = new OleDbCommand("SELECT [Writing Level]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Grade] = '" + writingOverallGrade + "'; ");
            cmdWritingOverallAssessment.Connection = conn;
            reader = cmdWritingOverallAssessment.ExecuteReader();
            writingOverallAssessment = reader.GetString(0);

            //KF 1 2, NS 1, 2
            OleDbCommand cmdWritingKF1 = new OleDbCommand("SELECT [KF 1], [KF 2], [NS 1], [NS 2]"
                    + " FROM [Writing National Standards]"
                    + " WHERE [Writing Level] = '" + writingOverallAssessment + "'; ");
            cmdWritingKF1.Connection = conn;
            reader = cmdWritingKF1.ExecuteReader();
            writingKF1 = reader.GetString(0);
            writingKF2 = reader.GetString(1);
            writingNS1 = reader.GetString(2);
            writingNS2 = reader.GetString(3);

            OleDbCommand cmdWritingNS3Statement = new OleDbCommand("SELECT [Comment]"
                    + " FROM [Writing Year Standards]"
                    + " WHERE [Code] = '" + writingNS3Code + "'; ");
            cmdWritingNS3Statement.Connection = conn;
            reader = cmdWritingNS3Statement.ExecuteReader();
            writingNS3Statement = reader.GetString(0);

            // NS Timeframe Writing Achieve
            OleDbCommand cmdWritingNSTimeframeAchieve = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Writing Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            cmdWritingNSTimeframeAchieve.Connection = conn;
            reader = cmdWritingNSTimeframeAchieve.ExecuteReader();
            writingNSAchievementTimeframe = reader.GetString(0);
            writingNSAchievementStatement = reader.GetString(1);

            // NS Achieve Level
            switch (NSAchieve)
            {
                case "1":
                    writingAchieveWellBelow = "P";
                    break;
                case "2":
                    writingAchieveBelow = "P";
                    break;
                case "3":
                    writingAchieveAt = "P";
                    break;
                case "4":
                    writingAchieveAbove = "P";
                    break;
                case "5":
                    writingAchieveWellAbove = "P";
                    break;
            }

            // NS Writing Achievemet (OTJ)
            OleDbCommand cmdWritingNSAchievementOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + writingNSAchievementCode + "'; ");
            cmdWritingNSAchievementOTJ.Connection = conn;
            reader = cmdWritingNSAchievementOTJ.ExecuteReader();
            writingNSAchievementOTJ = reader.GetString(0);

            // NS Writing Achievemet (Comp)
            OleDbCommand cmdWritingNSAchievementComp = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Writing National Standards]"
            + " WHERE [Assessment] = '" + writingFinalAssessment + "'; ");
            cmdWritingNSAchievementComp.Connection = conn;
            reader = cmdWritingNSAchievementComp.ExecuteReader();
            writingNSAchievementComp = reader.GetString(0);

            // NS Achievement OTJ vs COMP
            if (writingNSAchievementOTJVsComp.Equals(writingNSAchievementComp))
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
            writingNSProgressTimeframe = reader.GetString(0);
            writingNSProgressStatement = reader.GetString(1);

            // NS Progress Level
            switch (NSProgress)
            {
                case "1":
                    writingProgressBelow = "P";
                    break;
                case "2":
                    writingProgressAt = "P";
                    break;
                case "3":
                    writingProgressAbove = "P";
                    break;
            }

            // NS Writing Progress (OTJ)
            OleDbCommand cmdWritingNSProgressOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + writingNSProgress + "'; ");
            cmdWritingNSProgressOTJ.Connection = conn;
            reader = cmdWritingNSProgressOTJ.ExecuteReader();
            writingNSProgressOTJ = reader.GetString(0);

            // NS Writing Progress (Comp)
            OleDbCommand cmdWritingNSProgressComp = new OleDbCommand("SELECT [" + NSProgress + "]"
            + " FROM [Writing National Standards]"
            + " WHERE [Assessment] = '" + writingFinalAssessment + "'; ");
            cmdWritingNSProgressComp.Connection = conn;
            reader = cmdWritingNSProgressComp.ExecuteReader();
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
                    writingEffortBelow = "P";
                    break;
                case "2":
                    writingEffortAt = "P";
                    break;
                case "3":
                    writingEffortAbove = "P";
                    break;
            }

            // Effort Statement
            OleDbCommand cmdWritingEffortStatement = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + writingEffort + "'; ");
            cmdWritingEffortStatement.Connection = conn;
            reader = cmdWritingEffortStatement.ExecuteReader();
            writingEffortStatement = reader.GetString(0);

            //Writing Comment Length
            writingCommentLength = writingComment.Length.ToString();

        }

        private void mathCalculations()
        {
            // Math KF1
            OleDbCommand cmdMathKf1 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf1 + "'; ");
            cmdMathKf1.Connection = conn;
            OleDbDataReader reader = cmdMathKf1.ExecuteReader();
            mathKf1Statement = reader.GetString(0);

            // Math KF1
            OleDbCommand cmdMathKf2 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf2 + "'; ");
            cmdMathKf2.Connection = conn;
            reader = cmdMathKf2.ExecuteReader();
            mathKf2Statement = reader.GetString(0);

            // Math KF1
            OleDbCommand cmdMathKf3 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf3 + "'; ");
            cmdMathKf3.Connection = conn;
            reader = cmdMathKf3.ExecuteReader();
            mathKf3Statement = reader.GetString(0);

            // Math KF1
            OleDbCommand cmdMathKf4 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathKf4 + "'; ");
            cmdMathKf4.Connection = conn;
            reader = cmdMathKf4.ExecuteReader();
            mathKf4Statement = reader.GetString(0);

            // Math NS1
            OleDbCommand cmdMathNS1 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathNs1 + "'; ");
            cmdMathNS1.Connection = conn;
            reader = cmdMathNS1.ExecuteReader();
            mathNS1Statement = reader.GetString(0);

            // Math NS1
            OleDbCommand cmdMathNS2 = new OleDbCommand("SELECT [Statement]"
            + " FROM [Mathematics Level Statements]"
            + " WHERE [Maths Code] = '" + mathNs2 + "'; ");
            cmdMathNS2.Connection = conn;
            reader = cmdMathNS2.ExecuteReader();
            mathNS2Statement = reader.GetString(0);

            mathNA1 = mathKf1.Substring(0, 1);
            mathNA2 = mathKf2.Substring(0, 1);
            mathNA3 = mathKf3.Substring(0, 1);
            mathNA4 = mathKf4.Substring(0, 1);
            mathNA5 = mathNs1.Substring(0, 1);
            mathNA6 = mathNs2.Substring(0, 1);

            double n = (Int32.Parse(mathNA1) + Int32.Parse(mathNA2) + Int32.Parse(mathNA3) + Int32.Parse(mathNA4) + Int32.Parse(mathNA5) + Int32.Parse(mathNA6))/6;
            mathNAAverage = n.ToString();
            mathNARound = Math.Ceiling(n).ToString();

            OleDbCommand cmdMathPos2 = new OleDbCommand("SELECT [Position1], [Position2]"
            + " FROM [Math Reverse Lookup]"
            + " WHERE [Stage] = '" + mathOverallAssessment + "'; ");
            cmdMathPos2.Connection = conn;
            reader = cmdMathPos2.ExecuteReader();
            mathFinalGrade = reader.GetString(0);
            string a = reader.GetString(0);
            int b = Int32.Parse(a) - Int32.Parse(mathNARound) ;
            if(b == 0)
            {
                mathNAStageCheck = "1";
            }else
            {
                mathNAStageCheck = "0";
            }

            // NS Timeframe Math Achieve
            OleDbCommand cmdMathNSTimeframeAchieve = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Math Statements]"
            + " WHERE [Year Code] = '" + NSAchieve + "'; ");
            cmdMathNSTimeframeAchieve.Connection = conn;
            reader = cmdMathNSTimeframeAchieve.ExecuteReader();
            mathNSAchievementTimeframe = reader.GetString(0);
            mathNSAchievementStatement = reader.GetString(1);

            // NS Achieve Level
            switch (NSAchieve)
            {
                case "1":
                    mathAchieveWellBelow = "P";
                    break;
                case "2":
                    mathAchieveBelow = "P";
                    break;
                case "3":
                    mathAchieveAt = "P";
                    break;
                case "4":
                    mathAchieveAbove = "P";
                    break;
                case "5":
                    mathAchieveWellAbove = "P";
                    break;
            }

            // NS Math Achievemet (OTJ)
            OleDbCommand cmdMathNSAchievementOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + mathNSAchievementCode + "'; ");
            cmdMathNSAchievementOTJ.Connection = conn;
            reader = cmdMathNSAchievementOTJ.ExecuteReader();
            writingNSAchievementOTJ = reader.GetString(0);

            // NS Math Achievemet (Comp)
            OleDbCommand cmdMathNSAchievementComp = new OleDbCommand("SELECT [" + NSAchieve + "]"
            + " FROM [Math National Standards]"
            + " WHERE [Assessment] = '" + mathFinalGrade + "'; ");
            cmdMathNSAchievementComp.Connection = conn;
            reader = cmdMathNSAchievementComp.ExecuteReader();
            mathNSAchievementComp = reader.GetString(0);

            // NS Achievement OTJ vs COMP
            if (mathNSAchievementOTJVsComp.Equals(mathNSAchievementComp))
            {
                mathNSAchievementOTJVsComp = "1";
            }
            else
            {
                mathNSAchievementOTJVsComp = "0";
            }

            // NS Timeframe Math Progress
            OleDbCommand cmdMathNSTimeframeProgress = new OleDbCommand("SELECT [Timeframe], [Standard]"
            + " FROM [Math Statements]"
            + " WHERE [Year Code] = '" + NSProgress + "'; ");
            cmdMathNSTimeframeProgress.Connection = conn;
            reader = cmdMathNSTimeframeProgress.ExecuteReader();
            mathNSProgressTimeframe = reader.GetString(0);
            mathNSProgressStatement = reader.GetString(1);

            // NS Progress Level
            switch (NSProgress)
            {
                case "1":
                    mathProgressBelow = "P";
                    break;
                case "2":
                    mathProgressAt = "P";
                    break;
                case "3":
                    mathProgressAbove = "P";
                    break;
            }

            // NS Math Progress (OTJ)
            OleDbCommand cmdMathNSProgressOTJ = new OleDbCommand("SELECT [Achievement Statement]"
            + " FROM [National Standard Codes]"
            + " WHERE [National Standard Code] = '" + mathNSProgress + "'; ");
            cmdMathNSProgressOTJ.Connection = conn;
            reader = cmdMathNSProgressOTJ.ExecuteReader();
            mathNSProgressOTJ = reader.GetString(0);

            // NS Math Progress (Comp)
            OleDbCommand cmdMathNSProgressComp = new OleDbCommand("SELECT [" + NSProgress + "]"
            + " FROM [Math National Standards]"
            + " WHERE [Assessment] = '" + mathFinalGrade + "'; ");
            cmdMathNSProgressComp.Connection = conn;
            reader = cmdMathNSProgressComp.ExecuteReader();
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
                    mathEffortBelow = "P";
                    break;
                case "2":
                    mathEffortAt = "P";
                    break;
                case "3":
                    mathEffortAbove = "P";
                    break;
            }

            // Effort Statement
            OleDbCommand cmdMathEffortStatement = new OleDbCommand("SELECT [Effort Statement]"
            + " FROM [Effort]"
            + " WHERE [Effort Code] = '" + mathEffort + "'; ");
            cmdMathEffortStatement.Connection = conn;
            reader = cmdMathEffortStatement.ExecuteReader();
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
            curiosity1Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity2 + "'; ");
            cmdCuriosity2.Connection = conn;
            reader = cmdCuriosity2.ExecuteReader();
            curiosity2Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity3 + "'; ");
            cmdCuriosity3.Connection = conn;
            reader = cmdCuriosity3.ExecuteReader();
            curiosity3Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity4 + "'; ");
            cmdCuriosity4.Connection = conn;
            reader = cmdCuriosity4.ExecuteReader();
            curiosity4Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity5 + "'; ");
            cmdCuriosity5.Connection = conn;
            reader = cmdCuriosity5.ExecuteReader();
            curiosity5Statement = reader.GetString(0);

            OleDbCommand cmdCuriosity6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + curiosity6 + "'; ");
            cmdCuriosity6.Connection = conn;
            reader = cmdCuriosity6.ExecuteReader();
            curiosity6Statement = reader.GetString(0);
        }

        private void creativity()
        {

            OleDbCommand cmdCreativity1 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity1 + "'; ");
            cmdCreativity1.Connection = conn;
            OleDbDataReader reader = cmdCreativity1.ExecuteReader();
            creativity1Statement = reader.GetString(0);

            OleDbCommand cmdCreativity2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity2 + "'; ");
            cmdCreativity2.Connection = conn;
            reader = cmdCreativity2.ExecuteReader();
            creativity2Statement = reader.GetString(0);

            OleDbCommand cmdCreativity3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity3 + "'; ");
            cmdCreativity3.Connection = conn;
            reader = cmdCreativity3.ExecuteReader();
            creativity3Statement = reader.GetString(0);

            OleDbCommand cmdCreativity4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity4 + "'; ");
            cmdCreativity4.Connection = conn;
            reader = cmdCreativity4.ExecuteReader();
            creativity4Statement = reader.GetString(0);

            OleDbCommand cmdCreativity5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity5 + "'; ");
            cmdCreativity5.Connection = conn;
            reader = cmdCreativity5.ExecuteReader();
            creativity5Statement = reader.GetString(0);

            OleDbCommand cmdCreativity6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + creativity6 + "'; ");
            cmdCreativity6.Connection = conn;
            reader = cmdCreativity6.ExecuteReader();
            creativity6Statement = reader.GetString(0);
        }

        private void community()
        {

            OleDbCommand cmdCommunity1 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community1 + "'; ");
            cmdCommunity1.Connection = conn;
            OleDbDataReader reader = cmdCommunity1.ExecuteReader();
            community1Statement = reader.GetString(0);

            OleDbCommand cmdCommunity2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community2 + "'; ");
            cmdCommunity2.Connection = conn;
            reader = cmdCommunity2.ExecuteReader();
            community2Statement = reader.GetString(0);

            OleDbCommand cmdCommunity3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community3 + "'; ");
            cmdCommunity3.Connection = conn;
            reader = cmdCommunity3.ExecuteReader();
            community3Statement = reader.GetString(0);

            OleDbCommand cmdCommunity4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community4 + "'; ");
            cmdCommunity4.Connection = conn;
            reader = cmdCommunity4.ExecuteReader();
            community4Statement = reader.GetString(0);

            OleDbCommand cmdCommunity5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community5 + "'; ");
            cmdCommunity5.Connection = conn;
            reader = cmdCommunity5.ExecuteReader();
            community5Statement = reader.GetString(0);

            OleDbCommand cmdCommunity6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + community6 + "'; ");
            cmdCommunity6.Connection = conn;
            reader = cmdCommunity6.ExecuteReader();
            community6Statement = reader.GetString(0);
        }

        private void sustainability()
        {

            OleDbCommand cmdsustainability1 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability1 + "'; ");
            cmdsustainability1.Connection = conn;
            OleDbDataReader reader = cmdsustainability1.ExecuteReader();
            sustainability1Statement = reader.GetString(0);

            OleDbCommand cmdsustainability2 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability2 + "'; ");
            cmdsustainability2.Connection = conn;
            reader = cmdsustainability2.ExecuteReader();
            sustainability2Statement = reader.GetString(0);

            OleDbCommand cmdsustainability3 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability3 + "'; ");
            cmdsustainability3.Connection = conn;
            reader = cmdsustainability3.ExecuteReader();
            sustainability3Statement = reader.GetString(0);

            OleDbCommand cmdsustainability4 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability4 + "'; ");
            cmdsustainability4.Connection = conn;
            reader = cmdsustainability4.ExecuteReader();
            sustainability4Statement = reader.GetString(0);

            OleDbCommand cmdsustainability5 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability5 + "'; ");
            cmdsustainability5.Connection = conn;
            reader = cmdsustainability5.ExecuteReader();
            sustainability5Statement = reader.GetString(0);

            OleDbCommand cmdsustainability6 = new OleDbCommand("SELECT [Assessment]"
            + " FROM [School Assessment]"
            + " WHERE [Assessment Code] = '" + sustainability6 + "'; ");
            cmdsustainability6.Connection = conn;
            reader = cmdsustainability6.ExecuteReader();
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
            double managingSelfDec = ((Double.Parse(managingSelf) - 2)) / 40;
            managingSelfPercent = ((int)(managingSelfDec) * 100).ToString();
            if (managingSelfDec >= 0.25) {
                if (managingSelfDec >= 0.5)
                {
                    if (managingSelfDec >= 0.75)
                    {
                        managingSelfStatement = "Awesome";
                    }else
                    {
                        managingSelfStatement = "Admirable";
                    }
                }else
                {
                    managingSelfStatement = "Acceptable";
                }
            }else
            {
                managingSelfStatement = "Awesome";
            }

            relationToOthers = (cre5 + com1 + com2 +com4 + com5 + com6).ToString();
            double relationToOthersDec = (Double.Parse(relationToOthers) - 1) / 24;
            relationToOthersPercent = ((int)(relationToOthersDec) * 100).ToString();
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


            participatingContributing = (cur1 + cre3 + cre4 + com3 + com5+ com6 + sus1 + sus2 + sus4).ToString();
            double participatingContributingDec = (Double.Parse(participatingContributing) - 2) / 36;
            participatingContributingPercent = ((int)(participatingContributingDec) * 100).ToString();
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
            double thinkingDec = (Double.Parse(thinking) - 2) / 48;
            thinkingPercent = ((int)(thinkingDec) * 100).ToString();
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
            double lstDec = Double.Parse(lst) / 44;
            lstPercent = ((int)(lstDec) * 100).ToString();
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

        private void allCalculations()
        {
            readingCalculations();
            writingCalculations();
            mathCalculations();

            creativity();
            creativity();
            community();
            sustainability();

            lifeSkills();
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
                    firstName = drr["Preferred Name"].ToString();
                    gender = drr["Gender"].ToString();
                    room = drr["Room Number"].ToString();
                    NSAchieve = drr["National Standard Achieve"].ToString();
                    nextRoom = drr["Next Room Number"].ToString();
                    generalComment = drr["General Comment"].ToString();

                    readingInitialAssessmentMethod = drr["Reading Initial Assessment Method"].ToString();
                    readingFinalAssessmentMethod = drr["Reading Final Assessment Method"].ToString();
                    readingInitialAssessment = drr["Reading Initial Assessment Level"].ToString();
                    readingFinalAssessment = drr["Reading Final Assessment Level"].ToString();
                    NSReadingAchieve = drr["Reading NS Achievement Code"].ToString();
                    NSProgress = drr["National Standard Progress"].ToString();
                    NSReadingProgress = drr["Reading NS Progress"].ToString();
                    readingEffort = drr["Reading Effort"].ToString();
                    readingComment = drr["Reading Comment"].ToString();

                    writingInitialAssessment = drr["Writing Initial Assessment"].ToString();
                    writingFinalAssessment = drr["Writing Final Assessment"].ToString();
                    writingNS3Code = drr["Writing NS3"].ToString();
                    writingNSAchievementCode = drr["Writing NS Achievement Code"].ToString();
                    writingNSProgress = drr["Writing NS Progress"].ToString();
                    writingEffort = drr["Writing Effort"].ToString();
                    writingComment = drr["Writing Comment"].ToString();

                    mathFinalAssessmentMethod = drr["Math Final Assessment Method"].ToString();
                    mathOverallAssessment = drr["Math Overall Assessment"].ToString();
                    mathKf1 = drr["Math KF1"].ToString();
                    mathKf2 = drr["Math KF2"].ToString();
                    mathKf3 = drr["Math KF3"].ToString();
                    mathKf4 = drr["Math KF4"].ToString();
                    mathNs1 = drr["Math NS1"].ToString();
                    mathNs2 = drr["Math NS2"].ToString();
                    mathNSAchievementCode = drr["Math NS Achievement Code"].ToString();
                    mathNSProgress = drr["Math NS Progress"].ToString();
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

                    //Current Teacher
                    OleDbCommand cmdTeacherThisYear = new OleDbCommand("SELECT [Current Teacher]"
                    + " FROM [Room]"
                    + " WHERE [Room No] = '" + room + "'; ");
                    cmdTeacherThisYear.Connection = conn;
                    OleDbDataReader reader = cmdTeacherThisYear.ExecuteReader();
                    teacherThisYear = reader.GetString(0);

                    //School Year Ordinal
                    OleDbCommand cmdSchoolYearOrdinal = new OleDbCommand("SELECT [Achievement Ordinal]"
                    + " FROM [National Standard Codes]"
                    + " WHERE [National Standard Code] = '" + NSAchieve + "'; ");
                    cmdSchoolYearOrdinal.Connection = conn;
                    reader = cmdSchoolYearOrdinal.ExecuteReader();
                    schoolYearOrdinal = reader.GetString(0);

                    //Next Teacher
                    OleDbCommand cmdNextTeacher = new OleDbCommand("SELECT [Next Year Teacher]"
                    + " FROM [Room]"
                    + " WHERE [Room No] = '" + nextRoom + "'; ");
                    cmdNextTeacher.Connection = conn;
                    reader = cmdNextTeacher.ExecuteReader();
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
                    readingFinalCode = reader.GetString(0);

                    OleDbCommand cmdMathInitialGrade = new OleDbCommand("SELECT [Position1]"
                    + " FROM [Math Reverse Lookup]"
                    + " WHERE [Stage] = '" + mathInitialAssessmentLevel + "'; ");
                    cmdMathInitialGrade.Connection = conn;
                    reader = cmdMathInitialGrade.ExecuteReader();
                    mathInitialGrade = reader.GetString(0);
                    

                    allCalculations();

                    overallAcademic = ((Double.Parse(readingFinalCode) / 2) + (Double.Parse(writingOverallGrade)) + (Double.Parse(mathFinalGrade) * 2)).ToString();

                }

            }
        }
    }
}
