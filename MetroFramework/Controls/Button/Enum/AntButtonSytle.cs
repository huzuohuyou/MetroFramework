using System;
using System.Collections.Generic;
using System.Text;

namespace MetroFramework.Controls
{
    /// <summary>
    /// 按钮类型
    /// 按钮有五种类型：
    /// 主按钮、
    /// 次按钮、
    /// 虚线按钮、
    /// 危险按钮
    /// 和链接按钮。
    /// 主按钮在同一个操作区域最多出现一次。
    /// </summary>
    public enum AntButtonSytle
    {
        /// <summary>
        /// 主按钮
        /// </summary>
        Primary = 1,
        /// <summary>
        /// 次按钮
        /// </summary>
        Default = 2,
        /// <summary>
        /// 虚线按钮
        /// </summary>
        Dashed = 3,
        /// <summary>
        /// 危险按钮
        /// </summary>
        Danger = 4,
        /// <summary>
        /// 链接按钮
        /// </summary>
        Link = 5
    }
}
