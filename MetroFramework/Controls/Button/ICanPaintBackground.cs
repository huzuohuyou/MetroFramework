using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    interface ICanPaintBackground
    {
        void OnPaintBackground(PaintEventArgs e);
    }
}
