
namespace MetroFramework.Controls
{
    using CCWin;
    using MetroFramework.Components;
    using MetroFramework.Drawing;
    using MetroFramework.Interfaces;
    using MetroFramework.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class AntDropDownMenu : ContextMenuStrip, IMetroControl
    {


        #region Interface

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroColorStyle.Blue;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroThemeStyle.Light;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set
            {
                metroStyleManager = value;
                settheme();
            }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category("Metro Behaviour")]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion
       

        public AntDropDownMenu(IContainer Container)
        {
            if (Container != null)
            {
                Container.Add(this);
            }
            this.AutoSize = false;
            this.Size = new Size(Width + 40, Height + 80);
            //this.Items
            this.DropShadowEnabled = false;
            this.Padding = new Padding(20, 40, 20, 40);
            this.Font = new Font("微软雅黑", 14);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(Width + 15, Height + 5);
            Rectangle _BacklightLTRB = new Rectangle(20, 20, 20, 20);//窗体光泽重绘边界
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality; //高质量
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

            //ImageDrawRect.SetBits(ClientRectangle.Width, ClientRectangle.Height, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle);
            ImageDrawRect.DrawRect(e.Graphics, Resources.main_light_bkg_top123,
               new Rectangle
               {
                   X = ClientRectangle.X,
                   Y = ClientRectangle.Y - 2,
                   Width = ClientRectangle.Width,
                   Height = ClientRectangle.Height
               }
                , Rectangle.FromLTRB(_BacklightLTRB.X, _BacklightLTRB.Y, _BacklightLTRB.Width, _BacklightLTRB.Height), 1, 1);
        }

        private void settheme()
        {
            this.BackColor = MetroPaint.BackColor.Form(Theme);
            this.ForeColor = MetroPaint.ForeColor.Button.Normal(Theme);
            this.Renderer = new MetroCTXRenderer(Theme, Style);
        }

        public bool IsHover { get; set; }

        protected override void OnMouseEnter(EventArgs e)
        {
            IsHover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            IsHover = false;
            Invalidate();
            this.Hide();
            base.OnMouseLeave(e);
        }

        private class MetroCTXRenderer : ToolStripProfessionalRenderer
        {
            public MetroCTXRenderer(MetroFramework.MetroThemeStyle Theme, MetroColorStyle Style) : base(new contextcolors(Theme, Style)) { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                ///不调用该方法
                //base.OnRenderToolStripBorder(e);
                ToolStrip toolStrip = e.ToolStrip;

            }

            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = Color.Green;
                base.OnRenderArrow(e);
            }

            public static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
            {
                int diameter = radius;
                Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
                GraphicsPath path = new GraphicsPath();
                path.AddArc(arcRect, 180, 90);
                arcRect.X = rect.Right - diameter;
                path.AddArc(arcRect, 270, 90);
                arcRect.Y = rect.Bottom - diameter;
                path.AddArc(arcRect, 0, 90);
                arcRect.X = rect.Left;
                path.AddArc(arcRect, 90, 90);
                path.CloseFigure();
                return path;
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Graphics g = e.Graphics;
                ToolStripItem item = e.Item;
                ToolStrip toolstrip = e.ToolStrip;
                if (toolstrip is MenuStrip)
                {
                    SolidBrush lgbrush = new SolidBrush(Color.Blue);
                    if (e.Item.Selected)
                    {
                        GraphicsPath gp = GetRoundedRectPath(new Rectangle(new Point(0, 0), item.Size), 5);
                        g.FillPath(lgbrush, gp);
                    }
                    if (item.Pressed)
                    {
                        g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, item.Size));
                    }
                }
                else if (toolstrip is ToolStripDropDown)
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    SolidBrush lgbrush = new SolidBrush(Color.FromArgb(232, 232, 232));//选项背景色
                    if (item.Selected)
                    {
                        GraphicsPath gp = GetRoundedRectPath(new Rectangle(5, -0, item.Width, item.Height), 1);
                        g.FillPath(lgbrush, gp);
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                Graphics g = e.Graphics;
                LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(e.Item.Width, 0), Color.AntiqueWhite, Color.FromArgb(0, Color.AntiqueWhite));
                g.FillRectangle(lgbrush, new Rectangle(3, e.Item.Height / 2, e.Item.Width, 1));
            }

            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                //base.OnRenderImageMargin(e);
            }

        }

        private class contextcolors : ProfessionalColorTable
        {
            MetroThemeStyle _theme = MetroThemeStyle.Light;
            MetroColorStyle _style = MetroColorStyle.Blue;

            public contextcolors(MetroFramework.MetroThemeStyle Theme, MetroColorStyle Style)
            {
                _theme = Theme;
                _style = Style;
            }

            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(230, 247, 255); }
            }

            public override Color MenuBorder
            {
                get { return MetroPaint.BackColor.Form(_theme); }
            }

            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(230, 247, 255); }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return MetroPaint.BackColor.Form(_theme); }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return MetroPaint.BackColor.Form(_theme); }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return MetroPaint.BackColor.Form(_theme); }
            }


        }
    }
}
