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
            this.dropDownButton1 = new MetroFramework.Controls.DropDownButton();
            this.SuspendLayout();
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.BackColor = System.Drawing.Color.Transparent;
            this.dropDownButton1.ForeColor = System.Drawing.Color.Transparent;
            this.dropDownButton1.Location = new System.Drawing.Point(162, 106);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(171, 32);
            this.dropDownButton1.TabIndex = 0;
            this.dropDownButton1.Text = "dropDownButton1";
            this.dropDownButton1.UseSelectable = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dropDownButton1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DropDownButton dropDownButton1;
    }
}