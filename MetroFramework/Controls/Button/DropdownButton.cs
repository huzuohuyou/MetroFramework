using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace MetroFramework.Controls
{

    public class DropDownButton : DefaultButton
    {
        private IContainer components = null;
        private ToolStripMenuItem Item2;
        private ToolStripMenuItem Item3;
        private ToolStripMenuItem Item4;
        private AntDropDownMenu Menu1;

        

        public DropDownButton()
        {
            this.components = new Container();
            this.Menu1 = new AntDropDownMenu(components);

            this.Item2 = new ToolStripMenuItem();
            this.Item3 = new ToolStripMenuItem();
            this.Item4 = new ToolStripMenuItem();

            Item2.DropDown.AutoSize = false;
            Item2.DropDown.Size = new Size(50, Item2.DropDown.Height);
            Item3.DropDown.AutoSize = false;
            Item3.DropDown.Size = new Size(50, Item3.DropDown.Height);
            Item4.DropDown.AutoSize = false;
            Item4.DropDown.Size = new Size(50, Item4.DropDown.Height);

            this.Menu1.SuspendLayout();
            this.SuspendLayout();

            this.Menu1.Items.AddRange(new ToolStripItem[] {
            this.Item2,this.Item3,this.Item4});
            this.Menu1.Name = "metroContextMenu1";
            this.Menu1.Size = new Size(150, 170);

            this.Item2.Name = "toolStripMenuItem2";
            this.Item2.Text = "1234";
            this.Item3.Name = "toolStripMenuItem2";
            this.Item3.Text = "456";
            this.Item4.Name = "toolStripMenuItem2";
            this.Item4.Text = "789";

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
            Menu1.Show(this, new Point(0, this.Height+3));
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
