using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    //[Designer("MetroFramework.Design.Controls.MetroTabControlDesigner, " + AssemblyRef.MetroFrameworkDesignSN)]
    [ToolboxBitmap(typeof(TreeView))]
    public class MetroTreeView : TreeView, IMetroControl
    {
        #region Interface

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                
                CustomPaintBackground(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
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
                    return MetroDefaults.Style;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
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
                    return MetroDefaults.Theme;
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
            set { metroStyleManager = value; }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(MetroDefaults.PropertyCategory.Behaviour)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion

        #region   Constructor
        public MetroTreeView()
        {
            FullRowSelect = true;
            ShowLines = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.ItemHeight = 30;
            this.ShowLines = true;

            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            //BackColor = ChangeColor(MetroPaint.GetStyleColor(Style), -0.5f);
        }
        #endregion

        #region Fields
        private MetroTileTextSize metroLabelSize = MetroTileTextSize.Tall;
        [DefaultValue(MetroTabControlSize.Medium)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroTileTextSize FontSize
        {
            get { return metroLabelSize; }
            set { metroLabelSize = value; }
        }

        private MetroTileTextWeight metroLabelWeight = MetroTileTextWeight.Bold;
        [DefaultValue(MetroTabControlWeight.Light)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroTileTextWeight FontWeight
        {
            get { return metroLabelWeight; }
            set { metroLabelWeight = value; }
        }

        private ContentAlignment textAlign = ContentAlignment.MiddleLeft;
        [DefaultValue(ContentAlignment.MiddleLeft)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public ContentAlignment TextAlign
        {
            get
            {
                return textAlign;
            }
            set
            {
                textAlign = value;
            }
        }

        private Size ExpandButtonSize = new Size(16, 16);
        private Color _ExpandButtonColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 展开按扭颜色
        /// </summary>
        [Description("展开按扭颜色"), Category("XOProperty")]
        public Color ExpandButtonColor
        {
            get
            {
                return _ExpandButtonColor;
            }
            set
            {
                if (_ExpandButtonColor != value)
                {
                    _ExpandButtonColor = value;
                    this.Invalidate();
                }
            }
        }
        private Color _GroupBgColor = Color.FromArgb(95, 162, 211);
        /// <summary>
        /// 分组栏背景色
        /// </summary>
        [Description("分组栏背景色"), Category("XOProperty")]
        public Color GroupBgColor
        {
            get
            {
                return _GroupBgColor;
            }
            set
            {
                if (_GroupBgColor != value)
                {
                    _GroupBgColor = value;
                    this.Invalidate();

                }
            }
        }
        private Color _GroupTitleColor = Color.FromArgb(0, 0, 0);
        /// <summary>
        /// 分组栏标题色
        /// </summary>
        [Description("分组栏标题色"), Category("XOProperty")]
        public Color GroupTitleColor
        {
            get
            {
                return _GroupTitleColor;
            }
            set
            {
                if (_GroupTitleColor != value)
                {
                    _GroupTitleColor = value;
                    this.Invalidate();
                }
            }
        }
        private Color _OverForeColor = Color.DeepSkyBlue;
        /// <summary>
        /// 鼠标悬停色
        /// </summary>
        [Description("鼠标悬停色"), Category("XOProperty")]
        public Color OverForeColor
        {
            get
            {
                return _OverForeColor;
            }
            set
            {
                if (_OverForeColor != value)
                {
                    _OverForeColor = value;
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// 节点高度
        /// </summary>
        public new int ItemHeight
        {
            get
            {
                return base.ItemHeight;
            }
            set
            {
                if (base.ItemHeight != value && value >= 20)
                {
                    base.ItemHeight = value;
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region Overridden Methods
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = BackColor;


                if (!useCustomBackColor)
                {
                    backColor = MetroPaint.BackColor.Button.Normal(Theme);
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

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {

            //base.OnDrawNode(e);
            DrawNodeItem(e);
        }
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x0201)//单击
            {
                int wparam = m.LParam.ToInt32();
                Point point = new Point(
                    LOWORD(wparam),
                    HIWORD(wparam));
                //point = PointToClient(point);
                TreeNode tn = this.GetNodeAt(point);
                if (tn == null)
                {
                    base.WndProc(ref m);
                    return;
                }
                if (tn.Level >= 0&&tn.Nodes.Count>0)
                {
                    if (tn.IsExpanded)
                    {
                        tn.Collapse();
                    }
                    else
                    {
                        tn.Expand();
                    }
                    m.Result = IntPtr.Zero;
                    return;
                }
                else
                {
                    base.WndProc(ref m);
                    //tn.IsSelected = true;
                    //this.SelectedNode = tn;
                }
                this.SelectedNode = tn;
            }
            else if (m.Msg == 0x0203)//双击
            {
                int wparam = m.LParam.ToInt32();
                Point point = new Point(
                    LOWORD(wparam),
                    HIWORD(wparam));
                //point = PointToClient(point);
                TreeNode tn = this.GetNodeAt(point);
                if (tn == null)
                {
                    base.WndProc(ref m);
                    return;
                }
                if (tn.Level == 0)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
                else
                {
                    base.WndProc(ref m);
                }
                this.SelectedNode = tn;
            }
            else if (m.Msg == 0x0200)//鼠标移动
            {
                try
                {
                    int wparam = m.LParam.ToInt32();
                    Point point = new Point(
                        LOWORD(wparam),
                        HIWORD(wparam));
                    //point = PointToClient(point);
                    TreeNode tn = this.GetNodeAt(point);
                    if (tn == null)
                    {
                        // this.SelectedNode = null;
                        base.WndProc(ref m);
                        return;
                    }
                    //this.SelectedNode = tn;
                }
                catch { }
            }
            else if (m.Msg == 0x02A3)//鼠标移出 WM_MOUSELEAVE = $02A3;
            {
                // this.SelectedNode = null;
                base.WndProc(ref m);
                return;
            }
            else
            {
                base.WndProc(ref m);
            }
            //WM_LBUTTONDOWN = $0201
            //WM_LBUTTONDBLCLK = $0203;
        }
        #endregion

        #region private method
        /// <summary>
        /// 自定义绘制节点
        /// </summary>
        /// <param name="e"></param>
        private void DrawNodeItem(DrawTreeNodeEventArgs e)
        {
            TreeNode tn = e.Node;
            if (tn.Level == 0)
            {
                using (Graphics g = e.Graphics)
                {
                    if (!BackColor.Equals(ChangeColor(MetroPaint.GetStyleColor(Style), -0.5f)))
                    {
                        BackColor = ChangeColor(MetroPaint.GetStyleColor(Style), -0.5f);
                    }
                    //绘制分组的背景
                    RenderBackgroundInternalRate(
                        g,
                        e.Bounds,
                        BackColor,
                        false);
                    //绘制展开按扭
                    //g.FillEllipse(new SolidBrush(ExpandButtonColor), ExpandButtonBounds(e.Bounds));
                    //g.DrawEllipse(new Pen(Color.LightGray), ExpandButtonBounds(e.Bounds));
                    PointF p1;
                    PointF p2;
                    PointF p3;
                    if (tn.IsExpanded)
                    {
                        p1 = new PointF(ExpandButtonBounds(e.Bounds).X + 3, ExpandButtonBounds(e.Bounds).Bottom - 4);
                        p2 = new PointF(ExpandButtonBounds(e.Bounds).X + (ExpandButtonSize.Width) / 2, ExpandButtonBounds(e.Bounds).Top + 5);
                        p3 = new PointF(ExpandButtonBounds(e.Bounds).Right - 3, ExpandButtonBounds(e.Bounds).Bottom - 4);
                    }
                    else
                    {
                        p1 = new PointF(ExpandButtonBounds(e.Bounds).X + 3, ExpandButtonBounds(e.Bounds).Y + 4);
                        p2 = new PointF(ExpandButtonBounds(e.Bounds).X + (ExpandButtonSize.Width) / 2, ExpandButtonBounds(e.Bounds).Bottom - 5);
                        p3 = new PointF(ExpandButtonBounds(e.Bounds).Right - 3, ExpandButtonBounds(e.Bounds).Y + 4);
                    }
                    GraphicsPath gp = new GraphicsPath();
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    gp.AddLine(p1, p2);
                    gp.AddLine(p2, p3);
                    g.DrawPath(new Pen(Color.FromArgb(255, 255, 255, 255), 2f), gp);

                    //绘制分组的文本
                    TextRenderer.DrawText(
                        g, 
                        e.Node.Text, 
                        MetroFonts.Tile(metroLabelSize, metroLabelWeight), GroupTitleBounds(e.Bounds), 
                        Color.White,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
            }
            else if (tn.Level >= 1)
            {
                //e.DrawDefault = true;
                
                using (Graphics g = e.Graphics)
                {
                    PointF p1;
                    PointF p2;
                    PointF p3;
                    Console.WriteLine($@"tn.Nodes:{tn.Nodes.Count} {tn.Text}");
                    if (tn.Nodes.Count>0)
                    {
                        if (tn.IsExpanded)
                        {
                            Console.WriteLine("tn.IsExpanded");
                            p1 = new PointF(ExpandButtonBounds(e.Bounds).X + 3, ExpandButtonBounds(e.Bounds).Bottom - 4);
                            p2 = new PointF(ExpandButtonBounds(e.Bounds).X + (ExpandButtonSize.Width) / 2, ExpandButtonBounds(e.Bounds).Top + 5);
                            p3 = new PointF(ExpandButtonBounds(e.Bounds).Right - 3, ExpandButtonBounds(e.Bounds).Bottom - 4);
                        }
                        else
                        {
                            Console.WriteLine("tn.IsNotExpanded");
                            p1 = new PointF(ExpandButtonBounds(e.Bounds).X + 3, ExpandButtonBounds(e.Bounds).Y + 4);
                            p2 = new PointF(ExpandButtonBounds(e.Bounds).X + (ExpandButtonSize.Width) / 2, ExpandButtonBounds(e.Bounds).Bottom - 5);
                            p3 = new PointF(ExpandButtonBounds(e.Bounds).Right - 3, ExpandButtonBounds(e.Bounds).Y + 4);
                        }
                        GraphicsPath gp = new GraphicsPath();
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        gp.AddLine(p1, p2);
                        gp.AddLine(p2, p3);
                        g.DrawPath(new Pen(Color.FromArgb(255, 255, 255, 255), 2f), gp);
                        TextRenderer.DrawText(
                        g,
                        e.Node.Text,
                        MetroFonts.Tile(metroLabelSize, metroLabelWeight), 
                        new Rectangle { X = e.Bounds.X + 40, Y = e.Bounds.Y, Width = e.Bounds.Width, Height = e.Bounds.Height },
                        Color.White,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                    }
                    else
                    {
                        if (tn.IsSelected)
                        {
                            RenderBackgroundInternalRate(
                            g,
                            e.Bounds,
                            ChangeColor(MetroPaint.GetStyleColor(Style), 0.3f),
                            false
                           );
                            RenderBackgroundInternalRate(
                           g,
                           new Rectangle { X = e.Bounds.X, Y = e.Bounds.Y, Height = e.Bounds.Height, Width = 5 },
                           ChangeColor(MetroPaint.GetStyleColor(Style), -0.8f),
                           false
                          );
                            TextRenderer.DrawText(
                                g,
                                e.Node.Text,
                                MetroFonts.Tile(metroLabelSize, metroLabelWeight),
                                new Rectangle { X = e.Bounds.X + (tn.Level - 0) * 40, Y = e.Bounds.Y, Width = e.Bounds.Width, Height = e.Bounds.Height },
                                Color.White,
                                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                        }
                        else
                        {
                            RenderBackgroundInternalRate(
                            g,
                            e.Bounds,
                            BackColor,
                            false);
                            TextRenderer.DrawText(
                                g,
                                e.Node.Text,
                                MetroFonts.Tile(metroLabelSize, MetroTileTextWeight.Light),
                                new Rectangle { X = e.Bounds.X +(tn.Level - 0) * 40, Y = e.Bounds.Y, Width = e.Bounds.Width, Height = e.Bounds.Height },
                                Color.White,
                                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                        }
                    }
                }
            }
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

        /// <summary>
        /// 展开按扭区域  一级菜单后面的展开按钮
        /// </summary>
        /// <param name="childRect"></param>
        /// <returns></returns>
        private Rectangle ExpandButtonBounds(Rectangle childRect)
        {
            Rectangle lrect = new Rectangle(new Point(childRect.Right - ExpandButtonSize.Width * 3 / 2, (childRect.Height - ExpandButtonSize.Height) / 2 + childRect.Top), ExpandButtonSize);
            return lrect;
        }
        /// <summary>
        /// 取得分组标题绘制空间  一级菜单
        /// </summary>
        /// <param name="childRect"></param>
        /// <returns></returns>
        private Rectangle GroupTitleBounds(Rectangle childRect)
        {
            Rectangle lrect = childRect;
            lrect.Width -= ExpandButtonSize.Width * 3 / 2 + 20;
            lrect.Offset(20, 0);
            return lrect;
        }
        #endregion

        #region draw
        internal void RenderBackgroundInternal(
   Graphics g,
   Rectangle rect,
   Color baseColor,
   Color borderColor,
   Color innerBorderColor,
   float basePosition,
   bool drawBorder,
   LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(
               rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);
                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, rect);
            }
            if (baseColor.A > 80)
            {
                Rectangle rectTop = rect;
                if (mode == LinearGradientMode.Vertical)
                {
                    rectTop.Height = (int)(rectTop.Height * basePosition);
                }
                else
                {
                    rectTop.Width = (int)(rect.Width * basePosition);
                }
                using (SolidBrush brushAlpha =
                    new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillRectangle(brushAlpha, rectTop);
                }
            }
            if (drawBorder)
            {
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
                rect.Inflate(-1, -1);
                using (Pen pen = new Pen(innerBorderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        internal void RenderBackgroundInternalRate(
   Graphics g,
   Rectangle rect,
   Color baseColor,

   bool drawBorder)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }
            using (Brush brush = new SolidBrush(baseColor))
            {
                g.FillRectangle(brush, rect);
            }
           
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;
            if (a + a0 > 255) { a = 255; } else { a = a + a0; }
            if (r + r0 > 255) { r = 255; } else { r = r + r0; }
            if (g + g0 > 255) { g = 255; } else { g = g + g0; }
            if (b + b0 > 255) { b = 255; } else { b = b + b0; }
            return Color.FromArgb(a, r, g, b);
        }
        private Color GetColor2(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;
            if (a + a0 > 255) { a = 255; } else { a = a + a0; }
            if (r0 - r < 0) { r = 0; } else { r = r0 - r; }
            if (g0 - g < 0) { g = 0; } else { g = g0 - g; }
            if (b0 - b < 0) { b = 0; } else { b = b0 - b; }
            return Color.FromArgb(a, r, g, b);
        }
        #endregion
        public static int LOWORD(int value)
        {
            return value & 0xFFFF;
        }
        public static int HIWORD(int value)
        {
            return value >> 16;
        }
    }
}
