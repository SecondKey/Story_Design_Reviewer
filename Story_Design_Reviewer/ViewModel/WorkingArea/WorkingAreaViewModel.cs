using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    public class WorkingAreaViewModel: DataViewModelBase
    {
        #region test
        private ObservableCollection<string> testList = new ObservableCollection<string>()
        {
            "123",
            "123",
            "123",
            "123",
            "123",
            "123",
            "123",
            "123",
            "123"
        };
        public ObservableCollection<string> TestList
        {
            get { return testList; }
            set
            {
                testList = value;
                RaisePropertyChanged(() => TestList);
            }
        }
        #endregion

    }
}
