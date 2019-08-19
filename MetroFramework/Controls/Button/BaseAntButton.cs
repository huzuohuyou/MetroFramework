using System.Drawing;
using System.Drawing.Drawing2D;

namespace MetroFramework.Controls
{

    internal abstract class BaseAntButton : ICanManageStatusColor, ICanDrawButtonStyle
    {
        public MetroThemeStyle Theme { get; set; }
        public MetroColorStyle Style { get; set; }
        public Graphics Graphics { get; set; }
        public Color BackColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public AntButtonSize AntSize { get; set; }
        public bool IsFullCircle { get; set; }
        public BaseAntButton(Graphics _Graphics, int _Width, int _Height, AntButtonSize _AntSize, bool _IsFullCircle, MetroThemeStyle _Theme, MetroColorStyle _Style)
        {
            Width = _Width;
            Height = _Height;
            AntSize = _AntSize;
            IsFullCircle = _IsFullCircle;
            Graphics = _Graphics;
            Theme = _Theme;
            Style = _Style;
        }
        public abstract Color GetBackgroundColorByStatus(bool isHovered, bool isPressed, bool Enabled);
        public abstract Color GetForegroundColorByStatus(bool isHovered, bool isPressed, bool Enabled);
        public abstract void DrawButton();

        public void Paint(bool isHovered, bool isPressed, bool Enabled)
        {
            GetBackgroundColorByStatus(isHovered, isPressed, Enabled);
            DrawButton();
        }

        protected GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
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

        protected GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
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



    }
}
