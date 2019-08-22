using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace MetroFramework.Controls
{

    public class AntDropDown : DefaultButton
    {
        private IContainer components = null;
        private ToolStripMenuItem toolStripMenuItem2;
        private AntDropDownMenu metroContextMenu1;

        

        public AntDropDown()
        {
            this.components = new Container();
            this.metroContextMenu1 = new AntDropDownMenu(components);

            this.toolStripMenuItem2 = new ToolStripMenuItem();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();

            this.metroContextMenu1.Items.AddRange(new ToolStripItem[] {
            this.toolStripMenuItem2});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new Size(84, 70);

            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(83, 22);
            this.toolStripMenuItem2.Text = "1";

            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        protected override void OnEnter(EventArgs e)
        {
            metroContextMenu1.Show(this, new Point(0, this.Height));
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            metroContextMenu1.Show(this, new Point(0, this.Height));
            Invalidate();
            base.OnMouseEnter(e);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(150);
            
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!toolStripMenuItem2.Selected)
            {
                metroContextMenu1.Hide();
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
