namespace Recording_Student_Achievements
{
    partial class UpdateTeachers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateTeachers));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.teacherGrid = new System.Windows.Forms.DataGridView();
            this.saveBttn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teacherGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 34);
            this.label3.TabIndex = 12;
            this.label3.Text = "Update Teachers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 48);
            this.label1.TabIndex = 13;
            this.label1.Text = "Below is an editable table, that contains all the rooms and teachers.\r\n1. Double " +
    "Click on a cell to begin editing it\r\n2. Click Save to save table";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.teacherGrid);
            this.panel1.Location = new System.Drawing.Point(13, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 352);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Heavy", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Teachers";
            // 
            // teacherGrid
            // 
            this.teacherGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teacherGrid.Location = new System.Drawing.Point(13, 52);
            this.teacherGrid.Name = "teacherGrid";
            this.teacherGrid.Size = new System.Drawing.Size(421, 288);
            this.teacherGrid.DataSource = null;
            this.teacherGrid.TabIndex = 0;
            // 
            // saveBttn
            // 
            this.saveBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBttn.Location = new System.Drawing.Point(188, 456);
            this.saveBttn.Name = "saveBttn";
            this.saveBttn.Size = new System.Drawing.Size(88, 37);
            this.saveBttn.TabIndex = 15;
            this.saveBttn.Text = "Save";
            this.saveBttn.UseVisualStyleBackColor = true;
            this.saveBttn.Click += new System.EventHandler(this.saveBttn_Click);
            // 
            // UpdateTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 502);
            this.Controls.Add(this.saveBttn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateTeachers";
            this.Text = "UpdateTeachers";
            this.Load += new System.EventHandler(this.UpdateTeachers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teacherGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView teacherGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveBttn;
    }
}