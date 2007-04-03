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

namespace DOL.Tools.QuestDesigner.Util
{
	class DB
	{
        public const string TABLE_QUEST = "Quest";
        public const string TABLE_MOB = "Mob";
        public const string TABLE_AREA = "Area";
        public const string TABLE_ITEMTEMPLATE = "ItemTemplate";
        public const string TABLE_LOCATION = "Location";
        public const string TABLE_QUESTSTEP = "QuestStep";
        public const string TABLE_QUESTPART = "QuestPart";
        public const string TABLE_QUESTPARTACTION = "QuestPartAction";
        public const string TABLE_QUESTPARTTRIGGER = "QuestPartTrigger";
        public const string TABLE_QUESTPARTREQUIREMENT = "QuestPartRequirement";

        public const string TABLE_ZONE = "Zone";
        public const string TABLE_REGION = "Region";

        public const string TABLE_ENUMERATION = "eEnumeration";
        public const string TABLE_REQUIREMENTTYPE = "RequirementType";
        public const string TABLE_ACTIONTYPE = "ActionType";
        public const string TABLE_TRIGGERTYPE = "TriggerType";
        public const string TABLE_HAND = "Hand";        
        

		public static BindingSource emoteBinding;
        public static BindingSource areaBinding;
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

        private static Boolean suspended = false;

        #region Config Data Tables

        private static DataSet configDataSet;

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

        public static DataTable HandTable
        {
            get { return ConfigDataSet.Tables[TABLE_HAND]; }
        }

        public static DataTable EnumerationTable
        {
            get { return ConfigDataSet.Tables[TABLE_ENUMERATION]; }
        }

        #endregion

        #region Quest Data Tables

        private static DataSet questDataSet;

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

        public static DataTable MobTable
        {
            get { return QuestDataSet.Tables[TABLE_MOB]; }
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
            areaBinding = new BindingSource(QuestDataSet, TABLE_AREA);
            
            mobBinding = new BindingSource(QuestDataSet, TABLE_MOB);

            locationBinding = new BindingSource(QuestDataSet, TABLE_LOCATION);
            
            questPartBinding = new BindingSource(QuestDataSet, TABLE_QUESTPART);
            questPartBinding.Sort = "Position";
            
            zoneBinding = new BindingSource(ConfigDataSet, TABLE_ZONE);
            zoneBinding.Sort = "Description";

            regionBinding = new BindingSource(ConfigDataSet, TABLE_REGION);
            regionBinding.Sort = "Description";
            
            textTypeBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            textTypeBinding.AllowNew = false;                        
            textTypeBinding.Filter = "Type=\'eTextType\'";
            textTypeBinding.Sort = "Description";
            
            requirementTypeBinding = new BindingSource(ConfigDataSet, TABLE_REQUIREMENTTYPE);
                        
            comparatorBinding = new BindingSource(ConfigDataSet,TABLE_ENUMERATION);                       
            comparatorBinding.Filter = "Type=\'eComparator\'";
            comparatorBinding.Sort = "Value";

            comparatorBinaryBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);            
            comparatorBinaryBinding.Filter = "Type=\'eComparator\' and (Value=" + (byte)eComparator.None + " OR Value=" + (byte)eComparator.Not + ")";
            comparatorBinaryBinding.Sort = "Value";

            comparatorQuantityBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            comparatorQuantityBinding.Filter = "Type=\'eComparator\' and Value<>" + (byte)eComparator.None + " and Value<>" + (byte)eComparator.Not + "";
            comparatorQuantityBinding.Sort = "Value";
            
            actionTypeBinding = new BindingSource(ConfigDataSet, TABLE_ACTIONTYPE);                        
         
            triggerTypeBinding = new BindingSource(ConfigDataSet, TABLE_TRIGGERTYPE);
            
            emoteBinding = new BindingSource(ConfigDataSet, TABLE_ENUMERATION);
            emoteBinding.AllowNew = false;
            emoteBinding.Filter = "Type=\'eEmote\'";
            emoteBinding.Sort = "Description";
        }

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
			return QuestDataSet != null && ConfigDataSet !=null;
		}

		public static BindingSource GetBindingSourceForEnumeration(string type)
		{
			BindingSource bs =  new BindingSource();
			bs.DataSource = EnumerationTable;
			bs.Filter = "Type='" + type + "'";
			return bs;
		}

		public static string GetItemNameForID(string id)
		{
			DataRow[] rows = ItemTemplateTable.Select("ItemTemplateID='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static string getEnumerationNameForID(string type, string id)
		{
			DataRow[] rows = EnumerationTable.Select("Type='" + type + "' and Value="+id);
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Description"]);
			else
				return id;
		}

		public static string GetRegionNameForID(string id)
		{
			DataRow[] rows = RegionTable.Select("ID='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["description"]);
			else
				return id;
		}

		public static string GetZoneNameForID(string id)
		{
			DataRow[] rows = ZoneTable.Select("ZoneID='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["description"]);
			else
				return id;
		}

		public static string GetNPCNameForID(string id)
		{
			DataRow[] rows = MobTable.Select("ObjectName='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static string GetAreaNameForID(string id)
		{
			DataRow[] rows = AreaTable.Select("ObjectName='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static string GetLocationForID(string id)
		{
			DataRow[] rows = LocationTable.Select("ObjectName='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static DataRow GetTriggerTypeRowForID(int id)
		{
			DataRow[] triggerRows = TriggerTypeTable.Select("ID=" + id);
			if (triggerRows.Length > 0)
				return triggerRows[0];
			else
				return null;
		}

		public static DataRow GetRequirementTypeRowForID(int id)
		{
			DataRow[] requRows = RequirementTypeTable.Select("ID=" + id);
			if (requRows.Length > 0)
				return requRows[0];
			else
				return null;
		}

		public static DataRow GetActionTypeRowForID(int id)
		{
			DataRow[] actionRows = ActionTypeTable.Select("ID=" + id);
			if (actionRows.Length > 0)
				return actionRows[0];
			else
				return null;
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
                foreach (DataRow row in DB.MobTable.Rows)
                {
                    if (row["ObjectName"] is string && (string)row["ObjectName"] == name)
                        return true;
                }
                foreach (DataRow row in DB.ItemTemplateTable.Rows)
                {
                    if (row["ItemTemplateID"] is string && (string)row["ItemTemplateID"] == name)
                        return true;
                }
                foreach (DataRow row in DB.AreaTable.Rows)
                {
                    if (row["ObjectName"] is string && (string)row["ObjectName"] == name)
                        return true;
                }
                foreach (DataRow row in DB.LocationTable.Rows)
                {
                    if (row["ObjectName"] is string && (string)row["ObjectName"] == name)
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
                foreach (DataRow row in DB.MobTable.Rows)
                {
                    if (row["ObjectName"] is string && (string)row["ObjectName"] == name)
                        return true;
                }
            }
            return false;
        }
		
	}
}
