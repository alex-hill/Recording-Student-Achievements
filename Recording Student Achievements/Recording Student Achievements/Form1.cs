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

namespace Recording_Student_Achievements
{
    


    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;
Persist Security Info=False;";
            ns = new NewStudent();
            ws = new WithdrawStudent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Left = Top = 0;
           // Width = Screen.PrimaryScreen.WorkingArea.Width;
            //Height = Screen.PrimaryScreen.WorkingArea.Height;
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
            if (ns.IsDisposed)
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
            studentDataPnl.Show();
            studentDataPnl.Visible = true;
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

                    + "INNER JOIN [Student Extra] se ON se.[Student ID] = s.[Student ID]) "

                    + "INNER JOIN [Reading] r ON r.[Student ID] = s.[Student ID])"

                    + "INNER JOIN [Writing] w ON w.[Student ID] = s.[Student ID])"

                    + "INNER JOIN [Mathematics] m ON m.[Student ID] = s.[Student ID]);";

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
                MessageBox.Show("Error" + ex);
            }
        }

        private void homeLbl_Click(object sender, EventArgs e)
        {
            if (studentDataPnl.Visible)
            {
                // Add the message
                studentDataPnl.Visible = false;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (studentDataPnl.Visible)
            {
                // Add the message
                studentDataPnl.Visible = false;
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
    }
}
