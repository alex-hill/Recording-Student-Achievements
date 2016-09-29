using System.Windows.Forms;

namespace Recording_Student_Achievements
{
    partial class StudentAchievement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentAchievement));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.geekItPnl = new System.Windows.Forms.Panel();
            this.search = new System.Windows.Forms.Button();
            this.searchByNSN = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.summaryBttn = new System.Windows.Forms.Label();
            this.mathBttn = new System.Windows.Forms.Label();
            this.activitiesBttn = new System.Windows.Forms.Label();
            this.readingBttn = new System.Windows.Forms.Label();
            this.writingBttn = new System.Windows.Forms.Label();
            this.studentInfoBttn = new System.Windows.Forms.Label();
            this.lblGeekIt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuLbl = new System.Windows.Forms.Label();
            this.homeLbl = new System.Windows.Forms.Label();
            this.studentLbl = new System.Windows.Forms.Label();
            this.newStudentLbl = new System.Windows.Forms.Label();
            this.withdrawStudentLbl = new System.Windows.Forms.Label();
            this.assessmentAdd = new System.Windows.Forms.Label();
            this.geekLbl = new System.Windows.Forms.Label();
            this.reportLbl = new System.Windows.Forms.Label();
            this.generateIndiReportLbl = new System.Windows.Forms.Label();
            this.tableDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.header = new System.Windows.Forms.Panel();
            this.topBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quickMenuBar = new System.Windows.Forms.Panel();
            this.addExtra = new System.Windows.Forms.Label();
            this.addActivites = new System.Windows.Forms.Label();
            this.addBatchStudents = new System.Windows.Forms.Label();
            this.calculateLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.geekItPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataSetBindingSource)).BeginInit();
            this.quickMenuBar.SuspendLayout();
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
            // geekItPnl
            // 
            this.geekItPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geekItPnl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.geekItPnl.Controls.Add(this.search);
            this.geekItPnl.Controls.Add(this.searchByNSN);
            this.geekItPnl.Controls.Add(this.dataGridView1);
            this.geekItPnl.Controls.Add(this.summaryBttn);
            this.geekItPnl.Controls.Add(this.mathBttn);
            this.geekItPnl.Controls.Add(this.activitiesBttn);
            this.geekItPnl.Controls.Add(this.readingBttn);
            this.geekItPnl.Controls.Add(this.writingBttn);
            this.geekItPnl.Controls.Add(this.studentInfoBttn);
            this.geekItPnl.Controls.Add(this.lblGeekIt);
            this.geekItPnl.Controls.Add(this.label1);
            this.geekItPnl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.geekItPnl.Location = new System.Drawing.Point(185, 144);
            this.geekItPnl.Name = "geekItPnl";
            this.geekItPnl.Size = new System.Drawing.Size(1135, 562);
            this.geekItPnl.TabIndex = 6;
            this.geekItPnl.Visible = false;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(308, 26);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 6;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchByNSN
            // 
            this.searchByNSN.Location = new System.Drawing.Point(202, 28);
            this.searchByNSN.Name = "searchByNSN";
            this.searchByNSN.Size = new System.Drawing.Size(100, 20);
            this.searchByNSN.TabIndex = 5;
            this.searchByNSN.Text = "NSN (9 number)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1064, 460);
            this.dataGridView1.TabIndex = 4;
            // 
            // summaryBttn
            // 
            this.summaryBttn.AutoSize = true;
            this.summaryBttn.BackColor = System.Drawing.Color.Transparent;
            this.summaryBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.summaryBttn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryBttn.ForeColor = System.Drawing.Color.White;
            this.summaryBttn.Location = new System.Drawing.Point(634, 51);
            this.summaryBttn.Name = "summaryBttn";
            this.summaryBttn.Size = new System.Drawing.Size(60, 17);
            this.summaryBttn.TabIndex = 3;
            this.summaryBttn.Text = "Summary";
            this.summaryBttn.Click += new System.EventHandler(this.summaryBttn_Click);
            // 
            // mathBttn
            // 
            this.mathBttn.AutoSize = true;
            this.mathBttn.BackColor = System.Drawing.Color.Transparent;
            this.mathBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mathBttn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mathBttn.ForeColor = System.Drawing.Color.White;
            this.mathBttn.Location = new System.Drawing.Point(634, 7);
            this.mathBttn.Name = "mathBttn";
            this.mathBttn.Size = new System.Drawing.Size(80, 17);
            this.mathBttn.TabIndex = 3;
            this.mathBttn.Text = "Mathematics";
            this.mathBttn.Click += new System.EventHandler(this.mathBttn_Click);
            // 
            // activitiesBttn
            // 
            this.activitiesBttn.AutoSize = true;
            this.activitiesBttn.BackColor = System.Drawing.Color.Transparent;
            this.activitiesBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activitiesBttn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activitiesBttn.ForeColor = System.Drawing.Color.White;
            this.activitiesBttn.Location = new System.Drawing.Point(634, 29);
            this.activitiesBttn.Name = "activitiesBttn";
            this.activitiesBttn.Size = new System.Drawing.Size(58, 17);
            this.activitiesBttn.TabIndex = 3;
            this.activitiesBttn.Text = "Activities";
            this.activitiesBttn.Click += new System.EventHandler(this.activitiesBttn_Click);
            // 
            // readingBttn
            // 
            this.readingBttn.AutoSize = true;
            this.readingBttn.BackColor = System.Drawing.Color.Transparent;
            this.readingBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.readingBttn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readingBttn.ForeColor = System.Drawing.Color.White;
            this.readingBttn.Location = new System.Drawing.Point(553, 29);
            this.readingBttn.Name = "readingBttn";
            this.readingBttn.Size = new System.Drawing.Size(54, 17);
            this.readingBttn.TabIndex = 3;
            this.readingBttn.Text = "Reading";
            this.readingBttn.Click += new System.EventHandler(this.readingBttn_Click);
            // 
            // writingBttn
            // 
            this.writingBttn.AutoSize = true;
            this.writingBttn.BackColor = System.Drawing.Color.Transparent;
            this.writingBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.writingBttn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writingBttn.ForeColor = System.Drawing.Color.White;
            this.writingBttn.Location = new System.Drawing.Point(553, 51);
            this.writingBttn.Name = "writingBttn";
            this.writingBttn.Size = new System.Drawing.Size(47, 17);
            this.writingBttn.TabIndex = 3;
            this.writingBttn.Text = "Writing";
            this.writingBttn.Click += new System.EventHandler(this.writingBttn_Click);
            // 
            // studentInfoBttn
            // 
            this.studentInfoBttn.AutoSize = true;
            this.studentInfoBttn.BackColor = System.Drawing.Color.Transparent;
            this.studentInfoBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studentInfoBttn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentInfoBttn.ForeColor = System.Drawing.Color.White;
            this.studentInfoBttn.Location = new System.Drawing.Point(553, 7);
            this.studentInfoBttn.Name = "studentInfoBttn";
            this.studentInfoBttn.Size = new System.Drawing.Size(75, 17);
            this.studentInfoBttn.TabIndex = 3;
            this.studentInfoBttn.Text = "Student Info";
            this.studentInfoBttn.Click += new System.EventHandler(this.studentInfoBttn_Click);
            // 
            // lblGeekIt
            // 
            this.lblGeekIt.AutoSize = true;
            this.lblGeekIt.BackColor = System.Drawing.Color.Transparent;
            this.lblGeekIt.Font = new System.Drawing.Font("Franklin Gothic Heavy", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeekIt.ForeColor = System.Drawing.Color.White;
            this.lblGeekIt.Location = new System.Drawing.Point(427, 24);
            this.lblGeekIt.Name = "lblGeekIt";
            this.lblGeekIt.Size = new System.Drawing.Size(137, 29);
            this.lblGeekIt.TabIndex = 3;
            this.lblGeekIt.Text = "Shortcuts : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Heavy", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student Data";
            // 
            // menuLbl
            // 
            this.menuLbl.AutoSize = true;
            this.menuLbl.BackColor = System.Drawing.Color.Transparent;
            this.menuLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuLbl.Font = new System.Drawing.Font("Franklin Gothic Heavy", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLbl.ForeColor = System.Drawing.Color.White;
            this.menuLbl.Location = new System.Drawing.Point(2, 5);
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
            this.homeLbl.Location = new System.Drawing.Point(12, 43);
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
            this.studentLbl.Location = new System.Drawing.Point(27, 68);
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
            this.newStudentLbl.Location = new System.Drawing.Point(47, 88);
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
            this.withdrawStudentLbl.Location = new System.Drawing.Point(47, 128);
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
            this.assessmentAdd.Location = new System.Drawing.Point(46, 148);
            this.assessmentAdd.Name = "assessmentAdd";
            this.assessmentAdd.Size = new System.Drawing.Size(85, 13);
            this.assessmentAdd.TabIndex = 8;
            this.assessmentAdd.Text = "Add Assessment";
            this.assessmentAdd.Click += new System.EventHandler(this.label2_Click);
            // 
            // geekLbl
            // 
            this.geekLbl.AutoSize = true;
            this.geekLbl.BackColor = System.Drawing.Color.Transparent;
            this.geekLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.geekLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geekLbl.ForeColor = System.Drawing.Color.White;
            this.geekLbl.Location = new System.Drawing.Point(46, 208);
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
            this.reportLbl.Location = new System.Drawing.Point(27, 248);
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
            this.generateIndiReportLbl.Location = new System.Drawing.Point(46, 268);
            this.generateIndiReportLbl.Name = "generateIndiReportLbl";
            this.generateIndiReportLbl.Size = new System.Drawing.Size(92, 16);
            this.generateIndiReportLbl.TabIndex = 3;
            this.generateIndiReportLbl.Text = "Individual Report";
            this.generateIndiReportLbl.Click += new System.EventHandler(this.generateIndiReportLbl_Click);
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header.BackColor = System.Drawing.SystemColors.Desktop;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1350, 74);
            this.header.TabIndex = 8;
            // 
            // topBar
            // 
            this.topBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBar.BackColor = System.Drawing.SystemColors.Desktop;
            this.topBar.Location = new System.Drawing.Point(0, 75);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1350, 39);
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
            this.quickMenuBar.Controls.Add(this.addExtra);
            this.quickMenuBar.Controls.Add(this.addActivites);
            this.quickMenuBar.Controls.Add(this.addBatchStudents);
            this.quickMenuBar.Controls.Add(this.menuLbl);
            this.quickMenuBar.Controls.Add(this.newStudentLbl);
            this.quickMenuBar.Controls.Add(this.homeLbl);
            this.quickMenuBar.Controls.Add(this.generateIndiReportLbl);
            this.quickMenuBar.Controls.Add(this.studentLbl);
            this.quickMenuBar.Controls.Add(this.reportLbl);
            this.quickMenuBar.Controls.Add(this.calculateLbl);
            this.quickMenuBar.Controls.Add(this.geekLbl);
            this.quickMenuBar.Controls.Add(this.withdrawStudentLbl);
            this.quickMenuBar.Controls.Add(this.assessmentAdd);
            this.quickMenuBar.Location = new System.Drawing.Point(0, 114);
            this.quickMenuBar.Name = "quickMenuBar";
            this.quickMenuBar.Size = new System.Drawing.Size(153, 618);
            this.quickMenuBar.TabIndex = 10;
            // 
            // addExtra
            // 
            this.addExtra.AutoSize = true;
            this.addExtra.BackColor = System.Drawing.Color.Transparent;
            this.addExtra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addExtra.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addExtra.ForeColor = System.Drawing.Color.White;
            this.addExtra.Location = new System.Drawing.Point(47, 190);
            this.addExtra.Name = "addExtra";
            this.addExtra.Size = new System.Drawing.Size(55, 16);
            this.addExtra.TabIndex = 10;
            this.addExtra.Text = "Add Extra";
            this.addExtra.Click += new System.EventHandler(this.addExtra_Click_1);
            // 
            // addActivites
            // 
            this.addActivites.AutoSize = true;
            this.addActivites.BackColor = System.Drawing.Color.Transparent;
            this.addActivites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addActivites.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addActivites.ForeColor = System.Drawing.Color.White;
            this.addActivites.Location = new System.Drawing.Point(46, 168);
            this.addActivites.Name = "addActivites";
            this.addActivites.Size = new System.Drawing.Size(73, 16);
            this.addActivites.TabIndex = 10;
            this.addActivites.Text = "Add Activites";
            this.addActivites.Click += new System.EventHandler(this.addActivites_Click);
            // 
            // addBatchStudents
            // 
            this.addBatchStudents.AutoSize = true;
            this.addBatchStudents.BackColor = System.Drawing.Color.Transparent;
            this.addBatchStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBatchStudents.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBatchStudents.ForeColor = System.Drawing.Color.White;
            this.addBatchStudents.Location = new System.Drawing.Point(47, 108);
            this.addBatchStudents.Name = "addBatchStudents";
            this.addBatchStudents.Size = new System.Drawing.Size(74, 16);
            this.addBatchStudents.TabIndex = 9;
            this.addBatchStudents.Text = "Add Students";
            this.addBatchStudents.Click += new System.EventHandler(this.addBatchStudents_Click);
            // 
            // calculateLbl
            // 
            this.calculateLbl.AutoSize = true;
            this.calculateLbl.BackColor = System.Drawing.Color.Transparent;
            this.calculateLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculateLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateLbl.ForeColor = System.Drawing.Color.White;
            this.calculateLbl.Location = new System.Drawing.Point(46, 228);
            this.calculateLbl.Name = "calculateLbl";
            this.calculateLbl.Size = new System.Drawing.Size(107, 16);
            this.calculateLbl.TabIndex = 3;
            this.calculateLbl.Text = "Update Calculations";
            this.calculateLbl.Click += new System.EventHandler(this.calculateLbl_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Location = new System.Drawing.Point(-1, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1363, 651);
            this.panel2.TabIndex = 11;
            // 
            // StudentAchievement
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 733);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.geekItPnl);
            this.Controls.Add(this.quickMenuBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "StudentAchievement";
            this.Text = "Student Achievement System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.geekItPnl.ResumeLayout(false);
            this.geekItPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataSetBindingSource)).EndInit();
            this.quickMenuBar.ResumeLayout(false);
            this.quickMenuBar.PerformLayout();
            this.ResumeLayout(false);

        }





        #endregion
        private Label menuLbl, homeLbl, studentLbl, newStudentLbl, withdrawStudentLbl, geekLbl, reportLbl, generateIndiReportLbl;
        private Panel geekItPnl;
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
        private Panel panel2;
        private Label calculateLbl;
        private Label lblGeekIt;
        private Label readingBttn;
        private Label writingBttn;
        private Label studentInfoBttn;
        private Label summaryBttn;
        private Label mathBttn;
        private Label activitiesBttn;
        private Label addBatchStudents;
        private Label addActivites;
        private Label addExtra;
    }
}

