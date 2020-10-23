using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BasicLibrary
{
    /// <summary>
    /// NodeList.xaml 的交互逻辑
    /// </summary>
    public partial class NodeList : UserControl
    {
        public NodeList()
        {
            InitializeComponent();
        }

        public static DependencyProperty itemList;

        public ObservableCollection<string> ItemList
        {
            get { return (ObservableCollection<string>)GetValue(itemList); }
            set { SetValue(itemList, value); }
        }

        static NodeList()
        {
            itemList = DependencyProperty.Register("ItemList", typeof(ObservableCollection<string>), typeof(NodeList));
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
