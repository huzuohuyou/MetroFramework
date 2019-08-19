namespace MetroFramework.Demo.Button
{
    partial class UcButton
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
            this.antButton3 = new MetroFramework.Controls.AntButton();
            this.antButton2 = new MetroFramework.Controls.AntButton();
            this.antButton1 = new MetroFramework.Controls.AntButton();
            this.antButton4 = new MetroFramework.Controls.AntButton();
            this.SuspendLayout();
            // 
            // antButton3
            // 
            this.antButton3.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.antButton3.AntSytle = MetroFramework.Controls.AntButtonSytle.Danger;
            this.antButton3.BackColor = System.Drawing.Color.Transparent;
            this.antButton3.ForeColor = System.Drawing.Color.Transparent;
            this.antButton3.Location = new System.Drawing.Point(633, 33);
            this.antButton3.Name = "antButton3";
            this.antButton3.Size = new System.Drawing.Size(148, 36);
            this.antButton3.TabIndex = 2;
            this.antButton3.Text = "Danger";
            this.antButton3.UseSelectable = true;
            // 
            // antButton2
            // 
            this.antButton2.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.antButton2.BackColor = System.Drawing.Color.Transparent;
            this.antButton2.ForeColor = System.Drawing.Color.Transparent;
            this.antButton2.Location = new System.Drawing.Point(20, 33);
            this.antButton2.Name = "antButton2";
            this.antButton2.Size = new System.Drawing.Size(148, 36);
            this.antButton2.TabIndex = 1;
            this.antButton2.Text = "Main";
            this.antButton2.UseSelectable = true;
            this.antButton2.CustomPaintBackground += new System.EventHandler<MetroFramework.Drawing.MetroPaintEventArgs>(this.antButton2_CustomPaintBackground);
            // 
            // antButton1
            // 
            this.antButton1.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.antButton1.AntSytle = MetroFramework.Controls.AntButtonSytle.Dashed;
            this.antButton1.BackColor = System.Drawing.Color.Transparent;
            this.antButton1.ForeColor = System.Drawing.Color.White;
            this.antButton1.Location = new System.Drawing.Point(440, 33);
            this.antButton1.Name = "antButton1";
            this.antButton1.Size = new System.Drawing.Size(148, 36);
            this.antButton1.TabIndex = 0;
            this.antButton1.Text = "Dashed";
            this.antButton1.UseSelectable = true;
            // 
            // antButton4
            // 
            this.antButton4.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.antButton4.AntSytle = MetroFramework.Controls.AntButtonSytle.Default;
            this.antButton4.BackColor = System.Drawing.Color.Transparent;
            this.antButton4.ForeColor = System.Drawing.Color.White;
            this.antButton4.Location = new System.Drawing.Point(238, 33);
            this.antButton4.Name = "antButton4";
            this.antButton4.Size = new System.Drawing.Size(134, 36);
            this.antButton4.TabIndex = 3;
            this.antButton4.Text = "antButton4";
            this.antButton4.UseSelectable = true;
            // 
            // UcButton
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.antButton4);
            this.Controls.Add(this.antButton3);
            this.Controls.Add(this.antButton2);
            this.Controls.Add(this.antButton1);
            this.Name = "UcButton";
            this.Size = new System.Drawing.Size(915, 609);
            this.Load += new System.EventHandler(this.UcButton_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AntButton antButton1;
        private Controls.AntButton antButton2;
        private Controls.AntButton antButton3;
        private Controls.AntButton antButton4;
    }
}
