using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    public class LinkButton: AntButton
    {
        public LinkButton()
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
                //if (isHovered && !isPressed && Enabled)
                //{
                //    using (Pen pen = new Pen(BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f)))
                //    {
                //        pen.DashStyle = DashStyle.Dash;
                //        pen.DashPattern = new float[] { 4f, 2f };
                //        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);

                //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //        e.Graphics.DrawPath(pen, rec);
                //    }
                //}
                //else if (isHovered && isPressed && Enabled)
                //{
                //    using (Pen pen = new Pen(BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), -0.2f)))
                //    {
                //        pen.DashStyle = DashStyle.Dash;
                //        pen.DashPattern = new float[] { 4f, 2f };
                //        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);
                //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //        e.Graphics.DrawPath(pen, rec);
                //    }
                //}
                //else if (!Enabled)
                //{
                //    //BackColor = ColorTranslator.FromHtml("#d9d9d9");
                //}
                //else if (Enabled)
                //{
                //    using (Pen pen = new Pen(Color.FromArgb(217, 217, 217)))
                //    {
                //        pen.DashStyle = DashStyle.Dash;
                //        pen.DashPattern = new float[] { 4f, 2f };
                //        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);
                //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //        e.Graphics.DrawPath(pen, rec);
                //    }
                //}
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            Color foreColor = Color.Empty;

            if (isHovered && !isPressed && Enabled)
            {
                foreColor = BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f);
            }
            else if (isHovered && isPressed && Enabled)
            {
                foreColor = BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), -0.2f);
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
