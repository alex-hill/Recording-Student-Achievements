using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Recording_Student_Achievements
{
    public partial class BatchStudents : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        
        public BatchStudents()
        {
            string path = "C:\\Users\\Public\\Desktop\\";
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "\\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            InitializeComponent();
        }

        private void importStudents_Click(object sender, EventArgs e)
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

                        int next = reader.Peek();

                        if (next == -1)
                        {
                            throw new FormatException("The file you tried to import is empty. Please check and try again.");
                        }
                        while(reader.EndOfStream != true)
                        {
                            String line = reader.ReadLine();
                            String[] values = line.Split(',');

                            String familyNameAlias = values[1];
                            char[] ca = familyNameAlias.ToCharArray();
                            String familyNameAliasLower = familyNameAlias.Substring(1);
                            familyNameAliasLower.ToLower();
                            familyNameAlias = (ca[0] + familyNameAliasLower);
                            String familyNameLegal = values[2];
                            ca = familyNameLegal.ToCharArray();
                            String familyNameLegalLower = familyNameLegal.Substring(1);
                            familyNameLegalLower = familyNameLegalLower.ToLower();
                            familyNameLegal = (ca[0] + familyNameLegalLower);
                            String firstNames = values[3];
                            String preferredName = values[4];
                            String year = values[5];
                            year = year.Substring(1);
                            String roomNo = values[6];
                            roomNo = roomNo.Substring(2);
                            String gender = values[7];
                            String dob = values[8];
                            String ethnicity = values[9];
                            String nsn = values[10];
                            String moeYear = values[11];
                            String startDate = values[12];

                            Console.WriteLine(familyNameAlias);
                            Console.WriteLine(familyNameLegal);
                            Console.WriteLine(firstNames);
                            Console.WriteLine(preferredName);
                            Console.WriteLine(year);
                            Console.WriteLine(roomNo);
                            Console.WriteLine(gender);
                            Console.WriteLine(dob);
                            Console.WriteLine(ethnicity);
                            Console.WriteLine(nsn);
                            Console.WriteLine(moeYear);
                            Console.WriteLine(startDate);


                            //OleDbCommand cmd = new OleDbCommand("INSERT INTO [Student] ([Family Name Alias], [Family Name Legal], [First Name Legal], [Preferred Name], [Year Level], [Room Number]"
                            //    + ", [Gender], [Date Of Birth], [Ethnicity], [NSN], [Funding Year Level], [Start Date]) VALUES(["
                            //    + familyNameAlias + "], ["
                            //    + familyNameLegal + "], ["
                            //    + firstNames + "], ["
                            //    + preferredName + "], ["
                            //    + year + "], ["
                            //    + roomNo + "], ["
                            //    + gender + "], ["
                            //    + dob + "], ["
                            //    + ethnicity + "], ["
                            //    + nsn + "], ["
                            //    + moeYear + "], ["
                            //    + startDate + "]);");

                            OleDbCommand cmd = new OleDbCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = connection;

                            cmd.Parameters.Add("@Family Name Alias", OleDbType.VarChar).Value = familyNameAlias;
                            cmd.Parameters.Add("@Family Name Legal", OleDbType.VarChar).Value = familyNameLegal;
                            cmd.Parameters.Add("@First Name Legal", OleDbType.VarChar).Value = firstNames;
                            cmd.Parameters.Add("@Preferred Name", OleDbType.VarChar).Value = preferredName;
                            cmd.Parameters.Add("@Year Level", OleDbType.VarChar).Value = year;
                            cmd.Parameters.Add("@Room Number", OleDbType.VarChar).Value = roomNo;
                            cmd.Parameters.Add("@Gender", OleDbType.VarChar).Value = gender;
                            cmd.Parameters.Add("@Date Of Birth", OleDbType.VarChar).Value = dob;
                            cmd.Parameters.Add("@Ethnicity", OleDbType.VarChar).Value = ethnicity;
                            cmd.Parameters.Add("@NSN", OleDbType.VarChar).Value = nsn;
                            cmd.Parameters.Add("@Funding Year Level", OleDbType.VarChar).Value = moeYear;
                            cmd.Parameters.Add("@Start Date", OleDbType.VarChar).Value = startDate;

                            cmd.CommandText = "INSERT INTO Student ([Family Name Alias], [Family Name Legal], [First Name Legal], [Preferred Name], [Year Level], [Room Number], [Gender], [Date of Birth], [Ethnicity], [NSN], [Funding Year Level], [Start Date])"
                      + " VALUES([@Family Name Alias],  [@Family Name Legal] , [@First Name Legal], [@Preferred Name], [@Year Level], [@Room Number], [@Gender], [@Date Of Birth], [@Ethnicity], [@NSN], [@Funding Year Level], [@Start Date]);";
                           

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

        private void update_Click(object sender, EventArgs e)
        {
            string[] columns = new string[] {"NSN",
                "Family Name Alias",
                "Family Name Legal",
                "First Name Legal",
                "Preferred name",
                "Year Level",
                "Room Number",
                "Gender",
                "Date of Birth",
                "Ethnicity",
                "Funding Year Level",
                "Start Date"};
            try
            {
                connection.Open();
                // Create an instance of the open file dialog box.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set filter options and filter index.
                openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
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

                            //values[0] = nsn
                            for (int i = 1; i < values.Length; i++)
                            {
                                if (!values[i].Equals(""))
                                {
                                    cmd = new OleDbCommand();
                                    cmd.CommandText = "UPDATE [Student] SET [" + columns[i] + "] = '" + values[i] + "' WHERE NSN = '" + values[0] + "';";

                                    Console.WriteLine("Executing: " + cmd.CommandText.ToString());
                                    cmd.Connection = connection;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            student = reader.ReadLine();
                            values = student.Split(',');





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

            this.Dispose();
        }
        
    }
}
