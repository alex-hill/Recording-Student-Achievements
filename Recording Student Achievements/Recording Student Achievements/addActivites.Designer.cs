namespace Recording_Student_Achievements
{
    partial class addActivites
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
            this.addActivities = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addActivities
            // 
            this.addActivities.Location = new System.Drawing.Point(13, 227);
            this.addActivities.Name = "addActivities";
            this.addActivities.Size = new System.Drawing.Size(102, 23);
            this.addActivities.TabIndex = 0;
            this.addActivities.Text = "Add Activites";
            this.addActivities.UseVisualStyleBackColor = true;
            this.addActivities.Click += new System.EventHandler(this.addActivities_Click);
            // 
            // addActivites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.addActivities);
            this.Name = "addActivites";
            this.Text = "Add Activites";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addActivities;
    }
}