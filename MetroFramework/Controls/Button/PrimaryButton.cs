using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    public class PrimaryButton : AntButton,ICanPaint
    {
        public PrimaryButton() 
        {
            ICanPaint = this;
        }

        void ICanPaint.Background(PaintEventArgs e)
        {
            if (isHovered && !isPressed && Enabled)
            {
                BackColor = BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f);
            }
            else if (isHovered && isPressed && Enabled)
            {
                BackColor = BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), -0.3f);
            }
            else if (!Enabled)
            {
                BackColor = MetroPaint.BackColor.Button.Disabled(Theme);
            }
            else if (Enabled)
            {
                BackColor = BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), 0f);
            }

            using (Brush brush = new SolidBrush(BackColor))
            {
                var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, rec);
            }
        }

        void ICanPaint.Foreground(PaintEventArgs e)
        {
            Color  foreColor=Color.Empty;

            if (isHovered && !isPressed && Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Hover(Theme);
            }
            else if (isHovered && isPressed && Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Press(Theme);
            }
            else if (!Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Disabled(Theme);
            }
           
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            TextRenderer.DrawText(e.Graphics, Text, MetroFonts.Button(metroButtonSize, metroButtonWeight), ClientRectangle, foreColor, MetroPaint.GetTextFormatFlags(TextAlign));

            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, foreColor, e.Graphics));

        }
    }
}
