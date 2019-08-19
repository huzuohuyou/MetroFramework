using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MetroFramework.Controls
{

    class DangerButton : BaseAntButton
    {
        bool isHovered,  isPressed,  Enabled;
        public DangerButton(Graphics _Graphics, int Width, int Height, AntButtonSize AntSize, bool IsFullCircle, MetroThemeStyle Theme, MetroColorStyle Style, string Text)
            : base(_Graphics, Width, Height, AntSize, IsFullCircle, Theme, Style, Text)
        {

        }

        public override void DrawButton()
        {
            if (isHovered && !isPressed && Enabled)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(240, 65, 52)))
                {
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.FillPath(brush, rec);
                }
            }
            else if (isHovered && isPressed && Enabled)
            {
                using (Brush brush = new SolidBrush(ChangeColor(Color.FromArgb(240, 65, 52),-0.1f)))
                {
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.FillPath(brush, rec);
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
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.DrawPath(pen, rec);
                }
                using (Brush brush = new SolidBrush(Color.FromArgb(247, 247, 247)))
                {
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.FillPath(brush, rec);
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
            return new Color();
            //throw new NotImplementedException();
        }
    }
}
