﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace MetroFramework.Controls
{

    public class AntDropDown : DefaultButton
    {
        private IContainer components = null;
        private ToolStripMenuItem Item2;
        private ToolStripMenuItem Item3;
        private ToolStripMenuItem Item4;
        private AntDropDownMenu Menu1;

        

        public AntDropDown()
        {
            this.components = new Container();
            this.Menu1 = new AntDropDownMenu(components);

            this.Item2 = new ToolStripMenuItem();
            this.Item3 = new ToolStripMenuItem();
            this.Item4 = new ToolStripMenuItem();
            this.Menu1.SuspendLayout();
            this.SuspendLayout();

            this.Menu1.Items.AddRange(new ToolStripItem[] {
            this.Item2,this.Item3,this.Item4});
            this.Menu1.Name = "metroContextMenu1";
            this.Menu1.Size = new Size(300, 70);

            this.Item2.Name = "toolStripMenuItem2";
            this.Item2.Text = "1234";
            this.Item3.Name = "toolStripMenuItem2";
            this.Item3.Text = "1234";
            this.Item4.Name = "toolStripMenuItem2";
            this.Item4.Text = "1234";

            Menu1.StyleManager = this.StyleManager;
            this.Menu1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        protected override void OnEnter(EventArgs e)
        {
            Menu1.Show(this, new Point(10, this.Height+4));
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Menu1.Show(this, new Point(0, this.Height));
            Invalidate();
            base.OnMouseEnter(e);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(150);
            
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Item2.Selected)
            {
                Menu1.Hide();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerAsync("Tank");
            }
        }
    }
}
