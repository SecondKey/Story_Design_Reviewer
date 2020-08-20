using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Story_Design_Reviewer.DebugTools
{
    public enum DebugList
    {
        App = 0,
        RW = 1,
    }
    public enum DebugType
    {
        Log = 0,
        LogError = 1,
    }

    public class DebugViewModel : ViewModelBase
    {
        DebugWindow debugWindow;


        #region 单例
        public DebugViewModel()
        {
            AppMsgCenter.RegistSelf(this, AllAppMsg.ShowDebugText, DebugLogText<AppMsg>);
        }

        public void PretreatmentEvents()
        {
            debugWindow = new DebugWindow();
            debugWindow.Show();
        }
        #endregion

        void DebugLogText<T>(AppMsg msg)
        {
            MsgDebugText tmpMsg = (MsgDebugText)msg;
            IAddChild pannel = (StackPanel)debugWindow.FindName(string.Format("T{0}P{1}", (int)tmpMsg.list, (int)tmpMsg.type));
            TextBlock logText = new TextBlock()
            {
                Text = tmpMsg.text
            };
            if (tmpMsg.type == DebugType.LogError)
            {
                logText.Foreground = Brushes.Red;
            }
            pannel.AddChild(logText);
        }
    }
}
