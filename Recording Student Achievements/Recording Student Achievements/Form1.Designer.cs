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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TopBar = new System.Windows.Forms.PictureBox();
            this.QuickMenu = new System.Windows.Forms.PictureBox();
            this.MenuLbl = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.PictureBox();
            this.addStudent = new System.Windows.Forms.Button();
            this.removeStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TopBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuickMenu)).BeginInit();
            this.QuickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            this.SuspendLayout();
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
            this.QuickMenu.Controls.Add(this.MenuLbl);
            this.QuickMenu.Image = global::Recording_Student_Achievements.Properties.Resources.Quick_Menu;
            this.QuickMenu.Location = new System.Drawing.Point(-1, 110);
            this.QuickMenu.Name = "QuickMenu";
            this.QuickMenu.Size = new System.Drawing.Size(159, 907);
            this.QuickMenu.TabIndex = 2;
            this.QuickMenu.TabStop = false;
            // 
            // MenuLbl
            // 
            this.MenuLbl.AutoSize = true;
            this.MenuLbl.BackColor = System.Drawing.Color.Transparent;
            this.MenuLbl.ForeColor = System.Drawing.Color.White;
            this.MenuLbl.Location = new System.Drawing.Point(37, 25);
            this.MenuLbl.Name = "MenuLbl";
            this.MenuLbl.Size = new System.Drawing.Size(65, 13);
            this.MenuLbl.TabIndex = 3;
            this.MenuLbl.Text = "Quick Menu";
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
            // addStudent
            // 
            this.addStudent.Location = new System.Drawing.Point(12, 162);
            this.addStudent.Name = "addStudent";
            this.addStudent.Size = new System.Drawing.Size(121, 23);
            this.addStudent.TabIndex = 3;
            this.addStudent.Text = "Add a Student";
            this.addStudent.UseVisualStyleBackColor = true;
            // 
            // removeStudent
            // 
            this.removeStudent.Location = new System.Drawing.Point(12, 213);
            this.removeStudent.Name = "removeStudent";
            this.removeStudent.Size = new System.Drawing.Size(121, 23);
            this.removeStudent.TabIndex = 4;
            this.removeStudent.Text = "Remove a Student";
            this.removeStudent.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 1001);
            this.Controls.Add(this.removeStudent);
            this.Controls.Add(this.addStudent);
            this.Controls.Add(this.TopBar);
            this.Controls.Add(this.QuickMenu);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Name = "Form1";
            this.Text = "Student Achievement System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TopBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuickMenu)).EndInit();
            this.QuickMenu.ResumeLayout(false);
            this.QuickMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
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
        private Label MenuLbl;
        private Button addStudent;
        private Button removeStudent;
    }
}

