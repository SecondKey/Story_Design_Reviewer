using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows.Media;

namespace Story_Design_Reviewer
{
    /// <summary>
    /// 用于处理对于设置属性的绑定
    /// </summary>
    public class DataViewModelBase : ViewModelBase
    {
        public Dictionary<string, string> AppDataText
        {
            get { return AppDataCenter.GetInstence().AppDataText; }
        }

        public Dictionary<string, Color> InterfaceColor
        {
            get { return AppDataCenter.GetInstence().InterfaceColor; }
        }

        public Dictionary<string, float> LayOutSettings
        {
            get { return AppDataCenter.GetInstence().LayoutSettings; }
        }
    }
}
