namespace MetroFramework.Demo
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.antTopMenu1 = new MetroFramework.Controls.AntTopMenu();
            this.menuPage1 = new MetroFramework.Controls.MenuPage();
            this.menuPage2 = new MetroFramework.Controls.MenuPage();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.contextMenuStrip1.SuspendLayout();
            this.antTopMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 70);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem2.Text = "123";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem3.Text = "4";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem4.Text = "555555";
            // 
            // antTopMenu1
            // 
            this.antTopMenu1.Controls.Add(this.menuPage1);
            this.antTopMenu1.Controls.Add(this.menuPage2);
            this.antTopMenu1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.antTopMenu1.Location = new System.Drawing.Point(12, 12);
            this.antTopMenu1.Name = "antTopMenu1";
            this.antTopMenu1.SelectedIndex = 0;
            this.antTopMenu1.Size = new System.Drawing.Size(776, 100);
            this.antTopMenu1.TabIndex = 10;
            this.antTopMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.antTopMenu1.UseSelectable = true;
            // 
            // menuPage1
            // 
            this.menuPage1.HorizontalScrollbarBarColor = true;
            this.menuPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.menuPage1.HorizontalScrollbarSize = 10;
            this.menuPage1.Location = new System.Drawing.Point(4, 58);
            this.menuPage1.Name = "menuPage1";
            this.menuPage1.Size = new System.Drawing.Size(778, 38);
            this.menuPage1.TabIndex = 0;
            this.menuPage1.Text = "menuPage1";
            this.menuPage1.Titles = new string[] {
        "1",
        "2",
        "3"};
            this.menuPage1.VerticalScrollbarBarColor = true;
            this.menuPage1.VerticalScrollbarHighlightOnWheel = false;
            this.menuPage1.VerticalScrollbarSize = 10;
            // 
            // menuPage2
            // 
            this.menuPage2.HorizontalScrollbarBarColor = true;
            this.menuPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.menuPage2.HorizontalScrollbarSize = 10;
            this.menuPage2.Location = new System.Drawing.Point(4, 58);
            this.menuPage2.Name = "menuPage2";
            this.menuPage2.Size = new System.Drawing.Size(778, 38);
            this.menuPage2.TabIndex = 1;
            this.menuPage2.Text = "menuPage2";
            this.menuPage2.Titles = new string[] {
        "11",
        "22",
        "33"};
            this.menuPage2.VerticalScrollbarBarColor = true;
            this.menuPage2.VerticalScrollbarHighlightOnWheel = false;
            this.menuPage2.VerticalScrollbarSize = 10;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(614, 330);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(75, 23);
            this.metroTile1.TabIndex = 9;
            this.metroTile1.Text = "metroTile1";
            this.metroTile1.UseSelectable = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.antTopMenu1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.contextMenuStrip1.ResumeLayout(false);
            this.antTopMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private Controls.AntTopMenu antTopMenu1;
        private Controls.MenuPage menuPage1;
        private Controls.MenuPage menuPage2;
        private Controls.MetroTile metroTile1;
    }
}