﻿namespace MetroFramework.Demo.Button
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
            this.antButton1 = new MetroFramework.Controls.AntButton();
            this.SuspendLayout();
            // 
            // antButton1
            // 
            this.antButton1.AntCircular = false;
            this.antButton1.AntSize = MetroFramework.Controls.Enum.AntButtonSize.Large;
            this.antButton1.AntStyle = MetroFramework.Controls.Enum.AntButtonSytle.Secondary;
            this.antButton1.BackColor = System.Drawing.Color.Transparent;
            this.antButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.antButton1.ForeColor = System.Drawing.Color.White;
            this.antButton1.Location = new System.Drawing.Point(64, 27);
            this.antButton1.Name = "antButton1";
            this.antButton1.Size = new System.Drawing.Size(166, 36);
            this.antButton1.TabIndex = 0;
            this.antButton1.Text = "123456";
            this.antButton1.UseSelectable = true;
            // 
            // UcButton
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.antButton1);
            this.Name = "UcButton";
            this.Size = new System.Drawing.Size(726, 609);
            this.Load += new System.EventHandler(this.UcButton_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AntButton antButton1;
    }
}
