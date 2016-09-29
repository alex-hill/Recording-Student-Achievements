namespace Recording_Student_Achievements
{
    partial class DeleteAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteAll));
            this.label2 = new System.Windows.Forms.Label();
            this.deleteAllDataBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 48);
            this.label2.TabIndex = 14;
            this.label2.Text = "Warning! \nALL STUDENT DATA WILL BE DELETED. \nPROCEED WITH CARE!";
            // 
            // deleteAllDataBttn
            // 
            this.deleteAllDataBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllDataBttn.Location = new System.Drawing.Point(76, 120);
            this.deleteAllDataBttn.Name = "deleteAllDataBttn";
            this.deleteAllDataBttn.Size = new System.Drawing.Size(154, 60);
            this.deleteAllDataBttn.TabIndex = 13;
            this.deleteAllDataBttn.Text = "Delete All Data";
            this.deleteAllDataBttn.UseVisualStyleBackColor = true;
            this.deleteAllDataBttn.Click += new System.EventHandler(this.deleteAllDataBttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 48);
            this.label1.TabIndex = 12;
            this.label1.Text = "The button below will delete all data in the database \nAll Student related data w" +
    "ill be deleted and cannot \nbe retrieved, once deleted";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 34);
            this.label3.TabIndex = 11;
            this.label3.Text = "Delete All Data";
            // 
            // DeleteAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 249);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteAllDataBttn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteAll";
            this.Text = "DeleteAll";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteAllDataBttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}