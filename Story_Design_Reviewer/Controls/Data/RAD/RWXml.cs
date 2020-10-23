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
    class RWXml : iRADObject
    {
        /// <summary>
        /// 指定要加载的xml
        /// </summary>
        XDocument targetXml;
        /// <summary>
        /// 当前xml的完整路径
        /// </summary>
        string fullName;

        public RWXml(string path, string name)
        {
            fullName = path + name;
            LoadFile(path, name);
        }

        #region iRADAppObject Members

        public void LoadFile(string path, string name)
        {
            AppMsgCenter.SendMsg(new MsgDebugText(AllAppMsg.ShowDebugText, DebugTools.DebugList.RW, DebugTools.DebugType.Log, path));
            targetXml = XDocument.Load(path +"/"+ name);
        }

        public List<string> GetAllLayer(params string[] parameters)
        {
            List<string> tmp = new List<string>();

            XElement e = targetXml.Root;
            for (int i = 0; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }
            foreach (XElement layer in e.Elements())
            {
                tmp.Add(layer.Name.ToString());
            }

            return tmp;
        }

        public Dictionary<string, Dictionary<string, string>> GetDoubleLayerElements(params string[] parameters)
        {
            Dictionary<string, Dictionary<string, string>> tmp = new Dictionary<string, Dictionary<string, string>>();
            XElement e = targetXml.Root;
            for (int i = 0; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }
            foreach (XElement fLayer in e.Elements())
            {
                Dictionary<string, string> layerTmp = new Dictionary<string, string>();
                foreach (XElement sLayer in fLayer.Elements())
                {
                    layerTmp.Add(sLayer.Name.ToString(), sLayer.Value);
                }
                tmp.Add(fLayer.Name.ToString(), layerTmp);
            }
            return tmp;
        }

        public int GetElementNum(params string[] parameters)
        {
            XElement e = targetXml.Root;
            for (int i = 0; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }
            return e.Elements().Count();
        }

        public string GetOneElement(params string[] parameters)
        {
            XElement e = targetXml.Root;
            for (int i = 0; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }

            return e.Value.ToString();
        }

        public Dictionary<string, string> GetOneLayerElements(params string[] parameters)
        {
            Dictionary<string, string> tmp = new Dictionary<string, string>();
            XElement e = targetXml.Root;
            for (int i = 0; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }
            foreach (XElement element in e.Elements())
            {
                tmp.Add(element.Name.ToString(), element.Value);
            }

            return tmp;
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