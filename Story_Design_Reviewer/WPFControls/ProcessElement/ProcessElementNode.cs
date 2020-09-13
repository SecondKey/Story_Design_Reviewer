using Aga.Diagrams.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// 视图中元素节点
    /// </summary>
    class ProcessElementNode : Node
    {
        static ProcessElementNode()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProcessElementNode), new FrameworkPropertyMetadata(typeof(ProcessElementNode)));
        }
    }
}
