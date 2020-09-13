using ArxOne.MrAdvice.Advice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Design_Reviewer.Controls.UndoRedo
{
    class UndoRedoAdvice:Attribute ,IAdvice
    {
        public string propertyName;
        public object oldValue;
        public object newValue;
        
        public void Advise(MethodAdviceContext context)
        {
            
        }
    }
}
