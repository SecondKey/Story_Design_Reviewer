using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Story_Design_Reviewer.DebugTools;
using Story_Design_Reviewer.WPFControls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

namespace Story_Design_Reviewer.ViewModel
{

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            instence = this;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<DebugTools.DebugViewModel>();
            SimpleIoc.Default.Register<ErrorPageViewModel>();
            SimpleIoc.Default.Register<InspectViewModel>();
        }

        #region µ¥Àý
        public static ViewModelLocator instence;
        Dictionary<string, bool> HasInstence = new Dictionary<string, bool>()
        {
            { "MainWindow",false },
            { "DebugWindow",false},
        };
        #endregion

        public MainWindowViewModel MainWindow
        {
            get
            {
                MainWindowViewModel instence = ServiceLocator.Current.GetInstance<MainWindowViewModel>();
                if (!HasInstence["MainWindow"])
                {
                    HasInstence["MainWindow"] = true;
                    instence.PretreatmentEvents();
                }
                return instence;
            }
        }

        public DebugViewModel DebugWindow
        {
            get
            {
                DebugViewModel instence = ServiceLocator.Current.GetInstance<DebugViewModel>();
                if (!HasInstence["DebugWindow"])
                {
                    HasInstence["DebugWindow"] = true;
                    instence.PretreatmentEvents();
                }
                return instence;
            }
        }

        public ErrorPageViewModel ErrorPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ErrorPageViewModel>();
            }
        }

        public InspectPage inspectPageInstence;
        public InspectViewModel InspectPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InspectViewModel>();
            }
        }

        public static void Cleanup()
        {
            //TODO Clear the ViewModels
        }
    }
}