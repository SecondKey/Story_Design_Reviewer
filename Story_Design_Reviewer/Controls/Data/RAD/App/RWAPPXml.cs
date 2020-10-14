using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using GalaSoft.MvvmLight.Messaging;

namespace Story_Design_Reviewer
{
    class RWAPPXml : iRADObject
    {
        /// <summary>
        /// 指定要加载的xml
        /// </summary>
        XDocument targetXml;
        
        public RWAPPXml(string path, string name)
        {
            LoadFile(path, name);
        }

        #region iRADAppObject Members

        public void LoadFile(string path, string name)
        {
            AppMsgCenter.SendMsg(new MsgDebugText(AllAppMsg.ShowDebugText, DebugTools.DebugList.RW, DebugTools.DebugType.Log, path));
            targetXml = XDocument.Load(path + name);
        }

        public List<string> GetAllLayer(params string[] parameter)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Dictionary<string, string>> GetDoubleLayerElements(params string[] parameter)
        {
            throw new NotImplementedException();
        }

        public int GetElementNum()
        {
            throw new NotImplementedException();
        }

        public int GetLayerNum()
        {
            throw new NotImplementedException();
        }

        public string GetOneElement(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetOneLayerElements(params string[] parameters)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Tools：xml的工具
        void LogParameter(params string[] parameters)
        {
            string tmp = "";
            foreach (string s in parameters)
            {
                tmp += s + ",";
            }
            AppMsgCenter.SendMsg(new MsgDebugText(AllAppMsg.ShowDebugText, DebugTools.DebugList.RW, DebugTools.DebugType.Log, tmp));

        }


        #endregion


    }
}
