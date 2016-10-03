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

namespace Recording_Student_Achievements
{
    public partial class AddExtra : Form
    {
        OleDbConnection connection;
        String[] columns;
        public AddExtra()
        {
            InitializeComponent();
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            columns = new String[]{
                "NSN",
                "Next Room Number",
                "School Next Year Level",
                "Report Report Count",
                "Report Layout Type",
                "National Standard Achieve",
                "National Standard Progress",
                "General Comment",
                "Honesty",
                "Excellence",
                "Aroha",
                "Respect",
                "Curiosity 1",
                "Curiosity 2",
                "Curiosity 3",
                "Curiosity 4",
                "Curiosity 5",
                "Curiosity 6",
                "Creativity 1",
                "Creativity 2",
                "Creativity 3",
                "Creativity 4",
                "Creativity 5",
                "Creativity 6",
                "Community 1",
                "Community 2",
                "Community 3",
                "Community 4",
                "Community 5",
                "Community 6",
                "Sustainability 1",
                "Sustainability 2",
                "Sustainability 3",
                "Sustainability 4",
                "Sustainability 5",
                "Sustainability 6",
                "Trust",
            };
        }

        private void addStudentExtra_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                // Create an instance of the open file dialog box.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set filter options and filter index.
                openFileDialog1.Filter = "Excel Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = false;

                // Process input if the user clicked OK.
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Open the selected file to read.
                    System.IO.Stream fileStream = openFileDialog1.OpenFile();

                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                    {
                        reader.ReadLine();
                        while (reader.EndOfStream != true)
                        {
                            String line = reader.ReadLine();
                            String[] values = line.Split(',');

                            OleDbCommand cmd = new OleDbCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = connection;

                            int next = reader.Peek();

                            if (next == -1)
                            {
                                throw new FormatException("The file you tried to import is empty. Please check and try again.");
                            }

                            cmd.Parameters.Add("@NSN", OleDbType.VarChar).Value = values[0];
                            cmd.Parameters.Add("@Next Room Number", OleDbType.VarChar).Value = values[1];
                            cmd.Parameters.Add("@School Next Year Level", OleDbType.VarChar).Value = values[2];
                            cmd.Parameters.Add("@Report Report Count", OleDbType.VarChar).Value = values[3];
                            cmd.Parameters.Add("@Report Layout Type", OleDbType.VarChar).Value = values[4];
                            cmd.Parameters.Add("@National Standard Achieve", OleDbType.VarChar).Value = values[5];
                            cmd.Parameters.Add("@National Standard Progress", OleDbType.VarChar).Value = values[6];
                            cmd.Parameters.Add("@General Comment", OleDbType.VarChar).Value = values[7];
                            cmd.Parameters.Add("@Honesty", OleDbType.VarChar).Value = values[8];
                            cmd.Parameters.Add("@Excellence", OleDbType.VarChar).Value = values[9];
                            cmd.Parameters.Add("@Aroha", OleDbType.VarChar).Value = values[10];
                            cmd.Parameters.Add("@Respect", OleDbType.VarChar).Value = values[11];
                            cmd.Parameters.Add("@Curiosity 1", OleDbType.VarChar).Value = values[12];
                            cmd.Parameters.Add("@Curiosity 2", OleDbType.VarChar).Value = values[13];
                            cmd.Parameters.Add("@Curiosity 3", OleDbType.VarChar).Value = values[14];
                            cmd.Parameters.Add("@Curiosity 4", OleDbType.VarChar).Value = values[15];
                            cmd.Parameters.Add("@Curiosity 5", OleDbType.VarChar).Value = values[16];
                            cmd.Parameters.Add("@Curiosity 6", OleDbType.VarChar).Value = values[17];
                            cmd.Parameters.Add("@Creativity 1", OleDbType.VarChar).Value = values[18];
                            cmd.Parameters.Add("@Creativity 2", OleDbType.VarChar).Value = values[19];
                            cmd.Parameters.Add("@Creativity 3", OleDbType.VarChar).Value = values[20];
                            cmd.Parameters.Add("@Creativity 4", OleDbType.VarChar).Value = values[21];
                            cmd.Parameters.Add("@Creativity 5", OleDbType.VarChar).Value = values[22];
                            cmd.Parameters.Add("@Creativity 6", OleDbType.VarChar).Value = values[23];
                            cmd.Parameters.Add("@Community 1", OleDbType.VarChar).Value = values[24];
                            cmd.Parameters.Add("@Community 2", OleDbType.VarChar).Value = values[25];
                            cmd.Parameters.Add("@Community 3", OleDbType.VarChar).Value = values[26];
                            cmd.Parameters.Add("@Community 4", OleDbType.VarChar).Value = values[27];
                            cmd.Parameters.Add("@Community 5", OleDbType.VarChar).Value = values[28];
                            cmd.Parameters.Add("@Community 6", OleDbType.VarChar).Value = values[29];
                            cmd.Parameters.Add("@Sustainability 1", OleDbType.VarChar).Value = values[30];
                            cmd.Parameters.Add("@Sustainability 2", OleDbType.VarChar).Value = values[31];
                            cmd.Parameters.Add("@Sustainability 3", OleDbType.VarChar).Value = values[32];
                            cmd.Parameters.Add("@Sustainability 4", OleDbType.VarChar).Value = values[33];
                            cmd.Parameters.Add("@Sustainability 5", OleDbType.VarChar).Value = values[34];
                            cmd.Parameters.Add("@Sustainability 6", OleDbType.VarChar).Value = values[35];
                            cmd.Parameters.Add("@Trust", OleDbType.VarChar).Value = values[36];


                            cmd.CommandText = "INSERT INTO [Student Extra] (NSN, [Next Room Number], [School Next Year Level], [Report Report Count], [Report Layout Type], [National Standard Achieve], "+
                            "[National Standard Progress], [General Comment], Honesty, Excellence, Aroha, Respect, [Curiosity 1], [Curiosity 2], [Curiosity 3], [Curiosity 4], [Curiosity 5], [Curiosity 6], "
                            + " [Creativity 1], [Creativity 2], [Creativity 3], [Creativity 4], [Creativity 5], [Creativity 6], [Community 1], [Community 2], [Community 3], [Community 4], [Community 5], "
                            + "[Community 6], [Sustainability 1], [Sustainability 2], [Sustainability 3], [Sustainability 4], [Sustainability 5], [Sustainability 6], Trust)"
                      + " VALUES(@NSN, [@Next Room Number], [@School Next Year Level], [@Report Report Count], [@Report Layout Type], [@National Standard Achieve], [@National Standard Progress], [@General Comment], "
                            +" @Honesty, @Excellence, @Aroha, @Respect, [@Curiosity 1], [@Curiosity 2], [@Curiosity 3], [@Curiosity 4], [@Curiosity 5], [@Curiosity 6], [@Creativity 1], [@Creativity 2], [@Creativity 3], "
                            + "[@Creativity 4], [@Creativity 5], [@Creativity 6], [@Community 1], [@Community 2], [@Community 3], [@Community 4], [@Community 5], [@Community 6], [@Sustainability 1], [@Sustainability 2], "
                            + "[@Sustainability 3], [@Sustainability 4], [@Sustainability 5], [@Sustainability 6], @Trust);";


                            cmd.ExecuteNonQuery();


                        }
                        MessageBox.Show("Data Added");
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                connection.Close();
            }
            this.Dispose();
        }

        private void updateExtra_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                // Create an instance of the open file dialog box.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set filter options and filter index.
                openFileDialog1.Filter = "Excel Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = false;

                // Process input if the user clicked OK.
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Open the selected file to read.
                    System.IO.Stream fileStream = openFileDialog1.OpenFile();

                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                    {
                        String student = reader.ReadLine();

                        String[] values = student.Split(',');
                        OleDbCommand cmd = new OleDbCommand();
                        values = student.Split(',');

                        int next = reader.Peek();

                        if (next == -1)
                        {
                            throw new FormatException("The file you tried to import is empty. Please check and try again.");
                        }


                        while (!reader.EndOfStream)
                        {
                            student = reader.ReadLine();
                            values = student.Split(',');

                            //values[0] = nsn
                            for (int i = 1; i < values.Length; i++)
                            {
                                if (!values[i].Equals(""))
                                {
                                    cmd = new OleDbCommand();
                                    cmd.CommandText = "UPDATE [Student Extra] SET [" + columns[i] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';";

                                    Console.WriteLine("Executing: " + cmd.CommandText.ToString());
                                    cmd.Connection = connection;
                                    cmd.ExecuteNonQuery();
                                }
                            }





                        }
                        MessageBox.Show("Data Updated");


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

            this.Dispose();
        }
    }
}
