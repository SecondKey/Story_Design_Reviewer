using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Story_Design_Reviewer.DebugTools;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

namespace Story_Design_Reviewer.ViewModel
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            instence = this;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<DebugTools.DebugViewModel>();

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<ErrorPageViewModel>();
            SimpleIoc.Default.Register<InspectViewModel>();
            SimpleIoc.Default.Register<WorkingAreaViewModel>();
            #region Inspect
            SimpleIoc.Default.Register<EventInspectViewModel>();
            #endregion 
        }

        #region µ¥Àý
        public static ViewModelLocator instence;
        Dictionary<string, bool> HasInstence = new Dictionary<string, bool>()
        {
            { "MainWindow",false },
            { "DebugWindow",false},
            { "AppData",false},
        };
        #endregion

        public MainWindowViewModel MainWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
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

        public WorkingAreaViewModel WorkingAreaPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WorkingAreaViewModel>();
            }
        }

        #region Inspect
        public EventInspectViewModel EventInspectPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EventInspectViewModel>();
            }
        }
        #endregion

        public static void Cleanup()
        {
            //TODO Clear the ViewModels
        }
    }
}