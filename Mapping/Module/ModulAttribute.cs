using System;

namespace DOL.Tools.Mapping.Modules
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModulAttribute : Attribute
    {
        
        private bool m_InModulList;
        private bool m_InFilterList;

        public bool InModulList
        {
            get { return m_InModulList; }
            set { m_InModulList = value; }
        }

        public bool InFilterList
        {
            get { return m_InFilterList; }
            set { m_InFilterList = value; }
        }

        

        public ModulAttribute(bool inmodullist, bool infilterlist)
        {            
            m_InModulList = inmodullist;
            m_InFilterList = infilterlist;
        }
    }
}