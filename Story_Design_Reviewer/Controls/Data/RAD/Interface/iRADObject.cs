using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    interface iRADObject
    {
        #region 加载
        /// <summary>
        /// 加载一个文件
        /// </summary>
        void LoadFile(string path,string name);
        #endregion

        #region 读取数据
        /// <summary>
        /// 获取一个元素
        /// </summary>
        string GetOneElement(params string[] parameters);
        /// <summary>
        /// 获取一个层中所有的元素
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Dictionary<string, string> GetOneLayerElements(params string[] parameter);
        /// <summary>
        /// 获取一个层下所有的层
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        List<string> GetAllLayer(params string[] parameter);
        /// <summary>
        /// 获取一个层下所有的层中所有的元素
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Dictionary<string, Dictionary<string, string>> GetDoubleLayerElements(params string[] parameter);

        int GetElementNum();
        int GetLayerNum();
        #endregion
    }
}
