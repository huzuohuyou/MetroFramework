using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MetroFramework.Controls
{

    class DangerButton : BaseAntButton
    {
        public DangerButton(Graphics _Graphics, int Width, int Height, AntButtonSize AntSize, bool IsFullCircle, MetroThemeStyle Theme, MetroColorStyle Style)
            : base(_Graphics, Width, Height, AntSize, IsFullCircle, Theme, Style)
        {
            BackColor = ColorTranslator.FromHtml("#f0413");
        }

        public override void DrawButton()
        {
            using (Pen MyPen = new Pen(Color.FromArgb(240, 65, 52)))
            {
                var myPath = CreateRoundedRectanglePath(new Rectangle()
                {
                    X = 0,
                    Y = 0,
                    Width = Width - 1,
                    Height = Height - 1
                }, 5);
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.DrawPath(MyPen, myPath);
            }
        }

        public override Color GetBackgroundColorByStatus(bool isHovered, bool isPressed, bool Enabled)
        {
            if (isHovered && !isPressed && Enabled)
            {
                BackColor = ColorTranslator.FromHtml("#f7f7f7");
            }
            else if (isHovered && isPressed && Enabled)
            {
                BackColor = ColorTranslator.FromHtml("#f0413");
            }
            else if (!Enabled)
            {
                BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
            else if (Enabled)
            {
                BackColor = ColorTranslator.FromHtml("#f0413");
            }
            return BackColor;
        }

        public override Color GetForegroundColorByStatus(bool isHovered, bool isPressed, bool Enabled)
        {
            throw new NotImplementedException();
        }
    }
}
