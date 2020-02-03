using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    public class CustomProfessionalRenderer2 : ToolStripProfessionalRenderer
    {
        Font textFont = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Color menuItemSelectedColor = Color.Gray;
        private Color menuItemBorderColor = Color.Black;
        /// <summary>
        /// Initialize a new instance of the Visual Studio MenuBarRenderer class.
        /// </summary>
        public CustomProfessionalRenderer2()
            : base(new MenuBarColor())
        {
            this.menuItemSelectedColor = Color.LightSteelBlue;
            this.menuItemBorderColor = Color.LightSteelBlue;

        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextFont = textFont;

            base.OnRenderItemText(e);
        }
        #region Backgrounds
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.IsOnDropDown)
            {
                if (e.Item.Selected == true && e.Item.Enabled)
                {
                    DrawMenuDropDownItemHighlight(e);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿
            Rectangle bounds = e.AffectedBounds;
            LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(0, toolStrip.Height), Color.FromArgb(200, Color.FromArgb(48, 61, 69)), Color.FromArgb(200, Color.FromArgb(48, 61, 69)));
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

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            // base.OnRenderImageMargin(e);
        }
        #endregion
        #region DrawMenuDropDownItemHighlight
        private void DrawMenuDropDownItemHighlight(ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect = new Rectangle(2, 0, (int)e.Graphics.VisibleClipBounds.Width - 4, (int)e.Graphics.VisibleClipBounds.Height - 1);
            using (SolidBrush brush = new SolidBrush(menuItemSelectedColor))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
            using (Pen pen = new Pen(menuItemBorderColor))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        #endregion
    }
    public class MenuBarColor : ProfessionalColorTable
    {
        Color ManuBarCommonColor = Color.LightSteelBlue;
        Color SelectedHighlightColor = Color.FromArgb(253, 244, 191);
        Color MenuBorderColor = Color.White;
        Color MenuItemBorderColor = Color.FromArgb(48, 61, 69);
        Color MenuStripbg = Color.Transparent;
        /// <summary>
        /// Initialize a new instance of the Visual Studio MenuBarColor class.
        /// </summary>
        public MenuBarColor()
        {
        }
        #region
        ///// <summary>
        /////  获取选中除顶级 System.Windows.Forms.ToolStripMenuItem 之外的 System.Windows.Forms.ToolStripMenuItem 时，要使用的纯色。
        ///// </summary>
        //public override Color MenuItemSelected
        //{
        //    get
        //    {
        //        return SelectedHighlightColor;
        //    }
        //}
        /// <summary>
        ///  被按下时使用的渐变的开始颜色
        /// </summary>
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return MenuStripbg;
            }
        }
        /// <summary>
        /// 被按下时使用的渐变的结束颜色
        /// </summary>
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return MenuStripbg;
            }
        }
        /// <summary>
        /// 被按下时使用的渐变的中间颜色
        /// </summary>
        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                return MenuStripbg;
            }
        }
        /// <summary>
        /// 获取按钮被选定时使用的纯色
        /// </summary>
        public override Color ButtonSelectedHighlight
        {
            get
            {
                return ManuBarCommonColor;

            }
        }
        /// <summary>
        ///  被选定时使用的渐变的开始颜色
        /// </summary>
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        /// <summary>
        /// 被选定时使用的渐变的结束颜色
        /// </summary>
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return ManuBarCommonColor;
            }
        }
        /// <summary>
        /// MenuStrip 上使用的边框颜色
        /// </summary>
        public override Color MenuBorder
        {
            get
            {
                return MenuBorderColor;
            }
        }
        /// <summary>
        /// ToolStripMenuItem 的边框颜色
        /// </summary>
        public override Color MenuItemBorder
        {
            get
            {
                return MenuItemBorderColor;
            }
        }
        #endregion
    }

}
