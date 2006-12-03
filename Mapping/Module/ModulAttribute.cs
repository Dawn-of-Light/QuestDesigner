using System;

namespace DOL.Tools.Mapping.Modules
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModulAttribute : Attribute
    {
        private string m_ModulName;
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

        public string ModulName
        {
            get { return m_ModulName; }
            set { m_ModulName = value; }
        }

        public ModulAttribute(string modulname, bool inmodullist, bool infilterlist)
        {
            m_ModulName = modulname;
            m_InModulList = inmodullist;
            m_InFilterList = infilterlist;
        }
    }
}