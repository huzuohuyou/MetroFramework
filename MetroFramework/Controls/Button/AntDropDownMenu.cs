
namespace MetroFramework.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using MetroFramework.Components;
    using MetroFramework.Drawing;
    using MetroFramework.Interfaces;

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
            this.Size = new Size(50, Height);
            //this.Items
            this.DropShadowEnabled = true;
            this.Padding = new Padding(20, 20, 20, 20);
            this.Font = new Font("微软雅黑", 14);
            //for (int i = 0; i < this.Items.Count; i++)
            //{
            //    var a = (ToolStripMenuItem)Items[0];
            //    a.DropDown.AutoSize = false;
            //    a.DropDown.Size = new Size(50, a.DropDown.Height);
            //}
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

            //protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            //{
            //    ToolStrip toolStrip = e.ToolStrip;
            //    Graphics g = e.Graphics;
            //    g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿
            //    Rectangle bounds = e.AffectedBounds;
            //    SolidBrush lgbrush = new SolidBrush(Color.FromArgb(0, 250, 250));

               
            //    if (toolStrip is MenuStrip)
            //    {
            //        //由menuStrip的Paint方法定义 这里不做操作
            //    }
            //    else if (toolStrip is ToolStripDropDown)
            //    {

            //        var left = new Rectangle(new Point(0, 0), new Size { Width = 3, Height = toolStrip.Size.Height });
            //        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(left, Color.White, Color.FromArgb(255,130, 130, 130), LinearGradientMode.Horizontal))
            //        {
            //            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //            e.Graphics.FillRectangle(linearGradientBrush, left);
            //        }

            //        //var path= GetRoundedRectPath(new Rectangle(new Point(0, 0), toolStrip.Size), 5);
            //        //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //        //g.FillPath(lgbrush, path);
            //    }
            //    else
            //    {
            //        base.OnRenderToolStripBackground(e);

            //    }

            //}



            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                //ControlPaint.DrawBorder(
                //e.Graphics,
                //e.AffectedBounds,
                //SystemColors.ControlDarkDark, 0, ButtonBorderStyle.None, SystemColors.Control, 1, ButtonBorderStyle.Inset, SystemColors.ControlDarkDark, 0, ButtonBorderStyle.None, SystemColors.ControlDark, 0, ButtonBorderStyle.None);

                ///不调用该方法
                //base.OnRenderToolStripBorder(e);
                ToolStrip toolStrip = e.ToolStrip;
                //using (Pen pen = new Pen(Color.Red))
                //{
                //    GraphicsPath gp = GetRoundedRectPath(new Rectangle(new Point(0, 0), toolStrip.Size), 5);
                //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                //    e.Graphics.DrawPath(pen, gp);
                //}

              //  using (LinearGradientBrush _linearGradientBrush = new LinearGradientBrush(
              //new Rectangle(new Point(0, 0), new Size { Width = 5, Height = toolStrip.Size.Height })
              //, Color.FromArgb(255, 255, 255)
              //, Color.FromArgb(190, 190, 190)
              //, LinearGradientMode.Horizontal))
              //  {
              //      e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
              //      e.Graphics.FillRectangle(_linearGradientBrush, new Rectangle(new Point(-3, 0), new Size { Width = 5, Height = toolStrip.Size.Height }));
              //  }
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
                    SolidBrush lgbrush = new SolidBrush(Color.Blue);//Color.FromArgb(222,222,222)
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
                        GraphicsPath gp = GetRoundedRectPath(new Rectangle(0, 0, item.Width, item.Height), 1);
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
