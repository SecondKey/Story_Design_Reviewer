using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    class TimeAxisViewModel:ViewModelBase
    {


        private int startTime;
        public int StartTime
        {
            get { return startTime; }
            set 
            {
                startTime = value;
                RaisePropertyChanged(() => StartTime);
            }
        }

        private int timeInterval;
        public int TimeInterval
        {
            get { return timeInterval; }
            set 
            {
                timeInterval = value;
                RaisePropertyChanged(() => TimeInterval);
            }
        }

    }
}
