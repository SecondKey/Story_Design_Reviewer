using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    class LinkViewModel:ViewModelBase
    {
                /// <summary>
        /// 原节点
        /// </summary>
        [Browsable(false)]
        public ProcessElementViewModel Source { get; private set; }
        /// <summary>
        /// 原节点的端口
        /// </summary>
        [Browsable(false)]
        public PortType SourcePort { get; private set; }
        /// <summary>
        /// 目标节点
        /// </summary>
        [Browsable(false)]
        public ProcessElementViewModel Target { get; private set; }
        /// <summary>
        /// 目标节点的端口
        /// </summary>
        [Browsable(false)]
        public PortType TargetPort { get; private set; }

        /// <summary>
        /// 连接的信息
        /// </summary>
        private string linkInfo;
        /// <summary>
        /// 连接的信息
        /// </summary>
        public string LinkInfo
        {
            get { return linkInfo; }
            set
            {
                linkInfo = value;
                RaisePropertyChanged(() => LinkInfo);
            }
        }

        /// <summary>
        /// 连接的文本
        /// </summary>
        private string linkText;
        /// <summary>
        /// 连接的文本
        /// </summary>
        public string LinkText
        {
            get { return linkText; }
            set 
            {
                linkText = value;
                RaisePropertyChanged(() => LinkText);
            }
        }

        public LinkViewModel(ProcessElementViewModel source, PortType sourcePort, ProcessElementViewModel target, PortType targetPort)
        {
            Source = source;
            SourcePort = sourcePort;
            Target = target;
            TargetPort = targetPort;
        }     
    }
}
