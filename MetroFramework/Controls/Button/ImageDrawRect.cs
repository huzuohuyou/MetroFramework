using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace CCWin
{
    public partial class ImageDrawRect
    {
        public static ContentAlignment anyRight = ContentAlignment.BottomRight | (ContentAlignment.MiddleRight | ContentAlignment.TopRight);
        public static ContentAlignment anyTop = ContentAlignment.TopRight | (ContentAlignment.TopCenter | ContentAlignment.TopLeft);
        public static ContentAlignment anyBottom = ContentAlignment.BottomRight | (ContentAlignment.BottomCenter | ContentAlignment.BottomLeft);
        public static ContentAlignment anyCenter = ContentAlignment.BottomCenter | (ContentAlignment.MiddleCenter | ContentAlignment.TopCenter);
        public static ContentAlignment anyMiddle = ContentAlignment.MiddleRight | (ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft);

        private static Bitmap SetPictureAlpha(Image image, int alpha)
        {
            //颜色矩阵  
            float[][] matrixItems =
            {
               new float[]{1,0,0,0,0},
               new float[]{0,1,0,0,0},
               new float[]{0,0,1,0,0},
               new float[]{0,0,0,alpha/255f,0},
               new float[]{0,0,0,0,1}
           };
            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAtt);
            g.Dispose();

            return bmp;
        }

        /// <summary>
        /// 绘图对像
        /// </summary>
        /// <param name="g">绘图对像</param>
        /// <param name="img">图片</param>
        /// <param name="r">绘置的图片大小、坐标</param>
        /// <param name="lr">绘置的图片边界</param>
        /// <param name="index">当前状态</param> 
        /// <param name="Totalindex">状态总数</param>
        public static void DrawRect(Graphics g, Bitmap img, Rectangle r, Rectangle lr, int index, int Totalindex)
        {
            //img = SetPictureAlpha(img,200);
            if (img == null) return;
            Rectangle r1, r2;
            int x = (index - 1) * img.Width / Totalindex;
            int y = 0;
            int x1 = r.Left;
            int y1 = r.Top;

            if (r.Height > img.Height && r.Width <= img.Width / Totalindex)
            {
                r1 = new Rectangle(x, y, img.Width / Totalindex, lr.Top);
                r2 = new Rectangle(x1, y1, r.Width, lr.Top);
                g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x, y + lr.Top, img.Width / Totalindex, img.Height - lr.Top - lr.Bottom);
                r2 = new Rectangle(x1, y1 + lr.Top, r.Width, r.Height - lr.Top - lr.Bottom);
                if ((lr.Top + lr.Bottom) == 0) r1.Height = r1.Height - 1;
                g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x, y + img.Height - lr.Bottom, img.Width / Totalindex, lr.Bottom);
                r2 = new Rectangle(x1, y1 + r.Height - lr.Bottom, r.Width, lr.Bottom);
                g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
            }
            else
                if (r.Height <= img.Height && r.Width > img.Width / Totalindex)
                {
                    r1 = new Rectangle(x, y, lr.Left, img.Height);
                    r2 = new Rectangle(x1, y1, lr.Left, r.Height);
                    g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                    r1 = new Rectangle(x + lr.Left, y, img.Width / Totalindex - lr.Left - lr.Right, img.Height);
                    r2 = new Rectangle(x1 + lr.Left, y1, r.Width - lr.Left - lr.Right, r.Height);
                    g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                    r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y, lr.Right, img.Height);
                    r2 = new Rectangle(x1 + r.Width - lr.Right, y1, lr.Right, r.Height);
                    g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                }
                else
                    if (r.Height <= img.Height && r.Width <= img.Width / Totalindex)
                    {
                        r1 = new Rectangle((index - 1) * img.Width / Totalindex, 0, img.Width / Totalindex, img.Height - 1);
                        g.DrawImage(img, new Rectangle(x1, y1, r.Width, r.Height), r1, GraphicsUnit.Pixel);
                    }
                    else if (r.Height > img.Height && r.Width > img.Width / Totalindex)
                    {
                        //top-left
                        r1 = new Rectangle(x, y, lr.Left, lr.Top);
                        r2 = new Rectangle(x1, y1, lr.Left, lr.Top);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //top-bottom
                        r1 = new Rectangle(x, y + img.Height - lr.Bottom, lr.Left, lr.Bottom);
                        r2 = new Rectangle(x1, y1 + r.Height - lr.Bottom, lr.Left, lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //left
                        r1 = new Rectangle(x, y + lr.Top, lr.Left, img.Height - lr.Top - lr.Bottom);
                        r2 = new Rectangle(x1, y1 + lr.Top, lr.Left, r.Height - lr.Top - lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //top
                        r1 = new Rectangle(x + lr.Left, y,
                            img.Width / Totalindex - lr.Left - lr.Right, lr.Top);
                        r2 = new Rectangle(x1 + lr.Left, y1,
                            r.Width - lr.Left - lr.Right, lr.Top);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //right-top
                        r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y, lr.Right, lr.Top);
                        r2 = new Rectangle(x1 + r.Width - lr.Right, y1, lr.Right, lr.Top);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //Right
                        r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y + lr.Top,
                            lr.Right, img.Height - lr.Top - lr.Bottom);
                        r2 = new Rectangle(x1 + r.Width - lr.Right, y1 + lr.Top,
                            lr.Right, r.Height - lr.Top - lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //right-bottom
                        r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y + img.Height - lr.Bottom,
                            lr.Right, lr.Bottom);
                        r2 = new Rectangle(x1 + r.Width - lr.Right, y1 + r.Height - lr.Bottom,
                            lr.Right, lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //bottom
                        r1 = new Rectangle(x + lr.Left, y + img.Height - lr.Bottom,
                            img.Width / Totalindex - lr.Left - lr.Right, lr.Bottom);
                        r2 = new Rectangle(x1 + lr.Left, y1 + r.Height - lr.Bottom,
                            r.Width - lr.Left - lr.Right, lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //Center
                        r1 = new Rectangle(x + lr.Left, y + lr.Top,
                            img.Width / Totalindex - lr.Left - lr.Right, img.Height - lr.Top - lr.Bottom);
                        r2 = new Rectangle(x1 + lr.Left, y1 + lr.Top,
                            r.Width - lr.Left - lr.Right, r.Height - lr.Top - lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                    }
        }

        public static void SetBits(int Width, int Height, int Left, int Top, Rectangle ClientRectangle)
        {
            //绘制绘图层背景
            Bitmap bitmap = new Bitmap(Width , Height );
            Rectangle _BacklightLTRB = new Rectangle(10, 10, 10, 10);//窗体光泽重绘边界
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            ImageDrawRect.DrawRect(g, MetroFramework.Properties.Resources.main_light_bkg_top123, ClientRectangle, Rectangle.FromLTRB(_BacklightLTRB.X, _BacklightLTRB.Y, _BacklightLTRB.Width, _BacklightLTRB.Height), 1, 1);

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

        /// <summary>
        /// 绘图对像
        /// </summary>
        /// <param name="g"> 绘图对像</param>
        /// <param name="obj">图片对像</param>
        /// <param name="r">绘置的图片大小、坐标</param>
        /// <param name="index">当前状态</param>
        /// <param name="Totalindex">状态总数</param>
        public static void DrawRect(Graphics g, Bitmap img, Rectangle r, int index, int Totalindex)
        {
            if (img == null) return;
            int width= img.Width / Totalindex;
            int height = img.Height;
            Rectangle r1, r2;
            int x = (index - 1) * width;
            int y = 0;
            int x1 = r.Left;
            int y1 = r.Top;
            r1 = new Rectangle(x, y, width,height);
            r2 = new Rectangle(x1, y1, r.Width, r.Height);
            g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
        }

        public static Rectangle HAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
        {
            if ((align & anyRight) != (ContentAlignment)0)
            {
                withinThis.X += (withinThis.Width - alignThis.Width);
            }
            else if ((align & anyCenter) != ((ContentAlignment)0))
            {
                withinThis.X += ((withinThis.Width - alignThis.Width + 1) / 2);
            }
            withinThis.Width = alignThis.Width;
            return withinThis;
        }

        public static Rectangle VAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
        {
            if ((align & anyBottom) != ((ContentAlignment)0))
            {
                withinThis.Y += (withinThis.Height - alignThis.Height);
            }
            else if ((align & anyMiddle) != ((ContentAlignment)0))
            {
                withinThis.Y += ((withinThis.Height - alignThis.Height + 1) / 2);
            }
            withinThis.Height = alignThis.Height;
            return withinThis;
        }
    }
}
