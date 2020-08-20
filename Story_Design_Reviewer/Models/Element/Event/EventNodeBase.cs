using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer.Models.Element.Event
{
    public abstract class EventNodeBase : ProcessNodeElement
    {
        protected EventNodeBase(string elementName, ProcessElement parent, Vector v2, bool loadData) : base(elementName, parent, v2)
        {
            this.ElementType = ElementType.Event;

            if (loadData)
            {
                LoadEventData();
            }
        }

        public abstract void LoadEventData();
    }
}
