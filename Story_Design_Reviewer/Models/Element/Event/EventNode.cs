using Story_Design_Reviewer.Models.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer.Models.Element.Event
{
    public enum TimeRecordTyep
    {
        Int,
        Float,
        Time,
        DateTime,
    }

    class TimeOfEvent
    {

        private string time;
        private TimeRecordTyep timeType;

        public TimeOfEvent(string time, TimeRecordTyep type)
        {
            timeType = type;
            this.time = time;
        }

        public void ChangeType(TimeRecordTyep newType)
        {
            timeType = newType;
        }

        public void SetTime(object t)
        {
            time = t.ToString();
        }
    }

    public class EventNode : EventNodeBase
    {
        public EventNode(string elementName, ProcessElement parent, Vector v2, bool loadData) : base(elementName, parent, v2, loadData)
        {
        }


        //TODO:事件节点加载数据
        public override void LoadEventData()
        {

        }

        #region 子节点
        private List<EventNodeBase> eventLsit = new List<EventNodeBase>();
        public List<EventNodeBase> EventList
        {
            get { return eventLsit; }
            set
            {
                eventLsit = value;
                RaisePropertyChanged(() => EventList);
            }
        }


        #endregion

        #region 事件名
        bool UseAutoName = false;

        public override string ElementName
        {
            get
            {
                return base.ElementName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    UseAutoName = true;
                    base.ElementName = parentElement.ElementName + "_" + ((EventNode)parentElement).GetUnUsedNum();
                }
                else
                {
                    UseAutoName = false;
                    base.ElementName = value;
                }
            }
        }

        public string[] GetTreeName(List<string> list)
        {
            if (ParentElement != null)
            {
                list.Add(ElementName);
                return ((EventNode)ParentElement).GetTreeName(list);
            }
            else
            {
                list.Reverse();
                return list.ToArray();
            }
        }

        public void ParendNameChange()
        {
            if (UseAutoName == true)
            {
                ElementName = null;
            }
        }
        #endregion

        #region 事件信息
        private string eventInfo;
        public string EventInfo
        {
            get { return eventInfo; }
            set
            {
                eventInfo = value;
            }
        }
        #endregion

        #region 时间和时间轴
        private TimeRecordTyep tineRecordType;
        public TimeRecordTyep TimeRecordType
        {
            get { return tineRecordType; }
            set { tineRecordType = value; }
        }

        private string eventStartTime;
        public object EventStartTime
        {
            get
            {
                switch (((EventNode)ParentElement).TimeRecordType)
                {
                    case TimeRecordTyep.Int:
                        return int.Parse(eventStartTime);
                    case TimeRecordTyep.Float:
                        return float.Parse(eventStartTime);
                    case TimeRecordTyep.Time:
                        return new int[3] { int.Parse(eventStartTime.Substring(0, 2)), int.Parse(eventStartTime.Substring(2, 2)), int.Parse(eventStartTime.Substring(4, 2)) };
                    case TimeRecordTyep.DateTime:
                        return new KeyValuePair<string, int[]>(eventStartTime.Split(',')[0], new int[3]
                        {
                        int.Parse(eventStartTime.Split(',')[1].Substring(0, 2)),
                        int.Parse(eventStartTime.Split(',')[1].Substring(2, 2)),
                        int.Parse(eventStartTime.Split(',')[1].Substring(4, 2))
                        });
                    default:
                        return null;
                }
            }
            set { eventStartTime = (string)value; }
        }

        private string eventEndTime;
        public object EventEndTime
        {
            get
            {
                switch (((EventNode)ParentElement).TimeRecordType)
                {
                    case TimeRecordTyep.Int:
                        return int.Parse(eventEndTime);
                    case TimeRecordTyep.Float:
                        return float.Parse(eventEndTime);
                    case TimeRecordTyep.Time:
                        return new int[3] { int.Parse(eventEndTime.Substring(0, 2)), int.Parse(eventEndTime.Substring(2, 2)), int.Parse(eventEndTime.Substring(4, 2)) };
                    case TimeRecordTyep.DateTime:
                        return new KeyValuePair<string, int[]>(eventEndTime.Split(',')[0], new int[3]
                        {
                        int.Parse(eventEndTime.Split(',')[1].Substring(0, 2)),
                        int.Parse(eventEndTime.Split(',')[1].Substring(2, 2)),
                        int.Parse(eventEndTime.Split(',')[1].Substring(4, 2))
                        });
                    default:
                        return null;
                }
            }
            set { eventEndTime = (string)value; }
        }

        #endregion

        #region 用于为该事件下未命名的子事件命名
        private int nowEventNum = 0;
        private List<int> unUsedEventNum = new List<int>();


        public int GetUnUsedNum()
        {
            if (unUsedEventNum.Count > 0)
            {
                return unUsedEventNum[0];
            }
            else
            {
                nowEventNum += 1;
                return nowEventNum;
            }
        }
        public void AddUnUsedName(int num)
        {
            unUsedEventNum.Add(num);
            unUsedEventNum.Sort();
        }
        #endregion

    }
}
