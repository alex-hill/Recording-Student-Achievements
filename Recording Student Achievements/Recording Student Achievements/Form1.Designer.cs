using System.Windows.Forms;

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
            this.QuickMenu = new System.Windows.Forms.PictureBox();
            this.menuLbl = new System.Windows.Forms.Label();
            this.homeLbl = new System.Windows.Forms.Label();
            this.studentLbl = new System.Windows.Forms.Label();
            this.newStudentLbl = new System.Windows.Forms.Label();
            this.withdrawStudentLbl = new System.Windows.Forms.Label();
            this.assessmentAdd = new System.Windows.Forms.Label();
            this.geekLbl = new System.Windows.Forms.Label();
            this.reportLbl = new System.Windows.Forms.Label();
            this.generateIndiReportLbl = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.searchByNSN = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tableDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.header = new System.Windows.Forms.Panel();
            this.topBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quickMenuBar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.studentDataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuickMenu)).BeginInit();
            this.QuickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataSetBindingSource)).BeginInit();
            this.topBar.SuspendLayout();
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
            this.studentDataPnl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.studentDataPnl.BackgroundImage = global::Recording_Student_Achievements.Properties.Resources.Large_Box;
            this.studentDataPnl.Controls.Add(this.QuickMenu);
            this.studentDataPnl.Controls.Add(this.search);
            this.studentDataPnl.Controls.Add(this.searchByNSN);
            this.studentDataPnl.Controls.Add(this.dataGridView1);
            this.studentDataPnl.Controls.Add(this.label1);
            this.studentDataPnl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.studentDataPnl.Location = new System.Drawing.Point(165, 120);
            this.studentDataPnl.Name = "studentDataPnl";
            this.studentDataPnl.Size = new System.Drawing.Size(1180, 600);
            this.studentDataPnl.TabIndex = 6;
            this.studentDataPnl.Visible = false;
            // 
            // QuickMenu
            // 
            this.QuickMenu.Controls.Add(this.menuLbl);
            this.QuickMenu.Controls.Add(this.homeLbl);
            this.QuickMenu.Controls.Add(this.studentLbl);
            this.QuickMenu.Controls.Add(this.newStudentLbl);
            this.QuickMenu.Controls.Add(this.withdrawStudentLbl);
            this.QuickMenu.Controls.Add(this.assessmentAdd);
            this.QuickMenu.Controls.Add(this.geekLbl);
            this.QuickMenu.Controls.Add(this.reportLbl);
            this.QuickMenu.Controls.Add(this.generateIndiReportLbl);
            this.QuickMenu.Image = global::Recording_Student_Achievements.Properties.Resources.Quick_Menu;
            this.QuickMenu.Location = new System.Drawing.Point(11, -5);
            this.QuickMenu.Name = "QuickMenu";
            this.QuickMenu.Size = new System.Drawing.Size(176, 620);
            this.QuickMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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
            // assessmentAdd
            // 
            this.assessmentAdd.AutoSize = true;
            this.assessmentAdd.BackColor = System.Drawing.Color.Transparent;
            this.assessmentAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assessmentAdd.ForeColor = System.Drawing.Color.White;
            this.assessmentAdd.Location = new System.Drawing.Point(49, 125);
            this.assessmentAdd.Name = "assessmentAdd";
            this.assessmentAdd.Size = new System.Drawing.Size(83, 13);
            this.assessmentAdd.TabIndex = 8;
            this.assessmentAdd.Text = "Add Assignment";
            this.assessmentAdd.Click += new System.EventHandler(this.label2_Click);
            // 
            // geekLbl
            // 
            this.geekLbl.AutoSize = true;
            this.geekLbl.BackColor = System.Drawing.Color.Transparent;
            this.geekLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.geekLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geekLbl.ForeColor = System.Drawing.Color.White;
            this.geekLbl.Location = new System.Drawing.Point(49, 145);
            this.geekLbl.Name = "geekLbl";
            this.geekLbl.Size = new System.Drawing.Size(44, 16);
            this.geekLbl.TabIndex = 3;
            this.geekLbl.Text = "Geek It";
            this.geekLbl.Click += new System.EventHandler(this.geekLbl_Click);
            // 
            // reportLbl
            // 
            this.reportLbl.AutoSize = true;
            this.reportLbl.BackColor = System.Drawing.Color.Transparent;
            this.reportLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportLbl.ForeColor = System.Drawing.Color.White;
            this.reportLbl.Location = new System.Drawing.Point(30, 165);
            this.reportLbl.Name = "reportLbl";
            this.reportLbl.Size = new System.Drawing.Size(60, 20);
            this.reportLbl.TabIndex = 3;
            this.reportLbl.Text = "Reports";
            // 
            // generateIndiReportLbl
            // 
            this.generateIndiReportLbl.AutoSize = true;
            this.generateIndiReportLbl.BackColor = System.Drawing.Color.Transparent;
            this.generateIndiReportLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateIndiReportLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateIndiReportLbl.ForeColor = System.Drawing.Color.White;
            this.generateIndiReportLbl.Location = new System.Drawing.Point(49, 185);
            this.generateIndiReportLbl.Name = "generateIndiReportLbl";
            this.generateIndiReportLbl.Size = new System.Drawing.Size(92, 16);
            this.generateIndiReportLbl.TabIndex = 3;
            this.generateIndiReportLbl.Text = "Individual Report";
            this.generateIndiReportLbl.Click += new System.EventHandler(this.generateIndiReportLbl_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(311, 33);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 6;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchByNSN
            // 
            this.searchByNSN.Location = new System.Drawing.Point(205, 35);
            this.searchByNSN.Name = "searchByNSN";
            this.searchByNSN.Size = new System.Drawing.Size(100, 20);
            this.searchByNSN.TabIndex = 5;
            this.searchByNSN.Text = "NSN (9 number)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1100, 480);
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
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.Desktop;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1350, 76);
            this.header.TabIndex = 8;
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.topBar.Controls.Add(this.panel1);
            this.topBar.Location = new System.Drawing.Point(0, 75);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(2000, 39);
            this.topBar.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 621);
            this.panel1.TabIndex = 10;
            // 
            // quickMenuBar
            // 
            this.quickMenuBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.quickMenuBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.quickMenuBar.Location = new System.Drawing.Point(0, 114);
            this.quickMenuBar.Name = "quickMenuBar";
            this.quickMenuBar.Size = new System.Drawing.Size(153, 622);
            this.quickMenuBar.TabIndex = 10;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.header);
            this.Controls.Add(this.studentDataPnl);
            this.Controls.Add(this.quickMenuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "Form1";
            this.Text = "Student Achievement System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.studentDataPnl.ResumeLayout(false);
            this.studentDataPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuickMenu)).EndInit();
            this.QuickMenu.ResumeLayout(false);
            this.QuickMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataSetBindingSource)).EndInit();
            this.topBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }





        #endregion
        private PictureBox QuickMenu;
        private Label menuLbl, homeLbl, studentLbl, newStudentLbl, withdrawStudentLbl, geekLbl, reportLbl, generateIndiReportLbl;
        private Panel studentDataPnl;
        private Label label1;
        private BindingSource tableDataSetBindingSource;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Label assessmentAdd;
        private Button search;
        private TextBox searchByNSN;
        private Panel header;
        private Panel topBar;
        private Panel panel1;
        private Panel quickMenuBar;
    }
}

