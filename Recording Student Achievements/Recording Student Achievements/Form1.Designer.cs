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
            System.Windows.Forms.TextBox MenuLbl;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TopBar = new System.Windows.Forms.PictureBox();
            this.QuickMenu = new System.Windows.Forms.PictureBox();
            this.header = new System.Windows.Forms.PictureBox();
            MenuLbl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TopBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuickMenu)).BeginInit();
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
            this.QuickMenu.Image = global::Recording_Student_Achievements.Properties.Resources.Quick_Menu;
            this.QuickMenu.Location = new System.Drawing.Point(-1, 110);
            this.QuickMenu.Name = "QuickMenu";
            this.QuickMenu.Size = new System.Drawing.Size(159, 907);
            this.QuickMenu.TabIndex = 2;
            this.QuickMenu.TabStop = false;
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
            // MenuLbl
            // 
            MenuLbl.BackColor = System.Drawing.Color.Red;
            MenuLbl.ForeColor = System.Drawing.Color.White;
            MenuLbl.Location = new System.Drawing.Point(12, 132);
            MenuLbl.Name = "MenuLbl";
            MenuLbl.Size = new System.Drawing.Size(100, 20);
            MenuLbl.TabIndex = 3;
            MenuLbl.Text = "Quick Menu";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1996, 1001);
            this.Controls.Add(MenuLbl);
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
    }
}

