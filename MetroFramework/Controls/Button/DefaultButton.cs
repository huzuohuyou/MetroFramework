using MetroFramework.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    class DefaultButton : BaseAntButton
    {
        bool isHovered, isPressed, Enabled;
        public DefaultButton(Graphics _Graphics, int Width, int Height, AntButtonSize AntSize, bool IsFullCircle, MetroThemeStyle Theme, MetroColorStyle Style, string Text)
            : base(_Graphics, Width, Height, AntSize, IsFullCircle, Theme, Style, Text)
        {

        }

        public override void DrawButton()
        {
            if (isHovered && !isPressed && Enabled)
            {
                using (Pen pen = new Pen(BackColor))
                {
                   
                    var rec = DrawRoundRect(0, 0, Width - 1, Height - 1, IsFullCircle ? (int)AntSize : 10);

                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Graphics.DrawPath(pen, rec);
                }
            }
            else if (isHovered && isPressed && Enabled)
            {
                using (Pen pen = new Pen(BackColor))
                {
                   
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

        public override Color GetForegroundColorByStatus(bool _isHovered, bool _isPressed, bool _Enabled)
        {
            return Color.Empty;
            //Color  foreColor;

            //if (isHovered && !isPressed && Enabled)
            //{
            //    foreColor = MetroPaint.ForeColor.Button.Hover(Theme);
            //}
            //else if (isHovered && isPressed && Enabled)
            //{
            //    foreColor = MetroPaint.ForeColor.Button.Press(Theme);
            //}
            //else if (!Enabled)
            //{
            //    foreColor = MetroPaint.ForeColor.Button.Disabled(Theme);
            //}
            //Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //TextRenderer.DrawText(Graphics, Text, MetroFonts.Button(metroButtonSize, metroButtonWeight), ClientRectangle, foreColor, MetroPaint.GetTextFormatFlags(TextAlign));

            
        }
    }
}
