using Microsoft.Office.Interop.Excel;
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
using WindowsFormsApplication1;

namespace Recording_Student_Achievements
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            ns = new NewStudent();
            ws = new WithdrawStudent();
            ir = new IndividualReport();
            uc = new UpdateCalculations();
            sa = new StudentAchievement();
            da = new DeleteAll();
            ut = new UpdateTeachers();
        }


        private NewStudent ns;
        private void label6_Click(object sender, EventArgs e)
        {
            if (!ns.Visible && !ns.IsDisposed)
            {
                // Add the message
                ns.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ns.IsDisposed)
            {
                ns = new NewStudent();
                ns.Show();
            }
        }

        private WithdrawStudent ws;
        private void withdrawStudentLbl_Click(object sender, EventArgs e)
        {
            if (!ws.Visible && !ws.IsDisposed)
            {
                // Add the message
                ws.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ws.IsDisposed)
            {
                ws = new WithdrawStudent();
                ws.Show();
            }
        }

        private void withdrawAllStudentLbl_Click(object sender, EventArgs e)
        {
            if (!ws.Visible && !ws.IsDisposed)
            {
                // Add the message
                ws.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ws.IsDisposed)
            {
                ws = new WithdrawStudent();
                ws.Show();
            }
        }
        private IndividualReport ir;
        private void singleReportLbl_Click(object sender, EventArgs e)
        {
            if (!ir.Visible && !ir.IsDisposed)
            {
                ir.Show();
            }

            // Can now add more than one student (previously crashed if tried to add another student)
            if (ir.IsDisposed)
            {
                ir = new IndividualReport();
                ir.Show();
            }
        }
        private UpdateCalculations uc;
        private void updateDatabaseLbl_Click(object sender, EventArgs e)
        {
            if (!uc.Visible && !uc.IsDisposed)
            {
                // Add the message
                uc.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (uc.IsDisposed)
            {
                uc = new UpdateCalculations();
                uc.Show();
            }
        }

        private StudentAchievement sa;
        private void geekItLbl_Click(object sender, EventArgs e)
        {
            
            sa = new StudentAchievement();
            if (!sa.Visible && !sa.IsDisposed)
            {
                // Add the message
                sa.Show();

            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (sa.IsDisposed)
            {
                sa = new StudentAchievement();
                sa.Show();
            }
            Visible = false;
            sa.geekLbl_Click(sender, e);

        }

        private void addAssessmentLbl_Click(object sender, EventArgs e)
        {
            /*
             * 
             */
        }

        private DeleteAll da;
        private void deleteAll_Click(object sender, EventArgs e)
        {

            if (!da.Visible && !da.IsDisposed)
            {
                // Add the mesdage
                da.Show();


            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (da.IsDisposed)
            {
                da = new DeleteAll();
                da.Show();
            }
        }

        

        private UpdateTeachers ut;
        private void updateTeachersLbl_Click(object sender, EventArgs e)
        {

            if (!ut.Visible && !ut.IsDisposed)
            {
                // Add the mesutge
                ut.Show();


            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ut.IsDisposed)
            {
                ut = new UpdateTeachers();
                ut.Show();
            }
        }

        private void readingVennLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generating the Venn Diagrams now\nWill Open in Excel");

            OleDbConnection conn = new OleDbConnection();
            
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT [Students Well Below], [Students Below], [Students Above], [Students Well Above] FROM Calculated;";
            DataSet sd = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);

            int readingBelow = 0;
            int readingWritingBelow = 0;
            int readingMathBelow = 0;
            int writingBelow = 0;
            int writingMathBelow = 0;
            int mathBelow = 0;
            int totalBelow = 0;
            int readingAbove = 0;
            int readingMathAbove = 0;
            int readingWritingAbove = 0;
            int writingAbove = 0;
            int writingMathAbove = 0;
            int mathAbove = 0;
            int totalAbove = 0;
            int allAbove = 0;
            int allBelow = 0;

            foreach (DataRow row in table.Rows)
            {
                object[] values = row.ItemArray;

                if(values[0].ToString().Contains("1") || values[1].ToString().Contains("1"))
                {
                        if(values[0].ToString().Equals("11X") || values[1].ToString().Equals("11X"))
                        {
                            ++readingWritingBelow;
                        }
                        else if(values[0].ToString().Equals("1X1") || values[1].ToString().Equals("1X1"))
                        {
                            ++readingMathBelow;
                        }
                        else if(values[0].ToString().Equals("1XX") || values[1].ToString().Equals("1XX"))
                        {
                            ++readingBelow;
                        }
                        else if (values[0].ToString().Equals("X1X") || values[1].ToString().Equals("X1X"))
                        {
                            ++writingBelow;
                        }
                        else if (values[0].ToString().Equals("X11") || values[1].ToString().Equals("X11"))
                        {
                            ++writingMathBelow;
                        }
                        else if (values[0].ToString().Equals("XX1") || values[1].ToString().Equals("XX1"))
                        {
                            ++mathBelow;
                        }
                        else
                        {
                            ++allBelow;
                        }
                    
                    ++totalBelow;
                }
                if(values[2].ToString().Contains("1") || values[3].ToString().Contains("1"))
                {
                        if (values[2].ToString().Equals("11X") || values[3].ToString().Equals("11X"))
                        {
                            ++readingWritingAbove;
                        }
                        else if (values[2].ToString().Equals("1X1") || values[3].ToString().Equals("1X1"))
                        {
                            ++readingMathAbove;
                        }
                        else if (values[2].ToString().Equals("1XX") || values[3].ToString().Equals("1XX"))
                        {
                            ++readingAbove;
                        }
                        else if (values[2].ToString().Equals("X1X") || values[3].ToString().Equals("X1X"))
                        {
                            ++writingAbove;
                        }
                        else if (values[2].ToString().Equals("X11") || values[3].ToString().Equals("X11"))
                        {
                            ++writingMathAbove;
                        }
                        else if (values[2].ToString().Equals("XX1") || values[3].ToString().Equals("XX1"))
                        {
                            ++mathAbove;
                        }
                        else
                        {
                            ++allAbove;
                        }
                    
                    ++totalAbove;
                }
            }

            string path = "C:\\Users\\lxlxl\\Desktop\\Venn Diagram Template.xlsx";
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            Workbook excelWorkbook = excelApp.Workbooks.Open(path, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            Sheets excelSheets = excelWorkbook.Worksheets;
            Worksheet excelWorksheet = (Worksheet)excelSheets.get_Item("VennDiagrams");
            Range excelCell = excelWorksheet.get_Range("A2", "M60");

            foreach (Range c in excelCell.Cells)
            {
                if (c.Value != null)
                {
                    if (c.Value.Equals("BelowNum"))
                    {
                        c.Value = totalBelow;
                    }
                    else if (c.Value.Equals("BelowPercent"))
                    {
                        c.Value = (totalBelow / table.Rows.Count);
                    }
                    else if (c.Value.Equals("ReadingBelow"))
                    {
                        c.Value = readingBelow;
                    }
                    else if (c.Value.Equals("WritingBelow"))
                    {
                        c.Value = writingBelow;
                    }
                    else if (c.Value.Equals("MathBelow"))
                    {
                        c.Value = mathBelow;
                    }
                    else if (c.Value.Equals("ReadingWritingBelow"))
                    {
                        c.Value = readingWritingBelow;
                    }
                    else if (c.Value.Equals("ReadingMathBelow"))
                    {
                        c.Value = readingMathBelow;
                    }
                    else if (c.Value.Equals("WritingMathBelow"))
                    {
                        c.Value = writingMathBelow;
                    }
                    else if (c.Value.Equals("AllBelow"))
                    {
                        c.Value = allBelow;
                    }
                    else if (c.Value.Equals("AboveNum"))
                    {
                        c.Value = totalAbove;
                    }
                    else if (c.Value.Equals("AbovePercent"))
                    {
                        c.Value = (totalAbove / table.Rows.Count);
                    }
                    else if (c.Value.Equals("ReadingAbove"))
                    {
                        c.Value = readingAbove;
                    }
                    else if (c.Value.Equals("ReadingWritingAbove"))
                    {
                        c.Value = readingWritingAbove;
                    }
                    else if (c.Value.Equals("WritingAbove"))
                    {
                        c.Value = writingAbove;
                    }
                    else if (c.Value.Equals("ReadingMathAbove"))
                    {
                        c.Value = readingMathAbove;
                    }
                    else if (c.Value.Equals("AllAbove"))
                    {
                        c.Value = allAbove;
                    }
                    else if (c.Value.Equals("WritingMathAbove"))
                    {
                        c.Value = writingMathAbove;
                    }
                    else if (c.Value.Equals("MathAbove"))
                    {
                        c.Value = mathAbove;
                    }
                }
            }

            conn.Close();

        }
    }
}
