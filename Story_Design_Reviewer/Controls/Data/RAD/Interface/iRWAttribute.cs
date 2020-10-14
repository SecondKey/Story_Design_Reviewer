using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    interface iRWAttribute
    {
        /// <summary>
        /// 获取一个元素一个属性值
        /// </summary>
        string GetOneAttribute(params string[] parameters);
        /// <summary>
        /// 获取一个元素的所有属性值
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetOneLayerAllAttribute(params string[] parameters);
        /// <summary>
        /// 获取一个层中所有的元素的某个属性值
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetAllLayerOneAttribute(params string[] parameters);
        /// <summary>
        /// 获取一个层中所有元素的所有值
        /// </summary>
        /// <returns></returns>
        Dictionary<string, Dictionary<string, string>> GetAllLayerAllAttribute(params string[] parameters);
        /// <summary>
        /// 获取两个层级的全部元素中的一个属性值
        /// </summary>
        /// <returns></returns>
        Dictionary<string, Dictionary<string, string>> GetDoubleLayerOneAttribute(params string[] parameters);
    }
}
