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
            get { return ConfigDataSet.Tables["TriggerType"]; }
        }

        public static DataTable ActionTypeTable
        {
            get { return ConfigDataSet.Tables["ActionType"]; }
        }

        public static DataTable RequirementTypeTable
        {
            get { return ConfigDataSet.Tables["RequirementType"]; }
        }

        public static DataTable ZoneTable
        {
            get { return ConfigDataSet.Tables["Zone"]; }
        }

        public static DataTable RegionTable
        {
            get { return ConfigDataSet.Tables["Region"]; }
        }

        public static DataTable HandTable
        {
            get { return ConfigDataSet.Tables["Hand"]; }
        }

        public static DataTable EnumerationTable
        {
            get { return ConfigDataSet.Tables["eEnumeration"]; }
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
            get { return QuestDataSet.Tables["Quest"]; }
        }

        public static DataTable QuestStepTable
        {
            get { return QuestDataSet.Tables["QuestStep"]; }
        }

        public static DataTable QuestPartTable
        {
            get { return QuestDataSet.Tables["QuestPart"]; }
        }

        public static DataTable ActionTable
        {
            get { return QuestDataSet.Tables["QuestPartAction"]; }
        }

        public static DataTable TriggerTable
        {
            get { return QuestDataSet.Tables["QuestPartTrigger"]; }
        }

        public static DataTable RequirementTable
        {
            get { return QuestDataSet.Tables["QuestPartRequirement"]; }
        }

        public static DataTable MobTable
        {
            get { return QuestDataSet.Tables["Mob"]; }
        }

        public static DataTable ItemTemplateTable
        {
            get { return QuestDataSet.Tables["ItemTemplate"]; }
        }

        public static DataTable AreaTable
        {
            get { return QuestDataSet.Tables["Area"]; }
        }

        public static DataTable LocationTable
        {
            get { return QuestDataSet.Tables["Location"]; }
        }

        #endregion

        public static void Init()
        {
            areaBinding = new BindingSource(QuestDataSet, "Area");
            
            mobBinding = new BindingSource(QuestDataSet, "Mob");

            locationBinding = new BindingSource(QuestDataSet, "Location");
            
            questPartBinding = new BindingSource(QuestDataSet, "QuestPart"); 
            
            zoneBinding = new BindingSource(ConfigDataSet, "Zone");
            zoneBinding.Sort = "description";

            regionBinding = new BindingSource(ConfigDataSet, "Region");
            regionBinding.Sort = "description";
            
            textTypeBinding = new BindingSource(ConfigDataSet, "eEnumeration");
            textTypeBinding.AllowNew = false;                        
            textTypeBinding.Filter = "Type=\'eTextType\'";
            textTypeBinding.Sort = "Description";
            
            requirementTypeBinding = new BindingSource(ConfigDataSet, "RequirementType");
                        
            comparatorBinding = new BindingSource(ConfigDataSet,"eEnumeration");                       
            comparatorBinding.Filter = "Type=\'eComparator\'";
            comparatorBinding.Sort = "Value";

            comparatorBinaryBinding = new BindingSource(ConfigDataSet, "eEnumeration");            
            comparatorBinaryBinding.Filter = "Type=\'eComparator\' and (Value=" + (byte)eComparator.None + " OR Value=" + (byte)eComparator.Not + ")";
            comparatorBinaryBinding.Sort = "Value";

            comparatorQuantityBinding = new BindingSource(ConfigDataSet, "eEnumeration");
            comparatorQuantityBinding.Filter = "Type=\'eComparator\' and Value<>" + (byte)eComparator.None + " and Value<>" + (byte)eComparator.Not + "";
            comparatorQuantityBinding.Sort = "Value";
            
            actionTypeBinding = new BindingSource(ConfigDataSet, "ActionType");                        
         
            triggerTypeBinding = new BindingSource(ConfigDataSet, "TriggerType");
            
            emoteBinding = new BindingSource(ConfigDataSet, "eEnumeration");
            emoteBinding.AllowNew = false;
            emoteBinding.Filter = "Type=\'eEmote\'";
            emoteBinding.Sort = "Description";
        }

		public static bool isInitialized()
		{
			return QuestDataSet != null && ConfigDataSet !=null;
		}

		public static BindingSource GetBindingSourceForEnumeration(string type)
		{
			BindingSource bs =  new BindingSource();
			bs.DataSource = EnumerationTable;
			bs.Filter = "type='" + type + "'";
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
			DataRow[] rows = RegionTable.Select("id='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["description"]);
			else
				return id;
		}

		public static string GetZoneNameForID(string id)
		{
			DataRow[] rows = ZoneTable.Select("zoneID='" + id + "'");
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
