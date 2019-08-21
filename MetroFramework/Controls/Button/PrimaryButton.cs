using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    public class PrimaryButton : AntButton
    {
      
        public PrimaryButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;

          
        }


        public Font UseFileFont(float size)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            string appPath = @"D:\GitHub\MetroFramework\MetroFramework.Demo\bin\Debug\font\";
            string fontFile = appPath + "iconfont.ttf";
            pfc.AddFontFile(fontFile);
            Font font = new Font(pfc.Families[0], size, FontStyle.Regular, GraphicsUnit.Point, 0);
            return font;
        }

        public Font UseMemoryFont(float size)
        {
            System.Runtime.InteropServices.GCHandle hObject = System.Runtime.InteropServices.GCHandle.Alloc(Properties.Resources.iconfont, System.Runtime.InteropServices.GCHandleType.Pinned);
            IntPtr intptr = hObject.AddrOfPinnedObject();
            PrivateFontCollection fc = new PrivateFontCollection();
            fc.AddMemoryFont(intptr, Properties.Resources.iconfont.Length);
            Font font = new Font(fc.Families[0], size, FontStyle.Regular, GraphicsUnit.Point, 0);
            return font;
        }

       

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                
                if (isHovered && !isPressed && Enabled)
                {
                    using (Brush brush = new SolidBrush(BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);

                    }
                }
                else if (isHovered && isPressed && Enabled)
                {
                    using (Brush brush = new SolidBrush(BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), -0.2f)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
                else if (!Enabled)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(247, 247, 247)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
                else if (Enabled)
                {
                    using (Brush brush = new SolidBrush(MetroPaint.GetStyleColor(Style)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
            }
            catch (Exception)
            {
                Invalidate();
            }
        }

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            Color foreColor = Color.Empty;

            if (isHovered && !isPressed && Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Hover(Theme);
            }
            else if (isHovered && isPressed && Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Press(Theme);
            }
            else if (!Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Disabled(Theme);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
           

            
            if (AntIcon.Equals(AntButtonIcon.None))
            {
                TextRenderer.DrawText(e.Graphics, Text, MetroFonts.Button(metroButtonSize, metroButtonWeight),
              ClientRectangle
                , foreColor, MetroPaint.GetTextFormatFlags(TextAlign));
            }
            else
            {
                int iconX = 0, iconY = 0, iconSize = 20, textLeftPadding = 0;
                using (Brush brush = new SolidBrush(Color.White))
                {
                    var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, AntShape.Equals(AntButtonShape.Circle) ? (int)AntSize : 10);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

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
                    e.Graphics.DrawString(
           Icon.Style[AntIcon],
           UseFileFont(iconSize),
           brush, new RectangleF() { X = iconX, Y = iconY, Width = (int)AntSize, Height = (int)AntSize });

                }
                TextRenderer.DrawText(e.Graphics, Text, MetroFonts.Button(metroButtonSize, metroButtonWeight),
              new Rectangle { X = textLeftPadding, Y = ClientRectangle.Y, Width = ClientRectangle.Width - textLeftPadding, Height = ClientRectangle.Height }

               , foreColor, MetroPaint.GetTextFormatFlags(TextAlign));
            }


            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, foreColor, e.Graphics));

        }


    }
}
