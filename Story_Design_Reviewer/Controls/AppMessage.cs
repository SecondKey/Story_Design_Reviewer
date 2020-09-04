using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Story_Design_Reviewer.DebugTools;
using Story_Design_Reviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace Story_Design_Reviewer
{
    public class AppMsgCenter
    {
        public static void SendMsg(MsgBase tmp)
        {
            Messenger.Default.Send<MsgBase>(tmp, tmp.msg);
        }

        public static void RegistSelf(object target, AllAppMsg msg, Action<MsgBase> action)
        {
            Messenger.Default.Register(target, msg, action);
        }
    }

    public class MsgBase
    {
        public AllAppMsg msg;

        public MsgBase(AllAppMsg msg)
        {
            this.msg = msg;
        }
    }

    public class MsgDebugText : MsgBase
    {
        public DebugList list;
        public DebugType type;

        public string text;

        public MsgDebugText(AllAppMsg msg, DebugList list, DebugType type, string text) : base(msg)
        {
            this.list = list;
            this.type = type;
            this.text = text;
        }
    }

    public class MsgInt : MsgBase
    {
        public int parameter;

        public MsgInt(AllAppMsg msg, int parameter) : base(msg)
        {
            this.parameter = parameter;
        }
    }

    public class MsgString : MsgBase
    {
        public string parameter;

        public MsgString(AllAppMsg msg, string parameter) : base(msg)
        {
            this.parameter = parameter;
        }
    }

    public class MsgError : MsgBase
    {
        public ErrorType errorType;

        public List<string> errorSources;

        public MsgError(AllAppMsg msg) : base(msg)
        {
        }
    }

    public class MsgElementOperation : MsgBase
    {
        public ProcessElement targetElement;

        public ElementType elementType;

        public OperationType operationType;

        public MsgElementOperation(AllAppMsg msg, ProcessElement targetElement, ElementType elementType, OperationType operationType) : base(msg)
        {
            this.targetElement = targetElement;
            this.elementType = elementType;
            this.operationType = operationType;
        }
    }

    public class MsgElementChangeValue : MsgBase
    {
        public ProcessElement targetElement;

        public string propertyName;

        public MsgElementChangeValue(AllAppMsg msg) : base(msg)
        {
        }
    }
}
