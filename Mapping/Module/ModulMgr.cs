using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using DOL.Tools.Mapping.Forms;
using DOL.Tools.Mapping.Map;
using DOL.Tools.QuestDesigner.Util;
using DOL.Tools.QuestDesigner;

namespace DOL.Tools.Mapping.Modules
{
    public class ModulMgr
    {
        private static ArrayList m_Modules = new ArrayList();
        private static ModulObj m_ActiveModul;
        private static bool m_Dirty = false;

        public static bool Dirty
        {
            get { return m_Dirty; }
            set { m_Dirty = value; }
        }

        public static ModulObj ActiveModul
        {
            get { return m_ActiveModul; }
        }

        public class ModulObj
        {
            private string m_Name;
            private Type m_Type;
            private IModul m_Modul;

            public string Name
            {
                get { return m_Name; }
                set { m_Name = value; }
            }

            public Type Type
            {
                get { return m_Type; }
                set { m_Type = value; }
            }

            public IModul Modul
            {
                get { return m_Modul; }
                set { m_Modul = value; }
            }

            public ModulObj(string name, Type type, IModul mod)
            {
                Name = name;
                Type = type;
                Modul = mod;
            }
        }

        public static void LoadModules()
        {
            Log.Info("Loading Modules...");
            foreach (ModulObj modulObj in m_Modules)
            {
                ModulAttribute attrib = GetModulAttributeForType(modulObj.Type);

                if (attrib.InFilterList)                
                    QuestDesignerMain.DesignerForm.DXControl.AddFilter(modulObj.Name);
                //if (list)
                // QuestDesignerMain.DesignerForm.DXControl.contextMenuStrip.MenuItems.Add(name, new EventHandler(Instances.DialogMain.ModulClick));
            }

            Log.Info("Loading Modules finished.");
            QuestDesignerMain.DesignerForm.Update();
        }

        public static ModulAttribute GetModulAttributeForType(Type type)
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

                if (type.Namespace == null)
                    continue;

                if (type.IsSubclassOf(typeof(IModul)))
                    continue;

                ModulAttribute attrib = GetModulAttributeForType(type);

                if (attrib == null || String.IsNullOrEmpty(attrib.ModulName))
                    continue;                               

                Log.Info("Loading Module: " + attrib.ModulName);

                IModul o = (IModul)Activator.CreateInstance(type);
                ModulObj mod = new ModulObj(attrib.ModulName, type, o);
                m_Modules.Add(mod);                

                o.Load();
            }

            Log.Info("Preloading Modules finished.");                        
        }

        public static void UnloadModules()
        {
            Log.Info("Unloading Modules..");
            foreach (ModulObj mod in m_Modules)
            {
                Log.Info("Unloading Modul: " + mod.Name);
                mod.Modul.Unload();
            }
            //Instances.DialogMain.StatusChangeStatus("Clearing Modullist..");
            //m_Modules.Clear();
            //Instances.DialogMain.StatusChangeStatus("Ready");
        }

        public static void TriggerModule(ModulEvent modulevent, params object[] args)
        {
            foreach (ModulObj mdl in m_Modules)
            {
                switch (modulevent)
                {                    
                    case ModulEvent.DXClick:
                        mdl.Modul.DXClick((MouseEventArgs) args[0]);
                        break;
                    case ModulEvent.Load:
                        mdl.Modul.Load();
                        break;
                    case ModulEvent.RegionLoad:
                        mdl.Modul.RegionLoad((RegionMgr.Region) args[0]);
                        break;
                    case ModulEvent.RegionUnload:
                        mdl.Modul.RegionUnload((RegionMgr.Region) args[0]);
                        break;
                    case ModulEvent.Unload:
                        mdl.Modul.Unload();
                        break;
                    case ModulEvent.Filter:
                        mdl.Modul.Filter((ModulObj) args[0]);
                        break;
                    case ModulEvent.Unfilter:
                        mdl.Modul.Unfilter((ModulObj) args[0]);
                        break;
                    case ModulEvent.ClearDirty:
                        mdl.Modul.ClearDirty();
                        break;
                }
            }
        }

        public static void SwitchModul(ModulObj newmodul)
        {
            if (m_ActiveModul != null)
            {
                m_ActiveModul.Modul.Deactivate();
                m_ActiveModul = null;
            }

            //Instances.DialogMain.DXControl.contextMenu.MenuItems.Clear();

            if (newmodul != null)
            {
                m_ActiveModul = newmodul;
                m_ActiveModul.Modul.Activate();
            }
        }

        public static ModulObj GetModulByName(string name)
        {
            foreach (ModulObj mod in m_Modules)
            {
                if (mod.Name == name)
                    return mod;
            }
            return null;
        }

        public enum ModulEvent
        {
            Load = 0,
            Unload = 1,
            DBConnect = 2,
            DBDisconnect = 3,
            RegionLoad = 4,
            RegionUnload = 5,
            DXClick = 6,
            Activate = 7,
            Deactivate = 8,
            Filter = 9,
            Unfilter = 10,
            ClearDirty = 11,
        }

        public static IMapObject GetObjectAt(int x, int y)
        {
            IMapObject obj = null;

            if (RegionMgr.CurrentRegion != null)
            {
                foreach (ModulObj mod in m_Modules)
                {
                    obj = mod.Modul.GetObjectAt(x, y);
                    if (obj != null)
                        break;

                }
            }
            return obj;
        }

        public static ArrayList GetDirtyObjects()
        {
            ArrayList items = new ArrayList();

            foreach (ModulObj mod in m_Modules)
                items.AddRange(mod.Modul.GetObjects());

            return items;
        }
    }
}