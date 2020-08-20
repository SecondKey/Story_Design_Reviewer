using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer.Models
{
    public class ProcessNodeElement : ProcessElement
    {
        private Vector elementPos;

        public ProcessNodeElement(string elementName, ProcessElement parent, Vector v2) : base(elementName, parent)
        {
            ElementPos = v2;
        }

        public Vector ElementPos
        {
            get { return elementPos; }
            set { elementPos = value; }
        }
    }
}
