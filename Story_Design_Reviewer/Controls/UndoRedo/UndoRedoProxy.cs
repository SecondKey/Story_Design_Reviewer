using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    public enum UndoRedoProxyState
    {
        newValue,
        oldValue,
    }

    class UndoRedoStruct
    {
        public UndoRedoStruct last;
        public UndoRedoStruct next;

        public UndoRedoType type;

        public string propertyName;
        public object oldValue;
        public object newValue;
    }

    class UndoRedoProxy
    {
        public UndoRedoProxy(ProcessElement element, string name,object oldValue,object newValue)
        {
            
        }

        public UndoRedoProxy(ProcessElement element,string name,object value, UndoRedoOperationType operation)
        {
            
        }

        /// <summary>
        /// 下一个操作元素
        /// </summary>
        public UndoRedoProxy next;
        /// <summary>
        /// 上一个操作元素
        /// </summary>
        public UndoRedoProxy last;
        /// <summary>
        /// 当前的操作
        /// </summary>
        UndoRedoStruct nowUndoRedoOperation;
        /// <summary>
        /// 操作的元素
        /// </summary>
        public ProcessElement targetElement;

        /// <summary>
        /// 撤销
        /// 如果当前为新值，则将值改为旧值，返回true
        /// 如果已经为旧值，判断是否为该元素上第一个操作
        /// 如果不是第一个，指针指向前一个操作，并将值改为旧值返回true
        /// 如果是第一个，返回false
        /// </summary>
        /// <returns></returns>
        public bool Undo()
        {
            if (targetElement.GetType().GetProperty(nowUndoRedoOperation.propertyName).GetValue(targetElement) != nowUndoRedoOperation.oldValue)
            {
                targetElement.GetType().GetProperty(nowUndoRedoOperation.propertyName).SetValue(targetElement, nowUndoRedoOperation.oldValue);
            }
            else
            {
                if (nowUndoRedoOperation.last != null)
                {
                    nowUndoRedoOperation = nowUndoRedoOperation.last;
                    targetElement.GetType().GetProperty(nowUndoRedoOperation.propertyName).SetValue(targetElement, nowUndoRedoOperation.oldValue);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 重做
        /// 如果当前为旧值，则将值改为新值，返回true
        /// 如果已经为新值，判断是否为该元素上最后一个操作
        /// 如果不是第最后一个，指针指向下一个操作，并将值改为新值返回true
        /// 如果是最后一个，返回false
        /// </summary>
        /// <returns></returns>
        public bool Redo()
        {
            if (targetElement.GetType().GetProperty(nowUndoRedoOperation.propertyName).GetValue(targetElement) != nowUndoRedoOperation.newValue)
            {
                targetElement.GetType().GetProperty(nowUndoRedoOperation.propertyName).SetValue(targetElement, nowUndoRedoOperation.newValue);
            }
            else
            {
                if (nowUndoRedoOperation.next != null)
                {
                    nowUndoRedoOperation = nowUndoRedoOperation.next;
                    targetElement.GetType().GetProperty(nowUndoRedoOperation.propertyName).SetValue(targetElement, nowUndoRedoOperation.newValue);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
