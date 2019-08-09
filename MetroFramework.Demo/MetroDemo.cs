using MetroFramework.Demo.Button;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace MetroFramework.Demo
{
    public partial class MetroDemo : MetroForm
    {
        public MetroDemo()
        {
            InitializeComponent();
        }

        private void metroTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AddMetroTabPage(e.Node.Name, e.Node.Text, new UcButton());
        }

        public void AddMetroTabPage(string name, string text, UserControl uc)
        {
            if (metroTabControl1.Controls.Find(text, false).Length > 0)
            {
                metroTabControl1.SelectTab(text);
            }
            else
            {
                var metroTabPage4 = new Controls.MetroTabPage();
                metroTabPage4.SuspendLayout();
                metroTabPage4.Name = text;
                metroTabPage4.Text = text;
                uc.Dock = DockStyle.Fill;
                metroTabPage4.VerticalScrollbarBarColor = true;
                metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
                metroTabPage4.VerticalScrollbarSize = 10;
                metroTabPage4.Controls.Add(uc);
                metroTabControl1.Controls.Add(metroTabPage4);
                metroTabControl1.SelectTab(text);
            }
            
            
        }
    }
}
