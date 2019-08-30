using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    public class AntMenuStrip : MenuStrip, IMetroControl
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

        public AntMenuStrip(IContainer Container)
        {
            if (Container != null)
            {
                Container.Add(this);
            }
            settheme();
            //for (int i = 0; i < this.Items.Count; i++)
            //{
            //    Items[i].dr
            //}
            
            //DropShadowEnabled = false;
        }

        public AntMenuStrip()
        {
            settheme();
            render = new MetroCTXRenderer(Theme, Style);
            this.Renderer = render;
        }

        private void settheme()
        {
            this.BackColor = MetroPaint.BackColor.Form(Theme);
            this.ForeColor = MetroPaint.ForeColor.Button.Normal(Theme);
            this.Renderer = new MetroCTXRenderer(Theme, Style);
        }

        private Color _startColor = Color.White;
        private Color _endCoolor = Color.Blue;

        private MetroCTXRenderer render;

        //protected override void OnMouseHover(EventArgs e)
        //{
        //    this.Focus();
        //}


        private class MetroCTXRenderer : ToolStripProfessionalRenderer
        {
            public MetroCTXRenderer(MetroFramework.MetroThemeStyle Theme, MetroColorStyle Style) : base(new contextcolors(Theme, Style)) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Graphics g = e.Graphics;
                ToolStripItem item = e.Item;
                ToolStrip toolstrip = e.ToolStrip;


                //渲染顶级项
                if (toolstrip is MenuStrip)
                {
                    LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(0, item.Height), Color.FromArgb(100, Color.White), Color.FromArgb(0, Color.White));
                    SolidBrush brush = new SolidBrush(Color.FromArgb(255, Color.White));
                    if (e.Item.Selected)
                    {
                        GraphicsPath gp = GetRoundedRectPath(new Rectangle(new Point(0, 0), item.Size), 5);
                        g.FillPath(lgbrush, gp);
                    }
                    if (item.Pressed)
                    {
                        ////创建上面左右2圆角的矩形路径
                        //GraphicsPath path = new GraphicsPath();
                        //int diameter = 8;
                        //Rectangle rect = new Rectangle(Point.Empty, item.Size);
                        //Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
                        //// 左上角
                        //path.AddArc(arcRect, 180, 90);
                        //// 右上角
                        //arcRect.X = rect.Right - diameter;
                        //path.AddArc(arcRect, 270, 90);
                        //path.AddLine(new Point(rect.Width, rect.Height), new Point(0, rect.Height));
                        //path.CloseFigure();
                        ////填充路径
                        //g.FillPath(brush, path);
                        g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, item.Size));
                    }
                }
                //渲染下拉项
                else if (toolstrip is ToolStripDropDown)
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(item.Width, 0), Color.FromArgb(200, Color.Red), Color.FromArgb(0, Color.White));
                    if (item.Selected)
                    {
                        GraphicsPath gp = GetRoundedRectPath(new Rectangle(0, 0, item.Width, item.Height), 10);
                        g.FillPath(lgbrush, gp);
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
            public static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
            {
                int diameter = radius;
                Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
                GraphicsPath path = new GraphicsPath();

                // 左上角
                path.AddArc(arcRect, 180, 90);

                // 右上角
                arcRect.X = rect.Right - diameter;
                path.AddArc(arcRect, 270, 90);

                // 右下角
                arcRect.Y = rect.Bottom - diameter;
                path.AddArc(arcRect, 0, 90);

                // 左下角
                arcRect.X = rect.Left;
                path.AddArc(arcRect, 90, 90);
                path.CloseFigure();
                return path;
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
                get { return MetroPaint.GetStyleColor(_style); }
            }

            public override Color MenuBorder
            {
                get { return MetroPaint.BackColor.Form(_theme); }
            }

            public override Color MenuItemBorder
            {
                get { return MetroPaint.GetStyleColor(_style); }
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
