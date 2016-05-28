﻿using Recording_Student_Achievements;
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
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
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

                MessageBox.Show("Connection Successful");

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT * FROM Student";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

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



                            OleDbCommand cmd = new OleDbCommand("SELECT NSN FROM Student WHERE [Preferred Name] LIKE '" + values[0] + "' AND [Family Name Legal] LIKE '" + values[1] + "';");

                            // OleDbCommand cmd = new OleDbCommand("INSERT INTO Student (Gender, NSN) VALUES ('" + textBox7.Text + "', '" + textBox10.Text + "');");
                            cmd.Connection = connection;

                            OleDbDataReader returnValue = cmd.ExecuteReader();

                            returnValue.Read();
                            int nsn = (int)returnValue.GetValue(0);

                            returnValue.Close();

                            Console.WriteLine(nsn);
                            Console.WriteLine(subject);

                            switch (subject)
                            {
                                case "Reading":
                                    cmd = new OleDbCommand("INSERT INTO Reading (NSN, [Initial Assessment Method], [Initial Assessment Level], [Final Assessment Method], [Final Assessment Level], [NS Achievement Code], " +
                                        "[NS Progress], Effort, Comment) VALUES(" + returnValue + ", [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] +"], [" + values[8] + "], [" + values[9] +"]);");

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
                                        "[NS Progress], Effort, Comment) VALUES(" + returnValue + ", [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] + "], [" + values[8] + "], [" + values[9] + "]);");

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
                                        "[NS Progress], Effort, Comment) VALUES(" + returnValue + ", [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] + "], [" + values[8] + "], [" + values[9] + "]);");

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

                                //add data to database
                                // select * from * where roomno = values[1];
                            }

                        
                    }
                    fileStream.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
