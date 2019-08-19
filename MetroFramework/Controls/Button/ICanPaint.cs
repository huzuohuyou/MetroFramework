using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    public interface ICanPaint
    {
        void Foreground(PaintEventArgs e);
        void Background(PaintEventArgs e);
    }
}
