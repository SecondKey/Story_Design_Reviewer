using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer
{
    abstract class EventNodeBase : ProcessElementInDiagram,IContainsElements
    {
        protected EventNodeBase(string elementName, ProcessElement parent, Vector v2, bool loadData) : base(elementName, parent, v2)
        {
            this.ElementType = ElementType.Event;

            if (loadData)
            {
                LoadEventData();
            }
        }

        public ObservableCollection<ProcessElementInDiagram> Nodes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObservableCollection<LinkViewModel> Links { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public abstract void LoadEventData();
    }
}
