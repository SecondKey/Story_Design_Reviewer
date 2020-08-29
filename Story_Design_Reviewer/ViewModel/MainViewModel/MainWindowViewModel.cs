using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using Story_Design_Reviewer.DebugTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Story_Design_Reviewer.ViewModel
{
    public class MainWindowViewModel : DataViewModelBase
    {
        private RelayCommand clearFocus;
        public RelayCommand ClearFocus
        {
            get
            {
                clearFocus = new RelayCommand(() => { Keyboard.ClearFocus(); });
                return clearFocus;
            }
        }
    }
}
