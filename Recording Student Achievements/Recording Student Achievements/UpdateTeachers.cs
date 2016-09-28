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
using WindowsFormsApplication1;

namespace Recording_Student_Achievements
{
    public partial class UpdateTeachers : Form
    {
        string connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;";
        OleDbDataAdapter da;
        private BindingSource bindingSource = null;
        private OleDbCommandBuilder oleCommandBuilder = null;
        DataTable dataTable = new DataTable();
        public UpdateTeachers()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(geekItPnl_Paint);
            panel1.Refresh();
        }

        private void geekItPnl_Paint(object sender, PaintEventArgs e)
        {
            Color c2 = Color.FromArgb(0, 71, 131);
            Color c1 = Color.FromArgb(1, 56, 115);
            System.Drawing.Drawing2D.LinearGradientBrush myBrush
                = new System.Drawing.Drawing2D.LinearGradientBrush(panel1.ClientRectangle, c1, c2, 90);

            System.Drawing.Drawing2D.ColorBlend cblend = new System.Drawing.Drawing2D.ColorBlend(4);

            cblend.Colors = new Color[4] { Color.White, c1, c2, Color.Black };
            cblend.Positions = new float[4] { 0f, 0.0001f, 0.69f, 1f };
            myBrush.InterpolationColors = cblend;

            CustomRectangle.FillRoundedRectangle(e.Graphics, myBrush, new System.Drawing.Rectangle(0, 0, panel1.Width, panel1.Height), 25);
            myBrush.Dispose();
            e.Graphics.Dispose();
        }

        private void saveBttn_Click(object sender, EventArgs e)
        {
            teacherGrid.EndEdit(); //very important step
            da.Update(dataTable);
            MessageBox.Show("Updated");
            DataBind();
           
        }

        private void DataBind()
        {
            teacherGrid.DataSource = null;
            teacherGrid.Refresh();
            dataTable.Clear();

            OleDbConnection conn = new OleDbConnection(connectionStr);
            conn.Open();
            string query = "SELECT * FROM [ROOM];";
            OleDbCommand command = conn.CreateCommand();
            command.CommandText = query;

            try
            {
                da = new OleDbDataAdapter(query, conn);
                oleCommandBuilder = new OleDbCommandBuilder(da);
                da.Fill(dataTable);
                bindingSource = new BindingSource { DataSource = dataTable };
                teacherGrid.DataSource = bindingSource;
            }
            catch (Exception ex )
            {
                MessageBox.Show("Error: " + ex);
            }
                
            
        }

        private void UpdateTeachers_Load(object sender, EventArgs e)
        {
            DataBind();
        }
    }
        
    }

