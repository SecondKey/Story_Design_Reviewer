using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer
{
    abstract class ProcessElementInDiagram : ProcessElement
    {
        public ProcessElementInDiagram(string elementName, ProcessElement parent, Vector v2) : base(elementName, parent)
        {
            ElementPos = v2;
        }

        /// <summary>
        /// 记录该元素在图中位置记录的类型
        /// </summary>
        public PositionType posType;

        /// <summary>
        /// 元素所在的位置
        /// </summary>
        private Vector posLeftTop;
        private Vector posRowColumn;

        /// <summary>
        /// 元素所在的位置
        /// </summary>
        public Vector ElementPos
        {
            get
            {
                switch (posType)
                {
                    case PositionType.LeftTop:
                        return posLeftTop;
                    case PositionType.RowColumn:
                        return posRowColumn;
                    default:
                        return new Vector();
                }
            }
            set
            {
                switch (posType)
                {
                    case PositionType.LeftTop:
                        posLeftTop = value;
                        break;
                    case PositionType.RowColumn:
                        posRowColumn = value;
                        break;
                }
            }
        }

        public abstract IEnumerable<PortType> GetPorts();
    }
}
