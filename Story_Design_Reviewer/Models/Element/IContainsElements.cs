using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    /// <summary>
    /// 允许在该元素中添加子元素
    /// </summary>
    interface IContainsElements
    {
        /// <summary>
        /// 一个图中所有的节点（指节点模型）
        /// </summary>
        ObservableCollection<ProcessElementInDiagram> Nodes { get; set; }
        /// <summary>
        /// 一个图中所有的连接（指连接模型）
        /// </summary>
        ObservableCollection<LinkViewModel> Links { get; set; }
    }
}
