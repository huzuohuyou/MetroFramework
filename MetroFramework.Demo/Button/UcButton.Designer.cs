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
            this.antButton2 = new MetroFramework.Controls.AntButton();
            this.antButton1 = new MetroFramework.Controls.AntButton();
            this.antButton3 = new MetroFramework.Controls.AntButton();
            this.SuspendLayout();
            // 
            // antButton2
            // 
            this.antButton2.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.antButton2.BackColor = System.Drawing.Color.Transparent;
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
            this.antButton1.AntCircular = false;
            this.antButton1.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.antButton1.AntSytle = MetroFramework.Controls.AntButtonSytle.Secondary;
            this.antButton1.BackColor = System.Drawing.Color.Transparent;
            this.antButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.antButton1.ForeColor = System.Drawing.Color.White;
            this.antButton1.Location = new System.Drawing.Point(489, 33);
            this.antButton1.Name = "antButton1";
            this.antButton1.Size = new System.Drawing.Size(166, 36);
            this.antButton1.TabIndex = 0;
            this.antButton1.Text = "123456";
            this.antButton1.UseSelectable = true;
            // 
            // antButton3
            // 
            this.antButton3.AntSize = MetroFramework.Controls.AntButtonSize.Large;
            this.antButton3.AntSytle = MetroFramework.Controls.AntButtonSytle.Danger;
            this.antButton3.BackColor = System.Drawing.Color.Transparent;
            this.antButton3.Location = new System.Drawing.Point(234, 33);
            this.antButton3.Name = "antButton3";
            this.antButton3.Size = new System.Drawing.Size(148, 36);
            this.antButton3.TabIndex = 2;
            this.antButton3.Text = "Danger";
            this.antButton3.UseSelectable = true;
            // 
            // UcButton
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.antButton3);
            this.Controls.Add(this.antButton2);
            this.Controls.Add(this.antButton1);
            this.Name = "UcButton";
            this.Size = new System.Drawing.Size(726, 609);
            this.Load += new System.EventHandler(this.UcButton_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AntButton antButton1;
        private Controls.AntButton antButton2;
        private Controls.AntButton antButton3;
    }
}
