using GalaSoft.MvvmLight;
using Story_Design_Reviewer.Models;
using Story_Design_Reviewer.RW;
using Story_Design_Reviewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    public class ErrorElementModel : ObservableObject
    {
        public string ErrorText { get; set; }

        public string ErrorElementName { get; set; }

        public string ErrorInfo { get; set; }

        ProcessElement element;

        public ErrorElementModel(ErrorType errorType, ProcessElement errorElement)
        {
            element = errorElement;
            ErrorText = ErrorTypeText(errorType);
            ErrorElementName = errorElement.ElementName;
            ErrorInfo = ErrorText + "\n" + ErrorInfoText(errorType);
        }

        string ErrorTypeText(ErrorType type)
        {
            return RWXml.GetInstence().GetOneElement("Language_" + ViewModelLocator.instence.MainWindow.Language, "Error_" + type.ToString());
        }

        string ErrorInfoText(ErrorType type)
        {
            string info = "";
            foreach (var kv in RWXml.GetInstence().GetOneLayerAllElement("Language_" + ViewModelLocator.instence.MainWindow.Language, "ErrorInfo_" + type.ToString()))
            {
                info = info + kv.Value + GetElementInfo(kv.Key);
            }

            string path = "";
            List<string> pathList = element.GetElementPath(new List<string>());
            for (int i = 0; i < pathList.Count; i++)
            {
                path = path + pathList[pathList.Count - i - 1] + "\n";
            }

            string tmp = info + "\n\n"
                    + RWXml.GetInstence().GetOneElement("Language_" + ViewModelLocator.instence.MainWindow.Language, "ErrorText_ErrorPath")
                    + "\n"
                    + path;
            return tmp;
        }

        string GetElementInfo(string t)
        {
            switch (t)
            {
                case "ElementName":
                    return element.ElementName;
                default:
                    return "";
            }
        }
    }
}
