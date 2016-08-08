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
    class AddAssessment : StudentAchievement
    {
        public void addAssessment(OleDbConnection connection)
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

                        String roomNo = values[1];

                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            student = reader.ReadLine();
                            values = student.Split(',');


                            Console.WriteLine(values[0] + "\n" + values[1]);
                            OleDbCommand cmd = new OleDbCommand("SELECT [NSN] FROM Student WHERE [Preferred Name] LIKE '" + values[0] + "' AND [Family Name Legal] LIKE '" + values[1] + "';");

                            cmd.Connection = connection;

                            OleDbDataReader returnValue = cmd.ExecuteReader();

                            returnValue.Read();
                            Console.WriteLine(subject);
                            Console.WriteLine(returnValue.GetValue(0));
                            int nsn = Int32.Parse((String)returnValue.GetValue(0));

                            returnValue.Close();

                            Console.WriteLine(nsn);



                            //Insert statements for the different subjects; reading, mathematics, and writing
                            switch (subject)
                            {

                                case "Reading":
                                    for (int i = 0; i < values.Length; ++i)
                                    {
                                        Console.WriteLine("values[" + i + "] = " + values[i]);
                                    }
                                    cmd = new OleDbCommand("INSERT INTO Reading (NSN, [Initial Assessment Method], [Initial Assessment Level], [Final Assessment Method], [Final Assessment Level], [NS Achievement Code], " +
                                        "[NS Progress], Effort, Comment) VALUES(" + nsn + ", [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] + "], [" + values[8] + "], [" + values[9] + "]);");

                                    cmd.Parameters.AddWithValue("@NSN", values[2]);
                                    cmd.Parameters.AddWithValue("@Initial Assessment Method", values[3]);
                                    cmd.Parameters.AddWithValue("@Initial Assessment Level", values[4]);
                                    cmd.Parameters.AddWithValue("@Final Assessment Method", values[5]);
                                    cmd.Parameters.AddWithValue("@Final Assessment Level", values[6]);
                                    cmd.Parameters.AddWithValue("@NS Achievement Code", values[7]);
                                    cmd.Parameters.AddWithValue("@NS Progress", values[8]);
                                    cmd.Parameters.AddWithValue("@Effort", values[9]);
                                    // cmd.Parameters.AddWithValue("@Comment", values[10]);
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
                            string query = "SELECT * FROM " + subject + " INNER JOIN Student ON (" + subject + ".[NSN] = Student.[NSN]) WHERE Student.[Room Number] = '" + roomNo + "';";

                            cmd.CommandText = query;

                            geekItPnl.Show();
                            geekItPnl.Visible = true;


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
