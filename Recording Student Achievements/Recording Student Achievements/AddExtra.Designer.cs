namespace Recording_Student_Achievements
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addStudentExtra
            // 
            this.addStudentExtra.Location = new System.Drawing.Point(223, 76);
            this.addStudentExtra.Name = "addStudentExtra";
            this.addStudentExtra.Size = new System.Drawing.Size(126, 23);
            this.addStudentExtra.TabIndex = 0;
            this.addStudentExtra.Text = "Add Student Data";
            this.addStudentExtra.UseVisualStyleBackColor = true;
            this.addStudentExtra.Click += new System.EventHandler(this.addStudentExtra_Click);
            // 
            // updateExtra
            // 
            this.updateExtra.Location = new System.Drawing.Point(223, 150);
            this.updateExtra.Name = "updateExtra";
            this.updateExtra.Size = new System.Drawing.Size(126, 23);
            this.updateExtra.TabIndex = 1;
            this.updateExtra.Text = "Update Student Data";
            this.updateExtra.UseVisualStyleBackColor = true;
            this.updateExtra.Click += new System.EventHandler(this.updateExtra_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Add More Student Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Update the previously entered \r\ndata";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "*Will produce an error when tables are already populated";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 32);
            this.label5.TabIndex = 15;
            this.label5.Text = "Initially record \'more` student data,\r\ne.g. NS Achieve Level, Curisoity 1";
            // 
            // AddExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 198);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updateExtra);
            this.Controls.Add(this.addStudentExtra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddExtra";
            this.Text = "Add Student Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStudentExtra;
        private System.Windows.Forms.Button updateExtra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}