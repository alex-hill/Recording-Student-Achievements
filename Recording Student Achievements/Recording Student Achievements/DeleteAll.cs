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
    public partial class DeleteAll : Form
    {
        private OleDbConnection conn = new OleDbConnection();

        string path = "C:\\Users\\Public\\Desktop\\";
        string connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Table.accdb;Persist Security Info=False;";
        public DeleteAll()
        {
            InitializeComponent();
        }

        private void deleteAllDataBttn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You have selected to delete all data in the database\n Are you sure you wish to proceed?", "WARNING!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionStr))
                {
                    conn.Open();
                    try
                    {
                        string query = "DELETE "
                        + "FROM (((((((([Student] s "

                        + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Calculated] c ON c.[NSN] = s.[NSN])"

                        + "INNER JOIN [Cultural Activities] ca ON ca.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Sports Activities] sa ON sa.[NSN] = s.[NSN]) "

                        + "INNER JOIN [Extra Activities] ea ON ea.[NSN] = s.[NSN]);";

                        using (OleDbCommand deleteAll = new OleDbCommand(query, conn))
                        {
                            int rowAffected = deleteAll.ExecuteNonQuery();

                            if (rowAffected < 1)
                            {
                                MessageBox.Show("Deleting Table failed");
                            }else
                            {
                                MessageBox.Show("Successfully deleted all data!");

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
