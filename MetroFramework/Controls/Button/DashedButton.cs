using MetroFramework.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace MetroFramework.Controls
{

    class DashedButton : BaseAntButton
    {
        bool isHovered, isPressed, Enabled;
        public DashedButton(Graphics _Graphics, int Width, int Height, AntButtonSize AntSize, bool IsFullCircle, MetroThemeStyle Theme, MetroColorStyle Style)
            : base(_Graphics, Width, Height, AntSize, IsFullCircle, Theme, Style)
        {

        }

        public override void DrawButton()
        {
            if (isHovered && !isPressed && Enabled)
            {
                using (Pen pen = new Pen(BackColor))
                {
                    pen.DashStyle = DashStyle.Dash;
                    pen.DashPattern = new float[] { 4f, 2f };
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);

                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.DrawPath(pen, rec);
                }
            }
            else if (isHovered && isPressed && Enabled)
            {
                using (Pen pen = new Pen(BackColor))
                {
                    pen.DashStyle = DashStyle.Dash;
                    pen.DashPattern = new float[] { 4f, 2f };
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.DrawPath(pen, rec);
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
                    pen.DashStyle = DashStyle.Dash;
                    pen.DashPattern = new float[] { 4f, 2f };
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.DrawPath(pen, rec);
                }
            }
        }

        public override Color GetBackgroundColorByStatus(bool _isHovered, bool _isPressed, bool _Enabled)
        {
            isHovered = _isHovered;
            isPressed = _isPressed;
            Enabled = _Enabled;
            if (isHovered && !isPressed && Enabled)
            {
                BackColor = MetroTreeView.ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f);
            }
            else if (isHovered && isPressed && Enabled)
            {
                BackColor = MetroTreeView.ChangeColor(MetroPaint.GetStyleColor(Style), -0.3f);
            }
            else if (!Enabled)
            {
                BackColor = MetroPaint.BackColor.Button.Disabled(Theme);
            }
            else if (Enabled)
            {
                BackColor = MetroTreeView.ChangeColor(MetroPaint.GetStyleColor(Style), 0f);
            }
            return BackColor;
        }

        public override Color GetForegroundColorByStatus(bool isHovered, bool isPressed, bool Enabled)
        {
            throw new NotImplementedException();
        }
    }
}
