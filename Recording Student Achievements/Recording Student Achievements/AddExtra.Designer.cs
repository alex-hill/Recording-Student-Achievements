﻿namespace Recording_Student_Achievements
{
    partial class AddExtra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExtra));
            this.addStudentExtra = new System.Windows.Forms.Button();
            this.updateExtra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addStudentExtra
            // 
            this.addStudentExtra.Location = new System.Drawing.Point(13, 227);
            this.addStudentExtra.Name = "addStudentExtra";
            this.addStudentExtra.Size = new System.Drawing.Size(126, 23);
            this.addStudentExtra.TabIndex = 0;
            this.addStudentExtra.Text = "Add Student Data";
            this.addStudentExtra.UseVisualStyleBackColor = true;
            this.addStudentExtra.Click += new System.EventHandler(this.addStudentExtra_Click);
            // 
            // updateExtra
            // 
            this.updateExtra.Location = new System.Drawing.Point(146, 227);
            this.updateExtra.Name = "updateExtra";
            this.updateExtra.Size = new System.Drawing.Size(126, 23);
            this.updateExtra.TabIndex = 1;
            this.updateExtra.Text = "Update Student Data";
            this.updateExtra.UseVisualStyleBackColor = true;
            this.updateExtra.Click += new System.EventHandler(this.updateExtra_Click);
            // 
            // AddExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.updateExtra);
            this.Controls.Add(this.addStudentExtra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddExtra";
            this.Text = "Add Student Data";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addStudentExtra;
        private System.Windows.Forms.Button updateExtra;
    }
}