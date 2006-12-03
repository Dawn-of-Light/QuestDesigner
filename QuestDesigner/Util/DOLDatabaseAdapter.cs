using System;
using System.Collections.Generic;
using System.Text;
using DOL.Database;
using DOL.GS;
using DOL.Database.Attributes;
using System.Reflection;
using System.IO;
using DOL.Database.Connection;
using System.Collections;

namespace DOL.Tools.QuestDesigner.Util
{
    public class DOLDatabaseAdapter
    {
        ObjectDatabase m_database;

        public const String ITEM_ID = "Id_nb";
        public const String ITEM_NAME = "Name";

        public const String MOB_ID = "MobID";
        public const String MOB_NAME = "Name";

        GameServerConfiguration dolConfig;        

        public DOLDatabaseAdapter()
        {
            InitConfig();
            InitDB();
        }

        public Boolean isConnected()
        {
            return dolConfig != null && m_database != null;
        }

        public void InitConfig() {
            if (dolConfig==null) {
                dolConfig = new GameServerConfiguration();
                dolConfig.LoadFromXMLFile(new FileInfo(QuestDesignerMain.WorkingDirectory + System.Configuration.ConfigurationManager.AppSettings["DOLServerConfigFile"]));
            }
        }

        public IList GetNPCList()
        {
            return m_database.SelectAllObjects(typeof(Mob));
        }

        public IList GetItemList()
        {
            return m_database.SelectAllObjects(typeof(ItemTemplate));
        }

        public String ConvertDOLColumnToXMLColumn(String dolColumnName)
        {
            if (dolColumnName.Equals(ITEM_ID))
                return "ItemTemplateID";
            else
                return dolColumnName;
        }

        public String ConvertXMLColumnToDOLColumn(String xmlColumnName)
        {
            if (xmlColumnName.Equals("ItemTemplateID"))
                return ITEM_ID;
            else
                return xmlColumnName;
        }

        public void InitDB()
        {
            if (m_database == null)
            {
                DataConnection con = new DataConnection(dolConfig.DBType, dolConfig.DBConnectionString);
                m_database = new ObjectDatabase(con);
                try
                {
                    //We will search our assemblies for DataTables by reflection so 
                    //it is not neccessary anymore to register new tables with the 
                    //server, it is done automatically!
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        // Walk through each type in the assembly
                        foreach (Type type in assembly.GetTypes())
                        {
                            // Pick up a class
                            if (type.IsClass != true)
                                continue;
                            object[] attrib = type.GetCustomAttributes(typeof(DataTable), true);
                            if (attrib.Length > 0)
                            {                                
                                Log.Info("Registering table: " + type.FullName);
                                m_database.RegisterDataObject(type);
                            }
                        }
                    }
                }
                catch (DatabaseException e)
                {                                        
                    QuestDesignerMain.HandleException(e, "Error registering Tables");                    
                    return;
                }

                try
                {
                    m_database.LoadDatabaseTables();
                }
                catch (DatabaseException e)
                {
                    QuestDesignerMain.HandleException(e,"Error loading Database");                    
                }
            }
        }
    }
}
