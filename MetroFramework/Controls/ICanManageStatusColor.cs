using System.Drawing;

namespace MetroFramework.Controls
{
    /// <summary>
    /// 
    /// </summary>
    interface ICanManageStatusColor
    {
        Color GetBackgroundColorByStatus(bool isHovered, bool isPressed, bool Enabled);

        Color GetForegroundColorByStatus(bool isHovered, bool isPressed, bool Enabled);
    }
}
