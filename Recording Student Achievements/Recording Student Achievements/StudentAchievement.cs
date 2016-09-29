using Recording_Student_Achievements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using WindowsFormsApplication1;
using System.Data.SqlClient;
//using Microsoft.Office.Interop.Word;
using System.Collections;


namespace Recording_Student_Achievements
{
    


    public partial class StudentAchievement : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        ArrayList colNames = new ArrayList();
        public StudentAchievement()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            ns = new NewStudent();
            ws = new WithdrawStudent();
            ir = new IndividualReport();
            uc = new UpdateCalculations();
            bs = new BatchStudents();
            add = new AddAssessment();
            aa = new addActivites();
            topBar.Paint += new PaintEventHandler(topBar_Paint);
            topBar.Refresh();
            quickMenuBar.Paint += new PaintEventHandler(quickMenuBar_Paint);
            quickMenuBar.Refresh();
            geekItPnl.Paint += new PaintEventHandler(geekItPnl_Paint);
            geekItPnl.Refresh();

        }

        private void topBar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush linearGradientBrush = 
                new System.Drawing.Drawing2D.LinearGradientBrush(topBar.ClientRectangle, Color.Black, Color.Black, 90);
            System.Drawing.Drawing2D.ColorBlend cblend = new System.Drawing.Drawing2D.ColorBlend(4);

            cblend.Colors = new Color[4] { Color.White, Color.DimGray, Color.White, Color.Black };
            cblend.Positions = new float[4] { 0f, 0.1f, 0.8f, 1f };
            linearGradientBrush.InterpolationColors = cblend;
            e.Graphics.FillRectangle(linearGradientBrush, topBar.ClientRectangle);

        }


        private void quickMenuBar_Paint(object sender, PaintEventArgs e)
        {
            Color c2 = Color.FromArgb(0, 71, 131);
            Color c1 = Color.FromArgb(1, 56, 115);
            System.Drawing.Drawing2D.LinearGradientBrush myBrush
                = new System.Drawing.Drawing2D.LinearGradientBrush(quickMenuBar.ClientRectangle, c1, c2, 90);


            System.Drawing.Drawing2D.ColorBlend cblend = new System.Drawing.Drawing2D.ColorBlend(4);

            cblend.Colors = new Color[4] { Color.White, c1, c2, Color.Black};
            cblend.Positions = new float[4] { 0f, 0.0001f, 0.69f, 1f };
            myBrush.InterpolationColors = cblend;



            CustomRectangle.FillRoundedRectangle(e.Graphics, myBrush, new System.Drawing.Rectangle(-20,0, quickMenuBar.Width + 20, quickMenuBar.Height), 25);
            myBrush.Dispose();
            e.Graphics.Dispose();
        }

        private void geekItPnl_Paint(object sender, PaintEventArgs e)
        {
            Color c2 = Color.FromArgb(0, 71, 131);
            Color c1 = Color.FromArgb(1, 56, 115);
            System.Drawing.Drawing2D.LinearGradientBrush myBrush
                = new System.Drawing.Drawing2D.LinearGradientBrush(geekItPnl.ClientRectangle, c1, c2, 90);


            System.Drawing.Drawing2D.ColorBlend cblend = new System.Drawing.Drawing2D.ColorBlend(4);

            cblend.Colors = new Color[4] { Color.White, c1, c2, Color.Black };
            cblend.Positions = new float[4] { 0f, 0.0001f, 0.69f, 1f };
            myBrush.InterpolationColors = cblend;



            CustomRectangle.FillRoundedRectangle(e.Graphics, myBrush, new System.Drawing.Rectangle(0, 0, geekItPnl.Width , geekItPnl.Height), 25);
            myBrush.Dispose();
            e.Graphics.Dispose();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
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

        private NewStudent ns;
        private void newStudentLbl_Click(object sender, EventArgs e)
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

        private void geekLbl_Click(object sender, EventArgs e)
        {
            geekItPnl.Show();
            geekItPnl.Visible = true;
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                //
                command.Connection = connection;

                string query =
                        "SELECT [s.NSN] AS `NSN`, [s.Family Name Legal] AS `Last Name`, [s.First Name Legal] AS `First Name`, [s.Date Of Birth] AS `DoB`, [se.School Next Year Level] AS `Next Year Level`, [se.Next Room Number] AS `Next Room Number`, [s.Gender] AS `Gender`, [s.Ethnicity] AS `Ethnicity` "
                        + ", [r.Final Assessment Level] AS `Reading Final Assessment`, [r.NS Progress] AS `Reading Progress Level`"
                        + ", [w.Initial Assessment] AS `Writing Initial Assessment`, [w.NS Progress]  AS `Writing Progress Level`"
                        + ", [m.Overall Assessment] AS `Maths Overall Assessment`, [m.NS Progress]  AS `Maths Progress Level`"
                        + ", [se.Curiosity 1] AS `Curiosity 1`, [se.Curiosity 2] AS `Curiosity 2`, [se.Curiosity 3] AS `Curiosity 3`"
                        + ", [se.Creativity 1] AS `Creativity 1`, [se.Creativity 2]   AS `Creativity 2`, [se.Creativity 3]  AS `Creativity 3`"
                        + ", [se.Community 1] AS `Community 1`, [se.Community 2] AS `Community 2`, [se.Community 3] AS `Community 3`"
                        + ", [se.Sustainability 1] AS `Sustainability 1`, [se.Sustainability 2] AS `Sustainability 2`, [se.Sustainability 3]  AS `Sustainability 3` "

                        + "FROM (((([Student] s "

                        + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN])"

                        + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"

                        + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]);";


/*
                {

                    using (var cmd = new OleDbCommand("SELECT * FROM [Student], [Student Extra], [Reading], [Writing], [Mathematics], [Culture Activities], [Sports Activities], [Extra Activities]", connection))
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        var table = reader.GetSchemaTable();
                        var nameCol = table.Columns["ColumnName"];
                        foreach (DataRow row in table.Rows)
                        {
                            String str = row[nameCol].ToString();
                            if(str.Contains("Student."))
                            {
                                str = str.Replace("Student.", "");
                                colNames.Add(str);
                            }else if(str.Contains("Reading.NSN") || str.Contains("Writing.NSN") || str.Contains("Mathematics.NSN") || str.Contains("Culture Activities.NSN") || str.Contains("Sports Activities.NSN") || str.Contains("Extra Activities.NSN") ){
                            }else
                            {
                                colNames.Add(str);
                            }
                            
                        }
                    }
                }

                for (int iIndex = 0; iIndex < colNames.Count; iIndex++)
                {
                    object o = colNames[iIndex];
                    Console.WriteLine(o);
                }

                string query =
                    "SELECT * FROM((((((([Student] s "

                    + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "

                    + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN])"

                    + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"

                    + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN])"

                    + "INNER JOIN [Culture Activities] ca ON ca.[NSN] = s.[NSN])"
                    + "INNER JOIN [Sports Activities] sa ON sa.[NSN] = s.[NSN])"
                    + "INNER JOIN [Extra Activities] ea ON ea.[NSN] = s.[NSN]);";

                */

                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                /*
                dataGridView1.Columns["Last Name"].Frozen = true;
                dataGridView1.Columns["First Name"].Frozen = true;
                */

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }


        private void homeLbl_Click(object sender, EventArgs e)
        {
            if (geekItPnl.Visible)
            {
                // Add the message
                geekItPnl.Visible = false;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (geekItPnl.Visible)
            {
                // Add the message
                geekItPnl.Visible = false;
            }
        }

        private void headerPanel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.laingholm.school.nz/Site/Home.ashx");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.laingholm.school.nz/Site/Home.ashx");
        }

        AddAssessment add;
        private void label2_Click(object sender, EventArgs e)
        {
            if (!add.Visible && !add.IsDisposed)
            {
                add.Show();
            }

            // Can now add more than one student (previously crashed if tried to add another student)
            if (ir.IsDisposed)
            {
                add = new AddAssessment();
                add.Show();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            geekItPnl.Show();
            geekItPnl.Visible = true;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                //
                command.Connection = connection;
                string query =
                    "SELECT [s.NSN] AS `NSN`, [s.Family Name Legal] AS `Last Name`, [s.First Name Legal] AS `First Name`, [s.Date Of Birth] AS `DoB`, [se.School Next Year Level] AS `Next Year Level`, [se.Next Room Number] AS `Next Room Number`, [s.Gender] AS `Gender`, [s.Ethnicity] AS `Ethnicity` "
                    + ", [r.Final Assessment Level] AS `Reading Final Assessment`, [r.NS Progress] AS `Reading Progress Level`"
                    + ", [w.Overall Assessment] AS `Writing Overall Assessment`, [w.NS Progress]  AS `Writing Progress Level`"
                    + ", [m.Overall Assessment] AS `Maths Overall Assessment`, [m.NS Progress]  AS `Maths Progress Level`"
                    + ", [se.Curiosity 1] AS `Curiosity 1`, [se.Curiosity 2] AS `Curiosity 2`, [se.Curiosity 3] AS `Curiosity 3`"
                    + ", [se.Creativity 1] AS `Creativity 1`, [se.Creativity 2]   AS `Creativity 2`, [se.Creativity 3]  AS `Creativity 3`"
                    + ", [se.Community 1] AS `Community 1`, [se.Community 2] AS `Community 2`, [se.Community 3] AS `Community 3`"
                    + ", [se.Sustainability 1] AS `Sustainability 1`, [se.Sustainability 2] AS `Sustainability 2`, [se.Sustainability 3]  AS `Sustainability 3` "
                    + "FROM (((([Student] s "
                    + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "
                    + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN])"
                    + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"
                    + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN])"
                    + "WHERE se.NSN = '" + Int32.Parse(searchByNSN.Text) + "';";
                command.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Last Name"].Frozen = true;
                dataGridView1.Columns["First Name"].Frozen = true;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private IndividualReport ir;
        private void generateIndiReportLbl_Click(object sender, EventArgs e)
        {
            if(!ir.Visible && !ir.IsDisposed)
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

        private void header_Click(object sender, EventArgs e)
        {

        }

        private UpdateCalculations uc;
        private void calculateLbl_Click(object sender, EventArgs e)
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

        private BatchStudents bs;
        private void addBatchStudents_Click(object sender, EventArgs e)
        {
            if (!bs.Visible && !bs.IsDisposed)
            {
                // Add the message
                bs.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (bs.IsDisposed)
            {
                bs = new BatchStudents();
                bs.Show();
            }
        }

        private addActivites aa;
        private void addActivites_Click(object sender, EventArgs e)
        {
            if(!aa.Visible && !aa.IsDisposed)
            {
                aa.Show();
            }
            if(aa.IsDisposed)
            {
                aa = new addActivites();
                aa.Show();
            }
        }
    }
}
