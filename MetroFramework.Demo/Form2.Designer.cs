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
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.dropDownButton1 = new MetroFramework.Controls.DropDownButton();
            this.buttonGroup1 = new MetroFramework.Controls.ButtonGroup();
            this.defaultButton1 = new MetroFramework.Controls.DefaultButton();
            this.defaultButton2 = new MetroFramework.Controls.DefaultButton();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
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
            // dropDownButton1
            // 
            this.dropDownButton1.BackColor = System.Drawing.Color.Transparent;
            this.dropDownButton1.ForeColor = System.Drawing.Color.Transparent;
            this.dropDownButton1.Location = new System.Drawing.Point(12, 12);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(171, 32);
            this.dropDownButton1.TabIndex = 0;
            this.dropDownButton1.Text = "dropDownButton1";
            this.dropDownButton1.UseSelectable = true;
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.BackColor = System.Drawing.Color.Transparent;
            this.buttonGroup1.ForeColor = System.Drawing.Color.Transparent;
            this.buttonGroup1.Location = new System.Drawing.Point(12, 50);
            this.buttonGroup1.Name = "buttonGroup1";
            this.buttonGroup1.Size = new System.Drawing.Size(252, 32);
            this.buttonGroup1.TabIndex = 3;
            this.buttonGroup1.Text = "buttonGroup1";
            this.buttonGroup1.UseSelectable = true;
            // 
            // defaultButton1
            // 
            this.defaultButton1.BackColor = System.Drawing.Color.Transparent;
            this.defaultButton1.ForeColor = System.Drawing.Color.Transparent;
            this.defaultButton1.Location = new System.Drawing.Point(0, 0);
            this.defaultButton1.Name = "defaultButton1";
            this.defaultButton1.Size = new System.Drawing.Size(75, 23);
            this.defaultButton1.TabIndex = 0;
            this.defaultButton1.Text = "defaultButton1";
            this.defaultButton1.UseSelectable = true;
            // 
            // defaultButton2
            // 
            this.defaultButton2.BackColor = System.Drawing.Color.Transparent;
            this.defaultButton2.ForeColor = System.Drawing.Color.Transparent;
            this.defaultButton2.Location = new System.Drawing.Point(0, 0);
            this.defaultButton2.Name = "defaultButton2";
            this.defaultButton2.Size = new System.Drawing.Size(75, 23);
            this.defaultButton2.TabIndex = 0;
            this.defaultButton2.Text = "defaultButton2";
            this.defaultButton2.UseSelectable = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonGroup1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dropDownButton1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DropDownButton dropDownButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private Controls.ButtonGroup buttonGroup1;
        private Controls.DefaultButton defaultButton1;
        private Controls.DefaultButton defaultButton2;
    }
}