using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Story_Design_Reviewer
{
    public class ErrorCenter : ObservableObject
    {
        #region 单例
        private static ErrorCenter instence;
        private ErrorCenter()
        {

        }
        public static ErrorCenter GetInstence()
        {
            if (instence == null)
            {
                instence = new ErrorCenter();
            }
            return instence;
        }
        #endregion



    }
}
