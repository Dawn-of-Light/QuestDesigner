/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

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
        IObjectDatabase m_database;

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

        public IList<Mob> GetNPCList()
        {
			return m_database.SelectAllObjects<Mob>();
        }

        public IList<Mob> GetNPCListForRegion(int regionID)
        {
            return m_database.SelectObjects<Mob>("Region=" + regionID);
        }

        public IList<WorldObject> GetWorldObjectListForRegion(int regionID)
        {
            return m_database.SelectObjects<WorldObject>("Region=" + regionID);
        }

        public IList<ItemTemplate> GetItemList()
        {
            return m_database.SelectAllObjects<ItemTemplate>();
        }

        public String ConvertDOLColumnToXMLColumn(String dolColumnName)
        {
            if (dolColumnName.Equals(ITEM_ID))
                return DB.COL_ITEMTEMPLATE_ID;
            else
                return dolColumnName;
        }

        public String ConvertXMLColumnToDOLColumn(String xmlColumnName)
        {
            if (xmlColumnName.Equals(DB.COL_ITEMTEMPLATE_ID))
                return ITEM_ID;
            else
                return xmlColumnName;
        }

        public void InitDB()
        {
            if (m_database == null)
            {
				m_database = ObjectDatabase.GetObjectDatabase(dolConfig.DBType, dolConfig.DBConnectionString);
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
                                //Log.Info("Registering table: " + type.FullName);
                                m_database.RegisterDataObject(type);
                            }
                        }
                    }
                }
                catch (DatabaseException e)
                {                                        
                    QuestDesignerMain.HandleException(e);                    
                    return;
                }
            }
        }
    }
}
