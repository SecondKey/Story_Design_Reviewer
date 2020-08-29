using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Story_Design_Reviewer.WPFControls.Inspect.Element
{
    /// <summary>
    /// InspectItem.xaml 的交互逻辑
    /// </summary>
    public partial class InspectItem : UserControl
    {
        public InspectItem()
        {
            InitializeComponent();
        }

        public static DependencyProperty itemKey;
        public static DependencyProperty itemValue;
        public static DependencyProperty itemAllowModify;

        public string ItemKey
        {
            get { return (string)GetValue(itemKey); }
            set { SetValue(itemKey, value); }
        }

        public string ItemValue
        {
            get { return (string)GetValue(itemValue); }
            set { SetValue(itemValue, value); }
        }

        public bool ItemAllowModify
        {
            get { return (bool)GetValue(itemAllowModify); }
            set { SetValue(itemAllowModify, value); }
        }

        static InspectItem()
        {
            itemKey = DependencyProperty.Register("ItemKey", typeof(string), typeof(InspectItem));
            itemValue = DependencyProperty.Register("ItemValue", typeof(string), typeof(InspectItem));
            itemAllowModify = DependencyProperty.Register("ItemAllowModify", typeof(bool), typeof(InspectItem), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(SetAllowModify)));
        }

        static void SetAllowModify(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            InspectItem item = (InspectItem)sender;
            if (item.ItemAllowModify)
            {
                item.ValueText.BorderThickness = new Thickness(2);
            }
        }
    }
}
