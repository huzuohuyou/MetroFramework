using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //toolStripMenuItem5.
            //this.menuStrip1.Renderer = new CustomProfessionalRenderer2();
            var mnuEdit = new ToolStripDropDownMenu();
            mnuEdit.DropShadowEnabled = false;
            mnuEdit.Text = "mnuEdit";

            var button = new ToolStripDropDownButton();
            button.Text = "button";
            button.DropDown = mnuEdit;

            antMenuStrip1.Items.Add(button);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(button1, 0, button1.Height);
        }

        private void antTopMenu1_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
