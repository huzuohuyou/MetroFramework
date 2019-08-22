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
            this.antDropDown1 = new MetroFramework.Controls.AntDropDown();
            this.defaultButton1 = new MetroFramework.Controls.DefaultButton();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.SuspendLayout();
            // 
            // antDropDown1
            // 
            this.antDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.antDropDown1.ForeColor = System.Drawing.Color.Transparent;
            this.antDropDown1.Location = new System.Drawing.Point(47, 145);
            this.antDropDown1.Name = "antDropDown1";
            this.antDropDown1.Size = new System.Drawing.Size(144, 32);
            this.antDropDown1.TabIndex = 3;
            this.antDropDown1.Text = "antDropDown1";
            this.antDropDown1.UseSelectable = true;
            // 
            // defaultButton1
            // 
            this.defaultButton1.BackColor = System.Drawing.Color.Transparent;
            this.defaultButton1.ForeColor = System.Drawing.Color.Transparent;
            this.defaultButton1.Location = new System.Drawing.Point(317, 153);
            this.defaultButton1.Name = "defaultButton1";
            this.defaultButton1.Size = new System.Drawing.Size(75, 32);
            this.defaultButton1.TabIndex = 4;
            this.defaultButton1.Text = "defaultButton1";
            this.defaultButton1.UseSelectable = true;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.IsHover = false;
            this.metroContextMenu1.IsOpen = false;
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // ucDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.defaultButton1);
            this.Controls.Add(this.antDropDown1);
            this.Name = "ucDropDown";
            this.Size = new System.Drawing.Size(621, 493);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.AntDropDown antDropDown1;
        private Controls.DefaultButton defaultButton1;
        private Controls.MetroContextMenu metroContextMenu1;
    }
}
