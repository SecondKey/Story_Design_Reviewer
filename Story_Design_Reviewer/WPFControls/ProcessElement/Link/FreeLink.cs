using Aga.Diagrams.Controls;
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
    class FreeLink : SegmentLink
    {
        static FreeLink()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FreeLink), new FrameworkPropertyMetadata(typeof(FreeLink)));
        }
    }
}
