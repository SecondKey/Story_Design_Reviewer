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
    class RWXml
    {
        /// <summary>
        /// 所有的程序xml
        /// </summary>
        Dictionary<string, XDocument> allAppXml = new Dictionary<string, XDocument>();
        /// <summary>
        /// 当前项目应用模板xml
        /// </summary>
        XDocument templeteXml;
        /// <summary>
        /// 当前项目的xml
        /// </summary>
        XDocument projectXml;
        /// <summary>
        /// 临时xml，用于自动保存
        /// </summary>
        XDocument temporaryProjectXml;

        #region 单例
        private static RWXml instence;
        private RWXml() 
        {
                        string path = AppDataCenter.appPath;
            AppMsgCenter.SendMsg(new MsgDebugText(AllAppMsg.ShowDebugText, DebugTools.DebugList.RW, DebugTools.DebugType.Log, path));

            XDocument AppData = XDocument.Load(path + "AppData.xml");
            allAppXml.Add("AppData", AppData);
            foreach (string folder in GetAllLayer("AppData", "LoadPath"))
            {
                DirectoryInfo loadDir = new DirectoryInfo(path + folder);
                foreach (FileInfo f in loadDir.EnumerateFiles())
                {
                    XDocument xDoc = XDocument.Load(f.FullName);
                    allAppXml.Add(folder + "_" + Path.GetFileNameWithoutExtension(f.Name), xDoc);
                }
            }
        }
        public static RWXml GetInstence()
        {
            if (instence == null)
            {
                instence = new RWXml();
            }

            return instence;
        }
        #endregion



        #region AppData
        public string GetOneElement(params string[] parameters)
        {
            LogParameter(parameters);
            XElement e = allAppXml[parameters[0]].Root;
            for (int i = 1; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }
            return e.Value;
        }

        public string GetOneAttribute(params string[] parameters)
        {
            LogParameter(parameters);

            XElement e = allAppXml[parameters[0]].Root;
            int i = 1;
            for (; i < parameters.Length - 1; i++)
            {
                e = e.Element(parameters[i]);
            }

            XAttribute a = e.Attribute(parameters[i]);
            return a.Value;
        }

        public List<string> GetAllLayer(params string[] parameters)
        {
            LogParameter(parameters);

            List<string> tool = new List<string>();

            XElement e = allAppXml[parameters[0]].Root;
            for (int i = 1; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }

            foreach (XElement x in e.Elements())
            {
                tool.Add(x.Name.ToString());
            }
            return tool;
        }

        public Dictionary<string, string> GetOneLayerAllElement(params string[] parameters)
        {
            LogParameter(parameters);
            Dictionary<string, string> dictionaryTmp = new Dictionary<string, string>();

            XElement e = allAppXml[parameters[0]].Root;
            for (int i = 1; i < parameters.Length; i++)
            {
                e = e.Element(parameters[i]);
            }

            foreach (XElement x in e.Elements())
            {
                dictionaryTmp.Add(x.Name.ToString(), x.Value);
            }
            return dictionaryTmp;
        }
        #endregion

        #region Project

        #endregion

        #region Tools
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
