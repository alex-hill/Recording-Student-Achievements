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
    public partial class NewStudent : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public NewStudent()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.xlsx;Persist Security Info=False;Extended Properties=Excel 12.0;"; //For not Alex's laptop
            //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Table.mdb;Persist Security Info=True"; //For Alex's laptop
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            OleDbCommand cmd = new OleDbCommand("INSERT INTO [Student Data$] " + 
                "([Family Name Alias], [Family Name Legal], [First Name Legal], " +
                "[Preferred Name], [Year Level], [Room Number], " +
                "[Gender], [Date of Birth], [Ethnicity], " +
                "[NSN], [Funding Year Level], [Start Date]) " +

                "VALUES (" + familyNameAlias.Text + ", " + familyNameLegal.Text + ", " + firstNameLegal.Text + ", "
                + preferredName.Text + ", " + yearLevelCombo.Text + ", " + roomCombo.Text + ", "
                + genderCombo.Text + ", '" + dateOfBirth.Text + "', '" + ethnicityCombo.Text + "', "
                + nsn.Text + ", " + fundingLevelCombo.Text + ", '" + startDate.Text + "')");

            Console.Write(familyNameAlias.Text + ", " + familyNameLegal.Text + ", " + firstNameLegal.Text + ", "
                + preferredName.Text + ", " + yearLevelCombo.Text + ", " + roomCombo.Text + ", "
                + genderCombo.Text + ", '" + dateOfBirth.Text + "', '" + ethnicityCombo.Text + "', "
                + nsn.Text + ", " + fundingLevelCombo.Text + ", '" + startDate.Text + "')");

            cmd.Connection = conn;

            conn.Open();

            
            if (conn.State == ConnectionState.Open)
            {
                // cmd.Parameters.Add("@Student ID", OleDbType.VarChar).Value = 1;
                cmd.Parameters.Add("@Family Name Alias", OleDbType.VarChar).Value = familyNameAlias.Text;
                cmd.Parameters.Add("@Family Name Legal", OleDbType.VarChar).Value = familyNameLegal.Text;
                cmd.Parameters.Add("@First Name Legal", OleDbType.VarChar).Value = firstNameLegal.Text;
                cmd.Parameters.Add("@Preferred Name", OleDbType.VarChar).Value = preferredName.Text;
                cmd.Parameters.Add("@Year Level", OleDbType.VarChar).Value = yearLevelCombo.Text;
                cmd.Parameters.Add("@Room Number", OleDbType.VarChar).Value = roomCombo.Text;

                var gender = genderCombo.Text;
                cmd.Parameters.Add("@Gender", OleDbType.VarChar).Value = gender;

                cmd.Parameters.Add("@Date Of Birth", OleDbType.VarChar).Value = dateOfBirth.Text;
                cmd.Parameters.Add("@Ethnicity", OleDbType.VarChar).Value = ethnicityCombo.Text;
                cmd.Parameters.Add("@NSN", OleDbType.VarChar).Value = nsn.Text;
                cmd.Parameters.Add("@Funding Year Level", OleDbType.VarChar).Value = fundingLevelCombo.Text;


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added");
                    conn.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
            

            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yearLevelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
