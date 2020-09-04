using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Policy;

namespace Story_Design_Reviewer
{
    public enum UndoRedoOperation
    {
        Delete=1,
        Create=10,
    }

    public enum UndoRedoType
    {
        Value,
        Operation,
    }
    class UndoRedoController
    {

        #region 单例
        private static UndoRedoController instence;
        private UndoRedoController()
        {
            AppMsgCenter.RegistSelf(instence, AllAppMsg.Undo, Undo<MsgBase>);
            AppMsgCenter.RegistSelf(instence, AllAppMsg.Redo, Redo<MsgBase>);
        }
        public static UndoRedoController GetInstence()
        {
            if (instence == null)
            {
                instence = new UndoRedoController();
            }
            return instence;
        }
        #endregion

        public UndoRedoProxy nowOperationProxy;

        public void NewOperation()
        {
        }

        /// <summary>
        /// 执行撤销
        /// 如果当前元素无法执行撤销，进行循环，
        /// 将元素指向上一个元素尝试撤销
        /// </summary>
        public void Undo<T>(MsgBase msg)
        {
            if (!nowOperationProxy.Undo())
            {
                while (LastOperationProxyUndo()) ;
            }
        }
        /// <summary>
        /// 执行重做
        /// 如果当前元素无法执行重做，进行循环，
        /// 将元素指向下一个元素尝试撤销，直到有元素可以执行重做或没有元素为止
        /// </summary>
        public void Redo<T>(MsgBase msg)
        {
            if (!nowOperationProxy.Redo())
            {
                while (nowOperationProxy.next != null)
                {
                    nowOperationProxy = nowOperationProxy.next;
                    if (nowOperationProxy.Redo())
                    {
                        break;
                    }
                }
            }
        }

        public void NextOperationProxy()
        {
            
        }


        /// <summary>
        /// 判断是否为第一个操作对象
        /// 如果是返回false
        /// 如果不是，将元素指向上一个元素执行撤销
        /// 返回false说明操作已经被处理
        /// 返回true说明操作需要继续被执行
        /// </summary>
        /// <returns></returns>
        public bool LastOperationProxyUndo()
        {
            if (nowOperationProxy.last != null)
            {
                nowOperationProxy = nowOperationProxy.last;
                if (!nowOperationProxy.Undo())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
