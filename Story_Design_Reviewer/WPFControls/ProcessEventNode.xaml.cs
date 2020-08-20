﻿using Story_Design_Reviewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Story_Design_Reviewer.WPFControls
{

    /// <summary>
    /// ProcessEventNode.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessEventNode : Button
    {
        public ProcessEventNode(Models.Element.Event.EventNode target)
        {
            InitializeComponent();
            DataContext = new ElementNodeViewModel(null);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {

            this.Canvas.Visibility = Visibility.Visible;
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            this.Canvas.Visibility = Visibility.Hidden;
        }
    }


}