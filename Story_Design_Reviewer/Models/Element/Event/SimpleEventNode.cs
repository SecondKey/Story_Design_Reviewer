using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer
{
    class SimpleEventNode : EventNodeBase
    {
        public SimpleEventNode(string elementName, ProcessElement parent, Vector v2, bool loadData) : base(elementName, parent, v2, loadData)
        {
        }

        public override IEnumerable<PortType> GetPorts()
        {
            throw new NotImplementedException();
        }

        public override void LoadEventData()
        {
            
        }
    }
}
