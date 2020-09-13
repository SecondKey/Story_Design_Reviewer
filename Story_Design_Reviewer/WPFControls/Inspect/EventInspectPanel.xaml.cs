using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Story_Design_Reviewer
{
    /// <summary>
    /// EventInspectPanel.xaml 的交互逻辑
    /// </summary>
    public partial class EventInspectPanel : UserControl
    {
        public EventInspectPanel()
        {
            InitializeComponent();
        }

        public static DependencyProperty eventName;
        public static DependencyProperty eventTimeType;
        public static DependencyProperty eventStartTime;
        public static DependencyProperty eventEndTime;

        

        public string EventName
        {
            get { return (string)GetValue(eventName); }
            set { SetValue(eventName, value); }
        }

        public int TimeType
        {
            get { return (int)GetValue(eventTimeType); }
            set { SetValue(eventTimeType, value); }
        }

        public string StartTime
        {
            get { return (string)GetValue(eventStartTime); }
            set { SetValue(eventStartTime, value); }
        }

        public string EndTmie
        {
            get { return (string)GetValue(eventEndTime); }
            set { SetValue(eventEndTime, value); }

        }

        static EventInspectPanel()
        {
            eventName = DependencyProperty.Register("EventName", typeof(string), typeof(EventInspectPanel));
            eventName = DependencyProperty.Register("eventTimeType", typeof(string), typeof(EventInspectPanel));
            eventStartTime = DependencyProperty.Register("EventStartTime", typeof(string), typeof(EventInspectPanel));
            eventEndTime = DependencyProperty.Register("EventEndTime", typeof(string), typeof(EventInspectPanel));
            //eventEndTime = DependencyProperty.Register("EventEndTime", typeof(string), typeof(EventInspectPanel), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnEndTimeChanged)));
        }
    }

}
