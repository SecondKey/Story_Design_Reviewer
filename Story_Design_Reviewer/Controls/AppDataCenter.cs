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

        #region ElementOperation
        DeleteOptions,

        OnElementValueChange,
        #endregion

        #region UserControl
        ChoiseEveneElement,
        Undo,
        Redo
        #endregion
    }

    #endregion

    #region Type
    /// <summary>
    /// 撤销重做类型
    /// </summary>
    public enum UndoRedoOperationType
    {
        Delete = 1,
        Create = 10,
    }

    /// <summary>
    /// 错误的类型
    /// </summary>
    public enum ErrorType
    {
        LostMotivation,
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType
    {

    }

    #region Diagram
    /// <summary>
    /// 端口类型
    /// </summary>
    public enum PortType
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    /// <summary>
    /// 记录元素在图中
    /// </summary>
    public enum PositionType
    {
        LeftTop,//左边和顶边位置
        RowColumn,//所在行和所在列
    }

    /// <summary>
    /// 元素的类型
    /// </summary>
    public enum ElementType
    {
        Role,//角色

        MainTimeLine,//主时间线
        Event,//事件
        SimpleEvent,//简单事件
        SpecialEvent,//特殊事件

        Motive,//动机
        Behavior,//行为
        Relation,//关系
    }
    #endregion

    /// <summary>
    /// 设置的类型
    /// </summary>
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

        #region 模板数据

        private Dictionary<string, string> templeteDataText;
        public Dictionary<string, string> TempleteDataText
        {
            get { return templeteDataText; }
            set 
            {
                templeteDataText = value;
                RaisePropertyChanged(() => TempleteDataText);

            }
        }
        void GetTempleteText()
        {
            TempleteDataText = RWXml.GetInstence().GetOneLayerAllElement("Language_" + Language);
        }

        #endregion
    }
}
