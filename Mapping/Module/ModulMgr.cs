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
        DBConnect = 2,
        DBDisconnect = 3,
        RegionLoad = 4,
        RegionUnload = 5,
        DXClick = 6,        
        Filter = 9,
        Unfilter = 10,
        ClearDirty = 11,
    }

    public class ModulMgr
    {
        private static List<IModul> m_Modules = new List<IModul>();
        
        private static bool m_Dirty = false;

        public static bool Dirty
        {
            get { return m_Dirty; }
            set { m_Dirty = value; }
        }             

        public static void LoadModules()
        {
            Log.Info("Loading Modules...");
            foreach (IModul modul in m_Modules)
            {
                ModulAttribute attrib = GetModulAttributeForType(modul.GetType());

                if (attrib.InFilterList)                
                    QuestDesignerMain.DesignerForm.DXControl.AddFilter(modul.Name);                
            }

            Log.Info("Loading Modules finished.");
            QuestDesignerMain.DesignerForm.Update();
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
            Log.Info("Preloading Modules...");            

            Assembly asmly = Assembly.GetCallingAssembly();

            foreach (Type type in asmly.GetTypes())
            {
                if (type == null)
                    continue;

                ModulAttribute attrib = GetModulAttributeForType(type);

                if (attrib == null)
                    continue;                               

                Log.Info("Preloading Module: " + type.Name);

                IModul o = (IModul)Activator.CreateInstance(type);                
                m_Modules.Add(o);                
            }
            TriggerModules(ModulEvent.Load);

            Log.Info("Preloading Modules finished.");                        
        }

        public static void UnloadModules()
        {
            Log.Info("Unloading Modules...");
            TriggerModules(ModulEvent.Unload);
            Log.Info("Unloading Modules finished.");
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
                case ModulEvent.ClearDirty:
                    mdl.ClearDirty();
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

            if (RegionMgr.CurrentRegion != null)
            {
                foreach (IModul mod in m_Modules)
                {
                    obj = mod.GetObjectAt(x, y);
                    if (obj != null)
                        break;

                }
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

        public static List<GeometryObj> GetDirtyObjects()
        {
            List<GeometryObj> items = new List<GeometryObj>();

            foreach (IModul mod in m_Modules)
                items.AddRange(mod.GetObjects());

            return items;
        }
    }
}