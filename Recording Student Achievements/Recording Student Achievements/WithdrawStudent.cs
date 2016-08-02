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
    public partial class WithdrawStudent : Form
    {
        OleDbConnection conn = new OleDbConnection();
        public WithdrawStudent()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.xlsx;Persist Security Info=False;Extended Properties=Excel 12.0;"; //For not Alex's laptop
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Table.mdb;Persist Security Info=True"; //For Alex's laptop
            OleDbCommand cmd = new OleDbCommand("DELETE FROM [Sheet1$] WHERE [First Name Legal] LIKE '%" +  textBox1.Text + "%' AND [Family Name Legal] LIKE '%" + textBox2.Text + "%'");

            cmd.Connection = conn;

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Removed");
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

        private void WithdrawStudent_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Table.mdb;Persist Security Info=True";

            OleDbCommand cmd = new OleDbCommand("DELETE FROM [Sheet1$];");

            // OleDbCommand cmd = new OleDbCommand("INSERT INTO Student (Gender, NSN) VALUES ('" + textBox7.Text + "', '" + textBox10.Text + "');");
            cmd.Connection = conn;

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Removed");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
