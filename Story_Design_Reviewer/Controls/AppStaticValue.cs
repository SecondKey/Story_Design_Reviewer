using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer
{
    public enum AllAppMsg
    {
        #region Debug
        ShowDebugText,
        #endregion

        #region AppSettings
        ChangeLanguage,
        #endregion

        #region ElementOptions
        DeleteOptions,

        #endregion
    }

    public enum ElementType
    {
        Role,
        MainTimeLine,
        Event,
        SimpleEvent,
        SpecialEvent,
        Motive,
        Behavior,
        Relation
    }

    public enum ErrorType
    {
        LostMotivation,
    }

    public enum OptionsType
    {

    }

    public class AppStaticValue
    {

    }
}
