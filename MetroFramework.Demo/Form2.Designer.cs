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
            this.antLeftMenuStrip1 = new MetroFramework.Controls.AntLeftMenuStrip(this.components);
            this.antDropDownMenu1 = new MetroFramework.Controls.AntDropDownMenu(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.antDropDownMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // antLeftMenuStrip1
            // 
            this.antLeftMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.antLeftMenuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.antLeftMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.antLeftMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.antLeftMenuStrip1.Name = "antLeftMenuStrip1";
            this.antLeftMenuStrip1.Size = new System.Drawing.Size(126, 564);
            this.antLeftMenuStrip1.TabIndex = 1;
            this.antLeftMenuStrip1.Text = "antLeftMenuStrip1";
            // 
            // antDropDownMenu1
            // 
            this.antDropDownMenu1.AutoSize = false;
            this.antDropDownMenu1.DropShadowEnabled = false;
            this.antDropDownMenu1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.antDropDownMenu1.IsHover = false;
            this.antDropDownMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.antDropDownMenu1.Name = "antDropDownMenu1";
            this.antDropDownMenu1.Size = new System.Drawing.Size(140, 105);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(269, 30);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(269, 30);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(269, 30);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.antLeftMenuStrip1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.antDropDownMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Controls.AntDropDownMenu antDropDownMenu1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private Controls.AntLeftMenuStrip antLeftMenuStrip1;
    }
}