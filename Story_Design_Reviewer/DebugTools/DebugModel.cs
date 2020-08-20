using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer.DebugTools
{
    class DebugModel : ObservableObject
    {
        public DebugModel(string origin, string text)
        {
            Origin = origin;
            DebugText = text;
        }

        private string origin;
        public string Origin
        {
            get { return origin; }
            set
            {
                origin = value;
                RaisePropertyChanged(() => Origin);
            }
        }

        private string debugText;
        public string DebugText
        {
            get { return debugText; }
            set
            {
                debugText = value;
                RaisePropertyChanged(() => DebugText);
            }
        }


    }
}
