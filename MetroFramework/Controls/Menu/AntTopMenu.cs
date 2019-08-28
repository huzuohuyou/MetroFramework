﻿using MetroFramework.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    [Designer("MetroFramework.Design.Controls.AntTopMenuDesigner, " + AssemblyRef.MetroFrameworkDesignSN)]
    [ToolboxBitmap(typeof(TabControl))]
    public class AntTopMenu: MetroTabControl
    {
        public AntTopMenu() : base()
        {
            base.Padding = new Point(16, 18);
            base.TextAlign = ContentAlignment.MiddleCenter;
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

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            for (var index = 0; index < TabPages.Count; index++)
            {
                if (index != SelectedIndex)
                {
                    DrawTab(index, e.Graphics);
                }
            }
            if (SelectedIndex <= -1)
            {
                return;
            }

            DrawTabBottomBorder(SelectedIndex, e.Graphics);
            DrawTab(SelectedIndex, e.Graphics);
            DrawTabSelected(SelectedIndex, e.Graphics);

            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
        }


        private void DrawTab(int index, Graphics graphics)
        {
            Color foreColor;
            Color backColor = BackColor;

            backColor = MetroPaint.BackColor.Form(Theme);

            MenuPage tabPage = (MenuPage)TabPages[index];
            Rectangle tabRect = GetTabRect(index);

            if (!Enabled)
            {
                foreColor = MetroPaint.ForeColor.Label.Disabled(Theme);
            }
            else
            {

                foreColor = !UseStyleColors ? MetroPaint.ForeColor.TabControl.Normal(Theme) : MetroPaint.GetStyleColor(Style);

            }

            if (index == 0)
            {
                tabRect.X = DisplayRectangle.X;
            }

            Rectangle bgRect = tabRect;

            tabRect.Width += 20;

            //using (Brush bgBrush = new SolidBrush(backColor))
            //{
            //    graphics.FillRectangle(bgBrush, bgRect);
            //}


            int iconX = 0, iconY = 0, iconSize = 20, textLeftPadding = 0;

            if (tabPage.AntSize.Equals(AntButtonSize.Large))
            {
                iconX = (int)IconLoaction.LargeIconX;
                iconY = (int)IconLoaction.LargeIconY;
                iconSize = (int)IconLoaction.LargeSize;
                textLeftPadding = 20;
            }
            else if (tabPage.AntSize.Equals(AntButtonSize.Default))
            {
                iconX = (int)IconLoaction.DefaultIconX;
                iconY = (int)IconLoaction.DefaultIconY;
                iconSize = (int)IconLoaction.DefaultSize;
                textLeftPadding = 20;
            }
            else if (tabPage.AntSize.Equals(AntButtonSize.Small))
            {
                iconX = (int)IconLoaction.SmallIconX;
                iconY = (int)IconLoaction.SmallIconY;
                iconSize = (int)IconLoaction.SmallISize;
                textLeftPadding = 20;
            }
            using (Brush brush = new SolidBrush(MetroPaint.GetStyleColor(Style)))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.DrawString(
       Icon.Style[tabPage.AntIcon],
       UseMemoryFont(iconSize),
       brush, new RectangleF() { X = tabRect.X-5, Y = (tabRect.Height-iconY-15)/2, Width = (int)tabPage.AntSize, Height = (int)tabPage.AntSize });
            }


            TextRenderer.DrawText(
                graphics,
                $@"{tabPage.Text}",
                MetroFonts.TabControl(FontSize, FontWeight),
                tabRect,
                foreColor, backColor, MetroPaint.GetTextFormatFlags(TextAlign));

        }

        private void DrawTabBottomBorder(int index, Graphics graphics)
        {
            using (Brush bgBrush = new SolidBrush(MetroPaint.BorderColor.TabControl.Normal(Theme)))
            {
                Rectangle borderRectangle = new Rectangle(DisplayRectangle.X, GetTabRect(index).Bottom + 2 - TabBottomBorderHeight, DisplayRectangle.Width, TabBottomBorderHeight);
                graphics.FillRectangle(bgBrush, borderRectangle);
            }
        }

        private void DrawTabSelected(int index, Graphics graphics)
        {
            using (Brush selectionBrush = new SolidBrush(MetroPaint.GetStyleColor(Style)))
            {
                Rectangle selectedTabRect = GetTabRect(index);
                Rectangle borderRectangle = new Rectangle(selectedTabRect.X + ((index == 0) ? 2 : 0), GetTabRect(index).Bottom + 2 - TabBottomBorderHeight, selectedTabRect.Width + ((index == 0) ? 0 : 2), TabBottomBorderHeight);
                graphics.FillRectangle(selectionBrush, borderRectangle);
            }
        }

    }
}
