namespace MetroFramework.Demo.DropDown
{
    partial class ucDropDown
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.defaultButton1 = new MetroFramework.Controls.DefaultButton();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.dropDownButton1 = new MetroFramework.Controls.DropDownButton();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultButton1
            // 
            this.defaultButton1.BackColor = System.Drawing.Color.Transparent;
            this.defaultButton1.ForeColor = System.Drawing.Color.Transparent;
            this.defaultButton1.Location = new System.Drawing.Point(281, 52);
            this.defaultButton1.Name = "defaultButton1";
            this.defaultButton1.Size = new System.Drawing.Size(144, 32);
            this.defaultButton1.TabIndex = 4;
            this.defaultButton1.Text = "defaultButton1";
            this.defaultButton1.UseSelectable = true;
            this.defaultButton1.Click += new System.EventHandler(this.DefaultButton1_Click);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.IsHover = false;
            this.metroContextMenu1.IsOpen = false;
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(193, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.AntShape = MetroFramework.Controls.AntButtonShape.Circle;
            this.dropDownButton1.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.dropDownButton1.BackColor = System.Drawing.Color.Transparent;
            this.dropDownButton1.ForeColor = System.Drawing.Color.Transparent;
            this.dropDownButton1.Location = new System.Drawing.Point(58, 44);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(161, 40);
            this.dropDownButton1.TabIndex = 6;
            this.dropDownButton1.Text = "dropDownButton1";
            this.dropDownButton1.UseSelectable = true;
            // 
            // ucDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dropDownButton1);
            this.Controls.Add(this.defaultButton1);
            this.Name = "ucDropDown";
            this.Size = new System.Drawing.Size(621, 493);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.DefaultButton defaultButton1;
        private Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private Controls.DropDownButton dropDownButton1;
    }
}
