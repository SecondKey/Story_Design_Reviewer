using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Story_Design_Reviewer
{
    /// <summary>
    /// 在体系中的一个单位
    /// 指钱中的“元”，时间中的“时”等单位
    /// </summary>
    struct SystemUnit
    {
        /// <summary>
        /// 单位名称
        /// </summary>
        public string name;
        /// <summary>
        /// 单位的进制
        /// </summary>
        public int scale;
        /// <summary>
        /// 每个等级的名称
        /// 如果为空的话，则使用标准格式
        /// 如果有，在达到该等级时显示为指定字符串
        /// "少尉","上校"
        /// </summary>
        public List<string> levelList;

        /// <summary>
        /// 标准格式在数字之前的字符串
        /// "xx"1,"xx"2
        /// </summary>
        public string stringBefor;
        /// <summary>
        /// 标准格式在数字之后的字符串
        /// 2"xx"，4"xx"
        /// </summary>
        public string stringAfter;
    }
    /// <summary>
    /// 单个体系的基础体系，指在剧情中添加的一个体系
    /// 时间体系，货币体系，等级体系等
    /// </summary>
    class StorySystemBase
    {
        /// <summary>
        /// 体系的名称
        /// </summary>
        public string SystemName = "";
        /// <summary>
        /// 体系中元素的进制关系
        /// 元素+元素进制
        /// 从0-n成递增关系
        /// </summary>
        List<SystemUnit> systemList = new List<SystemUnit>();
        /// <summary>
        /// 体系的顺序，根据体系名获取在systemlist中的位置
        /// </summary>
        Dictionary<string, int> listOrder = new Dictionary<string, int>();
        /// <summary>
        /// 使用默认进制
        /// </summary>
        bool useCommon = false;
        /// <summary>
        /// 返回体系中节点的数量
        /// </summary>
        public int ListCount { get { return systemList.Count; } }

        /// <summary>
        /// 给出起始和结束，获取目标在起始和结束中间的比例
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public float GetRatio(long[] start, long[] end, long[] target)
        {
            return (float)(ChangeToMin(target) - ChangeToMin(start) / (ChangeToMin(end) - ChangeToMin(start)));
        }

        /// <summary>
        /// 将给定的数组转换为字符串
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public List<string> ChangeToString(long[] target)
        {
            List<string> tmp = new List<string>();
            for (int i = 0; i < target.Length; i++)
            {
                tmp.Add(GetUnitString(i, target[i]));
            }
            return tmp;
        }

        /// <summary>
        /// 获取指定一个数在指定单位的表示
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public string GetUnitString(int unit, long num)
        {
            SystemUnit tmp = systemList[unit];
            if (tmp.levelList.Count == 0)
            {
                return tmp.stringBefor + num + tmp.stringAfter;
            }
            else
            {
                return tmp.levelList[(int)num];
            }
        }

        /// <summary>
        /// 将所有数据转换为最低的数据
        /// </summary>
        /// <param name="targets"></param>
        /// <returns></returns>
        public double ChangeToMin(long[] target)
        {
            long numTmp = 0;
            long scaleTmp = 1;

            for (int i = 0; i < target.Length; i++)
            {
                numTmp += target[i] * scaleTmp;
                scaleTmp = systemList[i].scale;
            }
            return numTmp;
        }

    }
}
