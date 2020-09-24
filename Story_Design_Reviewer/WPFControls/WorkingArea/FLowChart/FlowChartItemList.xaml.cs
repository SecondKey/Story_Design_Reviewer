using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    /// FlowChartItemList.xaml 的交互逻辑
    /// </summary>
    public partial class FlowChartItemList : TabItem
    {
        public FlowChartItemList()
        {
            InitializeComponent();
        }

        public static DependencyProperty typeList;
        public static DependencyProperty itemList;

        public List<string> TypeList
        {
            get { return (List<string>)GetValue(typeList); }
            set { SetValue(typeList, value); }
        }
        public List<string> ItemKey
        {
            get { return (List<string>)GetValue(itemList); }
            set { SetValue(itemList, value); }
        }

        static FlowChartItemList()
        {
            itemList = DependencyProperty.Register("ItemList", typeof(List<string>), typeof(FlowChartItemList));
            typeList = DependencyProperty.Register("TypeList", typeof(List<string>), typeof(FlowChartItemList));
        }

        public void ListBox_Answers_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }
    }
}
