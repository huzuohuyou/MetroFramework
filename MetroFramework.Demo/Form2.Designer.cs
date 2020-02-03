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
            this.SuspendLayout();
            // 
            // antLeftMenuStrip1
            // 
            this.antLeftMenuStrip1.AutoSize = false;
            this.antLeftMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.antLeftMenuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.antLeftMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.antLeftMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.antLeftMenuStrip1.Name = "antLeftMenuStrip1";
            this.antLeftMenuStrip1.Size = new System.Drawing.Size(182, 564);
            this.antLeftMenuStrip1.TabIndex = 1;
            this.antLeftMenuStrip1.Text = "antLeftMenuStrip1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.antLeftMenuStrip1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Controls.AntLeftMenuStrip antLeftMenuStrip1;
    }
}