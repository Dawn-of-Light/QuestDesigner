using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace QuestDesigner.Util
{
	class DB
	{
		public static DataTable questTable;

		public static DataTable itemTemplateTable;
		public static DataTable npcTable;
		public static DataTable areaTable;
		public static DataTable questPartTable;
		public static DataTable locationTable;

		public static DataTable triggerTable;
		public static DataTable requirementTable;
		public static DataTable actionTable;

		public static DataTable triggerTypeTable;
		public static DataTable requirementTypeTable;
		public static DataTable actionTypeTable;

		public static DataTable enumerationTable;

		public static DataTable zoneTable;
		public static DataTable regionTable;

		public static BindingSource emoteBinding;

		public static BindingSource questPartBinding;
		public static BindingSource zoneBinding;		

		public static BindingSource textTypeBinding;
		public static BindingSource comparatorBinding;

		public static bool isInitialized()
		{
			return questTable != null;
		}

		public static BindingSource GetBindingSourceForEnumeration(string type)
		{
			BindingSource bs =  new BindingSource();
			bs.DataSource = enumerationTable;
			bs.Filter = "type='" + type + "'";
			return bs;
		}

		public static string GetItemNameForID(string id)
		{
			DataRow[] rows = itemTemplateTable.Select("ItemTemplateID='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static string getEnumerationNameForID(string type, string id)
		{
			DataRow[] rows = enumerationTable.Select("Type='" + type + "' and Value="+id);
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Description"]);
			else
				return id;
		}

		public static string GetRegionNameForID(string id)
		{
			DataRow[] rows = regionTable.Select("id='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["description"]);
			else
				return id;
		}

		public static string GetZoneNameForID(string id)
		{
			DataRow[] rows = zoneTable.Select("zoneID='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["description"]);
			else
				return id;
		}

		public static string GetNPCNameForID(string id)
		{
			DataRow[] rows = npcTable.Select("ObjectName='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static string GetAreaNameForID(string id)
		{
			DataRow[] rows = areaTable.Select("ObjectName='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static string GetLocationForID(string id)
		{
			DataRow[] rows = locationTable.Select("ObjectName='" + id + "'");
			if (rows.Length > 0)
				return Convert.ToString(rows[0]["Name"]);
			else
				return id;
		}

		public static DataRow GetTriggerTypeRowForID(int id)
		{
			DataRow[] triggerRows = triggerTypeTable.Select("ID=" + id);
			if (triggerRows.Length > 0)
				return triggerRows[0];
			else
				return null;
		}

		public static DataRow GetRequirementTypeRowForID(int id)
		{
			DataRow[] requRows = requirementTypeTable.Select("ID=" + id);
			if (requRows.Length > 0)
				return requRows[0];
			else
				return null;
		}

		public static DataRow GetActionTypeRowForID(int id)
		{
			DataRow[] actionRows = actionTypeTable.Select("ID=" + id);
			if (actionRows.Length > 0)
				return actionRows[0];
			else
				return null;
		}
		
	}
}
