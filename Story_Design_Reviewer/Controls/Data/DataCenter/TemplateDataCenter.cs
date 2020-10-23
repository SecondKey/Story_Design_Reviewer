using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{

    /// <summary>
    /// 模板的数据核心
    /// </summary>
    class TemplateDataCenter : ObservableObject
    {
        #region 基本成员变量
        /// <summary>
        /// 模板的核心数据
        /// </summary>
        RWXml mainTemplateXml;
        /// <summary>
        /// 模板的全部数据
        /// </summary>
        Dictionary<string, iRADObject> allTemplateData = new Dictionary<string, iRADObject>();
        /// <summary>
        /// 模板要加载的dll
        /// </summary>
        Dictionary<string, LoadTemplatePackage> allPackage = new Dictionary<string, LoadTemplatePackage>();
        /// <summary>
        /// 模板要加载的系统
        /// </summary>
        Dictionary<string, iTemplateSystem> allSystem = new Dictionary<string, iTemplateSystem>();
        #endregion

        #region 单例/加载
        private static TemplateDataCenter instence;
        public static TemplateDataCenter GetInstence()
        {
            if (instence == null)
            {
                instence = new TemplateDataCenter();
            }
            return instence;
        }
        private TemplateDataCenter()
        {
            mainTemplateXml = new RWXml(AppDataCenter.GetInstence().templatePath, "TemplateData.xml");
            foreach (var path in mainTemplateXml.GetDoubleLayerElements("Load", "Xml"))
            {
                foreach (var file in path.Value)
                {
                    allTemplateData.Add(file.Value, new RWXml(AppDataCenter.GetInstence().templatePath + path.Key, file.Key + ".xml"));
                }
            }

            GetTempleteText();
        }
        #endregion

        #region DataText
        private Dictionary<string, string> templeteDataText;
        public Dictionary<string, string> TempleteDataText
        {
            get { return templeteDataText; }
            set
            {
                templeteDataText = value;
                RaisePropertyChanged(() => TempleteDataText);

            }
        }
        void GetTempleteText()
        {
            TempleteDataText = allTemplateData["Language_" + AppDataCenter.GetInstence().Language].GetOneLayerElements();
        }

        #endregion
    }
}
