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
    public partial class AddAssessment : Form
    {
        OleDbConnection connection;
        public AddAssessment()
        {
            InitializeComponent();
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
        }

        private void addAss_Click(object sender, EventArgs e)
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

                        String subject = "";

                        Console.WriteLine(values[0]);

                        if (values[0].Equals("READING"))
                        {
                            subject = "Reading";
                        }
                        else if (values[0].Equals("WRITING"))
                        {
                            subject = "Writing";
                        }
                        else if (values[0].Equals("MATHEMATICS"))
                        {
                            subject = "Mathematics";
                        }

                        student = reader.ReadLine();
                        values = student.Split(',');

                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();

                        int next = reader.Peek();

                        if (next == -1)
                        {
                            throw new FormatException("The file you tried to import is empty. Please check and try again.");
                        }

                        while (!reader.EndOfStream)
                        {
                            student = reader.ReadLine();
                            values = student.Split(',');

                            OleDbCommand cmd = new OleDbCommand();

                            //Insert statements for the different subjects; reading, mathematics, and writing
                            switch (subject)
                            {

                                case "Reading":
                                    for (int i = 0; i < values.Length; ++i)
                                    {
                                        Console.WriteLine("values[" + i + "] = " + values[i]);
                                    }
                                    cmd = new OleDbCommand();

                                    cmd.CommandText = "INSERT INTO Reading (NSN, [Reading Initial Assessment Method], [Reading Initial Assessment Level], [Reading Final Assessment Method], [Reading Final Assessment Level], [Reading NS Achievement Code], " +
                                        "[Reading NS Progress], [Reading Effort Level], [Reading Comment]) VALUES(" + values[0] + ", [" + values[1] + "], [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] + "], [" + values[8] + "]);";

                                    cmd.Parameters.AddWithValue("@NSN", values[0]);
                                    cmd.Parameters.AddWithValue("@Reading Initial Assessment Method", values[1]);
                                    cmd.Parameters.AddWithValue("@Reading Initial Assessment Level", values[2]);
                                    cmd.Parameters.AddWithValue("@Reading Final Assessment Method", values[3]);
                                    cmd.Parameters.AddWithValue("@Reading Final Assessment Level", values[4]);
                                    cmd.Parameters.AddWithValue("@Reading NS Achievement Code", values[5]);
                                    cmd.Parameters.AddWithValue("@Reading NS Progress", values[6]);
                                    cmd.Parameters.AddWithValue("@Reading Effort Level", values[7]);
                                    cmd.Parameters.AddWithValue("@Reading Comment", values[8]);
                                    break;
                                case "Writing":
                                    Console.WriteLine("Values length: " + values.Length);
                                    for (int i = 0; i < values.Length; ++i)
                                    {
                                        Console.WriteLine("values[" + i + "] = " + values[i]);
                                    }

                                    cmd.CommandText = "INSERT INTO Writing (NSN, [Writing Initial Assessment], [Writing Final Assessment], [Writing NS3 Code], [Writing NS Achievement Code], [Writing NS Progress Code], " +
                                        "[Writing Effort Level], [Writing Comment]) VALUES(" + values[0] + ", [" + values[1] + "], [" + values[2] + "], [" + values[3] + "], [" + values[4] + "], [" + values[5] + "], [" + values[6] + "], [" + values[7] + "]);";

                                    cmd.Parameters.AddWithValue("@NSN", values[0]);
                                    cmd.Parameters.AddWithValue("@Writing Initial Assessment", values[1]);
                                    cmd.Parameters.AddWithValue("@Writing Final Assessment", values[2]);
                                    cmd.Parameters.AddWithValue("@Writing NS3 Code", values[3]);
                                    cmd.Parameters.AddWithValue("@Writing NS Achievement Code", values[4]);
                                    cmd.Parameters.AddWithValue("@Writing NS Progress Code", values[5]);
                                    cmd.Parameters.AddWithValue("@Writing Effort Level", values[6]);
                                    cmd.Parameters.AddWithValue("@Writing Comment", values[7]);

                                    Console.WriteLine("cmd.CommandText: " + cmd.CommandText);
                                    break;
                                case "Mathematics":
                                    cmd = new OleDbCommand();

                                    

                                    cmd.Parameters.AddWithValue("@NSN", values[0]);
                                    cmd.Parameters.AddWithValue("@Math Initial Assessment Method", values[1]);
                                    cmd.Parameters.AddWithValue("@Math Initial Assessment Level", values[2]);
                                    cmd.Parameters.AddWithValue("@Math Final Assessment Method", values[3]);
                                    cmd.Parameters.AddWithValue("@Math Final Assessment Level", values[4]);
                                    cmd.Parameters.AddWithValue("@Math Overall Assessment", values[5]);
                                    cmd.Parameters.AddWithValue("@Math NS Progress Code", values[6]);
                                    cmd.Parameters.AddWithValue("@Math Effort Level", values[7]);
                                    cmd.Parameters.AddWithValue("@Math Comment", values[8]);
                                    cmd.Parameters.AddWithValue("@Math KF1", values[9]);
                                    cmd.Parameters.AddWithValue("@Math KF2", values[10]);
                                    cmd.Parameters.AddWithValue("@Math NS1", values[11]);
                                    cmd.Parameters.AddWithValue("@Math NS2", values[12]);
                                    cmd.Parameters.AddWithValue("@Math NS Achievement Code", values[13]);
                                    cmd.Parameters.AddWithValue("@Math KF3", values[14]);
                                    cmd.Parameters.AddWithValue("@Math KF4", values[15]);

                                    cmd.CommandText = "INSERT INTO Mathematics (NSN, [Math Initial Assessment Method], [Math Initial Assessment Level], [Math Final Assessment Method], [Math Final Assessment Level], [Math Overall Assessment], " +
                                        "[Math NS Achievement Code], [Math NS Progress Code], [Math Effort Level], [Math Comment], [Math KF1], [Math KF2], [Math KF3], [Math KF4], [Math NS1], [Math NS2]) "
                                        + "VALUES(@NSN, [@Math Initial Assessment Method], [@Math Initial Assessment Level], [@Math Final Assessment Method], [@Math Final Assessment Level], [@Math Overall Assessment], [@Math NS Achievement Code], "
                                        +"[@Math NS Progress Code], [@Math Effort Level], [@Math Comment], [@Math KF1], [@Math KF2], [@Math KF3], [@Math KF4], [@Math NS1], [@Math NS2]); ";

                                    break;


                            }
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Added");

                            

                        }


                    }
                    fileStream.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                connection.Close();
            }
        }

        private void updateAss_Click(object sender, EventArgs e)
        {
            String[] columns = new String[] { 
                "Reading Initial Assessment Method", 
                "Reading Initial Assessment Level", 
                "Reading Final Assessment Method", 
                "Reading Final Assessment Level", 
                "Reading NS Achievement Code",
                "Reading NS Progress", 
                "Reading Effort Level", 
                "Reading Comment",
                "Writing Initial Assessment", 
                "Writing Final Assessment", 
                "Writing NS3 Code", 
                "Writing NS Achievement Code", 
                "Writing NS Progress Code", 
                "Writing Effort Level", 
                "Writing Comment", 
                "Math Initial Assessment Method", 
                "Math Initial Assessment Level", 
                "Math Final Assessment Method", 
                "Math Final Assessment Level", 
                "Math Overall Assessment", 
                "Math NS Progress Code", 
                "Math Effort Level", 
                "Math Comment",
                "Math KF1", 
                "Math KF2", 
                "Math NS1",
                "Math NS2",
                "Math NS Achievement Code",
                "Math KF3",
                "Math KF4"};
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
                            for (int i = 1; i < values.Length; i++ )
                            {
                                if(!values[i].Equals(""))
                                {
                                    //reading
                                    if(i < 9)
                                    {
                                        cmd.CommandText = ("UPDATE Reading SET [" + columns[i-1] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';");
                                        //Console.WriteLine(i + columns[i] + "\n" + values[i]);
                                        //Console.WriteLine(cmd.CommandText.ToString());
                                    }
                                    //writing
                                    else if(i < 16)
                                    {
                                        cmd.CommandText = ("UPDATE Writing SET [" + columns[i-1] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';");
                                    }
                                    //maths
                                    else
                                    {
                                        cmd.CommandText = ("UPDATE Mathematics SET [" + columns[i-1] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';");
                                    }

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
                MessageBox.Show(ex.Message, "Error");
                connection.Close();
            }
        }
    }
}
