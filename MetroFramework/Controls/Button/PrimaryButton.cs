using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MetroFramework.Controls
{

    class PrimaryButton : BaseAntButton
    {
        public PrimaryButton(Graphics _Graphics, int Width, int Height, AntButtonSize AntSize, bool IsFullCircle, MetroThemeStyle Theme, MetroColorStyle Style)
            : base(_Graphics, Width, Height, AntSize, IsFullCircle, Theme, Style)
        {

        }

        public override void DrawButton()
        {
            using (Brush brush = new SolidBrush(BackColor))
            {
                var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.FillPath(brush, rec);
            }
        }

        public override Color GetBackgroundColorByStatus(bool isHovered, bool isPressed, bool Enabled)
        {
            if (isHovered && !isPressed && Enabled)
            {
                BackColor = ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f);
            }
            else if (isHovered && isPressed && Enabled)
            {
                BackColor = ChangeColor(MetroPaint.GetStyleColor(Style), -0.3f);
            }
            else if (!Enabled)
            {
                BackColor = MetroPaint.BackColor.Button.Disabled(Theme);
            }
            else if (Enabled)
            {
                BackColor = ChangeColor(MetroPaint.GetStyleColor(Style), 0f);
            }
            return BackColor;
        }

        public override Color GetForegroundColorByStatus(bool isHovered, bool isPressed, bool Enabled)
        {
            throw new NotImplementedException();
        }
    }
}
