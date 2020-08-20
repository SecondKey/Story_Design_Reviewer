using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer.Models.Element.Event
{
    class SimpleEventNode : EventNodeBase
    {
        public SimpleEventNode(string elementName, ProcessElement parent, Vector v2, bool loadData) : base(elementName, parent, v2, loadData)
        {
        }

        public override void LoadEventData()
        {
            
        }
    }
}
