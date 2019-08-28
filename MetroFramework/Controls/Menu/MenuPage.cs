using MetroFramework.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    public class MenuPage : MetroTabPage
    {
        #region Fields

        private AntButtonIcon antIcon = AntButtonIcon.None;
        [DefaultValue(AntButtonIcon.None)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public AntButtonIcon AntIcon
        {
            get { return antIcon; }
            set { antIcon = value; }
        }

        private AntButtonSize antSize = AntButtonSize.Default;
        [DefaultValue(AntButtonSize.Default)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public AntButtonSize AntSize
        {
            get { return antSize; }
            set { antSize = value; }
        }

        private AntButtonShape antShape = AntButtonShape.Round;
        [DefaultValue(AntButtonShape.Round)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public AntButtonShape AntShape
        {
            get { return antShape; }
            set { antShape = value; }
        }

        #endregion

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            if (DesignMode)
            {
                horizontalScrollbar.Visible = false;
                verticalScrollbar.Visible = false;
                return;
            }

            UpdateScrollBarPositions();

            if (HorizontalScrollbar)
            {
                horizontalScrollbar.Visible = HorizontalScroll.Visible;
            }
            if (HorizontalScroll.Visible)
            {
                horizontalScrollbar.Minimum = HorizontalScroll.Minimum;
                horizontalScrollbar.Maximum = HorizontalScroll.Maximum;
                horizontalScrollbar.SmallChange = HorizontalScroll.SmallChange;
                horizontalScrollbar.LargeChange = HorizontalScroll.LargeChange;
            }

            if (VerticalScrollbar)
            {
                verticalScrollbar.Visible = VerticalScroll.Visible;
            }
            if (VerticalScroll.Visible)
            {
                verticalScrollbar.Minimum = VerticalScroll.Minimum;
                verticalScrollbar.Maximum = VerticalScroll.Maximum;
                verticalScrollbar.SmallChange = VerticalScroll.SmallChange;
                verticalScrollbar.LargeChange = VerticalScroll.LargeChange;
            }

            int iconX = 0, iconY = 0, iconSize = 20, textLeftPadding = 0;

            if (AntSize.Equals(AntButtonSize.Large))
            {
                iconX = (int)IconLoaction.LargeIconX;
                iconY = (int)IconLoaction.LargeIconY;
                iconSize = (int)IconLoaction.LargeSize;
                textLeftPadding = 20;
            }
            else if (AntSize.Equals(AntButtonSize.Default))
            {
                iconX = (int)IconLoaction.DefaultIconX;
                iconY = (int)IconLoaction.DefaultIconY;
                iconSize = (int)IconLoaction.DefaultSize;
                textLeftPadding = 20;
            }
            else if (AntSize.Equals(AntButtonSize.Small))
            {
                iconX = (int)IconLoaction.SmallIconX;
                iconY = (int)IconLoaction.SmallIconY;
                iconSize = (int)IconLoaction.SmallISize;
                textLeftPadding = 20;
            }
            using (Brush brush = new SolidBrush(Color.Red))
            {
                var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.DrawString(
       Icon.Style[AntIcon],
       UseMemoryFont(iconSize),
       brush, new RectangleF() { X = iconX, Y = iconY, Width = (int)AntSize, Height = (int)AntSize });

            }


            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = BackColor;

                if (!UseCustomBackColor)
                {
                    backColor = MetroPaint.BackColor.Form(Theme);
                }

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaintBackground(e);

                OnCustomPaintBackground(new MetroPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            {
                Invalidate();
            }
        }

    }
}
