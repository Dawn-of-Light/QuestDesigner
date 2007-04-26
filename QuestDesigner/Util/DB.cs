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
using System.Data;
using System.Windows.Forms;
using DOL.GS.Quests;
using DOL.GS;
using DOL.GS.PacketHandler;
using DOL.Tools.QuestDesigner.QuestDesigner.Util;
using System.Collections;
using System.Text.RegularExpressions;

namespace DOL.Tools.QuestDesigner.Util
{
	class DB
	{
        public const string TABLE_QUEST = "Quest";
        public const string TABLE_NPC = "Mob";
        public const string TABLE_AREA = "Area";
        public const string TABLE_ITEMTEMPLATE = "ItemTemplate";
        public const string TABLE_LOCATION = "Location";
        public const string TABLE_QUESTSTEP = "QuestStep";
        public const string TABLE_QUESTPART = "QuestPart";
        public const string TABLE_QUESTCHARACTERCLASS = "QuestCharacterClass";
        public const string TABLE_QUESTPARTACTION = "QuestPartAction";
        public const string TABLE_QUESTPARTTRIGGER = "QuestPartTrigger";
        public const string TABLE_QUESTPARTREQUIREMENT = "QuestPartRequirement";

        public const string TABLE_ZONE = "Zone";
        public const string TABLE_REGION = "Region";

        public const string TABLE_ENUMERATION = "eEnumeration";
        public const string TABLE_REQUIREMENTTYPE = "RequirementType";
        public const string TABLE_ACTIONTYPE = "ActionType";
        public const string TABLE_TRIGGERTYPE = "TriggerType";

        public const string COL_QUESTPARTTRIGGER_ID = "ID";
        public const string COL_QUESTPARTTRIGGER_TYPENAME = "TypeName";        
        public const string COL_QUESTPARTTRIGGER_TYPE = "Type";
        public const string COL_QUESTPARTTRIGGER_K = "K";
        public const string COL_QUESTPARTTRIGGER_I = "I";
        public const string COL_QUESTPARTTRIGGER_QUESTPARTID = "QuestPartID";

        public const string COL_TRIGGERTYPE_VALUE = "Value";
        public const string COL_TRIGGERTYPE_CATEGORY = "Category";
        public const string COL_TRIGGERTYPE_ID = "ID";
        public const string COL_TRIGGERTYPE_K = "K";
        public const string COL_TRIGGERTYPE_HELP = "Help";
        public const string COL_TRIGGERTYPE_TEXT = "Text";
        public const string COL_TRIGGERTYPE_I = "I";
        public const string COL_TRIGGERTYPE_DESCRIPTION = "Description";

        public const string COL_QUESTPARTREQUIREMENT_ID = "ID";
        public const string COL_QUESTPARTREQUIREMENT_TYPENAME = "TypeName";        
        public const string COL_QUESTPARTREQUIREMENT_TYPE = "Type";
        public const string COL_QUESTPARTREQUIREMENT_N = "N";
        public const string COL_QUESTPARTREQUIREMENT_V = "V";
        public const string COL_QUESTPARTREQUIREMENT_QUESTPARTID = "QuestPartID";
        public const string COL_QUESTPARTREQUIREMENT_COMPARATOR = "Comparator";

        public const string COL_REQUIREMENTTYPE_VALUE = "Value";
        public const string COL_REQUIREMENTTYPE_CATEGORY = "Category";
        public const string COL_REQUIREMENTTYPE_ID = "ID";
        public const string COL_REQUIREMENTTYPE_N = "N";
        public const string COL_REQUIREMENTTYPE_V = "V";
        public const string COL_REQUIREMENTTYPE_COMPARATOR = "Comparator";
        public const string COL_REQUIREMENTTYPE_TEXT = "Text";
        public const string COL_REQUIREMENTTYPE_HELP = "Help";
        public const string COL_REQUIREMENTTYPE_DESCRIPTION = "Description";

        public const string COL_QUESTPARTACTION_ID = "ID";
        public const string COL_QUESTPARTACTION_TYPENAME = "TypeName";
        public const string COL_QUESTPARTACTION_TYPE = "Type";
        public const string COL_QUESTPARTACTION_P = "P";
        public const string COL_QUESTPARTACTION_Q = "Q";
        public const string COL_QUESTPARTACTION_QUESTPARTID = "QuestPartID";

        public const string COL_ACTIONTYPE_VALUE = "Value";
        public const string COL_ACTIONTYPE_CATEGORY = "Category";
        public const string COL_ACTIONTYPE_ID = "ID";
        public const string COL_ACTIONTYPE_P = "P";
        public const string COL_ACTIONTYPE_Q = "Q";
        public const string COL_ACTIONTYPE_HELP = "Help";
        public const string COL_ACTIONTYPE_TEXT = "Text";
        public const string COL_ACTIONTYPE_DESCRIPTION = "Description";

        public const string COL_QUEST_NAME = "Name";
        public const string COL_QUEST_TITLE = "Title";
        public const string COL_QUEST_AUTHOR = "Author";
        public const string COL_QUEST_DATE = "Date";
        public const string COL_QUEST_VERSION = "Version";
        public const string COL_QUEST_MAXQUESTCOUNT = "MaxQuestCount";
        public const string COL_QUEST_NAMESPACE = "Namespace";
        public const string COL_QUEST_MINIMUMLEVEL = "MinimumLevel";
        public const string COL_QUEST_MAXIMUMLEVEL = "MaximumLevel";
        public const string COL_QUEST_DESCRIPTION = "Description";
        public const string COL_QUEST_INVITINGNPC = "InvitingNPC";        
        public const string COL_QUEST_SCRIPTLOADEDCODE = "ScriptLoadedCode";
        public const string COL_QUEST_SCRIPTUNLOADEDCODE = "ScriptUnloadedCode";
        public const string COL_QUEST_INITIALIZATIONCODE = "InitializationCode";
        public const string COL_QUEST_CHECKQUESTQUALIFICATIONCODE = "CheckQuestQualificationCode";

        public const string COL_NPC_ID = "MobID";
        public const string COL_NPC_REALM = "Realm";        
        public const string COL_NPC_NAME = "Name";
        public const string COL_NPC_OBJECTNAME = "ObjectName";
        public const string COL_NPC_X = "X";
        public const string COL_NPC_Y = "Y";
        public const string COL_NPC_Z = "Z";
        public const string COL_NPC_HEADING = "Heading";
        public const string COL_NPC_REGION = "Region";

        public const string COL_ITEMTEMPLATE_ID = "ItemTemplateID";
        public const string COL_ITEMTEMPLATE_NAME = "Name";
        public const string COL_ITEMTEMPLATE_OBJECTNAME = "ObjectName";
        public const string COL_ITEMTEMPLATE_OBJECTTYPE = "Object_Type";

        public const string COL_AREA_REGIONID = "RegionID";
        public const string COL_AREA_OBJECTNAME = "ObjectName";
        public const string COL_AREA_NAME = "Name";
        public const string COL_AREA_X="X";
        public const string COL_AREA_Y = "Y";        
        public const string COL_AREA_Z = "Z";
        public const string COL_AREA_R = "R";
        public const string COL_AREA_SOUND = "Sound";
        public const string COL_AREA_DISPLAYMESSAGE = "DisplayMessage";
        public const string COL_AREA_CANBROADCAST = "CanBroadcast";
        public const string COL_AREA_ISSAFEAREA = "IsSafeArea";
        public const string COL_AREA_AREATYPE = "AreaType";

        public const string COL_LOCATION_OBJECTNAME = "ObjectName";
        public const string COL_LOCATION_NAME = "Name";
        public const string COL_LOCATION_X = "X";
        public const string COL_LOCATION_Y = "Y";
        public const string COL_LOCATION_Z = "Z";
        public const string COL_LOCATION_REGIONID = "RegionID";

        public const string COL_REGION_ID = "ID";
        public const string COL_REGION_DESCRIPTION = "Description";

        public const string COL_ZONE_ID = "zoneID";
        public const string COL_ZONE_REGIONID = "regionID";
        public const string COL_ZONE_DESCRIPTION = "Description";
        public const string COL_ZONE_OFFSETX = "OffsetX";
        public const string COL_ZONE_OFFSETY = "OffsetY";
        public const string COL_ZONE_WIDTH = "Width";
        public const string COL_ZONE_HEIGHT = "Height";

        public const string COL_QUESTSTEP_DESCRIPTION = "Description";

        public const string COL_QUESTPART_ID = "ID";
        public const string COL_QUESTPART_CATEGORY = "Category";
        public const string COL_QUESTPART_CATEGORYAUTOGENERATE = "CategoryAutoGenerate";
        public const string COL_QUESTPART_POSITION = "Position";
        public const string COL_QUESTPART_DEFAULTNPC = "defaultNPC";
        public const string COL_QUESTPART_MAXEXECUTIONS = "MaxExecutions";
        

        public const string COL_QUESTCHARACTERCLASS_VALUE = "Value";
        public const string COL_QUESTCHARACTERCLASS_DESCRIPTION = "Description";

        public const string COL_ENUMERATION_VALUE = "Value";
        public const string COL_ENUMERATION_NAME = "Name";
        public const string COL_ENUMERATION_DESCRIPTION = "Description";
        public const string COL_ENUMERATION_TYPE = "Type";

        public delegate void DatabaseLoadedEventHandler();

        public static BindingSource characterClassBinding;
		public static BindingSource emoteBinding;
        public static BindingSource areaBinding;
        public static BindingSource handBinding;
        public static BindingSource areaTypeBinding;
        public static BindingSource objectTypeBinding;
        public static BindingSource locationBinding;
		public static BindingSource questPartBinding;
		public static BindingSource zoneBinding;
        public static BindingSource regionBinding;
        public static BindingSource requirementTypeBinding;
        public static BindingSource actionTypeBinding;
        public static BindingSource triggerTypeBinding;		
		public static BindingSource textTypeBinding;
		public static BindingSource comparatorBinding;
        public static BindingSource comparatorBinaryBinding;
        public static BindingSource comparatorQuantityBinding;
        public static BindingSource mobBinding;

        private static Set<String> questTypeCategories = null;

        private static Set<String> questTypeFilterCategories = new Set<String>();

        public static Set<String> QuestTypeFilterCategories
        {
            get { return questTypeFilterCategories ; }
            set { questTypeFilterCategories = value; }
        }
	

        private static Boolean suspended = false;
        private static Boolean initialized = false;

        #region Config Data Tables

        private static DataSet configDataSet = null;

        public static DataSet ConfigDataSet
        {
            get { return configDataSet; }
            set { 
                configDataSet = value;
                if (ConfigDataSet != null && QuestDataSet != null)
                    Init();
            }
        }

        public static DataTable TriggerTypeTable
        {
            get { return ConfigDataSet.Tables[TABLE_TRIGGERTYPE]; }
        }

        public static DataTable ActionTypeTable
        {
            get { return ConfigDataSet.Tables[TABLE_ACTIONTYPE]; }
        }

        public static DataTable RequirementTypeTable
        {
            get { return ConfigDataSet.Tables[TABLE_REQUIREMENTTYPE]; }
        }

        public static DataTable ZoneTable
        {
            get { return ConfigDataSet.Tables[TABLE_ZONE]; }
        }

        public static DataTable RegionTable
        {
            get { return ConfigDataSet.Tables[TABLE_REGION]; }
        }        

        public static DataTable EnumerationTable
        {
            get { return ConfigDataSet.Tables[TABLE_ENUMERATION]; }
        }

        #endregion

        #region Quest Data Tables

        private static DataSet questDataSet = null;

        public static DataSet QuestDataSet
        {
            get { return questDataSet; }
            set { 
                questDataSet = value;
                if (ConfigDataSet!=null && QuestDataSet!=null)
                    Init();
            }
        }

        public static DataTable QuestTable
        {
            get { return QuestDataSet.Tables[TABLE_QUEST]; }
        }

        public static DataTable QuestCharacterClassTable
        {
            get { return QuestDataSet.Tables[TABLE_QUESTCHARACTERCLASS]; }
        }

        public static DataTable QuestStepTable
        {
            get { return QuestDataSet.Tables[TABLE_QUESTSTEP]; }
        }

        public static DataTable QuestPartTable
        {
            get { return QuestDataSet.Tables[TABLE_QUESTPART]; }
        }

        public static DataTable ActionTable
        {
            get { return QuestDataSet.Tables[TABLE_QUESTPARTACTION]; }
        }

        public static DataTable TriggerTable
        {
            get { return QuestDataSet.Tables[TABLE_QUESTPARTTRIGGER]; }
        }

        public static DataTable RequirementTable
        {
            get { return QuestDataSet.Tables[TABLE_QUESTPARTREQUIREMENT]; }
        }

        public static DataTable NPCTable
        {
            get { return QuestDataSet.Tables[TABLE_NPC]; }
        }

        public static DataTable ItemTemplateTable
        {
            get { return QuestDataSet.Tables[TABLE_ITEMTEMPLATE]; }
        }

        public static DataTable AreaTable
        {
            get { return QuestDataSet.Tables[TABLE_AREA]; }
        }

        public static DataTable LocationTable
        {
            get { return QuestDataSet.Tables[TABLE_LOCATION]; }
        }

        #endregion

        public static void Init()
        {

            if (initialized)
                throw new Exception("DB already inited");

            areaBinding = new BindingSource(QuestDataSet, TABLE_AREA);
            
            mobBinding = new BindingSource(QuestDataSet, TABLE_NPC);

            locationBinding = new BindingSource(QuestDataSet, TABLE_LOCATION);
            
            questPartBinding = new BindingSource(QuestDataSet, TABLE_QUESTPART);
            questPartBinding.Sort = DB.COL_QUESTPART_POSITION;
            
            zoneBinding = new BindingSource(ConfigDataSet, TABLE_ZONE);
            zoneBinding.Sort = DB.COL_ZONE_DESCRIPTION;

            regionBinding = new BindingSource(ConfigDataSet, TABLE_REGION);
            regionBinding.Sort = DB.COL_REGION_DESCRIPTION;
            
            textTypeBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            textTypeBinding.AllowNew = false;                        
            textTypeBinding.Filter = DB.COL_ENUMERATION_TYPE+"='"+typeof(eTextType).Name+"'";
            textTypeBinding.Sort = DB.COL_ENUMERATION_DESCRIPTION;

            areaTypeBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            areaTypeBinding.AllowNew = false;
            areaTypeBinding.Filter = DB.COL_ENUMERATION_TYPE  +"='AreaType'";
            areaTypeBinding.Sort = DB.COL_ENUMERATION_DESCRIPTION;

            objectTypeBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            objectTypeBinding.AllowNew = false;
            objectTypeBinding.Filter = DB.COL_ENUMERATION_TYPE  +"='" + typeof(eObjectType).Name + "'";
            objectTypeBinding.Sort = DB.COL_ENUMERATION_DESCRIPTION;

            handBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            handBinding.AllowNew = false;
            handBinding.Filter = DB.COL_ENUMERATION_TYPE  +"='Hand'";
            handBinding.Sort = DB.COL_ENUMERATION_VALUE;

            characterClassBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            characterClassBinding.AllowNew = false;
            characterClassBinding.Filter = DB.COL_ENUMERATION_TYPE  +"='" + typeof(eCharacterClass).Name + "'";
            characterClassBinding.Sort = DB.COL_ENUMERATION_DESCRIPTION;
            
            requirementTypeBinding = new BindingSource(ConfigDataSet, TABLE_REQUIREMENTTYPE);
                        
            comparatorBinding = new BindingSource(ConfigDataSet,TABLE_ENUMERATION);
            comparatorBinding.Filter = DB.COL_ENUMERATION_TYPE  +"='"+typeof(eComparator).Name+"'";
            comparatorBinding.Sort = DB.COL_ENUMERATION_VALUE;

            comparatorBinaryBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            comparatorBinaryBinding.Filter = DB.COL_ENUMERATION_TYPE + "='" + typeof(eComparator).Name + "' and (" + DB.COL_ENUMERATION_VALUE + "='" + (byte)eComparator.None + "' OR " + DB.COL_ENUMERATION_VALUE + "='" + (byte)eComparator.Not + "')";
            comparatorBinaryBinding.Sort = DB.COL_ENUMERATION_VALUE;

            comparatorQuantityBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            comparatorQuantityBinding.Filter = DB.COL_ENUMERATION_TYPE + "='" + typeof(eComparator).Name + "' and " + DB.COL_ENUMERATION_VALUE + "<>'" + (byte)eComparator.None + "' and " + DB.COL_ENUMERATION_VALUE + "<>'" + (byte)eComparator.Not + "'";
            comparatorQuantityBinding.Sort = DB.COL_ENUMERATION_VALUE;
            
            actionTypeBinding = new BindingSource(ConfigDataSet, TABLE_ACTIONTYPE);                        
         
            triggerTypeBinding = new BindingSource(ConfigDataSet, TABLE_TRIGGERTYPE);
            
            emoteBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            emoteBinding.AllowNew = false;
            emoteBinding.Filter = DB.COL_ENUMERATION_TYPE + "='" + typeof(eEmote).Name + "'";
            emoteBinding.Sort = DB.COL_ENUMERATION_DESCRIPTION;            

            initialized = true;

            if (DatabaseLoaded != null)
            {
                DatabaseLoaded();
            }
        }

        public static void AddQuestPartCategory(string category)
        {
            if (!String.IsNullOrEmpty(category))
            {
                QuestTypeCategories.Add(category);
                QuestDesignerMain.DesignerForm.RefreshQuestPartCategories();
            }
        }

        public static void RemoveQuestPartCategory(string category)
        {
            QuestTypeCategories.Remove(category);
            QuestDesignerMain.DesignerForm.RefreshQuestPartCategories();
        }

        public static void AddQuestPartCategoryFilter(string category)
        {
            QuestTypeFilterCategories.Add(category);

            questPartBinding.Filter = GetQuestPartCategoryFilterString();
        }

        public static void RemoveQuestPartCategoryFilter(string category)
        {
            QuestTypeFilterCategories.Remove(category);

            questPartBinding.Filter = GetQuestPartCategoryFilterString();
        }

        private static string GetQuestPartCategoryFilterString()
        {
            StringBuilder filter = new StringBuilder();
            for (int i = 0; i < QuestTypeFilterCategories.Count; i++)
            {
                if (i > 0)
                    filter.Append(" OR ");
                filter.Append(COL_QUESTPART_CATEGORY+" LIKE '%"+QuestTypeFilterCategories[i]+";%'");
            }
            return filter.ToString();
        }

        public static event DatabaseLoadedEventHandler DatabaseLoaded;

        public static void SuspendBindings()
        {            
            emoteBinding.RaiseListChangedEvents = false;
            emoteBinding.SuspendBinding();
            areaBinding.RaiseListChangedEvents = false;
            areaBinding.SuspendBinding();
            locationBinding.RaiseListChangedEvents = false;
            locationBinding.SuspendBinding();
            questPartBinding.RaiseListChangedEvents = false;
            questPartBinding.SuspendBinding();
            zoneBinding.RaiseListChangedEvents = false;
            zoneBinding.SuspendBinding();
            regionBinding.RaiseListChangedEvents = false;
            regionBinding.SuspendBinding();
            requirementTypeBinding.RaiseListChangedEvents = false;
            requirementTypeBinding.SuspendBinding();
            actionTypeBinding.RaiseListChangedEvents = false;
            actionTypeBinding.SuspendBinding();
            triggerTypeBinding.RaiseListChangedEvents = false;
            triggerTypeBinding.SuspendBinding();
            textTypeBinding.RaiseListChangedEvents = false;
            textTypeBinding.SuspendBinding();
            comparatorBinding.RaiseListChangedEvents = false;
            comparatorBinding.SuspendBinding();
            comparatorBinaryBinding.RaiseListChangedEvents = false;
            comparatorBinaryBinding.SuspendBinding();
            comparatorQuantityBinding.RaiseListChangedEvents = false;
            comparatorQuantityBinding.SuspendBinding();
            mobBinding.RaiseListChangedEvents = false;
            mobBinding.SuspendBinding();

            suspended = true;
        }

        public static void ResumeBindings()
        {
            emoteBinding.RaiseListChangedEvents = true;
            emoteBinding.ResumeBinding();
            areaBinding.RaiseListChangedEvents = true;
            areaBinding.ResumeBinding();
            locationBinding.RaiseListChangedEvents = true;
            locationBinding.ResumeBinding();
            questPartBinding.RaiseListChangedEvents = true;
            questPartBinding.ResumeBinding();
            zoneBinding.RaiseListChangedEvents = true;
            zoneBinding.ResumeBinding();
            regionBinding.RaiseListChangedEvents = true;
            regionBinding.ResumeBinding();
            requirementTypeBinding.RaiseListChangedEvents = true;
            requirementTypeBinding.ResumeBinding();
            actionTypeBinding.RaiseListChangedEvents = true;
            actionTypeBinding.ResumeBinding();
            triggerTypeBinding.RaiseListChangedEvents = true;
            triggerTypeBinding.ResumeBinding();
            textTypeBinding.RaiseListChangedEvents = true;
            textTypeBinding.ResumeBinding();
            comparatorBinding.RaiseListChangedEvents = true;
            comparatorBinding.ResumeBinding();
            comparatorBinaryBinding.RaiseListChangedEvents = true;
            comparatorBinaryBinding.ResumeBinding();
            comparatorQuantityBinding.RaiseListChangedEvents = true;
            comparatorQuantityBinding.ResumeBinding();
            mobBinding.RaiseListChangedEvents = true;
            mobBinding.ResumeBinding();

            suspended = false;
        }

        public static bool isSuspended
        {
            get {return suspended;}
        }

		public static bool isInitialized()
		{
            return initialized;
		}

		public static BindingSource GetBindingSourceForEnumeration(string type)
		{
			BindingSource bs =  new BindingSource();
			bs.DataSource = EnumerationTable;
			bs.Filter = DB.COL_ENUMERATION_TYPE+"='" + type + "'";
			return bs;
		}

		public static string GetItemNameForID(string id)
		{
			DataRow[] rows = ItemTemplateTable.Select(COL_ITEMTEMPLATE_ID+"='" + id + "'");
			if (rows.Length > 0)
                return Convert.ToString(rows[0][COL_ITEMTEMPLATE_NAME]);
			else
				return id;
		}

		public static string getEnumerationNameForID(string type, string id)
		{
			DataRow[] rows = EnumerationTable.Select(DB.COL_ENUMERATION_TYPE+"='" + type + "' and "+DB.COL_ENUMERATION_VALUE+"='"+id+"'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0][DB.COL_ENUMERATION_DESCRIPTION]);
			else
				return id;
		}

		public static string GetRegionNameForID(string id)
		{
			DataRow[] rows = RegionTable.Select(DB.COL_REGION_ID+"='" + id + "'");
			if (rows.Length > 0)
                return Convert.ToString(rows[0][DB.COL_REGION_DESCRIPTION]);
			else
				return id;
		}

		public static string GetZoneNameForID(string id)
		{
			DataRow[] rows = ZoneTable.Select(DB.COL_ZONE_ID+"='" + id + "'");
			if (rows.Length > 0)
                return Convert.ToString(rows[0][DB.COL_ZONE_DESCRIPTION]);
			else
				return id;
		}

		public static string GetNPCNameForID(string id)
		{
			DataRow[] rows = NPCTable.Select(COL_NPC_OBJECTNAME+"='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0][COL_NPC_NAME]);
			else
				return id;
		}

		public static string GetAreaNameForID(string id)
		{
			DataRow[] rows = AreaTable.Select(COL_AREA_OBJECTNAME+"='" + id + "'");
			if (rows.Length > 0)
                return Convert.ToString(rows[0][COL_AREA_NAME]);
			else
				return id;
		}

		public static string GetLocationForID(string id)
		{
			DataRow[] rows = LocationTable.Select(COL_LOCATION_OBJECTNAME+"='" + id + "'");
			if (rows.Length > 0)
                return Convert.ToString(rows[0][COL_LOCATION_NAME]);
			else
				return id;
		}

		public static DataRow GetTriggerTypeRowForID(int id)
		{
			DataRow[] triggerRows = TriggerTypeTable.Select(COL_TRIGGERTYPE_ID+"=" + id);
			if (triggerRows.Length > 0)
				return triggerRows[0];
			else
				return null;
		}

		public static DataRow GetRequirementTypeRowForID(int id)
		{
			DataRow[] requRows = RequirementTypeTable.Select(COL_REQUIREMENTTYPE_ID+"=" + id);
			if (requRows.Length > 0)
				return requRows[0];
			else
				return null;
		}

		public static DataRow GetActionTypeRowForID(int id)
		{
			DataRow[] actionRows = ActionTypeTable.Select(COL_ACTIONTYPE_ID+"=" + id);
			if (actionRows.Length > 0)
				return actionRows[0];
			else
				return null;
		}

        public static Set<String> QuestTypeCategories
        {
            get
            {
                if (questTypeCategories == null)
                {
                    questTypeCategories = new Set<String>();

                    // look for trigger categories            
                    foreach (DataRow triggerTypeRow in TriggerTypeTable.Rows)
                    {
                        if (!String.IsNullOrEmpty((string)triggerTypeRow[COL_TRIGGERTYPE_CATEGORY]))
                        {
                            CategoryComparator comparator = new CategoryComparator((string)triggerTypeRow[COL_TRIGGERTYPE_CATEGORY]);
                            questTypeCategories.Add(comparator.Name);
                        }
                    }

                    // look for requirement categories            
                    foreach (DataRow requTypeRow in RequirementTypeTable.Rows)
                    {
                        if (!String.IsNullOrEmpty((string)requTypeRow[COL_REQUIREMENTTYPE_CATEGORY]))
                        {
                            CategoryComparator comparator = new CategoryComparator((string)requTypeRow[COL_REQUIREMENTTYPE_CATEGORY]);
                            questTypeCategories.Add(comparator.Name);
                        }
                    }

                    // look for action categories            
                    foreach (DataRow actionTypeRow in ActionTypeTable.Rows)
                    {
                        if (!String.IsNullOrEmpty((string)actionTypeRow[COL_ACTIONTYPE_CATEGORY]))
                        {
                            CategoryComparator comparator = new CategoryComparator((string)actionTypeRow[COL_ACTIONTYPE_CATEGORY]);
                            questTypeCategories.Add(comparator.Name);
                        }
                    }
                }

                return questTypeCategories;
            }
        }

        public static string GetQuestPartCategoriesForID(int id)
        {
            
            Set<String> categoriesSet = new Set<String>();            

            // look for trigger categories
            DataRow[] triggerRows = TriggerTable.Select(COL_QUESTPARTTRIGGER_QUESTPARTID + "=" + id);
            foreach (DataRow triggerRow in triggerRows)
            {
                DataRow triggerTypeRow = GetTriggerTypeRowForID((int) triggerRow[COL_QUESTPARTTRIGGER_TYPE]);
                if (!String.IsNullOrEmpty((string)triggerTypeRow[COL_TRIGGERTYPE_CATEGORY]))
                {                    
                    string categoryString = (string)triggerTypeRow[COL_TRIGGERTYPE_CATEGORY];
                    string[] categories = categoryString.Split(';');

                    foreach (string category in categories)
                    {
                        CategoryComparator comparer = new CategoryComparator(category);
                        if (comparer.Compare(triggerRow))
                            categoriesSet.Add(comparer.Name);
                    }
                }
            }

            // look for requirement categories
            DataRow[] requRows = RequirementTable.Select(COL_QUESTPARTREQUIREMENT_QUESTPARTID + "=" + id);
            foreach (DataRow requRow in requRows)
            {                
                DataRow requTypeRow = GetRequirementTypeRowForID((int)requRow[COL_QUESTPARTREQUIREMENT_TYPE]);
                if (!String.IsNullOrEmpty((string)requTypeRow[COL_REQUIREMENTTYPE_CATEGORY]))
                {
                    string categoryString = (string)requTypeRow[COL_REQUIREMENTTYPE_CATEGORY];
                    string[] categories = categoryString.Split(';');

                    foreach (string category in categories) {
                        CategoryComparator comparer = new CategoryComparator(category);
                        if (comparer.Compare(requRow))
                            categoriesSet.Add(comparer.Name);
                    }
                }
            }

            // look for action categories
            DataRow[] actionRows = ActionTable.Select(COL_QUESTPARTACTION_QUESTPARTID + "=" + id);
            foreach (DataRow actionRow in actionRows)
            {
                DataRow actionTypeRow = GetActionTypeRowForID((int)actionRow[COL_QUESTPARTACTION_TYPE]);
                if (!String.IsNullOrEmpty((string)actionTypeRow[COL_ACTIONTYPE_CATEGORY]))
                {
                    string categoryString = (string)actionTypeRow[COL_ACTIONTYPE_CATEGORY];
                    string[] categories = categoryString.Split(';');

                    foreach (string category in categories)
                    {
                        CategoryComparator comparer = new CategoryComparator(category);
                        if (comparer.Compare(actionRow))
                            categoriesSet.Add(comparer.Name);
                    }
                }
            }
            

            StringBuilder categoryStringBuilder = new StringBuilder();
            for (int i = 0; i < categoriesSet.Count; i++)
            {
                categoryStringBuilder.Append(categoriesSet[i]);
                categoryStringBuilder.Append(";");
            }

            return categoryStringBuilder.ToString();
        }

        /// <summary>
        /// Checks the given name against all defined objects in quest.
        /// Needed to decide wether " should be added or not.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>true if objectname, else false</returns>
        public static bool isObjectName(object value)
        {
            if (value is string)
            {
                string name = (string)value;
                foreach (DataRow row in DB.NPCTable.Rows)
                {
                    if (row[COL_NPC_OBJECTNAME] is string && (string)row[COL_NPC_OBJECTNAME] == name)
                        return true;
                }
                foreach (DataRow row in DB.ItemTemplateTable.Rows)
                {
                    if (row[COL_ITEMTEMPLATE_ID] is string && (string)row[COL_ITEMTEMPLATE_ID] == name)
                        return true;
                }
                foreach (DataRow row in DB.AreaTable.Rows)
                {
                    if (row[COL_AREA_OBJECTNAME] is string && (string)row[COL_AREA_OBJECTNAME] == name)
                        return true;
                }
                foreach (DataRow row in DB.LocationTable.Rows)
                {
                    if (row[COL_LOCATION_OBJECTNAME] is string && (string)row[COL_LOCATION_OBJECTNAME] == name)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks the given name against all defined objects in quest.
        /// Needed to decide wether " should be added or not.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>true if objectname, else false</returns>
        public static bool isMobName(object value)
        {
            if (value is string)
            {
                string name = (string)value;
                foreach (DataRow row in DB.NPCTable.Rows)
                {
                    if (row[COL_NPC_OBJECTNAME] is string && (string)row[COL_NPC_OBJECTNAME] == name)
                        return true;
                }
            }
            return false;
        }
		
	}

    public class CategoryComparator
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        public bool IsFiltered
        {
            get { return FilterParameter!=null && FilterValue!=null; }            
        }

        private string filterParameter;

        public string FilterParameter
        {
            get { return filterParameter; }
            set { filterParameter = value; }
        }

        private object filterValue;

        public object FilterValue
        {
            get { return filterValue; }
            set { filterValue = value; }
        }
	
        public CategoryComparator(string categoryString)
        {
            
            Match matches = Regex.Match(categoryString, "([^\\(]+)\\(([^=]+)=([^\\)]+)\\)", RegexOptions.Compiled);

            if (matches.Success && matches.Groups.Count == 4)
            {
                Name = matches.Groups[1].Value;
                FilterParameter = matches.Groups[2].Value;
                string expressionValue = matches.Groups[3].Value;
                if (Utils.EqualsIgnoreCase(DB.COL_REQUIREMENTTYPE_COMPARATOR, FilterParameter))
                {
                    eComparator comparator = (eComparator)Enum.Parse(typeof(eComparator), expressionValue);
                    FilterValue = comparator;
                }
                else
                {
                    FilterValue = expressionValue;
                }
            }
            else
            {
                Name = categoryString;
            }
        }

        public bool Compare(DataRow row)
        {
            if (!IsFiltered)
                return true;

            if (Utils.EqualsIgnoreCase(DB.COL_REQUIREMENTTYPE_COMPARATOR, FilterParameter))
            {
                try
                {
                    object value = row[DB.COL_REQUIREMENTTYPE_COMPARATOR];
                    if (value!=DBNull.Value)
                    {
                        eComparator comparatorRow = (eComparator)Enum.Parse(typeof(eComparator), Convert.ToString(value));
                        return (comparatorRow == (eComparator)FilterValue);
                    }
                    else
                    {
                        if ((eComparator)filterValue == eComparator.None)
                            return true;
                        else
                            return false;
                    }
                }
                catch (Exception e)
                {
                    QuestDesignerMain.HandleException(e);
                    return false;
                }
            }
            else
            {
                return (string)FilterValue == (string)row[FilterParameter];
            }
        }
    }
}
