using Recording_Student_Achievements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording_Student_Achievements
{
    


    public partial class Form1 : Form
    {
        public String dbFileName;
        private OpenFileDialog fileChooser;
        public Form1()
        {
            InitializeComponent();
            ns = new NewStudent();
            ws = new WithdrawStudent();
            fileChooser = new OpenFileDialog();
            

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            fileChooser.Title = "Choose the database file";
            if (fileChooser.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                this.dbFileName = fileChooser.FileName;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private WithdrawStudent ws;
        private void withdrawStudentLbl_Click(object sender, EventArgs e)
        {
            if (!ws.Visible && !ws.IsDisposed)
            {
                // Add the message
                ws.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ns.IsDisposed)
            {
                ws = new WithdrawStudent();
                ws.Show();
            }
        }

        private NewStudent ns;
        private void newStudentLbl_Click(object sender, EventArgs e)
        {
            
            if (!ns.Visible && !ns.IsDisposed)
            {
                // Add the message
                ns.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ns.IsDisposed)
            {
                ns = new NewStudent();
                ns.Show();
            }
        }
    }
}
