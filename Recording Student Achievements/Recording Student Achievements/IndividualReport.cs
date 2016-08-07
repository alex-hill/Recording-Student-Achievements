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
    public partial class IndividualReport : Form
    {
        public IndividualReport()
        {
            InitializeComponent();
        }

        private void optionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (optionBox.SelectedIndex)
            {
                case 1:
                    userNSN.Visible = true;
                    nsnNumber.Visible = true;

                    userLastName.Visible = false;
                    userFirstName.Visible = false;
                    famName.Visible = false;
                    firName.Visible = false;

                    generateBttn.Visible = true;
                    break;
                case 2:
                    userNSN.Visible = false;
                    nsnNumber.Visible = false;

                    userLastName.Visible = true;
                    userFirstName.Visible = true;
                    famName.Visible = true;
                    firName.Visible = true;

                    generateBttn.Visible = true;
                    break;
            }
        }

        private void generateBttn_Click(object sender, EventArgs e)
        {
            String nsn, firstName, lastName = null;
            Boolean valid = false;
            if (optionBox.SelectedIndex == 1)
            {
                if (!string.IsNullOrWhiteSpace(userNSN.Text))
                {
                    nsn = userNSN.Text;
                    valid = true;
                }
                else
                {
                    MessageBox.Show("Please enter an NSN number", "NSN error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (optionBox.SelectedIndex == 2)
            { 
                if (!string.IsNullOrWhiteSpace(userLastName.Text) && !string.IsNullOrWhiteSpace(userFirstName.Text)) {
                    firstName = userFirstName.Text;
                    lastName = userLastName.Text;
                    valid = true;
                } else
                {
                    MessageBox.Show("Please enter a first and family name", "Name error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if(optionBox.SelectedIndex == 1 && string.IsNullOrWhiteSpace(userNSN.Text))
            {

            }
        }
    }
}
