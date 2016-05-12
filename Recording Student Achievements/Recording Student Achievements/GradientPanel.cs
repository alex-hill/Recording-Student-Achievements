using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Recording_Student_Achievements
{
    public partial class GradientPanel : UserControl
    {
        public GradientPanel()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.DarkBlue, Color.RoyalBlue, LinearGradientMode.Vertical))
            {
                pevent.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    }
}
