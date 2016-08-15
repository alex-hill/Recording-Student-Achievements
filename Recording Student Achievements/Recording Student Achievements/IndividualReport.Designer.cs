using System;
using System.Globalization;
using System.Windows.Forms;
namespace Recording_Student_Achievements
{
    partial class IndividualReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividualReport));
            this.titleLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userNSN = new System.Windows.Forms.NumericUpDown();
            this.generateBttn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nsnNumber = new System.Windows.Forms.Label();
            this.famName = new System.Windows.Forms.Label();
            this.firName = new System.Windows.Forms.Label();
            this.userLastName = new System.Windows.Forms.TextBox();
            this.userFirstName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.optionBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.userNSN)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(12, 9);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(236, 34);
            this.titleLbl.TabIndex = 7;
            this.titleLbl.Text = "Individual Report";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selected Student";
            // 
            // userNSN
            // 
            this.userNSN.Location = new System.Drawing.Point(167, 151);
            this.userNSN.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.userNSN.Name = "userNSN";
            this.userNSN.Size = new System.Drawing.Size(100, 20);
            this.userNSN.TabIndex = 10;
            this.userNSN.Value = new decimal(new int[] {
            134817833,
            0,
            0,
            0});
            this.userNSN.Visible = false;
            // 
            // generateBttn
            // 
            this.generateBttn.Location = new System.Drawing.Point(127, 211);
            this.generateBttn.Name = "generateBttn";
            this.generateBttn.Size = new System.Drawing.Size(75, 23);
            this.generateBttn.TabIndex = 11;
            this.generateBttn.Text = "Generate";
            this.generateBttn.UseVisualStyleBackColor = true;
            this.generateBttn.Visible = false;
            this.generateBttn.Click += new System.EventHandler(this.generateBttn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "- This will generate a single student\'s report. ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "- Please choose to either enter the student\'s NSN number ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "or their legal first and last name.";
            // 
            // nsnNumber
            // 
            this.nsnNumber.AutoSize = true;
            this.nsnNumber.Location = new System.Drawing.Point(89, 154);
            this.nsnNumber.Name = "nsnNumber";
            this.nsnNumber.Size = new System.Drawing.Size(70, 13);
            this.nsnNumber.TabIndex = 13;
            this.nsnNumber.Text = "NSN Number";
            this.nsnNumber.Visible = false;
            // 
            // famName
            // 
            this.famName.AutoSize = true;
            this.famName.Location = new System.Drawing.Point(63, 152);
            this.famName.Name = "famName";
            this.famName.Size = new System.Drawing.Size(96, 13);
            this.famName.TabIndex = 13;
            this.famName.Text = "Legal Family Name";
            this.famName.Visible = false;
            // 
            // firName
            // 
            this.firName.AutoSize = true;
            this.firName.Location = new System.Drawing.Point(73, 181);
            this.firName.Name = "firName";
            this.firName.Size = new System.Drawing.Size(86, 13);
            this.firName.TabIndex = 13;
            this.firName.Text = "Legal First Name";
            this.firName.Visible = false;
            // 
            // userLastName
            // 
            this.userLastName.Location = new System.Drawing.Point(167, 152);
            this.userLastName.Name = "userLastName";
            this.userLastName.Size = new System.Drawing.Size(100, 20);
            this.userLastName.TabIndex = 10;
            this.userLastName.Visible = false;
            // 
            // userFirstName
            // 
            this.userFirstName.Location = new System.Drawing.Point(167, 178);
            this.userFirstName.Name = "userFirstName";
            this.userFirstName.Size = new System.Drawing.Size(100, 20);
            this.userFirstName.TabIndex = 10;
            this.userFirstName.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(90, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Enter by: ";
            // 
            // optionBox
            // 
            this.optionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionBox.FormattingEnabled = true;
            this.optionBox.Items.AddRange(new object[] {
            "",
            "NSN",
            "Legal Name"});
            this.optionBox.Location = new System.Drawing.Point(167, 121);
            this.optionBox.Name = "optionBox";
            this.optionBox.Size = new System.Drawing.Size(100, 21);
            this.optionBox.TabIndex = 15;
            this.optionBox.SelectedIndexChanged += new System.EventHandler(this.optionBox_SelectedIndexChanged);
            // 
            // IndividualReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 249);
            this.Controls.Add(this.optionBox);
            this.Controls.Add(this.firName);
            this.Controls.Add(this.famName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nsnNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generateBttn);
            this.Controls.Add(this.userFirstName);
            this.Controls.Add(this.userLastName);
            this.Controls.Add(this.userNSN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndividualReport";
            this.Text = "Generate Individual Reports";
            ((System.ComponentModel.ISupportInitialize)(this.userNSN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown userNSN;
        private System.Windows.Forms.Button generateBttn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nsnNumber;
        private System.Windows.Forms.Label famName;
        private System.Windows.Forms.Label firName;
        private System.Windows.Forms.TextBox userLastName;
        private System.Windows.Forms.TextBox userFirstName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox optionBox;
    }
}