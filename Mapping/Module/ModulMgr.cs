using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using DOL.Tools.Mapping.Forms;
using DOL.Tools.Mapping.Map;
using DOL.Tools.QuestDesigner.Util;
using DOL.Tools.QuestDesigner;
using System.Collections.Generic;
using DOL.Tools.Mapping.DX;

namespace DOL.Tools.Mapping.Modules
{

    public enum ModulEvent
    {
        Load = 0,
        Unload = 1,        
        RegionLoad = 4,
        RegionUnload = 5,
        DXClick = 6,        
        Filter = 9,
        Unfilter = 10,        
    }

    public class ModulMgr
    {
        private static List<IModul> m_Modules = new List<IModul>();                     

        public static void LoadModules()
        {            
            foreach (IModul modul in m_Modules)
            {
                ModulAttribute attrib = GetModulAttributeForType(modul.GetType());

                if (attrib.InFilterList)                
                    QuestDesignerMain.DesignerForm.DXControl.AddFilter(modul.Name);                
            }            
        }

        private static ModulAttribute GetModulAttributeForType(Type type)
        {
            object[] attribs = type.GetCustomAttributes(typeof(ModulAttribute), false);

            if (attribs.Length <= 0)
                return null;            

            foreach (object obj in attribs)
            {
                if (obj is ModulAttribute)
                {
                    return (ModulAttribute) obj;
                }
            }
            return null;
        }

        public static void PreloadModules()
        {           
            Assembly asmly = Assembly.GetCallingAssembly();

            foreach (Type type in asmly.GetTypes())
            {
                if (type == null)
                    continue;

                ModulAttribute attrib = GetModulAttributeForType(type);

                if (attrib == null)
                    continue;                               

                

                IModul o = (IModul)Activator.CreateInstance(type);                
                m_Modules.Add(o);                
            }
            TriggerModules(ModulEvent.Load);            
        }

        public static void UnloadModules()
        {            
            TriggerModules(ModulEvent.Unload);            
        }

        public static void TriggerModules(ModulEvent modulevent, params object[] args)
        {
            foreach (IModul mdl in m_Modules)
            {
                TriggerModule(mdl,modulevent,args);
            }
        }

        public static void TriggerModule(IModul mdl, ModulEvent modulevent, params object[] args)
        {
            switch (modulevent)
            {
                case ModulEvent.DXClick:
                    mdl.DXClick((MouseEventArgs) args[0]);
                    break;
                case ModulEvent.Load:
                    mdl.Load();
                    break;
                case ModulEvent.RegionLoad:
                    mdl.RegionLoad((RegionMgr.Region) args[0]);
                    break;
                case ModulEvent.RegionUnload:
                    mdl.RegionUnload((RegionMgr.Region) args[0]);
                    break;
                case ModulEvent.Unload:
                    mdl.Unload();
                    break;
                case ModulEvent.Filter:                    
                    mdl.Filter();
                    break;
                case ModulEvent.Unfilter:
                    mdl.Unfilter();
                    break;                
            }
        }

        public static IModul GetModulByName(string name)
        {
            foreach (IModul mod in m_Modules)
            {
                if (mod.Name == name)
                    return mod;
            }
            return null;
        }        

        public static GeometryObj GetObjectAt(int x, int y)
        {
            GeometryObj obj = null;

            List<GeometryObj> objects = GetObjectsAt(x, y);

            foreach (GeometryObj o in objects) {
                if (obj == null || o.DrawLevel > obj.DrawLevel)
                    obj = o;
            }            
            return obj;
        }

        public static List<GeometryObj> GetObjectsAt(int x, int y)
        {
            List<GeometryObj> items = new List<GeometryObj>();

            if (RegionMgr.CurrentRegion != null)
            {
                foreach (IModul mod in m_Modules)
                {
                    GeometryObj obj = mod.GetObjectAt(x, y);
                    if (obj != null)
                        items.Add(obj);

                }
            }
            return items;
        }
    }
}