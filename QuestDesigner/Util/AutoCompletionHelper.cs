using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace QuestDesigner.Util
{
	class AutoCompletionHelper
	{

		
		

		public static  string[] getItemTemplateIDs()
		{
			ArrayList ids = new ArrayList();
			foreach (DataRow row in DB.itemTemplateTable.Rows)
			{
				if (!(row["ItemTemplateID"] is DBNull))
					ids.Add(row["ItemTemplateID"]);
			}
			return (string[])ids.ToArray(typeof(string));
		}

		public static string[] getAreaIDs()
		{
			ArrayList ids = new ArrayList();
			foreach (DataRow row in DB.areaTable.Rows)
			{
				if (!(row["ObjectName"] is DBNull))
					ids.Add(row["ObjectName"]);
			}
			return (string[])ids.ToArray(typeof(string));
		}

		public static string[] getNPCNames()
		{
			ArrayList ids = new ArrayList();
			foreach (DataRow row in DB.npcTable.Rows)
			{
				if (!(row["Name"] is DBNull))
					ids.Add(row["Name"]);
			}
			return (string[])ids.ToArray(typeof(string));
		}

		public static string[] getNPCIDs()
		{
			ArrayList ids = new ArrayList();
			foreach (DataRow row in DB.npcTable.Rows)
			{
				if (!(row["ObjectName"] is DBNull))
					ids.Add(row["ObjectName"]);
			}
			return (string[])ids.ToArray(typeof(string));
		}		
	}
}
