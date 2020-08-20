using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer.ViewModel
{
    class ElementNodeViewModel
    {
        Models.ProcessNodeElement proxyNode;

        public ElementNodeViewModel(Models.ProcessNodeElement target)
        {
            if (target != null)
            {
                proxyNode = target;
            }
        }
    }
}
