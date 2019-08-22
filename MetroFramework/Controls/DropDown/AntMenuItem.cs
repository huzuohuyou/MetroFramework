using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    public class AntMenuItem: ToolStripMenuItem
    {
        public AntMenuItem() {
            Margin = new Padding(0, 0, 0, 0);
            Padding = new Padding(0, 0, 0, 0);
        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    try
        //    {
        //        //base.OnPaint(e);
        //        using (Brush brush = new SolidBrush(Color.Green))
        //        {
        //            var rec = BaseAntButton.DrawRoundRect(0, 0, Width-1, Height - 1, 5);
        //            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //            e.Graphics.FillPath(brush, rec);
        //        }
        //    }
        //    catch
        //    {
        //        Invalidate();
        //    }

        //}

        
    }
}
