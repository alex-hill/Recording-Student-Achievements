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
        string connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;";
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
            ae = new AddExtra();
            ut = new UpdateTeachers();
            da = new DeleteAll();
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

        public void geekLbl_Click(object sender, EventArgs e)
        {
            geekItPnl.Show();
            geekItPnl.Visible = true;
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {

            try
            {
                    conn.Open();
                    string query = "SELECT "
                        + "[s.NSN] AS `NSN`, "
                        + "[s.Family Name Legal] AS `Surname`, "
                        + "[s.First Name Legal] AS `First Name`, "
                        + "[se.Report Layout Type] AS `Report Layout Code`, "
                        + "[s.Date of Birth] AS `DOB`, "
                        + "[s.Room Number] AS `Room This Year`, "
                        + "[c.Teacher this year] AS `Teacher This Year`, "
                        + "[s.Year Level] AS `Current LPS Year Level`, "
                        + "[se.MOE Year] AS `MOE Year (Current)`, "
                        + "[se.National Standard Achieve] AS `Nat Std Achieve`, "
                        + "[c.School Year Ordinal] AS `Sch Year Ordinal`, "
                        + "[se.National Standard Progress] AS `Nat Std Progress`, "
                        + "[se.Report Count] AS `Report Week Count`, "
                        + "[se.School Next Year Level] AS `LPS Year Level Next Year`, "
                        + "[se.Next Room Number] AS `Next Room No`, "
                        + "[c.Next Teacher] AS `Next Teacher`, "
                        + "[c.Placement Statement] AS `Placement Statement`, "
                        + "[c.Next Room Statement] AS `Next Room`, "
                        + "[s.Gender] AS `Gender`, "
                        + "[c.HeShe] AS `He/She`, "
                        + "[c.HisHer] AS `His/Her`, "
                        + "[c.HimHer] AS `Him/Her`, "
                        + "[s.Ethnicity] AS `Ethnic`, "
                        + "[r.Reading Initial Assessment Method] AS `Reading Initial Assessment Method`, "
                        + "[r.Reading Initial Assessment Level] AS `Reading Initial Assessment Level`, "
                        + "[c.Reading Initial Statement] AS `Reading Initial Report Statement `, "
                        + "[r.Reading Final Assessment Method] AS `Reading Final Assessment Method`, "
                        + "[r.Reading Final Assessment Level] AS `Reading Final Assessment Level`, "
                        + "[c.Reading Final Statement] AS `Reading Final Report Statement`, "
                        + "[c.Reading KF1 Statement] AS `Reading KF #1`, "
                        + "[c.Reading KF2 Statement] AS `Reading KF #2`, "
                        + "[c.Reading NS1 Statement] AS `Reading NS #1`, "
                        + "[c.Reading NS2 Statement] AS `Reading NS #2`, "
                        + "[c.Reading NS Achievement Timeframe] AS `Reading NS Achievement Timeframe`, "
                        + "[c.Reading NS Achievement Statement] AS `Reading NS Achievement Statement`, "
                        + "[r.Reading NS Achievement Code] AS `Reading NS Achievement Code`, "
                        + "[c.Reading NS Achieve Level] AS `Reading NS Achieve Level`, "
                        + "[c.Reading NS Achievement OTJ] AS `Reading NS Achievement OTJ`, "
                        + "[c.Reading NS Achievement Comp] AS `Reading NS Achievement Comp`, "
                        + "[c.Reading NS Achievement OTJ vs COMP] AS `Reading NS Achievement OTJ vs COMP`, "
                        + "[c.Reading NS Progress Timeframe] AS `Reading NS Progress Timeframe`, "
                        + "[c.Reading NS Progress Statement] AS `Reading NS Progress Statement`, "
                        + "[r.Reading NS Progress] AS `Reading NS Progress Code`, "
                        + "[c.Reading NS Progress Level] AS `Reading NS Progress Level`, "
                        + "[c.Reading NS Progress OTJ] AS `Reading NS Progress OTJ`, "
                        + "[c.Reading NS Progress Comp] AS `Reading NS Progress Comp`, "
                        + "[c.Reading NS Progress OTJ vs Comp] AS `Reading NS Progress OTJ vs Comp`, "
                        + "[r.Reading Effort Level] AS `Reading Effort Code`, "
                        + "[c.Reading Effort Level] AS `Reading Effort Level`, "
                        + "[c.Reading Effort Statement] AS `Reading Effort Statement`, "
                        + "[r.Reading Comment] AS `Reading Comment`, "
                        + "[c.Reading Comment Length] AS `Reading Comment Length`, "
                        + "[w.Writing Initial Assessment] AS `Writing Initial Assessment`, "
                        + "[w.Writing Final Assessment] AS `Writing Final Assessment`, "
                        + "[c.Writing Overall Assessment] AS `Writing Overall Assessment`, "
                        + "[c.Writing KF1 Statement] AS `Writing KF1 Statement`, "
                        + "[c.Writing KF2 Statement] AS `Writing KF2 Statement`, "
                        + "[c.Writing NS1 Statement] AS `Writing NS1 Statement`, "
                        + "[c.Writing NS2 Statement] AS `Writing NS2 Statement`, "
                        + "[w.Writing NS3 Code] AS `Write NS#3 Code`, "
                        + "[c.Writing NS3 Statement] AS `Writing NS3 Statement`, "
                        + "[c.Writing NS Achievement Timeframe] AS `Writing NS Achievement Timeframe`, "
                        + "[c.Writing NS Achievement Statement] AS `Writing NS Achievement Statement`, "
                        + "[w.Writing NS Achievement Code] AS `Writing NS Achievement Code`, "
                        + "[c.Writing NS Achieve Level] AS `Writing NS Achieve Level`, "
                        + "[c.Writing NS Achievement OTJ] AS `Writing NS Achievement OTJ`, "
                        + "[c.Writing NS Achievement Comp] AS `Writing NS Achievement Comp`, "
                        + "[c.Writing NS Achievement OTJ vs COMP] AS `Writing NS Achievement OTJ vs COMP`, "
                        + "[c.Writing NS Progress Timeframe] AS `Writing NS Progress Timeframe`, "
                        + "[c.Writing NS Progress Statement] AS `Writing NS Progress Statement`, "
                        + "[w.Writing NS Progress Code] AS `Writing NS Progress Code`, "
                        + "[c.Writing NS Progress Level] AS `Writing NS Progress Level`, "
                        + "[c.Writing NS Progress OTJ] AS `Writing NS Progress OTJ`, "
                        + "[c.Writing NS Progress Comp] AS `Writing NS Progress Comp`, "
                        + "[c.Writing NS Progress OTJ vs COMP] AS `Writing NS Progress OTJ vs COMP`, "
                        + "[w.Writing Effort Level] AS `Writing Effort (Code)`, "
                        + "[c.Writing Effort Level] AS `Writing Effort Level`, "
                        + "[c.Writing Effort Statement] AS `Writing Effort Statement`, "
                        + "[w.Writing Comment] AS `Writing Comment`, "
                        + "[c.Writing Comment Length] AS `Writing Comment Length`, "
                        + "[m.Math Initial Assessment Method] AS `Math Initial Assessment Method`, "
                        + "[m.Math Initial Assessment Level] AS `Math Initial Assessment Level`, "
                        + "[m.Math Final Assessment Method] AS `Math Final Assessment Method`, "
                        + "[m.Math Final Assessment Level] AS `Math Final Assessment Level`, "
                        + "[m.Math Overall Assessment] AS `Math Overall Assessment`, "
                        + "[m.Math KF1] AS `Math KF#1`, "
                        + "[c.Math KF1 Statement] AS `Math KF#1 Statement`, "
                        + "[m.Math KF2] AS `Math KF#2`, "
                        + "[c.Math KF2 Statement] AS `Math KF#2 Statement`, "
                        + "[m.Math KF3] AS `Math KF#3`, "
                        + "[c.Math KF3 Statement] AS `Math KF#3 Statement`, "
                        + "[m.Math KF4] AS `Math KF#4`, "
                        + "[c.Math KF4 Statement] AS `Math KF#4 Statement`, "
                        + "[m.Math NS1] AS `Math NS#1`, "
                        + "[c.Math NS1 Statement] AS `Math NS#1 Statement`, "
                        + "[m.Math NS2] AS `Math NS#2`, "
                        + "[c.Math NS2 Statement] AS `Math NS#2 Statement`, "
                        + "[c.Math NA Average] AS `Math NA Average`, "
                        + "[c.Math NA Round] AS `Math NA Round`, "
                        + "[c.Math NA Stage Check] AS `Math NA Stage Check`, "
                        + "[c.Math NS Achievement Timeframe] AS `Math NS Achievement Timeframe`, "
                        + "[c.Math NS Achievement Statement] AS `Math NS Achievement Statement`, "
                        + "[m.Math NS Achievement Code] AS `Math NS Achievement Code`, "
                        + "[c.Math NS Achieve Level] AS `Math NS Achieve Level`, "
                        + "[c.Math NS Achievement OTJ] AS `Math NS Achievement OTJ`, "
                        + "[c.Math NS Achievement Comp] AS `Math NS Achievement Comp`, "
                        + "[c.Math NS Achievement OTJ vs Comp] AS `Math NS Achievement OTJ vs Comp`, "
                        + "[c.Math NS Progress Timeframe] AS `Math NS Progress Timeframe`, "
                        + "[c.Math NS Progress Statement] AS `Math NS Progress Statement`, "
                        + "[m.Math NS Progress Code] AS `Math NS Progress Code`, "
                        + "[c.Math NS Progress Level] AS `Math NS Progress Level`, "
                        + "[c.Math NS Progress OTJ] AS `Math NS Progress OTJ`, "
                        + "[c.Math NS Progress Comp] AS `Math NS Progress Comp`, "
                        + "[c.Math NS Progress OTJ vs Comp] AS `Math NS Progress OTJ vs Comp`, "
                        + "[m.Math Effort Level] AS `Maths Effort (Code)`, "
                        + "[c.Math Effort Level] AS `Math Effort Level`, "
                        + "[c.Math Effort Statement] AS `Maths Effort Statement`, "
                        + "[m.Math Comment] AS `Maths Comment`, "
                        + "[c.Math Comment Length] AS `Math Comment Length`, "
                        + "[ca.Te Reo] AS `Te Reo Class`, "
                        + "[ca.Mandarin] AS `Mandarin`, "
                        + "[ea.Extension Program] AS `Extension Programs`, "
                        + "[ea.Service to School] AS `Service to the School`, "
                        + "[ea.AV & Media Technician] AS `AV & Media Technician`, "
                        + "[ea.Bus Monitor] AS `Bus Monitor`, "
                        + "[ea.Cool School Mediator] AS `Cool School Mediator`, "
                        + "[ca.Geek squad] AS `Geek Squad`, "
                        + "[ea.Librarian] AS `Librarian`, "
                        + "[ea.Road Patrol] AS `Road Patrol`, "
                        + "[ea.Student Council] AS `Student Council`, "
                        + "[ea.Wet Day Monitor] AS `Wet Day Monitor`, "
                        + "[ca.Horticulture Club] AS `Horticulture Club`, "
                        + "[ea.Nature Savers] AS `Nature Savers`, "
                        + "[ea.Weed Busters] AS `Weed Busters`, "
                        + "[ea.Worm Farm] AS `Worm Farm`, "
                        + "[ea.Artist in Residence] AS `Artist in Residence`, "
                        + "[ea.Silo Art Installation] AS `Silo Art Installation`, "
                        + "[ca.Choir] AS `Choir`, "
                        + "[ca.Kapa Haka] AS `Kapa Haka`, "
                        + "[ea.Laingholm Got Talent Crew] AS `Laingholm's Got Talent (Crew)`, "
                        + "[ea.Laingholm Got Talent Finalist] AS `Laingholm's Got Talent (Finalist)`, "
                        + "[ca.Ukulele Group] AS `Ukulele Group`, "
                        + "[sa.Athletics] AS `Athletics`, "
                        + "[sa.Cricket] AS `Cricket`, "
                        + "[sa.Cross Country] AS `Cross Country`, "
                        + "[sa.Football] AS `Football`, "
                        + "[sa.Hockey] AS `Hockey`, "
                        + "[sa.Gymnastics] AS `Gymnastics Team`, "
                        + "[sa.Jump Jam] AS `Jump Jam`, "
                        + "[sa.Krypton Factor] AS `Krypton Factor`, "
                        + "[sa.Netball Saturday] AS `Netball (Saturday)`, "
                        + "[sa.Netball Interschool] AS `Netball Interschool`, "
                        + "[sa.Swimming Team] AS `Swimming Team`, "
                        + "[sa.Sports and Team Leader] AS `Sports & Team Leader`, "
                        + "[c.Activities Count] AS `Total Participation`, "
                        + "[c.Sports Count] AS `Total Sport Participation`, "
                        + "[se.Curiosity 1] AS `Curiosity #1`, "
                        + "[c.Curiosity 1 Statement] AS `Curiosity #1 Statement`, "
                        + "[se.Curiosity 2] AS `Curiosity #2`, "
                        + "[c.Curiosity 2 Statement] AS `Curiosity #2 Statement`, "
                        + "[se.Curiosity 3] AS `Curiosity #3`, "
                        + "[c.Curiosity 3 Statement] AS `Curiosity #3 Statement`, "
                        + "[se.Curiosity 4] AS `Curiosity #4`, "
                        + "[c.Curiosity 4 Statement] AS `Curiosity #4 Statement`, "
                        + "[se.Curiosity 5] AS `Curiosity #5`, "
                        + "[c.Curiosity 5 Statement] AS `Curiosity #5 Statement`, "
                        + "[se.Curiosity 6] AS `Curiosity #6`, "
                        + "[c.Curiosity 6 Statement] AS `Curiosity #6 Statement`, "
                        + "[se.Creativity 1] AS `Creativity #1`, "
                        + "[c.Creativity 1 Statement] AS `Creativity #1 Statement`, "
                        + "[se.Creativity 2] AS `Creativity #2`, "
                        + "[c.Creativity 2 Statement] AS `Creativity #2 Statement`, "
                        + "[se.Creativity 3] AS `Creativity #3`, "
                        + "[c.Creativity 3 Statement] AS `Creativity #3 Statement`, "
                        + "[se.Creativity 4] AS `Creativity #4`, "
                        + "[c.Creativity 4 Statement] AS `Creativity #4 Statement`, "
                        + "[se.Creativity 5] AS `Creativity #5`, "
                        + "[c.Creativity 5 Statement] AS `Creativity #5 Statement`, "
                        + "[se.Creativity 6] AS `Creativity #6`, "
                        + "[c.Creativity 6 Statement] AS `Creativity #6 Statement`, "
                        + "[se.Community 1] AS `Community #1`, "
                        + "[c.Community 1 Statement] AS `Community #1 Statement`, "
                        + "[se.Community 2] AS `Community #2`, "
                        + "[c.Community 2 Statement] AS `Community #2 Statement`, "
                        + "[se.Community 3] AS `Community #3`, "
                        + "[c.Community 3 Statement] AS `Community #3 Statement`, "
                        + "[se.Community 4] AS `Community #4`, "
                        + "[c.Community 4 Statement] AS `Community #4 Statement`, "
                        + "[se.Community 5] AS `Community #5`, "
                        + "[c.Community 5 Statement] AS `Community #5 Statement`, "
                        + "[se.Community 6] AS `Community #6`, "
                        + "[c.Community 6 Statement] AS `Community #6 Statement`, "
                        + "[se.Sustainability 1] AS `Sustainability #1`, "
                        + "[c.Sustainability 1 Statement] AS `Sustainability #1 Statement`, "
                        + "[se.Sustainability 2] AS `Sustainability #2`, "
                        + "[c.Sustainability 2 Statement] AS `Sustainability #2 Statement`, "
                        + "[se.Sustainability 3] AS `Sustainability #3`, "
                        + "[c.Sustainability 3 Statement] AS `Sustainability #3 Statement`, "
                        + "[se.Sustainability 4] AS `Sustainability #4`, "
                        + "[c.Sustainability 4 Statement] AS `Sustainability #4 Statement`, "
                        + "[se.Sustainability 5] AS `Sustainability #5`, "
                        + "[c.Sustainability 5 Statement] AS `Sustainability #5 Statement`, "
                        + "[se.Sustainability 6] AS `Sustainability #6`, "
                        + "[c.Sustainability 6 Statement] AS `Sustainability #6 Statement`, "
                        + "[c.Managing Self] AS `Managing Self`, "
                        + "[c.Managing Self Percent] AS `MS Percentage`, "
                        + "[c.Managing Self Statement] AS `MS Statement`, "
                        + "[c.Relation to Others] AS `Relating to Others`, "
                        + "[c.Relation to Others Percent] AS `RO Percentage`, "
                        + "[c.Relation to Others Statement] AS `RO Statement`, "
                        + "[c.Participating Contributing] AS `Participating & Contributing`, "
                        + "[c.Participating Contributing Percent] AS `P&C Percentage`, "
                        + "[c.Participating Contributing Statement] AS `P&C Statement`, "
                        + "[c.Thinking] AS `Thinking`, "
                        + "[c.Thinking Percent] AS `T Percentage`, "
                        + "[c.Thinking Statement] AS `T Statement`, "
                        + "[c.LST] AS `Using Language, Symbols & Text`, "
                        + "[c.LST Percent] AS `SLT Percentage`, "
                        + "[c.LST Statement] AS `SLT Statement`, "


                        + "[c.Reading Final Code] AS `Final Reading Code`, "
                        + "[c.Writing Initial Grade] AS `Writing Initial Grade`, "
                        + "[c.Writing Final Grade] AS `Writing Final Grade`, "
                        + "[c.Writing Overall Grade] AS `Final Writing Code`, "
                        + "[c.Math Initial Grade] AS `Initial Grade (Maths)`, "
                        + "[c.Math Final Grade] AS `Final OTJ Grade (Maths)`, "
                        + "[se.Honesty] AS `Honesty`, "
                        + "[se.Excellence] AS `Excellence`, "
                        + "[se.Aroha] AS `Aroha`, "
                        + "[se.Respect] AS `Respect`, "
                        + "[se.Trust] AS `Trust`, "
                        + "[c.All Human Values] AS `All Values (Yes/No)`, "
                        + "[c.Total Human Values] AS `Total Values`, "
                        + "[c.Reading Progress Check] AS `Reading Progress Check`, "
                        + "[c.Writing Progress Check] AS `Writing Progress Check`, "
                        + "[c.Math Progress Check] AS `Maths Progress Check`, "
                        + "[c.Data Summary] AS `Data Summary`, "
                        + "[c.Checksums] AS `Checksums`, "
                        + "[c.Students Well Below] AS `Students Well Below Expectation`, "
                        + "[c.Students Below] AS `Students Well Below or Below Expectation`, "
                        + "[c.Students At] AS `Students At Expectation`, "
                        + "[c.Students Above] AS `Students Above or Well Above Expectation`, "
                        + "[c.Students Well Above] AS `Students Well Above Expectation`, "
                        + "[se.General Comment] AS `General Comment`, "
                        + "[c.General Comment Length] AS `General Comment Length`, "
                        + "[c.Overall Academic] AS `Overall Academic`, "
                        + "[c.Teachers Cup] AS `Teachers Cup` "

                        + "FROM (((((((([Student] s "

                        + "LEFT OUTER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "

                        + "LEFT OUTER JOIN [Reading] r ON r.[NSN] = s.[NSN]) "

                        + "LEFT OUTER JOIN [Writing] w ON w.[NSN] = s.[NSN]) "

                        + "LEFT OUTER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "

                        + "LEFT OUTER JOIN [Calculated] c ON c.[NSN] = s.[NSN])"

                        + "LEFT OUTER JOIN [Cultural Activities] ca ON ca.[NSN] = s.[NSN]) "
                        
                        + "LEFT OUTER JOIN [Sports Activities] sa ON sa.[NSN] = s.[NSN]) "

                        + "LEFT OUTER JOIN [Extra Activities] ea ON ea.[NSN] = s.[NSN]);";
                        
                    using (OleDbCommand allStudents = new OleDbCommand(query, conn))
                {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(allStudents))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                                dataGridView1.Columns["Surname"].Frozen = true;
                                dataGridView1.Columns["First Name"].Frozen = true;

                                int i = 0;
                                foreach(DataColumn c in dt.Columns)
                    {

                                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                                    style.Alignment =
                                        DataGridViewContentAlignment.MiddleCenter;
                                    style.ForeColor = Color.Black;
                                    

                                    DataGridViewColumn dataGridViewColumn = dataGridView1.Columns[c.ColumnName];
                                    //Student
                                    if (i < 23)
                        {
                                        style.BackColor = Color.LightGreen;
                                    }
                                    // Reading
                                    else if (i < 52)
                            {
                                        style.BackColor = Color.Orange;
                                    }
                                    //Writing
                                    else if (i < 80)
                            {
                                        style.BackColor = Color.LightSkyBlue;
                            }
                                    //Math
                                    else if (i < 119)
                                    {
                                        style.BackColor = Color.LightSteelBlue;
                        }
                                    //Activities
                                    else if (i < 156)
                                    {
                                        dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        style.BackColor = Color.LightGray;
                    }
                                    //Cur, cre, sus
                                    else if (i < 220)
                                    {
                                        style.BackColor = Color.Yellow;
                }
                                    // Final Reading
                                    else if (i < 220)
                {
                                        style.BackColor = Color.Orange;
                                    }
                                    // Final Writing
                                    else if (i < 222)
                                    {
                                        style.BackColor = Color.LightSkyBlue;
                                    }
                                    // Final Math
                                    else if (i < 225)
                                    {
                                        style.BackColor = Color.LightSteelBlue;
                                    }
                                    // Human
                                    else if (i < 232)
                                    {
                                        style.BackColor = Color.LightPink;
                                    }
                                    // Summary
                                    else
                                    {
                                        style.BackColor = Color.MediumPurple;
                                    }
                                    dataGridViewColumn.DefaultCellStyle.ApplyStyle(style);
                                    dataGridViewColumn.HeaderCell.Style = style;
                                    i++;
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Error: " +  ex);
                }
            }
        }


        private void homeLbl_Click(object sender, EventArgs e)
        {
            if (geekItPnl.Visible)
            {
                // Add the message
                geekItPnl.Visible = false;
            }
            this.Dispose();
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
        public void label2_Click(object sender, EventArgs e)
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
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {

            try
            {
                    conn.Open();
                    string query = "SELECT "
                        + "[s.NSN] AS `NSN`, "
                        + "[s.Family Name Legal] AS `Surname`, "
                        + "[s.First Name Legal] AS `First Name`, "
                        + "[se.Report Layout Type] AS `Report Layout Code`, "
                        + "[s.Date of Birth] AS `DOB`, "
                        + "[s.Room Number] AS `Room This Year`, "
                        + "[c.Teacher this year] AS `Teacher This Year`, "
                        + "[s.Year Level] AS `Current LPS Year Level`, "
                        + "[se.MOE Year] AS `MOE Year (Current)`, "
                        + "[se.National Standard Achieve] AS `Nat Std Achieve`, "
                        + "[c.School Year Ordinal] AS `Sch Year Ordinal`, "
                        + "[se.National Standard Progress] AS `Nat Std Progress`, "
                        + "[se.Report Count] AS `Report Week Count`, "
                        + "[se.School Next Year Level] AS `LPS Year Level Next Year`, "
                        + "[se.Next Room Number] AS `Next Room No`, "
                        + "[c.Next Teacher] AS `Next Teacher`, "
                        + "[c.Placement Statement] AS `Placement Statement`, "
                        + "[c.Next Room Statement] AS `Next Room`, "
                        + "[s.Gender] AS `Gender`, "
                        + "[c.HeShe] AS `He/She`, "
                        + "[c.HisHer] AS `His/Her`, "
                        + "[c.HimHer] AS `Him/Her`, "
                        + "[s.Ethnicity] AS `Ethnic`, "
                        + "[r.Reading Initial Assessment Method] AS `Reading Initial Assessment Method`, "
                        + "[r.Reading Initial Assessment Level] AS `Reading Initial Assessment Level`, "
                        + "[c.Reading Initial Statement] AS `Reading Initial Report Statement `, "
                        + "[r.Reading Final Assessment Method] AS `Reading Final Assessment Method`, "
                        + "[r.Reading Final Assessment Level] AS `Reading Final Assessment Level`, "
                        + "[c.Reading Final Statement] AS `Reading Final Report Statement`, "
                        + "[c.Reading KF1 Statement] AS `Reading KF #1`, "
                        + "[c.Reading KF2 Statement] AS `Reading KF #2`, "
                        + "[c.Reading NS1 Statement] AS `Reading NS #1`, "
                        + "[c.Reading NS2 Statement] AS `Reading NS #2`, "
                        + "[c.Reading NS Achievement Timeframe] AS `Reading NS Achievement Timeframe`, "
                        + "[c.Reading NS Achievement Statement] AS `Reading NS Achievement Statement`, "
                        + "[r.Reading NS Achievement Code] AS `Reading NS Achievement Code`, "
                        + "[c.Reading NS Achieve Level] AS `Reading NS Achieve Level`, "
                        + "[c.Reading NS Achievement OTJ] AS `Reading NS Achievement OTJ`, "
                        + "[c.Reading NS Achievement Comp] AS `Reading NS Achievement Comp`, "
                        + "[c.Reading NS Achievement OTJ vs COMP] AS `Reading NS Achievement OTJ vs COMP`, "
                        + "[c.Reading NS Progress Timeframe] AS `Reading NS Progress Timeframe`, "
                        + "[c.Reading NS Progress Statement] AS `Reading NS Progress Statement`, "
                        + "[r.Reading NS Progress] AS `Reading NS Progress Code`, "
                        + "[c.Reading NS Progress Level] AS `Reading NS Progress Level`, "
                        + "[c.Reading NS Progress OTJ] AS `Reading NS Progress OTJ`, "
                        + "[c.Reading NS Progress Comp] AS `Reading NS Progress Comp`, "
                        + "[c.Reading NS Progress OTJ vs Comp] AS `Reading NS Progress OTJ vs Comp`, "
                        + "[r.Reading Effort Level] AS `Reading Effort Code`, "
                        + "[c.Reading Effort Level] AS `Reading Effort Level`, "
                        + "[c.Reading Effort Statement] AS `Reading Effort Statement`, "
                        + "[r.Reading Comment] AS `Reading Comment`, "
                        + "[c.Reading Comment Length] AS `Reading Comment Length`, "
                        + "[w.Writing Initial Assessment] AS `Writing Initial Assessment`, "
                        + "[w.Writing Final Assessment] AS `Writing Final Assessment`, "
                        + "[c.Writing Overall Assessment] AS `Writing Overall Assessment`, "
                        + "[c.Writing KF1 Statement] AS `Writing KF1 Statement`, "
                        + "[c.Writing KF2 Statement] AS `Writing KF2 Statement`, "
                        + "[c.Writing NS1 Statement] AS `Writing NS1 Statement`, "
                        + "[c.Writing NS2 Statement] AS `Writing NS2 Statement`, "
                        + "[w.Writing NS3 Code] AS `Write NS#3 Code`, "
                        + "[c.Writing NS3 Statement] AS `Writing NS3 Statement`, "
                        + "[c.Writing NS Achievement Timeframe] AS `Writing NS Achievement Timeframe`, "
                        + "[c.Writing NS Achievement Statement] AS `Writing NS Achievement Statement`, "
                        + "[w.Writing NS Achievement Code] AS `Writing NS Achievement Code`, "
                        + "[c.Writing NS Achieve Level] AS `Writing NS Achieve Level`, "
                        + "[c.Writing NS Achievement OTJ] AS `Writing NS Achievement OTJ`, "
                        + "[c.Writing NS Achievement Comp] AS `Writing NS Achievement Comp`, "
                        + "[c.Writing NS Achievement OTJ vs COMP] AS `Writing NS Achievement OTJ vs COMP`, "
                        + "[c.Writing NS Progress Timeframe] AS `Writing NS Progress Timeframe`, "
                        + "[c.Writing NS Progress Statement] AS `Writing NS Progress Statement`, "
                        + "[w.Writing NS Progress Code] AS `Writing NS Progress Code`, "
                        + "[c.Writing NS Progress Level] AS `Writing NS Progress Level`, "
                        + "[c.Writing NS Progress OTJ] AS `Writing NS Progress OTJ`, "
                        + "[c.Writing NS Progress Comp] AS `Writing NS Progress Comp`, "
                        + "[c.Writing NS Progress OTJ vs COMP] AS `Writing NS Progress OTJ vs COMP`, "
                        + "[w.Writing Effort Level] AS `Writing Effort (Code)`, "
                        + "[c.Writing Effort Level] AS `Writing Effort Level`, "
                        + "[c.Writing Effort Statement] AS `Writing Effort Statement`, "
                        + "[w.Writing Comment] AS `Writing Comment`, "
                        + "[c.Writing Comment Length] AS `Writing Comment Length`, "
                        + "[m.Math Initial Assessment Method] AS `Math Initial Assessment Method`, "
                        + "[m.Math Initial Assessment Level] AS `Math Initial Assessment Level`, "
                        + "[m.Math Final Assessment Method] AS `Math Final Assessment Method`, "
                        + "[m.Math Final Assessment Level] AS `Math Final Assessment Level`, "
                        + "[m.Math Overall Assessment] AS `Math Overall Assessment`, "
                        + "[m.Math KF1] AS `Math KF#1`, "
                        + "[c.Math KF1 Statement] AS `Math KF#1 Statement`, "
                        + "[m.Math KF2] AS `Math KF#2`, "
                        + "[c.Math KF2 Statement] AS `Math KF#2 Statement`, "
                        + "[m.Math KF3] AS `Math KF#3`, "
                        + "[c.Math KF3 Statement] AS `Math KF#3 Statement`, "
                        + "[m.Math KF4] AS `Math KF#4`, "
                        + "[c.Math KF4 Statement] AS `Math KF#4 Statement`, "
                        + "[m.Math NS1] AS `Math NS#1`, "
                        + "[c.Math NS1 Statement] AS `Math NS#1 Statement`, "
                        + "[m.Math NS2] AS `Math NS#2`, "
                        + "[c.Math NS2 Statement] AS `Math NS#2 Statement`, "
                        + "[c.Math NA Average] AS `Math NA Average`, "
                        + "[c.Math NA Round] AS `Math NA Round`, "
                        + "[c.Math NA Stage Check] AS `Math NA Stage Check`, "
                        + "[c.Math NS Achievement Timeframe] AS `Math NS Achievement Timeframe`, "
                        + "[c.Math NS Achievement Statement] AS `Math NS Achievement Statement`, "
                        + "[m.Math NS Achievement Code] AS `Math NS Achievement Code`, "
                        + "[c.Math NS Achieve Level] AS `Math NS Achieve Level`, "
                        + "[c.Math NS Achievement OTJ] AS `Math NS Achievement OTJ`, "
                        + "[c.Math NS Achievement Comp] AS `Math NS Achievement Comp`, "
                        + "[c.Math NS Achievement OTJ vs Comp] AS `Math NS Achievement OTJ vs Comp`, "
                        + "[c.Math NS Progress Timeframe] AS `Math NS Progress Timeframe`, "
                        + "[c.Math NS Progress Statement] AS `Math NS Progress Statement`, "
                        + "[m.Math NS Progress Code] AS `Math NS Progress Code`, "
                        + "[c.Math NS Progress Level] AS `Math NS Progress Level`, "
                        + "[c.Math NS Progress OTJ] AS `Math NS Progress OTJ`, "
                        + "[c.Math NS Progress Comp] AS `Math NS Progress Comp`, "
                        + "[c.Math NS Progress OTJ vs Comp] AS `Math NS Progress OTJ vs Comp`, "
                        + "[m.Math Effort Level] AS `Maths Effort (Code)`, "
                        + "[c.Math Effort Level] AS `Math Effort Level`, "
                        + "[c.Math Effort Statement] AS `Maths Effort Statement`, "
                        + "[m.Math Comment] AS `Maths Comment`, "
                        + "[c.Math Comment Length] AS `Math Comment Length`, "
                        + "[se.Curiosity 1] AS `Curiosity #1`, "
                        + "[c.Curiosity 1 Statement] AS `Curiosity #1 Statement`, "
                        + "[se.Curiosity 2] AS `Curiosity #2`, "
                        + "[c.Curiosity 2 Statement] AS `Curiosity #2 Statement`, "
                        + "[se.Curiosity 3] AS `Curiosity #3`, "
                        + "[c.Curiosity 3 Statement] AS `Curiosity #3 Statement`, "
                        + "[se.Curiosity 4] AS `Curiosity #4`, "
                        + "[c.Curiosity 4 Statement] AS `Curiosity #4 Statement`, "
                        + "[se.Curiosity 5] AS `Curiosity #5`, "
                        + "[c.Curiosity 5 Statement] AS `Curiosity #5 Statement`, "
                        + "[se.Curiosity 6] AS `Curiosity #6`, "
                        + "[c.Curiosity 6 Statement] AS `Curiosity #6 Statement`, "
                        + "[se.Creativity 1] AS `Creativity #1`, "
                        + "[c.Creativity 1 Statement] AS `Creativity #1 Statement`, "
                        + "[se.Creativity 2] AS `Creativity #2`, "
                        + "[c.Creativity 2 Statement] AS `Creativity #2 Statement`, "
                        + "[se.Creativity 3] AS `Creativity #3`, "
                        + "[c.Creativity 3 Statement] AS `Creativity #3 Statement`, "
                        + "[se.Creativity 4] AS `Creativity #4`, "
                        + "[c.Creativity 4 Statement] AS `Creativity #4 Statement`, "
                        + "[se.Creativity 5] AS `Creativity #5`, "
                        + "[c.Creativity 5 Statement] AS `Creativity #5 Statement`, "
                        + "[se.Creativity 6] AS `Creativity #6`, "
                        + "[c.Creativity 6 Statement] AS `Creativity #6 Statement`, "
                        + "[se.Community 1] AS `Community #1`, "
                        + "[c.Community 1 Statement] AS `Community #1 Statement`, "
                        + "[se.Community 2] AS `Community #2`, "
                        + "[c.Community 2 Statement] AS `Community #2 Statement`, "
                        + "[se.Community 3] AS `Community #3`, "
                        + "[c.Community 3 Statement] AS `Community #3 Statement`, "
                        + "[se.Community 4] AS `Community #4`, "
                        + "[c.Community 4 Statement] AS `Community #4 Statement`, "
                        + "[se.Community 5] AS `Community #5`, "
                        + "[c.Community 5 Statement] AS `Community #5 Statement`, "
                        + "[se.Community 6] AS `Community #6`, "
                        + "[c.Community 6 Statement] AS `Community #6 Statement`, "
                        + "[se.Sustainability 1] AS `Sustainability #1`, "
                        + "[c.Sustainability 1 Statement] AS `Sustainability #1 Statement`, "
                        + "[se.Sustainability 2] AS `Sustainability #2`, "
                        + "[c.Sustainability 2 Statement] AS `Sustainability #2 Statement`, "
                        + "[se.Sustainability 3] AS `Sustainability #3`, "
                        + "[c.Sustainability 3 Statement] AS `Sustainability #3 Statement`, "
                        + "[se.Sustainability 4] AS `Sustainability #4`, "
                        + "[c.Sustainability 4 Statement] AS `Sustainability #4 Statement`, "
                        + "[se.Sustainability 5] AS `Sustainability #5`, "
                        + "[c.Sustainability 5 Statement] AS `Sustainability #5 Statement`, "
                        + "[se.Sustainability 6] AS `Sustainability #6`, "
                        + "[c.Sustainability 6 Statement] AS `Sustainability #6 Statement`, "
                        + "[c.Managing Self] AS `Managing Self`, "
                        + "[c.Managing Self Percent] AS `MS Percentage`, "
                        + "[c.Managing Self Statement] AS `MS Statement`, "
                        + "[c.Relation to Others] AS `Relating to Others`, "
                        + "[c.Relation to Others Percent] AS `RO Percentage`, "
                        + "[c.Relation to Others Statement] AS `RO Statement`, "
                        + "[c.Participating Contributing] AS `Participating & Contributing`, "
                        + "[c.Participating Contributing Percent] AS `P&C Percentage`, "
                        + "[c.Participating Contributing Statement] AS `P&C Statement`, "
                        + "[c.Thinking] AS `Thinking`, "
                        + "[c.Thinking Percent] AS `T Percentage`, "
                        + "[c.Thinking Statement] AS `T Statement`, "
                        + "[c.LST] AS `Using Language, Symbols & Text`, "
                        + "[c.LST Percent] AS `SLT Percentage`, "
                        + "[c.LST Statement] AS `SLT Statement`, "
                        + "[se.General Comment] AS `General Comment`, "
                        + "[c.General Comment Length] AS `General Comment Length`, "
                        + "[ca.Te Reo] AS `Te Reo Class`, "
                        + "[ca.Mandarin] AS `Mandarin`, "
                        + "[ea.Extension Program] AS `Extension Programs`, "
                        + "[ea.Service to School] AS `Service to the School`, "
                        + "[ea.AV & Media Technician] AS `AV & Media Technician`, "
                        + "[ea.Bus Monitor] AS `Bus Monitor`, "
                        + "[ea.Cool School Mediator] AS `Cool School Mediator`, "
                        + "[ca.Geek squad] AS `Geek Squad`, "
                        + "[ea.Librarian] AS `Librarian`, "
                        + "[ea.Road Patrol] AS `Road Patrol`, "
                        + "[ea.Student Council] AS `Student Council`, "
                        + "[ea.Wet Day Monitor] AS `Wet Day Monitor`, "
                        + "[ca.Horticulture Club] AS `Horticulture Club`, "
                        + "[ea.Nature Savers] AS `Nature Savers`, "
                        + "[ea.Weed Busters] AS `Weed Busters`, "
                        + "[ea.Worm Farm] AS `Worm Farm`, "
                        + "[ea.Artist in Residence] AS `Artist in Residence`, "
                        + "[ea.Silo Art Installation] AS `Silo Art Installation`, "
                        + "[ca.Choir] AS `Choir`, "
                        + "[ca.Kapa Haka] AS `Kapa Haka`, "
                        + "[ea.Laingholm Got Talent Crew] AS `Laingholm's Got Talent (Crew)`, "
                        + "[ea.Laingholm Got Talent Finalist] AS `Laingholm's Got Talent (Finalist)`, "
                        + "[ca.Ukulele Group] AS `Ukulele Group`, "
                        + "[sa.Athletics] AS `Athletics`, "
                        + "[sa.Cricket] AS `Cricket`, "
                        + "[sa.Cross Country] AS `Cross Country`, "
                        + "[sa.Football] AS `Football`, "
                        + "[sa.Hockey] AS `Hockey`, "
                        + "[sa.Gymnastics] AS `Gymnastics Team`, "
                        + "[sa.Jump Jam] AS `Jump Jam`, "
                        + "[sa.Krypton Factor] AS `Krypton Factor`, "
                        + "[sa.Netball Saturday] AS `Netball (Saturday)`, "
                        + "[sa.Netball Interschool] AS `Netball Interschool`, "
                        + "[sa.Swimming Team] AS `Swimming Team`, "
                        + "[sa.Sports and Team Leader] AS `Sports & Team Leader`, "
                        + "[c.Activities Count] AS `Total Participation`, "
                        + "[c.Sports Count] AS `Total Sport Participation`, "
                        + "[c.Reading Final Code] AS `Final Reading Code`, "
                        + "[c.Writing Initial Grade] AS `Writing Initial Grade`, "
                        + "[c.Writing Final Grade] AS `Writing Final Grade`, "
                        + "[c.Writing Overall Grade] AS `Final Writing Code`, "
                        + "[c.Math Initial Grade] AS `Initial Grade (Maths)`, "
                        + "[c.Math Final Grade] AS `Final OTJ Grade (Maths)`, "
                        + "[c.Overall Academic] AS `Overall Academic`, "
                        + "[c.Teachers Cup] AS `Teachers Cup`, "
                        + "[se.Honesty] AS `Honesty`, "
                        + "[se.Excellence] AS `Excellence`, "
                        + "[se.Aroha] AS `Aroha`, "
                        + "[se.Respect] AS `Respect`, "
                        + "[se.Trust] AS `Trust`, "
                        + "[c.All Human Values] AS `All Values (Yes/No)`, "
                        + "[c.Total Human Values] AS `Total Values`, "
                        + "[c.Reading Progress Check] AS `Reading Progress Check`, "
                        + "[c.Writing Progress Check] AS `Writing Progress Check`, "
                        + "[c.Math Progress Check] AS `Maths Progress Check`, "
                        + "[c.Data Summary] AS `Data Summary`, "
                        + "[c.Checksums] AS `Checksums`, "
                        + "[c.Students Well Below] AS `Students Well Below Expectation`, "
                        + "[c.Students Below] AS `Students Well Below or Below Expectation`, "
                        + "[c.Students At] AS `Students At Expectation`, "
                        + "[c.Students Above] AS `Students Above or Well Above Expectation`, "
                        + "[c.Students Well Above] AS `Students Well Above Expectation` "

                        + "FROM (((((((([Student] s "

                    + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Calculated] c ON c.[NSN] = s.[NSN])"

                        + "INNER JOIN [Cultural Activities] ca ON ca.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Sports Activities] sa ON sa.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Extra Activities] ea ON ea.[NSN] = s.[NSN])"
                    + "WHERE se.NSN = '" + Int32.Parse(searchByNSN.Text) + "';";

                    using (OleDbCommand allStudents = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(allStudents))
                        {
                            using (DataTable dt = new DataTable())
                            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                                dataGridView1.Columns["Surname"].Frozen = true;
                dataGridView1.Columns["First Name"].Frozen = true;


                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Error: " + ex);
                }
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

        private void readingBttn_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingColumnIndex = 23;
        }

        private void studentInfoBttn_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingColumnIndex = 3;
        }

        private void writingBttn_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingColumnIndex = 52;
        }

        private void mathBttn_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingColumnIndex = 80;
        }

        private void activitiesBttn_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingColumnIndex = 119;
        }

        private void summaryBttn_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingColumnIndex = 156;
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
        private AddExtra ae;

        private void addExtra_Click_1(object sender, EventArgs e)
        {
            if (!ae.Visible && !ae.IsDisposed)
            {
                ae.Show();
            }
            if (ae.IsDisposed)
            {
                ae = new AddExtra();
                ae.Show();
            }
        }

        private void venn_Click(object sender, EventArgs e)
        {
            VennDiagram.makeVenn();
        }

        

         private UpdateTeachers ut;

        private void updateTeachers_Click(object sender, EventArgs e)
        {
            if (!ut.Visible && !ae.IsDisposed)
            {
                ut.Show();
            }
            if (ut.IsDisposed)
            {
                ut = new UpdateTeachers();
                ut.Show();
            }
        }

        private DeleteAll da;

        private void deleteAll_Click(object sender, EventArgs e)
        {
            if (!da.Visible && !ae.IsDisposed)
            {
                da.Show();
            }
            if (da.IsDisposed)
            {
                da = new DeleteAll();
                da.Show();
            }
        }


        private void quickMenuBar_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
