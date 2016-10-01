namespace Recording_Student_Achievements
{
    partial class AddAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAssessment));
            this.addAss = new System.Windows.Forms.Button();
            this.updateAss = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addAss
            // 
            this.addAss.Location = new System.Drawing.Point(248, 87);
            this.addAss.Name = "addAss";
            this.addAss.Size = new System.Drawing.Size(126, 23);
            this.addAss.TabIndex = 0;
            this.addAss.Text = "Add Assessments";
            this.addAss.UseVisualStyleBackColor = true;
            this.addAss.Click += new System.EventHandler(this.addAss_Click);
            // 
            // updateAss
            // 
            this.updateAss.Location = new System.Drawing.Point(248, 158);
            this.updateAss.Name = "updateAss";
            this.updateAss.Size = new System.Drawing.Size(126, 23);
            this.updateAss.TabIndex = 1;
            this.updateAss.Text = "Update Assessments";
            this.updateAss.UseVisualStyleBackColor = true;
            this.updateAss.Click += new System.EventHandler(this.updateAss_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 34);
            this.label3.TabIndex = 13;
            this.label3.Text = "Add Student Assessments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(22, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "Using the \"Update Template.csv\"\r\nfile, update any incorrect information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(19, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "*Will produce an error when tables are already populated";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(22, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Import Assessment information \r\nby each Room\'s CSV file\r\n";
            // 
            // AddAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 228);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.updateAss);
            this.Controls.Add(this.addAss);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddAssessment";
            this.Text = "Add Assessments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addAss;
        private System.Windows.Forms.Button updateAss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}