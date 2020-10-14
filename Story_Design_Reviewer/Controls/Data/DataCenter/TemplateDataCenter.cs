using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    class TemplateDataCenter:ObservableObject
    {
        #region 变量

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
        private TemplateDataCenter() { }
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
        //void GetTempleteText()
        //{
        //    TempleteDataText = RWXml.GetInstence().GetOneLayerAllElement("Language_" + AppDataCenter.GetInstence().Language);
        //}

        #endregion
    }
}
