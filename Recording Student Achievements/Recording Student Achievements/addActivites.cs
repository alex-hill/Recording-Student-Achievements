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
    public partial class addActivites : Form
    {
        OleDbConnection connection;
        String[] columns;
        public addActivites()
        {
            InitializeComponent();
            
            connection = new OleDbConnection();
            string path = "C:\\Users\\Public\\Desktop\\";
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ path +"\\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            columns = new String[]{
                "Te Reo",
                "Geek Squad",
                "Horticulture Club",
                "Choir",
                "Kapa Haka",
                "Ukulele Group",
                "Mandarin",
                "Extension Program",
                "Service to School",
                "AV & Media Technician",
                "Bus Monitor",
                "Cool School Mediator",
                "Librarian",
                "Road Patrol",
                "Student Council",
                "Wet Day Monitor",
                "Nature Savers",
                "Weed Busters",
                "Worm Farm",
                "Artist in Residence",
                "Silo Art Installation",
                "Laingholm Got Talent Crew",
                "Laingholm Got Talent Finalist",
                "Athletics",
                "Cricket",
                "Cross Country",
                "Football",
                "Hockey",
                "Gymnastics",
                "Jump Jam",
                "Krypton Factor",
                "Netball Saturday",
                "Netball InterSchool",
                "Swimming Team",
                "Sports and Team Leader",
            };
        }

        private void addActivities_Click(object sender, EventArgs e)
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


                        while (!reader.EndOfStream)
                        {
                            student = reader.ReadLine();
                            values = student.Split(',');

                            foreach (String str in values)
                            {
                                Console.WriteLine(str + "\n");
                            }

                            cmd.Connection = connection;

                            cmd.Parameters.AddWithValue("@NSN", values[0]);
                            cmd.Parameters.AddWithValue("@Te Reo", values[1]);
                            cmd.Parameters.AddWithValue("@Geek squad", values[2]);
                            cmd.Parameters.AddWithValue("@Horticulture Club", values[3]);
                            cmd.Parameters.AddWithValue("@Choir", values[4]);
                            cmd.Parameters.AddWithValue("@Kapa Haka", values[5]);
                            cmd.Parameters.AddWithValue("@Ukulele Group", values[6]);
                            cmd.Parameters.AddWithValue("@Mandarin", values[7]);
                            

                            cmd.CommandText = "INSERT INTO [Cultural Activities] (NSN, [Te Reo], [Geek squad], [Horticulture Club], Choir, [Kapa Haka], [Ukulele Group], Mandarin) "
                                + "VALUES(@NSN, [@Te Reo], [@Geek squad], [@Horticulture Club], @Choir, [@Kapa Haka], [@Ukulele Group], @Mandarin);";
                            Console.WriteLine("Executing: " + cmd.CommandText.ToString());
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Done");

                            cmd = new OleDbCommand();
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@NSN", values[0]);
                            cmd.Parameters.AddWithValue("@Extension Program", values[8]);
                            cmd.Parameters.AddWithValue("@Service to School", values[9]);
                            cmd.Parameters.AddWithValue("@AV & Media Technician", values[10]);
                            cmd.Parameters.AddWithValue("@Bus Monitor", values[11]);
                            cmd.Parameters.AddWithValue("@Cool School Mediator", values[12]);
                            cmd.Parameters.AddWithValue("@Librarian", values[13]);
                            cmd.Parameters.AddWithValue("@Road Patrol", values[14]);
                            cmd.Parameters.AddWithValue("@Student Council", values[15]);
                            cmd.Parameters.AddWithValue("@Wet Day Monitor", values[16]);
                            cmd.Parameters.AddWithValue("@Nature Savers", values[17]);
                            cmd.Parameters.AddWithValue("@Weed Busters", values[18]);
                            cmd.Parameters.AddWithValue("@Worm Farm", values[19]);
                            cmd.Parameters.AddWithValue("@Artist in Residence", values[20]);
                            cmd.Parameters.AddWithValue("@Silo Art Installation", values[21]);
                            cmd.Parameters.AddWithValue("@Laingholm Got Talent Crew", values[22]);
                            cmd.Parameters.AddWithValue("@Laingholm Got Talent Finalist", values[23]);
                            

                            cmd.CommandText = "INSERT INTO [Extra Activities] (NSN, [Extension Program], [Service to School], [AV & Media Technician], [Bus Monitor], [Cool School Mediator], "
                            +"Librarian, [Road Patrol], [Student Council], [Wet Day Monitor], [Nature Savers], [Weed Busters], [Worm Farm], [Artist in Residence], [Silo Art Installation], [Laingholm Got Talent Crew], [Laingholm Got Talent Finalist]) "
                                + "VALUES(@NSN, [@Extension Program], [@Service to School], [@AV & Media Technician], [@Bus Monitor], [@Cool School Mediator], @Librarian, [@Road Patrol], [@Student Council], "
                                +"[@Wet Day Monitor], [@Nature Savers], [@Weed Busters], [@Worm Farm], [@Artist in Residence], [@Silo Art Installation], [@Laingholm Got Talent Crew], [@Laingholm Got Talent Finalist]);";
                            Console.WriteLine("Executing: " + cmd.CommandText.ToString());
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Done");

                            cmd = new OleDbCommand();
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@NSN", values[0]);
                            cmd.Parameters.AddWithValue("@Athletics", values[24]);
                            cmd.Parameters.AddWithValue("@Cricket", values[25]);
                            cmd.Parameters.AddWithValue("@Cross Country", values[26]);
                            cmd.Parameters.AddWithValue("@Football", values[27]);
                            cmd.Parameters.AddWithValue("@Hockey", values[28]);
                            cmd.Parameters.AddWithValue("@Gymnastics", values[29]);
                            cmd.Parameters.AddWithValue("@Jump Jam", values[30]);
                            cmd.Parameters.AddWithValue("@Krypton Factor", values[31]);
                            cmd.Parameters.AddWithValue("@Netball Saturday", values[32]);
                            cmd.Parameters.AddWithValue("@Netball InterSchool", values[33]);
                            cmd.Parameters.AddWithValue("@Swimming Team", values[34]);
                            cmd.Parameters.AddWithValue("@Sports and Team Leader", values[35]);

                            cmd.CommandText = "INSERT INTO [Sports Activities] (NSN, Athletics, Cricket, [Cross Country], Football, Hockey, Gymnastics, [Jump Jam], [Krypton Factor], [Netball Saturday], [Netball InterSchool], [Swimming Team], [Sports and Team Leader]) "
                                + "VALUES(@NSN, @Athletics, @Cricket, [@Cross Country], @Football, @Hockey, @Gymnastics, [@Jump Jam], [@Krypton Factor], [@Netball Saturday], [@Netball InterSchool], [@Swimming Team], [@Sports and Team Leader]);";
                            Console.WriteLine("Executing: " + cmd.CommandText.ToString());
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Done");

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
        }

        private void updateActivities_Click(object sender, EventArgs e)
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
                        OleDbCommand cmd = new OleDbCommand();
                        values = student.Split(',');


                        while (!reader.EndOfStream)
                        {
                            student = reader.ReadLine();
                            values = student.Split(',');

                            //values[0] = nsn
                            for (int i = 1; i < values.Length; i++)
                            {
                                if (!values[i].Equals(""))
                                {
                                    //Cultural Activities
                                    if (i < 8)
                                    {
                                        cmd.CommandText = ("UPDATE [Cultural Activities] SET [" + columns[i - 1] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';");
                                        //Console.WriteLine(i + columns[i] + "\n" + values[i]);
                                        //Console.WriteLine(cmd.CommandText.ToString());
                                    }
                                    //Extra Activities
                                    else if (i < 24)
                                    {
                                        cmd.CommandText = ("UPDATE [Extra Activities] SET [" + columns[i - 1] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';");
                                    }
                                    //Sports Activities
                                    else
                                    {
                                        cmd.CommandText = ("UPDATE [Sports Activities] SET [" + columns[i - 1] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';");
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
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                connection.Close();
            }
        }
    }
}
