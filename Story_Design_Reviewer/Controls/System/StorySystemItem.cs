using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    class StorySystemItem
    {
        /// <summary>
        /// 所属的体系
        /// </summary>
        StorySystemBase baseSystem;
        /// <summary>
        /// 当前item所有的数据
        /// 从小到大排序
        /// </summary>
        long[] itemList;
        
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="baseSystem"></param>
        /// <param name="allNum"></param>
        public StorySystemItem(StorySystemBase baseSystem, params long[] allNum)
        {
            this.baseSystem = baseSystem;
            itemList = allNum;
        }

        /// <summary>
        /// 将当前的数据根据所属体系转化为字符串
        /// </summary>
        /// <returns></returns>
        public List<string> GetString()
        {
            return baseSystem.ChangeToString(itemList);
        }
    }
}
