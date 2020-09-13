using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer
{
    class ProcessElementViewModel : ViewModelBase
    {
        public ProcessElementInDiagram proxyNode;

        public ProcessElementViewModel(ProcessElementInDiagram target)
        {
            if (target != null)
            {
                proxyNode = target;
            }
        }
    }
}
