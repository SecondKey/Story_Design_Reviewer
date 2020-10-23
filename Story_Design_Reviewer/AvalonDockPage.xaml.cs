using System;
using System.Collections.Generic;
using System.IO;
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
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace Story_Design_Reviewer
{
    /// <summary>
    /// AvalonDockPage.xaml 的交互逻辑
    /// </summary>
    public partial class AvalonDockPage : UserControl
    {
        public AvalonDockPage()
        {
            InitializeComponent();
        }

        public void Load(object sender, RoutedEventArgs e)
        {
            XmlLayoutSerializer serializer = new XmlLayoutSerializer(DockManager);
            using (var stream = new StreamReader("Data/Layout/Layout.xml"))
            {
                serializer.Deserialize(stream);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {

            XmlLayoutSerializer serializer = new XmlLayoutSerializer(DockManager);
            using (var stream = new StreamWriter("Data/Layout/Layout.xml"))
            {
                serializer.Serialize(stream);
            }
        }
    }
}
