
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
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Threading;
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

        [System.ComponentModel.Browsable(false)]
        public System.Drawing.Color TransparencyKey { get; set; }

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new FormBorderStyle FormBorderStyle
        //{
        //    get { return base.FormBorderStyle; }
        //    set { base.bor = FormBorderStyle.None; }
        //}
        #endregion

        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            //base.AutoScaleMode = AutoScaleMode.None;
        }
        #endregion

        public void SetBits()
        {
            //绘制绘图层背景
            Bitmap bitmap = new Bitmap(Resources.main_light_bkg_top123,Width,Height);
            Color backColor = bitmap.GetPixel(1, 1);
            bitmap.MakeTransparent(backColor);

            Rectangle _BacklightLTRB = new Rectangle(20, 20, 20, 20);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            ImageDrawRect.DrawRect(g, Properties.Resources.main_light_bkg_top123, ClientRectangle, Rectangle.FromLTRB(_BacklightLTRB.X, _BacklightLTRB.Y, _BacklightLTRB.Width, _BacklightLTRB.Height), 1, 1);

            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(Width, Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = Byte.Parse("255");
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }

        public AntDropDownMenu(IContainer Container)
        {
            //BackgroundImage = Properties.Resources.main_light_bkg_top123;
            BackColor = Color.White;
           
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
            TransparencyKey = Color.White;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            //Office格式颜色
            ProfessionalColorTable ColorTable = new ProfessionalColorTable();
            ColorTable.UseSystemColors = true;
            //是否为设计模式
            if (!DesignMode)
            {
                //this.Renderer = new ToolStripRenderer(ColorTable);
            }
            else
            {
                this.Renderer = new ToolStripProfessionalRenderer(ColorTable);
            }
            this.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Font = new Font(this.Font.FontFamily, 10);
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                int Rgn = Win32.CreateRoundRectRgn(1, 1, ClientSize.Width, Height, 7, 7);
                Win32.SetWindowRgn(this.Handle, Rgn, true);
            }

            //int result = Win32.SetClassLong(this.Handle, Win32.GCL_STYLE, 0);
        }

        /// CreateRoundedRectanglePath
        /// </summary>
        /// <param name="rect">Rectangle</param>
        /// <param name="cornerRadius"int></param>
        /// <returns></returns>
        internal static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
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
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //SetBits();
            //using (Pen pen = new Pen(BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f), 1.5f))
            //{
            //    var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1,  10);
            //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //    e.Graphics.DrawPath(pen, rec);
            //}

            if (!DesignMode)
            {
                Graphics g = e.Graphics;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                SolidBrush bruch = new SolidBrush(Color.Red);

                g.FillRectangle(bruch, 0, 0, 25, this.Height);

                bruch = new SolidBrush(Color.White);
                g.FillRectangle(bruch, 27, 0, this.Width - 27, this.Height);

                Pen pen = new Pen(Color.Blue, 1f);
                e.Graphics.DrawPath(pen, CreateRoundedRectanglePath(new Rectangle(1, 1, ClientSize.Width - 3, Height - 3), 10));
            }

            base.OnPaint(e);
            //base.OnPaint(e);

            //Bitmap bitmap = new Bitmap(Width + 15, Height + 5);
            //Rectangle _BacklightLTRB = new Rectangle(20, 20, 20, 20);//窗体光泽重绘边界
            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality; //高质量
            //e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            //ImageDrawRect.DrawRect(
            //    e.Graphics,
            //    Resources.main_light_bkg_top123,
            //    new Rectangle
            //    {
            //        X = ClientRectangle.X,
            //        Y = ClientRectangle.Y - 3,
            //        Width = ClientRectangle.Width + 3,
            //        Height = ClientRectangle.Height + 6
            //    },
            //    Rectangle.FromLTRB(_BacklightLTRB.X, _BacklightLTRB.Y, _BacklightLTRB.Width, _BacklightLTRB.Height),
            //    1,
            //    1);

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
