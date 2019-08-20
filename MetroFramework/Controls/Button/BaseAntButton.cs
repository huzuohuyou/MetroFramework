using System.Drawing;
using System.Drawing.Drawing2D;

namespace MetroFramework.Controls
{

    internal abstract class BaseAntButton : ICanManageStatusColor
    {
        public MetroThemeStyle Theme { get; set; }
        public MetroColorStyle Style { get; set; }
        public Graphics Graphics { get; set; }
        public Color BackColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public AntButtonSize AntSize { get; set; }
        public bool IsFullCircle { get; set; }
        public string Text { get; set; }

        public BaseAntButton(Graphics _Graphics
            , int _Width, int _Height
            , AntButtonSize _AntSize
            , bool _IsFullCircle
            , MetroThemeStyle _Theme, MetroColorStyle _Style
            ,string _Text)
        {
            Width = _Width;
            Height = _Height;
            AntSize = _AntSize;
            IsFullCircle = _IsFullCircle;
            Graphics = _Graphics;
            Theme = _Theme;
            Style = _Style;
            Text = _Text;
        }
        public abstract Color GetBackgroundColorByStatus(bool _isHovered, bool _isPressed, bool _Enabled);
        public abstract Color GetForegroundColorByStatus(bool _isHovered, bool _isPressed, bool _Enabled);
        public abstract void DrawButton();

        public void Paint(bool isHovered, bool isPressed, bool Enabled)
        {
            GetForegroundColorByStatus(isHovered, isPressed, Enabled);
            GetBackgroundColorByStatus(isHovered, isPressed, Enabled);
            DrawButton();
        }

        public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            //四边圆角
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }

        public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        public static Color ChangeColor(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            if (red < 0) red = 0;

            if (red > 255) red = 255;

            if (green < 0) green = 0;

            if (green > 255) green = 255;

            if (blue < 0) blue = 0;

            if (blue > 255) blue = 255;



            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }


    }
}
