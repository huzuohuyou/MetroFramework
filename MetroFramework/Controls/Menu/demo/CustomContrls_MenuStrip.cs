using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    public partial class CustomContrls_MenuStrip : MenuStrip
    {
        private Color _themeColor = Color.Gray;
        public CustomContrls_MenuStrip()
        {
            //InitializeComponent();
            this.Renderer = new CustomProfessionalRenderer(_themeColor);
        }
        public Color ThemeColor
        {
            get { return _themeColor; }
            set
            {
                _themeColor = value;
                this.Renderer = new CustomProfessionalRenderer(_themeColor);
            }
        }
    }
}
