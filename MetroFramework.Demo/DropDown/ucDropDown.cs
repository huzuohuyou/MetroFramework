using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo.DropDown
{
    public partial class ucDropDown : UserControl
    {
        public ucDropDown()
        {
            InitializeComponent();
        }

        private void DefaultButton1_Click(object sender, EventArgs e)
        {
            metroContextMenu1.Show(defaultButton1, new Point(0, defaultButton1.Height));
        }
    }
}
