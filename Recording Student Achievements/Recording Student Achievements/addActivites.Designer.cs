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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addActivites));
            this.addActivities = new System.Windows.Forms.Button();
            this.updateActivities = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addActivities
            // 
            this.addActivities.Location = new System.Drawing.Point(228, 71);
            this.addActivities.Name = "addActivities";
            this.addActivities.Size = new System.Drawing.Size(126, 23);
            this.addActivities.TabIndex = 0;
            this.addActivities.Text = "Add Activites";
            this.addActivities.UseVisualStyleBackColor = true;
            this.addActivities.Click += new System.EventHandler(this.addActivities_Click);
            // 
            // updateActivities
            // 
            this.updateActivities.Location = new System.Drawing.Point(226, 151);
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
            this.label1.Location = new System.Drawing.Point(15, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Initially record data in the Cultural, \r\nExtra and Sports activity tables.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 34);
            this.label3.TabIndex = 12;
            this.label3.Text = "Extra Curricular Activities";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(15, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Update the previously entered \r\ndata";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "*Will produce an error when tables are already populated";
            // 
            // addActivites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 216);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}