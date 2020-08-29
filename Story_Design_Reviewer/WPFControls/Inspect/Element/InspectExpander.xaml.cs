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

namespace Story_Design_Reviewer.WPFControls.Inspect.Element
{
    /// <summary>
    /// InspectExpander.xaml 的交互逻辑
    /// </summary>
    public partial class InspectExpander : UserControl
    {
        public InspectExpander()
        {
            InitializeComponent();
        }

        public static DependencyProperty expanderHeaderKey;
        public static DependencyProperty expanderHeaderValue;
        public static DependencyProperty expanderContant;
        public static DependencyProperty expanderAllowModify;

        public string ExpanderHeaderKey
        {
            get { return (string)GetValue(expanderHeaderKey); }
            set { SetValue(expanderHeaderKey, value); }
        }

        public string ExpanderHeaderValue
        {
            get { return (string)GetValue(expanderHeaderValue); }
            set { SetValue(expanderHeaderValue, value); }
        }

        public string ExpanderContant
        {
            get { return (string)GetValue(expanderContant); }
            set { SetValue(expanderContant, value); }
        }

        public bool ExpanderAllowModify
        {
            get { return (bool)GetValue(expanderAllowModify); }
            set { SetValue(expanderAllowModify, value); }
        }

        static InspectExpander()
        {
            expanderHeaderKey = DependencyProperty.Register("ExpanderHeaderKey", typeof(string), typeof(InspectExpander));
            expanderHeaderValue = DependencyProperty.Register("ExpanderHeaderValue", typeof(string), typeof(InspectExpander));
            expanderContant = DependencyProperty.Register("ExpanderContant", typeof(string), typeof(InspectExpander));
            expanderAllowModify = DependencyProperty.Register("ExpanderAllowModify", typeof(bool), typeof(InspectExpander), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(SetAllowModify)));
        }

        static void SetAllowModify(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            InspectExpander item = (InspectExpander)sender;
            if (item.ExpanderAllowModify)
            {
            }
        }
    }
}
