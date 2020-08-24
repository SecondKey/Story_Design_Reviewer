using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer.ViewModel.InspectView
{
    public class EventInspectViewModel : ViewModelBase
    {
        public EventInspectViewModel()
        {
            EventHierarchy.Add(new InspectItemStruct { ItemKey = "项目名1", ItemValue = "项目说明", AllowModify = true });
            EventHierarchy.Add(new InspectItemStruct { ItemKey = "项目名2", ItemValue = "项目说明", AllowModify = true });
            EventHierarchy.Add(new InspectItemStruct { ItemKey = "项目名3", ItemValue = "项目说明", AllowModify = false });
            
            
            EventContain.Add(new InspectItemStruct { ItemKey = "项目名1", ItemValue = "项目说明123", AllowModify = true });
            EventContain.Add(new InspectItemStruct { ItemKey = "项目名2", ItemValue = "项目说明123", AllowModify = false });
            EventContain.Add(new InspectItemStruct { ItemKey = "项目名3", ItemValue = "项目说明", AllowModify = true });
            EventContain.Add(new InspectItemStruct { ItemKey = "项目名4", ItemValue = "项目说明", AllowModify = false });
        }

        private ObservableCollection<InspectItemStruct> eventHierarchy=new ObservableCollection<InspectItemStruct>();
        public ObservableCollection<InspectItemStruct> EventHierarchy
        {
            get { return eventHierarchy; }
            set
            {
                eventHierarchy = value;
                RaisePropertyChanged(() => EventHierarchy);
            }
        }

        private ObservableCollection<InspectItemStruct> eventContain=new ObservableCollection<InspectItemStruct>();
        public ObservableCollection<InspectItemStruct> EventContain
        {
            get { return eventContain; }
            set
            {
                eventContain = value;
                RaisePropertyChanged(() => EventContain);
            }
        }


    }
}
