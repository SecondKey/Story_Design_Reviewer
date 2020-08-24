using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Story_Design_Reviewer.RW;

namespace Story_Design_Reviewer.ViewModel
{
    public class AppDataViewModel : ViewModelBase, IPretreatmentEvents
    {

        public void PretreatmentEvents()
        {
            AppPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            AppMsgCenter.SendMsg(new MsgDebugText(AllAppMsg.ShowDebugText, DebugTools.DebugList.App, DebugTools.DebugType.Log, AppPath));
            AppMsgCenter.RegistSelf(this, AllAppMsg.ChangeLanguage, ChangeLanguage);

            LoadSettings();
        }


        #region DataText
        #region 测试文本
        private string test;
        public string Test
        {
            get { return "Test"; }
            set
            {
                test = value;
                RaisePropertyChanged(() => Test);
            }
        }
        #endregion

        private Dictionary<string, string> appDataText;
        public Dictionary<string, string> AppDataText
        {
            get { return appDataText; }
            set
            {
                appDataText = value;
                RaisePropertyChanged();
            }
        }

        public void ChangeLanguage(AppMsg msg)
        {
            AppDataText = RWXml.GetInstence().GetOneLayerAllElement("Language_" + Language);
        }
        #endregion
        #region 文件路径
        private string appPath;

        public string AppPath
        {
            get { return appPath; }
            set
            {
                appPath = value;
                RaisePropertyChanged(() => AppPath);
            }
        }

        #endregion
        #region Settings
        private string language;
        public string Language
        {
            get { return language; }
            set
            {
                language = value;
                RaisePropertyChanged(() => Language);
                AppMsgCenter.SendMsg(new MsgString(AllAppMsg.ChangeLanguage, language));
            }
        }

        private int errorPageWidth;
        public int ErrorPageWidth
        {
            get { return errorPageWidth; }
            set
            {
                errorPageWidth = value;
                RaisePropertyChanged(() => ErrorPageWidth);
            }
        }

        private int inspectePageWidth;
        public int InsPectePageWidth
        {
            get { return inspectePageWidth; }
            set
            {
                inspectePageWidth = value;
                RaisePropertyChanged(() => InsPectePageWidth);
            }
        }

        void LoadSettings()
        {

            Language = RWXml.GetInstence().GetOneElement("AppData", "Settings", "Language");
            ErrorPageWidth = int.Parse(RWXml.GetInstence().GetOneElement("AppData", "Settings", "LayOut", "ErrorPage", "Width"));
            inspectePageWidth = int.Parse(RWXml.GetInstence().GetOneElement("AppData", "Settings", "LayOut", "InspectePage", "Width"));
        }

        #endregion

    }
}
