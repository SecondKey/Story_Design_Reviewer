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
        public static void SendMsg(AppMsg tmp)
        {
            Messenger.Default.Send<AppMsg>(tmp, tmp.msg);
        }

        public static void RegistSelf(object target, AllAppMsg msg, Action<AppMsg> action)
        {
            Messenger.Default.Register(target, msg, action);
        }
    }

    public class AppMsg
    {
        public AllAppMsg msg;

        public AppMsg(AllAppMsg msg)
        {
            this.msg = msg;
        }
    }

    public class MsgDebugText : AppMsg
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

    public class MsgInt : AppMsg
    {
        public int parameter;

        public MsgInt(AllAppMsg msg, int parameter) : base(msg)
        {
            this.parameter = parameter;
        }
    }

    public class MsgString : AppMsg
    {
        public string parameter;

        public MsgString(AllAppMsg msg, string parameter) : base(msg)
        {
            this.parameter = parameter;
        }
    }

    public class MsgError : AppMsg
    {
        public ErrorType errorType;

        public List<string> errorSources;

        public MsgError(AllAppMsg msg) : base(msg)
        {
        }
    }

    public class MsgElementOptions : AppMsg
    {
        public ProcessElement targetElement;

        public ElementType elementType;

        public OptionsType optionsType;

        public MsgElementOptions(AllAppMsg msg, ProcessElement targetElement, ElementType elementType, OptionsType optionsType) : base(msg)
        {
            this.targetElement = targetElement;
            this.elementType = elementType;
            this.optionsType = optionsType;
        }
    }
}
