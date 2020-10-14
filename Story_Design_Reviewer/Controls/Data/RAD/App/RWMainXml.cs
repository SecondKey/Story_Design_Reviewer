using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    class RWMainXml : RWAPPXml,iRWAttribute
    {
        public RWMainXml(string path, string name) : base(path, name)
        {
        }


        #region iRWAttribute Members
        public Dictionary<string, Dictionary<string, string>> GetAllLayerAllAttribute(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetAllLayerOneAttribute(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Dictionary<string, string>> GetDoubleLayerOneAttribute(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public string GetOneAttribute(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetOneLayerAllAttribute(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
