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
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
        }

        private void removeOneStudent_click(object sender, EventArgs e)
        {
            OleDbCommand nsn = new OleDbCommand("SELECT NSN FROM Student WHERE [First Name Legal] LIKE '%" + legalNameTxtBox.Text + "%' AND [Famile Name Legal] LIKE '%" + familyNameTxtBox.Text + "%';");
            nsn.Connection = conn;
            OleDbDataReader reader = nsn.ExecuteReader();
            string nssn = reader.GetString(0);

            OleDbCommand cmd = new OleDbCommand("DELETE FROM Student WHERE [First Name Legal] LIKE '%" + legalNameTxtBox.Text + "%' AND [Family Name Legal] LIKE '%" + familyNameTxtBox.Text + "%'");
            OleDbCommand cmd1 = new OleDbCommand("DELETE FROM Calculated WHERE [NSN] LIKE '%" + nssn + "'%");
            OleDbCommand cmd2 = new OleDbCommand("DELETE FROM [Student Extra] WHERE [NSN] LIKE '%" + nssn + "'%");
            OleDbCommand cmd3 = new OleDbCommand("DELETE FROM Reading WHERE [NSN] LIKE '%" + nssn + "'%");
            OleDbCommand cmd4 = new OleDbCommand("DELETE FROM Writing WHERE [NSN] LIKE '%" + nssn + "'%");
            OleDbCommand cmd5 = new OleDbCommand("DELETE FROM Mathematics WHERE [NSN] LIKE '%" + nssn + "'%");
            OleDbCommand cmd6 = new OleDbCommand("DELETE FROM [Cultural Activities] WHERE [NSN] LIKE '%" + nssn + "'%");
            OleDbCommand cmd7 = new OleDbCommand("DELETE FROM [Extra Activities] WHERE [NSN] LIKE '%" + nssn + "'%");
            OleDbCommand cmd8 = new OleDbCommand("DELETE FROM [Sports Activities] WHERE [NSN] LIKE '%" + nssn + "'%");
            // OleDbCommand cmd = new OleDbCommand("INSERT INTO Student (Gender, NSN) VALUES ('" + textBox7.Text + "', '" + textBox10.Text + "');");
            cmd.Connection = conn;

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    cmd5.ExecuteNonQuery();
                    cmd6.ExecuteNonQuery();
                    cmd7.ExecuteNonQuery();
                    cmd8.ExecuteNonQuery();
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

        private void removeAll_click(object sender, EventArgs e)
        {

            OleDbCommand cmd = new OleDbCommand("DELETE FROM Student;");

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

    }
}