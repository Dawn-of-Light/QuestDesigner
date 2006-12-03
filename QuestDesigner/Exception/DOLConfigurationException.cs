using System;
using System.Collections.Generic;
using System.Text;

namespace DOL.Tools.QuestDesigner.Exceptions 
{
    class DOLConfigurationException : System.Exception
    {
        public DOLConfigurationException(): base() {}

        public DOLConfigurationException(String msg) : base(msg) {}        
    }
}
