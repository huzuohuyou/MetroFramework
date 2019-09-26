using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    class BitmapRegion
    {
        //创建支持位图区域的控件（目前有button，form，imagebutton）
        public static void CreateControlRegion(Control control, Bitmap bitmap)
        {
            //判断控件是否存在
            if (control == null)//|| bitmap == null
                return;

            //控件大小设置为位图大小
            control.Width = bitmap.Width;
            control.Height = bitmap.Height;

            // 档控件为form时
            if (control is System.Windows.Forms.Form)
            {
                //强制转化为form
                Form form = (Form)control;

                //当FORM的边界FormBorderStyle不为NONE时，应将FORM的大小设置成比位图大小稍大一点
                form.Width += 15;
                form.Height += 35;
                //设置form为没有边界
                form.FormBorderStyle = FormBorderStyle.None;

                //将位图设置为控件背景图
                form.BackgroundImage = bitmap;

                //计算位图中不透明的部分
                GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);

                //应用新的区域
                form.Region = new Region(graphicsPath);
            }
            //当控件是panel时
            else if (control is System.Windows.Forms.Panel)
            {
                //强制转化为panel
                Panel form = control as Panel;

                //当FORM的边界FormBorderStyle不为NONE时，应将FORM的大小设置成比位图大小稍大一点
                //form.Width += 15;
                //form.Height += 35;
                //form.Width += 15;
                //form.Height += 35;
                // 设置panel为没有边界
                form.BorderStyle = BorderStyle.None;

                //将位图设置为控件背景图
                form.BackgroundImage = bitmap;

                //计算位图中不透明的部分
                GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);

                //应用新的区域
                form.Region = new Region(graphicsPath);
            }
            //当控件是button时
            else if (control is System.Windows.Forms.Button)
            {

                // 强制转化为button
                Button button = (Button)control;

                // 不显示button文字
                button.Text = "";

                // 改变cursor的style
                button.Cursor = Cursors.Hand;

                // 设置button的背景图片
                button.BackgroundImage = bitmap;

                // 计算图中不透明部分
                GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);

                // 应用新的区域
                button.Region = new Region(graphicsPath);
            }
            //当控件是imagebutton时
            //else if (control is M3Host.view.utils.ImageButton)
            //{
            //    M3Host.view.utils.ImageButton button = control as M3Host.view.utils.ImageButton;

            //    // 不显示文字
            //    button.Text = "";

            //    // 改变模式和设置正常状态下的图片为空
            //    button.Cursor = Cursors.Hand;
            //    button.NormalImage = null;
            //    // 设置位图为背景图片
            //    button.BackgroundImage = bitmap;

            //    // 计算图中不透明部分
            //    GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);

            //    // 应用新的区域
            //    button.Region = new Region(graphicsPath);
            //}
        }

        // 计算位图中不透明部分
        private static GraphicsPath CalculateControlGraphicsPath(Bitmap bitmap)
        {
            // 创建graphicsPath
            GraphicsPath graphicsPath = new GraphicsPath();

            // 取得左上角的第一个点作为透明点
            Color colorTransparent = bitmap.GetPixel(0, 0);

            // 第一个找到的点
            int colOpaquePixel = 0;

            // 遍历所有Y方向的点
            for (int row = 0; row < bitmap.Height; row++)
            {
                // 重设
                colOpaquePixel = 0;

                // 遍历X方向的所有点
                for (int col = 0; col < bitmap.Width; col++)
                {
                    // 如果不是透明点，则继续遍历
                    if (bitmap.GetPixel(col, row) != colorTransparent)
                    {
                        // 记录当前点
                        colOpaquePixel = col;

                        // 新建变量记录当前点
                        int colNext = col;

                        // 从找到的不透明点开始，继续寻找不透明点,一直到找到或则达到图片宽度
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == colorTransparent)
                                break;

                        // 将不透明点加到graphics path
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel,
                                                   row, colNext - colOpaquePixel, 1));
                        //覆盖前一个点
                        col = colNext;
                    }
                }
            }

            return graphicsPath;
        }
    }
}
