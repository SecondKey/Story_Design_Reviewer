using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    interface iRADProjectObject : iRADObject
    {
        void CreateProject();
        void SaveProject();
        void TemporarySave();


    }
}
