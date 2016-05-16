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
        public NewStudent()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Table.mdb;Persist Security Info=True";

              OleDbCommand cmd = new OleDbCommand("INSERT INTO Student ([Family Name Alias], [Family Name Legal], [First Name Legal], [Preferred Name], [Year Level], [Room Number], [Gender], [Date of Birth], [Ethnicity], [NSN], [Funding Year Level], [Start Date])"
                  +" VALUES(" + textBox1.Text + ", " + textBox2.Text + ", [" + textBox3.Text + "], " + textBox4.Text + ", " + textBox5.Text + ", " + textBox6.Text
                   + ", " + textBox7.Text + ", " + textBox8.Text + ", " + textBox9.Text + ", " + textBox10.Text + ", " + textBox11.Text + ", " + textBox12.Text + ");");

           // OleDbCommand cmd = new OleDbCommand("INSERT INTO Student (Gender, NSN) VALUES ('" + textBox7.Text + "', '" + textBox10.Text + "');");
            cmd.Connection = conn;

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
               // cmd.Parameters.Add("@Student ID", OleDbType.VarChar).Value = 1;
               cmd.Parameters.Add("@Family Name Alias", OleDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@Family Name Legal", OleDbType.VarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@First Name Legal", OleDbType.VarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@Preferred Name", OleDbType.VarChar).Value = textBox4.Text;
                cmd.Parameters.Add("@Year Level", OleDbType.VarChar).Value = textBox5.Text;
                cmd.Parameters.Add("@Room Number", OleDbType.VarChar).Value = textBox6.Text;
                cmd.Parameters.Add("@Gender", OleDbType.VarChar).Value = textBox7.Text;
                cmd.Parameters.Add("@Date Of Birth", OleDbType.VarChar).Value = textBox8.Text;
                cmd.Parameters.Add("@Ethnicity", OleDbType.VarChar).Value = textBox9.Text;
                cmd.Parameters.Add("@NSN", OleDbType.VarChar).Value = textBox10.Text;
                cmd.Parameters.Add("@Funding Year Level", OleDbType.VarChar).Value = textBox11.Text;
                cmd.Parameters.Add("@Start Date", OleDbType.VarChar).Value = textBox12.Text;

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
    }
}
