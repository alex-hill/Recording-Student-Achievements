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
    public partial class UpdateCalculations : Form
    {
        private Calculations calculations;
        public UpdateCalculations()
        {
            InitializeComponent();
            calculations = new Calculations();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculations.Calculate();
            MessageBox.Show("Completed and Updated all fields.");
        }
    }
}
