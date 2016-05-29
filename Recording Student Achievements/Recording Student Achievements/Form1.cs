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
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Table.mdb;Persist Security Info=True"; //For Alex's laptop
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

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                // Create an instance of the open file dialog box.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set filter options and filter index.
                openFileDialog1.Filter = "Excel Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = true;

                // Process input if the user clicked OK.
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Open the selected file to read.
                    System.IO.Stream fileStream = openFileDialog1.OpenFile();

                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                    {
                        String student = reader.ReadLine();

                        String[] values = student.Split(',');

                        String subject = "";

                        if (values[0].Equals("READING"))
                        {
                            subject = "Reading";
                        }
                        else if (values[0].Equals("Writing"))
                        {
                            subject = "Writing";
                        }
                        else if (values[0].Equals("Mathematics"))
                        {
                            subject = "Mathematics";
                        }

                        student = reader.ReadLine();
                        values = student.Split(',');

                        String roomNo = values[0];

                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            student = reader.ReadLine();
                            values = student.Split(',');



                            OleDbCommand cmd = new OleDbCommand("SELECT NSN, [Student ID] FROM Student WHERE [Preferred Name] LIKE '" + values[0] + "' AND [Family Name Legal] LIKE '" + values[1] + "';");

                            // OleDbCommand cmd = new OleDbCommand("INSERT INTO Student (Gender, NSN) VALUES ('" + textBox7.Text + "', '" + textBox10.Text + "');");
                            cmd.Connection = connection;

                            OleDbDataReader returnValue = cmd.ExecuteReader();

                            returnValue.Read();
                            int nsn = Int32.Parse((String)returnValue.GetValue(0));
                            int studentID = (int)returnValue.GetValue(1);

                            returnValue.Close();

                            Console.WriteLine(nsn);
                            Console.WriteLine(subject);


                            //Insert statements for the different subjects; reading, mathematics, and writing
                            switch (subject)
                            {
                                case "Reading":
                                    cmd = new OleDbCommand("INSERT INTO Reading ([Student ID], NSN, [Initial Assessment Method], [Initial Assessment Level], [Final Assessment Method], [Final Assessment Level], [NS Achievement Code], " +
                                        "[NS Progress], Effort, Comment) VALUES(" + studentID + ", " + nsn + ", [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] +"], [" + values[8] + "], [" + values[9] +"]);");

                                    cmd.Parameters.AddWithValue("@Student ID", studentID);
                                    cmd.Parameters.AddWithValue("@NSN", nsn);
                                    cmd.Parameters.AddWithValue("@Initial Assessment Method", values[2]);
                                    cmd.Parameters.AddWithValue("@Initial Assessment Level", values[3]);
                                    cmd.Parameters.AddWithValue("@Final Assessment Method", values[4]);
                                    cmd.Parameters.AddWithValue("Final Assessment Level", values[5]);
                                    cmd.Parameters.AddWithValue("NS Achievement Code", values[6]);
                                    cmd.Parameters.AddWithValue("NS Progress", values[7]);
                                    cmd.Parameters.AddWithValue("Effort", values[8]);
                                    cmd.Parameters.AddWithValue("Comment", values[9]);
                                    break;
                                case "Writing":
                                    cmd = new OleDbCommand("INSERT INTO Writing (NSN, [Initial Assessment], [Initial Assessment], [Overall Assessment], [NS Code], [NS Achievement Code], " +
                                        "[NS Progress], Effort, Comment) VALUES(" + nsn + ", [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] + "], [" + values[8] + "], [" + values[9] + "]);");

                                    cmd.Parameters.AddWithValue("@NSN", nsn);
                                    cmd.Parameters.AddWithValue("@Initial Assessment", values[2]);
                                    cmd.Parameters.AddWithValue("@Final Assessment", values[3]);
                                    cmd.Parameters.AddWithValue("@Overall Assessment", values[4]);
                                    cmd.Parameters.AddWithValue("NS Code", values[5]);
                                    cmd.Parameters.AddWithValue("NS Achievement Code", values[6]);
                                    cmd.Parameters.AddWithValue("NS Progress", values[7]);
                                    cmd.Parameters.AddWithValue("Effort", values[8]);
                                    cmd.Parameters.AddWithValue("Comment", values[9]);
                                    break;
                                case "Mathematics":
                                    cmd = new OleDbCommand("INSERT INTO Mathematics (NSN, [Initial Assessment Method], [Initial Assessment Level], [Final Assessment Method], [Final Assessment Level], [Overall Assessment], " +
                                        "[NS Progress], Effort, Comment) VALUES(" + nsn + ", [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] + "], [" + values[8] + "], [" + values[9] + "]);");

                                    cmd.Parameters.AddWithValue("@NSN", nsn);
                                    cmd.Parameters.AddWithValue("@Initial Assessment Method", values[2]);
                                    cmd.Parameters.AddWithValue("@Initial Assessment Level", values[3]);
                                    cmd.Parameters.AddWithValue("@Final Assessment Method", values[4]);
                                    cmd.Parameters.AddWithValue("Final Assessment Level", values[5]);
                                    cmd.Parameters.AddWithValue("Overall Assessment", values[6]);
                                    cmd.Parameters.AddWithValue("NS Progress", values[7]);
                                    cmd.Parameters.AddWithValue("Effort", values[8]);
                                    cmd.Parameters.AddWithValue("Comment", values[9]);
                                    break;

                                    
                            }
                            cmd.Connection = connection;
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Data Added");

                            //Displaying the data that was just added
                            string query = "SELECT * FROM " + subject + " INNER JOIN Student ON (" + subject + ".[Student ID] = Student.[Student ID]);";

                            cmd.CommandText = query;

                            studentDataPnl.Show();
                            studentDataPnl.Visible = true;


                            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                           
                        }

                        
                    }
                    fileStream.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                connection.Close();
            }
        }
    }
}
