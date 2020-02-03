using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MetroFramework.Controls
{

    public class AntLeftMenuStrip : MenuStrip, IMetroControl
    {
        #region Interface

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroColorStyle.Blue;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroThemeStyle.Light;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set
            {
                metroStyleManager = value;
                settheme();
            }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category("Metro Behaviour")]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion


        #region Fields

        private MetroTabControlSize metroLabelSize = MetroTabControlSize.Medium;
        [DefaultValue(MetroTabControlSize.Medium)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroTabControlSize FontSize
        {
            get { return metroLabelSize; }
            set { metroLabelSize = value; }
        }

        private MetroTabControlWeight metroLabelWeight = MetroTabControlWeight.Light;
        [DefaultValue(MetroTabControlWeight.Light)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroTabControlWeight FontWeight
        {
            get { return metroLabelWeight; }
            set { metroLabelWeight = value; }
        }

        private ContentAlignment textAlign = ContentAlignment.MiddleLeft;
        [DefaultValue(ContentAlignment.MiddleLeft)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public ContentAlignment TextAlign
        {
            get
            {
                return textAlign;
            }
            set
            {
                textAlign = value;
            }
        }

        #endregion
        private IContainer components = null;
        private ToolStripMenuItem Item2;
        private ToolStripMenuItem Item3;
        private ToolStripMenuItem Item4;
        private ToolStripMenuItem Item5;
        private ToolStripMenuItem Item6;
        private AntDropDownMenu Menu1;
        private AntDropDownMenu Menu2;

        public AntLeftMenuStrip(IContainer Container)
        {
            Dock = DockStyle.Left;
            if (Container != null)
            {
                Container.Add(this);
            }
            settheme();
            this.components = new Container();
            this.Menu1 = new AntDropDownMenu(components);
            this.Menu2 = new AntDropDownMenu(components);

            this.Item2 = new ToolStripMenuItem();
            this.Item3 = new ToolStripMenuItem();
            this.Item4 = new ToolStripMenuItem();

            this.Item5 = new ToolStripMenuItem();
            this.Item6 = new ToolStripMenuItem();

            this.Menu1.SuspendLayout();
            //this.Menu2.SuspendLayout();
            this.SuspendLayout();
            
            this.Menu1.Items.AddRange(new ToolStripItem[] {
            this.Item2,this.Item3,this.Item4});

            this.Menu2.Items.AddRange(new ToolStripItem[] {
            this.Item5,this.Item6});
            //Item2.Margin = new Padding(0,5,0,5);
            Item2.Padding = new Padding(0, 5, 0, 5);
            Item2.TextAlign = ContentAlignment.BottomCenter;
            this.Item2.Name = "toolStripMenuItem2";
            this.Item2.Text = "真的很长很长的文本";
            this.Item3.Name = "toolStripMenuItem2";
            this.Item3.Text = "文本1";
            this.Item4.Name = "toolStripMenuItem2";
            this.Item4.Text = "文本2";

            this.Item5.Name = "toolStripMenuItem2";
            this.Item5.Text = "文本1";
            this.Item6.Name = "toolStripMenuItem2";
            this.Item6.Text = "文本2";
            this.Menu1.Name = "metroContextMenu1";
            this.Menu1.Size = new Size(202, Item2.DropDown.Height * 4);

            Menu1.StyleManager = this.StyleManager;
            Menu2.StyleManager = this.StyleManager;
            this.Menu1.ResumeLayout(false);
            this.ResumeLayout(false);

            var button = new ToolStripMenuItem();
            button.Text = "button";
            button.DropDown = Menu1;


            Item2.DropDown = Menu2;
            this.Items.Add(button);


        }

        public AntLeftMenuStrip()
        {
            settheme();
           
        }

        private void settheme()
        {
            this.BackColor = MetroPaint.BackColor.Form(Theme);
            this.ForeColor = MetroPaint.ForeColor.Button.Normal(Theme);
        }

        

        private Color _startColor = Color.White;
        private Color _endCoolor = Color.Blue;



        #region Paint Methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = BackColor;

                if (!useCustomBackColor)
                {
                    backColor = MetroPaint.BackColor.Form(Theme);
                }

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaintBackground(e);

                OnCustomPaintBackground(new MetroPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            {
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                OnCustomPaint(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
                OnPaintForeground(e);
            }
            catch
            {
                Invalidate();
            }
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            for (var index = 0; index < Items.Count; index++)
            {
                DrawTab(Items[index], e.Graphics);
                if (Items[index].Selected)
                {

                    DrawTabBottomBorder(Items[index], e.Graphics);
                }
                
                DrawTabSelected(Items[index], e.Graphics);
            }
            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
        }

        int TabBottomBorderHeight = 2;
        private void DrawTabBottomBorder(ToolStripItem item, Graphics graphics)
        {
            using (Brush bgBrush = new SolidBrush(Color.Blue))
            {
                Rectangle borderRectangle = new Rectangle(DisplayRectangle.X, item.Size.Height  - TabBottomBorderHeight, DisplayRectangle.Width, TabBottomBorderHeight);
                graphics.FillRectangle(bgBrush, borderRectangle);
            }
        }

        private void DrawTab(ToolStripItem item, Graphics graphics)
        {
            TextRenderer.DrawText(
                graphics,
                $@"{item.Text}",
                MetroFonts.TabControl(metroLabelSize, metroLabelWeight),
                new Rectangle { Size= item.Size },
                Color.Red, Color.White, MetroPaint.GetTextFormatFlags(TextAlign));
        }

        private void DrawTabSelected(ToolStripItem item, Graphics graphics)
        {
            //using (Brush selectionBrush = new SolidBrush(MetroPaint.GetStyleColor(Style)))
            //{
            //    Rectangle selectedTabRect = GetTabRect(index);
            //    Rectangle borderRectangle = new Rectangle(selectedTabRect.X + ((index == 0) ? 2 : 0), GetTabRect(index).Bottom + 2 - TabBottomBorderHeight, selectedTabRect.Width + ((index == 0) ? 0 : 2), TabBottomBorderHeight);
            //    graphics.FillRectangle(selectionBrush, borderRectangle);
            //}
        }
        #endregion

    }
}
