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
using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using System.IO;


namespace Recording_Student_Achievements
{
    


    public partial class StudentAchievement : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private AddAssessment aa = new AddAssessment();
        private GeekIt gi = new GeekIt();
        private NSNSearch nsnSearch = new NSNSearch();
        public StudentAchievement()
        {
            InitializeComponent();

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            //connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Table.mdb;Persist Security Info=True"; //For Alex's laptop
            ns = new NewStudent();
            ws = new WithdrawStudent();
            ir = new IndividualReport();
            topBar.Paint += new PaintEventHandler(topBar_Paint);
            topBar.Refresh();
            quickMenuBar.Paint += new PaintEventHandler(quickMenuBar_Paint);
            quickMenuBar.Refresh();
            geekItPnl.Paint += new PaintEventHandler(geekItPnl_Paint);
            geekItPnl.Refresh();

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

            gi.geekIt(connection);
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

        //Add Assessment
        private void label2_Click(object sender, EventArgs e)
        {
            aa.addAssessment(connection);
        }

        private void search_Click(object sender, EventArgs e)
        {
            nsnSearch.nsnSearch(connection);
            
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

            cblend.Colors = new Color[4] { Color.White, c1, c2, Color.Black };
            cblend.Positions = new float[4] { 0f, 0.0001f, 0.69f, 1f };
            myBrush.InterpolationColors = cblend;



            CustomRectangle.FillRoundedRectangle(e.Graphics, myBrush, new System.Drawing.Rectangle(-20, 0, quickMenuBar.Width + 20, quickMenuBar.Height), 25);
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



            CustomRectangle.FillRoundedRectangle(e.Graphics, myBrush, new System.Drawing.Rectangle(0, 0, geekItPnl.Width, geekItPnl.Height), 25);
            myBrush.Dispose();
            e.Graphics.Dispose();
        }

        private void header_Click(object sender, EventArgs e)
        {

        }
    }
}
