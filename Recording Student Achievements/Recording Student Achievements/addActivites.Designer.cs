﻿namespace Recording_Student_Achievements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addActivites));
            this.addActivities = new System.Windows.Forms.Button();
            this.updateActivities = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addActivities
            // 
            this.addActivities.Location = new System.Drawing.Point(13, 227);
            this.addActivities.Name = "addActivities";
            this.addActivities.Size = new System.Drawing.Size(126, 23);
            this.addActivities.TabIndex = 0;
            this.addActivities.Text = "Add Activites";
            this.addActivities.UseVisualStyleBackColor = true;
            this.addActivities.Click += new System.EventHandler(this.addActivities_Click);
            // 
            // updateActivities
            // 
            this.updateActivities.Location = new System.Drawing.Point(146, 227);
            this.updateActivities.Name = "updateActivities";
            this.updateActivities.Size = new System.Drawing.Size(126, 23);
            this.updateActivities.TabIndex = 1;
            this.updateActivities.Text = "Update Activities";
            this.updateActivities.UseVisualStyleBackColor = true;
            this.updateActivities.Click += new System.EventHandler(this.updateActivities_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 160);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // addActivites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateActivities);
            this.Controls.Add(this.addActivities);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addActivites";
            this.Text = "Add Activites";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addActivities;
        private System.Windows.Forms.Button updateActivities;
        private System.Windows.Forms.Label label1;
    }
}