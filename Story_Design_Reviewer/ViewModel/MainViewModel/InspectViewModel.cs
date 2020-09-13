using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Story_Design_Reviewer
{
    public struct InspectItemStruct
    {
        public string ItemKey { get; set; }
        public string ItemValue { get; set; }
        public bool AllowModify { get; set; }
    }

    class InspectViewModel : DataViewModelBase
    {
        InspectPage inspectPage;
        StackPanel inspectStackPanel;

        ProcessElement targetElement;

        public InspectViewModel()
        {
            //inspectPage = (InspectPage)Application.Current.MainWindow.FindName("inspectPage");
            //inspectStackPanel = (StackPanel)inspectPage.FindName("Panel");
            //ChoiseOneElement(new EventNode("TextEventNode", null, new Vector(), false));
        }
        #region 组装Inspect面板
        void ChoiseOneElement(ProcessElement target)
        {
            targetElement = target;
            switch (target.ElementType)
            {
                case ElementType.Event:
                    ShowEventInfo();
                    break;
                default:
                    break;
            }
        }

        public void ShowEventInfo()
        {
            inspectStackPanel.Children.Clear();
            Border infoBorder = new Border();

            StackPanel infoList = new StackPanel();

            Border eventName = (Border)inspectPage.FindResource("ReadOnlyText");
            ((TextBlock)eventName.FindName("RKey")).SetBinding(TextBlock.TextProperty, AppDataText["InspectEvent_EventName"]);
            ((TextBlock)eventName.FindName("RKey")).Text = "123";

            ((IAddChild)infoList).AddChild(eventName);


            infoBorder.Child = infoList;
            ((IAddChild)inspectStackPanel).AddChild(infoBorder);
        }

        #endregion


        #region 获取单个border

        public Border GetEventBorder()
        {
            return new Border();
        }


        #endregion
        private List<string> elementBasicInfo;
        public List<string> ElementBasicInfo
        {
            get { return elementBasicInfo; }
            set
            {
                elementBasicInfo = value;
                RaisePropertyChanged(() => ElementBasicInfo);
            }
        }

    }
}
