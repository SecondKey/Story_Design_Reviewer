using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer.Controls
{
    class ProcessElementControl
    {
        #region 单例
        private static ProcessElementControl instence;
        private ProcessElementControl() { }
        public static ProcessElementControl GetInstence()
        {
            if (instence == null)
            {
                instence = new ProcessElementControl();
            }
            return instence;
        }
        #endregion

        public ProcessElementNode GetElementNode(string type)
        {
            return new ProcessElementNode(type);
        }

        public ProcessElementNode GetElementNode(ProcessElement target)
        {
            return new ProcessElementNode(target);

        }

    }
}
