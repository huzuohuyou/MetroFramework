using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo.Button
{
    public partial class UcButton : UserControl
    {
        public UcButton()
        {
            InitializeComponent();
            this.label1.Text = "\uE670";
            this.label1.Font = new Font("anticon", 16);
            this.label1.ForeColor = Color.Green;
        }

        private void UcButton_Load(object sender, EventArgs e)
        {

        }

        private void antButton2_CustomPaintBackground(object sender, Drawing.MetroPaintEventArgs e)
        {

        }
    }
}
