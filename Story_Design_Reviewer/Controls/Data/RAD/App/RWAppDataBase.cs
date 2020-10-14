using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    class RWAppDataBase : iRADObject
    {
        public RWAppDataBase(string path, string name)
        {
            LoadFile(path, name);
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

        public Dictionary<string, string> GetOneLayerElements(params string[] parameter)
        {
            throw new NotImplementedException();
        }

        public void LoadFile(string path, string name)
        {
            throw new NotImplementedException();
        }
    }
}
