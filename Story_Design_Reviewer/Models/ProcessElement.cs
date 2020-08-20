using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer.Models
{
    public class ProcessElement : ObservableObject
    {
        private ElementType elementType;
        public virtual ElementType ElementType
        {
            get { return elementType; }
            set { elementType = value; }
        }

        protected ProcessElement parentElement;
        public ProcessElement ParentElement
        {
            get { return parentElement; }
            set { parentElement = value; }
        }

        private string elementName;
        public virtual string ElementName
        {
            get { return elementName; }
            set { elementName = value; }
        }

        public ProcessElement( string elementName, ProcessElement parent)
        {
            ElementName = elementName;
            ParentElement = parent;
        }

        public List<string> GetElementPath(List<string> tmp)
        {
            tmp.Add(ElementName);
            if (ParentElement != null)
            {
                return parentElement.GetElementPath(tmp);
            }
            else
            {
                return tmp;
            }
        }
    }
}
