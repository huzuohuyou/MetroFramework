using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    public class DangerButtonV2 : AntButton
    {
        public DangerButtonV2()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                if (isHovered && !isPressed && Enabled)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(240, 65, 52)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
                else if (isHovered && isPressed && Enabled)
                {
                    using (Brush brush = new SolidBrush(BaseAntButton.ChangeColor(Color.FromArgb(240, 65, 52), -0.1f)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
                else if (!Enabled)
                {
                    //BackColor = ColorTranslator.FromHtml("#d9d9d9");
                }
                else if (Enabled)
                {
                    using (Pen pen = new Pen(Color.FromArgb(217, 217, 217)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawPath(pen, rec);
                    }
                    using (Brush brush = new SolidBrush(Color.FromArgb(247, 247, 247)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }

            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            try
            {
                Color foreColor = Color.Empty;

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
            }
            catch (Exception)
            {
                Invalidate();
            }
            
        }
    }
}
