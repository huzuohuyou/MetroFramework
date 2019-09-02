using CCWin;
using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using MetroFramework.Properties;
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

        private IContainer components = null;
        private ToolStripMenuItem Item2;
        private ToolStripMenuItem Item3;
        private ToolStripMenuItem Item4;
        private AntDropDownMenu Menu1;

        public AntMenuStrip(IContainer Container)
        {
            if (Container != null)
            {
                Container.Add(this);
            }
            settheme();

           

            this.components = new Container();
            this.Menu1 = new AntDropDownMenu(components);

            this.Item2 = new ToolStripMenuItem();
            this.Item3 = new ToolStripMenuItem();
            this.Item4 = new ToolStripMenuItem();

            Item2.DropDown.AutoSize = false;
            Item2.DropDown.Size = new Size(280, Item2.DropDown.Height);
            Item3.DropDown.AutoSize = false;
            Item3.DropDown.Size = new Size(80, Item3.DropDown.Height);
            Item4.DropDown.AutoSize = false;
            Item4.DropDown.Size = new Size(80, Item4.DropDown.Height);

            this.Menu1.SuspendLayout();
            this.SuspendLayout();

            this.Menu1.Items.AddRange(new ToolStripItem[] {
            this.Item2,this.Item3,this.Item4});

            this.Item2.Name = "toolStripMenuItem2";
            this.Item2.Text = "真的很长很长的文本";
            this.Item3.Name = "toolStripMenuItem2";
            this.Item3.Text = "文本1";
            this.Item4.Name = "toolStripMenuItem2";
            this.Item4.Text = "文本2";
            this.Menu1.Name = "metroContextMenu1";
            this.Menu1.Size = new Size(Item2.DropDown.Width + 45, Item2.DropDown.Height * 4);

            Menu1.StyleManager = this.StyleManager;
            this.Menu1.ResumeLayout(false);
            this.ResumeLayout(false);

            var button = new ToolStripMenuItem();
            button.Text = "button";
            button.DropDown = Menu1;

            this.Items.Add(button);


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
            public MetroCTXRenderer(MetroThemeStyle Theme, MetroColorStyle Style) : base(new contextcolors(Theme, Style)) { }

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

            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                //base.OnRenderImageMargin(e);
                //屏蔽掉左边图片竖条
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                Graphics g = e.Graphics;

                LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(e.Item.Width, 0), Color.PaleGreen, Color.FromArgb(0, Color.PaleGreen));
                g.FillRectangle(lgbrush, new Rectangle(3, e.Item.Height / 2, e.Item.Width, 1));
                //base.OnRenderSeparator(e);
            }

            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = Color.PaleGreen;
                base.OnRenderArrow(e);
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                ToolStrip toolStrip = e.ToolStrip;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿
                Rectangle bounds = e.AffectedBounds;
                LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(0, toolStrip.Height), Color.FromArgb(255, Color.White), Color.FromArgb(150, Color.PaleTurquoise));
                if (toolStrip is MenuStrip)
                {
                    //由menuStrip的Paint方法定义 这里不做操作
                }
                else if (toolStrip is ToolStripDropDown)
                {
                    int diameter = 10;//直径
                    GraphicsPath path = new GraphicsPath();
                    Rectangle rect = new Rectangle(Point.Empty, toolStrip.Size);
                    Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

                    path.AddLine(0, 0, 10, 0);
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
                    toolStrip.Region = new Region(path);
                    g.FillPath(lgbrush, path);
                }
                else
                {
                    base.OnRenderToolStripBackground(e);
                }
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
