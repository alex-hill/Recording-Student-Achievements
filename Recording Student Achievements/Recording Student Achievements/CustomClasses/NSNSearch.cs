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
    class NSNSearch : StudentAchievement
    {
        public void nsnSearch(OleDbConnection connection)
        {

            geekItPnl.Show();
            geekItPnl.Visible = true;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                //
                command.Connection = connection;
                string query =
                    "SELECT [s.NSN] AS `NSN`, [s.Family Name Legal] AS `Last Name`, [s.First Name Legal] AS `First Name`, [s.Date Of Birth] AS `DoB`, [se.School Next Year Level] AS `Next Year Level`, [se.Next Room Number] AS `Next Room Number`, [s.Gender] AS `Gender`, [s.Ethnicity] AS `Ethnicity` "
                    + ", [r.Final Assessment Level] AS `Reading Final Assessment`, [r.NS Progress] AS `Reading Progress Level`"
                    + ", [w.Overall Assessment] AS `Writing Overall Assessment`, [w.NS Progress]  AS `Writing Progress Level`"
                    + ", [m.Overall Assessment] AS `Maths Overall Assessment`, [m.NS Progress]  AS `Maths Progress Level`"
                    + ", [se.Curiosity 1] AS `Curiosity 1`, [se.Curiosity 2] AS `Curiosity 2`, [se.Curiosity 3] AS `Curiosity 3`"
                    + ", [se.Creativity 1] AS `Creativity 1`, [se.Creativity 2]   AS `Creativity 2`, [se.Creativity 3]  AS `Creativity 3`"
                    + ", [se.Community 1] AS `Community 1`, [se.Community 2] AS `Community 2`, [se.Community 3] AS `Community 3`"
                    + ", [se.Sustainability 1] AS `Sustainability 1`, [se.Sustainability 2] AS `Sustainability 2`, [se.Sustainability 3]  AS `Sustainability 3` "
                    + "FROM (((([Student] s "
                    + "INNER JOIN [Student Extra] se ON se.[NSN] = s.[NSN]) "
                    + "INNER JOIN [Reading] r ON r.[NSN] = s.[NSN])"
                    + "INNER JOIN [Writing] w ON w.[NSN] = s.[NSN])"
                    + "INNER JOIN [Mathematics] m ON m.[NSN] = s.[NSN])"
                    + "WHERE se.NSN = '" + Int32.Parse(searchByNSN.Text) + "';";
                command.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Last Name"].Frozen = true;
                dataGridView1.Columns["First Name"].Frozen = true;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
