namespace Recording_Student_Achievements
{
    partial class WithdrawStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WithdrawStudent));
            this.removeOneStudentBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.legalNameTxtBox = new System.Windows.Forms.TextBox();
            this.familyNameTxtBox = new System.Windows.Forms.TextBox();
            this.removeAllBttn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // removeOneStudentBttn
            // 
            this.removeOneStudentBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.removeOneStudentBttn.Location = new System.Drawing.Point(96, 146);
            this.removeOneStudentBttn.Name = "removeOneStudentBttn";
            this.removeOneStudentBttn.Size = new System.Drawing.Size(152, 52);
            this.removeOneStudentBttn.TabIndex = 0;
            this.removeOneStudentBttn.Text = "Remove Selected Student";
            this.removeOneStudentBttn.UseVisualStyleBackColor = true;
            this.removeOneStudentBttn.Click += new System.EventHandler(this.removeOneStudent_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(58, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Legal Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(58, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Family Name";
            // 
            // legalNameTxtBox
            // 
            this.legalNameTxtBox.Location = new System.Drawing.Point(164, 66);
            this.legalNameTxtBox.Name = "legalNameTxtBox";
            this.legalNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.legalNameTxtBox.TabIndex = 3;
            // 
            // familyNameTxtBox
            // 
            this.familyNameTxtBox.Location = new System.Drawing.Point(164, 100);
            this.familyNameTxtBox.Name = "familyNameTxtBox";
            this.familyNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.familyNameTxtBox.TabIndex = 4;
            // 
            // removeAllBttn
            // 
            this.removeAllBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.removeAllBttn.Location = new System.Drawing.Point(102, 255);
            this.removeAllBttn.Name = "removeAllBttn";
            this.removeAllBttn.Size = new System.Drawing.Size(137, 49);
            this.removeAllBttn.TabIndex = 5;
            this.removeAllBttn.Text = "Remove All Students";
            this.removeAllBttn.UseVisualStyleBackColor = true;
            this.removeAllBttn.Click += new System.EventHandler(this.removeAll_click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "Withdraw Student";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 34);
            this.label4.TabIndex = 7;
            this.label4.Text = "Withdraw All Students";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(4, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(336, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "*Note : Any student(s) data once withdrawn cannot be retrieved again";
            // 
            // WithdrawStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 350);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.removeAllBttn);
            this.Controls.Add(this.familyNameTxtBox);
            this.Controls.Add(this.legalNameTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeOneStudentBttn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WithdrawStudent";
            this.Text = "Withdraw Student(s)";
            this.Load += new System.EventHandler(this.WithdrawStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button removeOneStudentBttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox legalNameTxtBox;
        private System.Windows.Forms.TextBox familyNameTxtBox;
        private System.Windows.Forms.Button removeAllBttn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}