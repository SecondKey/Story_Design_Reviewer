using GalaSoft.MvvmLight;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Story_Design_Reviewer
{
    #region StaticValue

    #region Msg
    public enum AllAppMsg
    {
        #region Debug
        ShowDebugText,
        #endregion

        #region AppSettings
        ChangeLanguage,
        #endregion

        #region ElementOptions
        DeleteOptions,
        #endregion

        #region UserControl
        ChoiseEveneElement,
        #endregion
    }

    #endregion

    #region Type
    public enum ElementType
    {
        Role,
        MainTimeLine,
        Event,
        SimpleEvent,
        SpecialEvent,
        Motive,
        Behavior,
        Relation
    }

    public enum ErrorType
    {
        LostMotivation,
    }

    public enum OptionsType
    {

    }



    public enum SettingsType
    {
        Language,
    }
    #endregion
    #endregion

    public class AppDataCenter : ObservableObject
    {
        #region 变量
        public static string appPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Data/";
        #endregion

        #region 单例/加载
        private static AppDataCenter instence = null;
        private AppDataCenter()
        {
            AppMsgCenter.SendMsg(new MsgDebugText(AllAppMsg.ShowDebugText, DebugTools.DebugList.App, DebugTools.DebugType.Log, appPath));

            GetLanguage();
            GetLayOutSettings();
            GetInterfaceColor();
        }
        public static AppDataCenter GetInstence()
        {
            if (instence == null)
            {
                instence = new AppDataCenter();
            }
            return instence;
        }
        #endregion

        #region DataText
        /// <summary>
        /// 文本数据
        /// </summary>
        private Dictionary<string, string> appDataText;
        public Dictionary<string, string> AppDataText
        {
            get { return appDataText; }
            set
            {
                appDataText = value;
                RaisePropertyChanged(() => AppDataText);
            }
        }
        void GetDataText()
        {
            AppDataText = RWXml.GetInstence().GetOneLayerAllElement("Language_" + Language);
        }
        #endregion

        #region Settings
        /// <summary>
        /// 文本
        /// </summary>
        private string language;
        public string Language
        {
            get { return language; }
            set
            {
                language = value;
                RaisePropertyChanged(() => Language);
                GetDataText();
                AppMsgCenter.SendMsg(new MsgBase(AllAppMsg.ChangeLanguage));
            }
        }
        void GetLanguage()
        {
            Language = RWXml.GetInstence().GetOneElement("AppData", "Settings", "Language");
        }

        /// <summary>
        /// 布局
        /// </summary>
        private Dictionary<string, float> layoutSettings;
        public Dictionary<string, float> LayoutSettings
        {
            get { return layoutSettings; }
            set
            {
                layoutSettings = value;
                RaisePropertyChanged(() => LayoutSettings);
            }
        }
        void GetLayOutSettings()
        {
            Dictionary<string, string> settings = RWXml.GetInstence().GetOneLayerAllElement("AppData", "Settings", "LayOut");
            Dictionary<string, float> tmp = new Dictionary<string, float>();
            foreach (var kv in settings)
            {
                tmp.Add(kv.Key, float.Parse(kv.Value));
            }
            LayoutSettings = tmp;
        }

        /// <summary>
        /// 界面颜色
        /// </summary>
        private Dictionary<string, Color> interfaceColor;
        public Dictionary<string, Color> InterfaceColor
        {
            get { return interfaceColor; }
            set
            {
                interfaceColor = value;
                RaisePropertyChanged(() => LayoutSettings);
            }
        }
        void GetInterfaceColor()
        {
            Dictionary<string, string> settings = RWXml.GetInstence().GetOneLayerAllElement("AppData", "Settings", "AppColor");
            Dictionary<string, Color> tmp = new Dictionary<string, Color>();
            foreach (var kv in settings)
            {
                tmp.Add(kv.Key, (Color)ColorConverter.ConvertFromString(kv.Value));
            }
            InterfaceColor = tmp;
        }

        #endregion
    }
}
