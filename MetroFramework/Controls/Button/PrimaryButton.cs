using FontAwesomeNet;
using MetroFramework.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    public class PrimaryButton : AntButton
    {
        private Label label1 { get; set; }

        public PrimaryButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;

            this.label1 = new Label();
            this.label1.AutoSize = true;
            
            this.label1.Name = "label1";
            this.label1.BackColor = Color.Transparent;
            this.label1.Text = "\uE670";
            this.label1.Font = GetFontbyFile(20);// GetResoruceFont(Properties.Resources.iconfont);// new Font("anticon", 16);
            this.label1.ForeColor = Color.White;
            this.Controls.Add(this.label1);
        }
        /// <summary>
        /// 如何使用资源文件中的字体，无安装无释放
        /// </summary>
        /// <param name="bytes">资源文件中的字体文件,如Properties.Resources.华文行楷</param>
        /// <returns></returns>
        public Font GetResoruceFont(byte[] bytes)
        {
            System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
            IntPtr MeAdd = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, MeAdd, bytes.Length);
            pfc.AddMemoryFont(MeAdd, bytes.Length);
            return new Font(pfc.Families[0], 15, FontStyle.Regular);
        }

        public Font GetFontbyFile(float size)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            string appPath = Application.StartupPath + "\\font\\";//font是程序目录下放字体的文件夹
            string fontFile1 = appPath + "iconfont.ttf";
            pfc.AddFontFile(fontFile1);//字体文件的路径
            Font myFont1 = new Font(pfc.Families[0], size, FontStyle.Regular, GraphicsUnit.Point, 0);
            return myFont1;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                this.label1.Location = new Point(2, (int)AntSize / 2 - label1.Height / 2);
                if (isHovered && !isPressed && Enabled)
                {
                    using (Brush brush = new SolidBrush(BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), 0.2f)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
                else if (isHovered && isPressed && Enabled)
                {
                    using (Brush brush = new SolidBrush(BaseAntButton.ChangeColor(MetroPaint.GetStyleColor(Style), -0.2f)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
                else if (!Enabled)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(247, 247, 247)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }
                }
                else if (Enabled)
                {
                    using (Brush brush = new SolidBrush(MetroPaint.GetStyleColor(Style)))
                    {
                        var rec = BaseAntButton.DrawRoundRect(0, 0, Width - 1, Height - 1, IsRounded ? (int)AntSize : 10);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, rec);
                    }

                  
                }
            }
            catch
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


            //int val = FontAwesome.TypeDict["fa-glass"];
            //Bitmap bmp = FontAwesome.GetImage(val);
            //Rectangle rg = new Rectangle(10, 10, 30, 30);

            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.DrawImage(bmp, rg);
            //}
            //TextRenderer.DrawText(e.Graphics, "\uE670", MetroFonts.Icon(16), ClientRectangle, Color.Red, MetroPaint.GetTextFormatFlags(TextAlign));

            TextRenderer.DrawText(e.Graphics, Text, MetroFonts.Button(metroButtonSize, metroButtonWeight), ClientRectangle, foreColor, MetroPaint.GetTextFormatFlags(TextAlign));

            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, foreColor, e.Graphics));

        }

        
    }
}
