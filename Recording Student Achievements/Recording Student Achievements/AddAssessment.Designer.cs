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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addAss
            // 
            this.addAss.Location = new System.Drawing.Point(13, 226);
            this.addAss.Name = "addAss";
            this.addAss.Size = new System.Drawing.Size(126, 23);
            this.addAss.TabIndex = 0;
            this.addAss.Text = "Add Assessments";
            this.addAss.UseVisualStyleBackColor = true;
            this.addAss.Click += new System.EventHandler(this.addAss_Click);
            // 
            // updateAss
            // 
            this.updateAss.Location = new System.Drawing.Point(146, 226);
            this.updateAss.Name = "updateAss";
            this.updateAss.Size = new System.Drawing.Size(126, 23);
            this.updateAss.TabIndex = 1;
            this.updateAss.Text = "Update Assessments";
            this.updateAss.UseVisualStyleBackColor = true;
            this.updateAss.Click += new System.EventHandler(this.updateAss_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 176);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // AddAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
    }
}