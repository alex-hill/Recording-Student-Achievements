﻿using System.Windows.Forms;

namespace Recording_Student_Achievements
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studentDataPnl = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.homePic = new System.Windows.Forms.PictureBox();
            this.TopBar = new System.Windows.Forms.PictureBox();
            this.QuickMenu = new System.Windows.Forms.PictureBox();
            this.menuLbl = new System.Windows.Forms.Label();
            this.homeLbl = new System.Windows.Forms.Label();
            this.studentLbl = new System.Windows.Forms.Label();
            this.newStudentLbl = new System.Windows.Forms.Label();
            this.withdrawStudentLbl = new System.Windows.Forms.Label();
            this.geekLbl = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.PictureBox();
            this.tableDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.studentDataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuickMenu)).BeginInit();
            this.QuickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Recording_Student_Achievements.Properties.Resources.Logo1;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 76);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // studentDataPnl
            // 
            this.studentDataPnl.BackgroundImage = global::Recording_Student_Achievements.Properties.Resources.Large_Box;
            this.studentDataPnl.Controls.Add(this.dataGridView1);
            this.studentDataPnl.Controls.Add(this.label1);
            this.studentDataPnl.Location = new System.Drawing.Point(165, 120);
            this.studentDataPnl.Name = "studentDataPnl";
            this.studentDataPnl.Size = new System.Drawing.Size(1742, 875);
            this.studentDataPnl.TabIndex = 6;
            this.studentDataPnl.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1648, 747);
            this.dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Heavy", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student Data";
            // 
            // homePic
            // 
            this.homePic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homePic.Image = global::Recording_Student_Achievements.Properties.Resources.Home;
            this.homePic.Location = new System.Drawing.Point(9, 81);
            this.homePic.Name = "homePic";
            this.homePic.Size = new System.Drawing.Size(31, 24);
            this.homePic.TabIndex = 5;
            this.homePic.TabStop = false;
            this.homePic.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // TopBar
            // 
            this.TopBar.Image = global::Recording_Student_Achievements.Properties.Resources.Top_Bar;
            this.TopBar.Location = new System.Drawing.Point(-1, 74);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(2000, 39);
            this.TopBar.TabIndex = 1;
            this.TopBar.TabStop = false;
            // 
            // QuickMenu
            // 
            this.QuickMenu.Controls.Add(this.menuLbl);
            this.QuickMenu.Controls.Add(this.homeLbl);
            this.QuickMenu.Controls.Add(this.studentLbl);
            this.QuickMenu.Controls.Add(this.newStudentLbl);
            this.QuickMenu.Controls.Add(this.withdrawStudentLbl);
            this.QuickMenu.Controls.Add(this.geekLbl);
            this.QuickMenu.Image = global::Recording_Student_Achievements.Properties.Resources.Quick_Menu;
            this.QuickMenu.Location = new System.Drawing.Point(-1, 110);
            this.QuickMenu.Name = "QuickMenu";
            this.QuickMenu.Size = new System.Drawing.Size(159, 931);
            this.QuickMenu.TabIndex = 2;
            this.QuickMenu.TabStop = false;
            // 
            // menuLbl
            // 
            this.menuLbl.AutoSize = true;
            this.menuLbl.BackColor = System.Drawing.Color.Transparent;
            this.menuLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuLbl.Font = new System.Drawing.Font("Franklin Gothic Heavy", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLbl.ForeColor = System.Drawing.Color.White;
            this.menuLbl.Location = new System.Drawing.Point(5, 2);
            this.menuLbl.Name = "menuLbl";
            this.menuLbl.Size = new System.Drawing.Size(139, 29);
            this.menuLbl.TabIndex = 3;
            this.menuLbl.Text = "Quick Menu";
            // 
            // homeLbl
            // 
            this.homeLbl.AutoSize = true;
            this.homeLbl.BackColor = System.Drawing.Color.Transparent;
            this.homeLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeLbl.ForeColor = System.Drawing.Color.White;
            this.homeLbl.Location = new System.Drawing.Point(15, 40);
            this.homeLbl.Name = "homeLbl";
            this.homeLbl.Size = new System.Drawing.Size(63, 25);
            this.homeLbl.TabIndex = 3;
            this.homeLbl.Text = "Home";
            this.homeLbl.Click += new System.EventHandler(this.homeLbl_Click);
            // 
            // studentLbl
            // 
            this.studentLbl.AutoSize = true;
            this.studentLbl.BackColor = System.Drawing.Color.Transparent;
            this.studentLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLbl.ForeColor = System.Drawing.Color.White;
            this.studentLbl.Location = new System.Drawing.Point(30, 65);
            this.studentLbl.Name = "studentLbl";
            this.studentLbl.Size = new System.Drawing.Size(67, 20);
            this.studentLbl.TabIndex = 3;
            this.studentLbl.Text = "Students";
            // 
            // newStudentLbl
            // 
            this.newStudentLbl.AutoSize = true;
            this.newStudentLbl.BackColor = System.Drawing.Color.Transparent;
            this.newStudentLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newStudentLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newStudentLbl.ForeColor = System.Drawing.Color.White;
            this.newStudentLbl.Location = new System.Drawing.Point(50, 85);
            this.newStudentLbl.Name = "newStudentLbl";
            this.newStudentLbl.Size = new System.Drawing.Size(72, 16);
            this.newStudentLbl.TabIndex = 3;
            this.newStudentLbl.Text = "New Student";
            this.newStudentLbl.Click += new System.EventHandler(this.newStudentLbl_Click);
            // 
            // withdrawStudentLbl
            // 
            this.withdrawStudentLbl.AutoSize = true;
            this.withdrawStudentLbl.BackColor = System.Drawing.Color.Transparent;
            this.withdrawStudentLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withdrawStudentLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withdrawStudentLbl.ForeColor = System.Drawing.Color.White;
            this.withdrawStudentLbl.Location = new System.Drawing.Point(50, 105);
            this.withdrawStudentLbl.Name = "withdrawStudentLbl";
            this.withdrawStudentLbl.Size = new System.Drawing.Size(98, 16);
            this.withdrawStudentLbl.TabIndex = 3;
            this.withdrawStudentLbl.Text = "Withdraw Student";
            this.withdrawStudentLbl.Click += new System.EventHandler(this.withdrawStudentLbl_Click);
            // 
            // geekLbl
            // 
            this.geekLbl.AutoSize = true;
            this.geekLbl.BackColor = System.Drawing.Color.Transparent;
            this.geekLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.geekLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geekLbl.ForeColor = System.Drawing.Color.White;
            this.geekLbl.Location = new System.Drawing.Point(50, 125);
            this.geekLbl.Name = "geekLbl";
            this.geekLbl.Size = new System.Drawing.Size(44, 16);
            this.geekLbl.TabIndex = 3;
            this.geekLbl.Text = "Geek It";
            this.geekLbl.Click += new System.EventHandler(this.geekLbl_Click);
            // 
            // header
            // 
            this.header.Image = global::Recording_Student_Achievements.Properties.Resources.Header;
            this.header.Location = new System.Drawing.Point(-1, -1);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(2000, 75);
            this.header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.header.TabIndex = 0;
            this.header.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 1053);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.studentDataPnl);
            this.Controls.Add(this.homePic);
            this.Controls.Add(this.TopBar);
            this.Controls.Add(this.QuickMenu);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Student Achievement System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.studentDataPnl.ResumeLayout(false);
            this.studentDataPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuickMenu)).EndInit();
            this.QuickMenu.ResumeLayout(false);
            this.QuickMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;
            const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:             //preventing the form from being moved by the mouse.
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            if (m.Msg == WM_NCLBUTTONDBLCLK)       //preventing the form being resized by the mouse double click on the title bar.
            {
                m.Result = System.IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }



        #endregion

        private PictureBox header;
        private PictureBox TopBar;
        private PictureBox QuickMenu;
        private Label menuLbl, homeLbl, studentLbl, newStudentLbl, withdrawStudentLbl, geekLbl;
        private PictureBox homePic;
        private Panel studentDataPnl;
        private Label label1;
        private BindingSource tableDataSetBindingSource;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
    }
}

