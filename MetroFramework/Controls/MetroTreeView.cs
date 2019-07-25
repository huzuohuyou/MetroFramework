using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
    [Designer("MetroFramework.Design.Controls.MetroTabControlDesigner, " + AssemblyRef.MetroFrameworkDesignSN)]
    [ToolboxBitmap(typeof(TreeView))]
    public class MetroTreeView : TreeView, IMetroControl
    {
        public MetroColorStyle Style { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MetroThemeStyle Theme { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MetroStyleManager StyleManager { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseCustomBackColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseCustomForeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseStyleColors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseSelectable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
    }
}
