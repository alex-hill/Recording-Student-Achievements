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
            this.addAss = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addAss
            // 
            this.addAss.Location = new System.Drawing.Point(13, 226);
            this.addAss.Name = "addAss";
            this.addAss.Size = new System.Drawing.Size(75, 23);
            this.addAss.TabIndex = 0;
            this.addAss.Text = "button1";
            this.addAss.UseVisualStyleBackColor = true;
            this.addAss.Click += new System.EventHandler(this.addAss_Click);
            // 
            // AddAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addAss);
            this.Name = "AddAssessment";
            this.Text = "AddAssessment";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addAss;
    }
}