
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
using System.Collections;
using DOL.GS.Quests;
using DOL.GS;
using System.Data;
using System.Reflection;
using DOL.GS.PacketHandler;

namespace QuestDesigner.Util
{
	class Utils
	{
		public static string ConvertToObjectName(string value)
		{
			value = value.Replace(" ", "");
			value = value.Replace("'", "");
			return value.Trim();
		}

		public static string ConvertToNamespace(string value)
		{
			value = value.Replace(" ", "");
			value = value.Replace("'", "");
			return value.Trim();
		}

		public static string[] GetQualifiedEnumNames(Type enumeration) 
		{
			ArrayList vals = new ArrayList();
			foreach (string name in Enum.GetNames(enumeration))
			{
				vals.Add(enumeration.Name + "." + name);
			}
			return (string[])vals.ToArray(typeof(string));
		}

		#region Coordinate Conversion

		public static Point ConvertZonePointToRegion(int zoneID, Point local)
		{
			Point global = new Point();
			DataRow[] row = DB.zoneTable.Select("zoneID=" + zoneID);
			if (row.Length>0) {
				global.X = Convert.ToInt32(row[0]["offsetx"]) * 8192 + local.X;
				global.Y = Convert.ToInt32(row[0]["offsety"]) * 8192 + local.Y;
				global.Z = local.Z;
			}

			return global;
		}

		public static Point ConvertRegionPointToZone(int zoneID, Point global)
		{
			Point local = new Point();
			DataRow[] row = DB.zoneTable.Select("zoneID=" + zoneID);
			if (row.Length > 0)
			{
				local.X = global.X - Convert.ToInt32(row[0]["offsetx"]) * 8192;
				local.Y = global.Y - Convert.ToInt32(row[0]["offsety"]) * 8192;
				local.Z = global.Z;
			}

			return global;
		}

		public static int ConvertZoneXToRegion(int zoneID, int localX)
		{
			int globalX = 0;
			DataRow[] row = DB.zoneTable.Select("zoneID=" + zoneID);
			if (row.Length > 0)
			{
				globalX = Convert.ToInt32(row[0]["offsetx"]) * 8192 + localX;
			}
			return globalX;
		}

		public static int ConvertRegionXToZone(int zoneID, int globalX)
		{
			int localX = 0;
			DataRow[] row = DB.zoneTable.Select("zoneID=" + zoneID);
			if (row.Length > 0)
			{
				localX = globalX - Convert.ToInt32(row[0]["offsetx"]) * 8192;
			}
			return localX;
		}

		public static int ConvertRegionYToZone(int zoneID, int globalY)
		{
			int localY = 0;
			DataRow[] row = DB.zoneTable.Select("zoneID=" + zoneID);
			if (row.Length > 0)
			{
				localY = globalY - Convert.ToInt32(row[0]["offsety"]) * 8192;
			}
			return localY;
		}

		public static int ConvertZoneYToRegion(int zoneID, int localY)
		{
			int globalY = 0;
			DataRow[] row = DB.zoneTable.Select("zoneID=" + zoneID);
			if (row.Length > 0)
			{
				globalY = Convert.ToInt32(row[0]["offsety"]) * 8192 + localY;
			}

			return globalY;
		}
		
		#endregion

		private static string GenerateParameter(char param, eComparator value)
		{						
			return ComparatorToText(value);
		}

		private static string GenerateParameter(char param, string typeDescr, string value)
		{
			string defaultValue = null;
			string type = null;
			
			int defBegin =typeDescr.IndexOf('(');
			int defEnd = typeDescr.IndexOf(')');
			int typeEnd = typeDescr.IndexOf(':');
			if (defBegin >= 0 && defEnd >= 0)
				defaultValue = typeDescr.Substring(defBegin+1, defEnd - defBegin-1);

			if (typeEnd >= 0)
				type = typeDescr.Substring(0, typeEnd);
			else if (defBegin >= 0)
				type = typeDescr.Substring(0, defBegin);
			else
				type = typeDescr;

			// parameter
			if (type.StartsWith("QuestType"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "this quest" : defaultValue;
				else
					return "the quest " + value;
			}
			else if (type.StartsWith("GameLiving") || type.StartsWith("GameNPC"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "nobody" : defaultValue;
				else
					return DB.GetNPCNameForID(value);				
			}
			else if (type.StartsWith("Area"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "an area" : defaultValue;
				else
					return DB.GetAreaNameForID(value);
			}
			else if (type.StartsWith("Item"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "an item" : defaultValue;
				else
					return DB.GetItemNameForID(value);				
			}
			else if (type.StartsWith("Whisper"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a word" : defaultValue;
				else
					return value;

			}
			else if (type.StartsWith("Zone"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a zone" : defaultValue;
				else
					return DB.GetZoneNameForID(value);
			}
			else if (type.StartsWith("Region"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a region" : defaultValue;
				else
					return DB.GetRegionNameForID(value);
			}
			else if (type.StartsWith("TextType"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "texttype" : defaultValue;
				else
					return TextTypeToText((eTextType)Enum.Parse(typeof(eTextType),value));
			}
			else if (type.StartsWith("Text"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "text" : defaultValue;
				else
					return value;
			}
			else if (type.StartsWith("int") || type.StartsWith("long"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "number" : defaultValue;
				else 
					return value;
			}
			else if (type.StartsWith("Location"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a location" : defaultValue;
				else
					return DB.GetLocationForID(value);
			}
			else if (type.StartsWith("Emote"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "eEmote" : defaultValue;
				else
					return DB.getEnumerationNameForID(typeof(eEmote).Name, value);
			}
			else if (type.StartsWith("CharacterClass"))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "eCharacterClass" : defaultValue;
				else
					return DB.getEnumerationNameForID(typeof(eCharacterClass).Name, value);
			}
			else
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "parameter" : defaultValue;
				else
					return value;
			}
		}

		public static string TriggerText(eTriggerType TriggerType, string K, string I)
		{
			string text = null;
			object[] formatParams = null;

			DataRow triggerRow = DB.GetTriggerTypeRowForID((int)TriggerType);

			if (triggerRow != null)
			{
				text = Convert.ToString(triggerRow["text"]);
				string typeI = Convert.ToString(triggerRow["i"]);
				string typeK = Convert.ToString(triggerRow["k"]);


				int startIndex = 0;
				int index;
				int i = 0;
				char param;
				formatParams = new object[2];
				while ((index = text.IndexOf('$', startIndex)) >= 0)
				{
					param = Convert.ToChar(text.Substring(index + 1, 1));

					if (param == Const.CODE_K)
						formatParams[i++] = GenerateParameter(param, typeK, K);
					else if (param == Const.CODE_I)
						formatParams[i++] = GenerateParameter(param, typeI, I);

					startIndex = index + 6; // skip ending $ of param clause 
				}
			}

			if (!String.IsNullOrEmpty(text))
			{
				return String.Format(text, formatParams);
			}
			else
			{
				return "TRIGGERTYPE UNKNOWN:" + TriggerType;
			}
		}

		public static string RequirementText(eRequirementType Type, string N, string V, eComparator comp)
		{
			string text = null;
			object[] formatParams = null;
			DataRow requirementRow = DB.GetRequirementTypeRowForID((int)Type);
			if (requirementRow != null)
			{

				text = Convert.ToString(requirementRow["text"]);
				string typeN = Convert.ToString(requirementRow["n"]);
				string typeV = Convert.ToString(requirementRow["v"]);

				int startIndex = 0;
				int index;
				int i = 0;
				char param;
				formatParams = new object[3];
				while ((index = text.IndexOf('$', startIndex)) >= 0)
				{
					param = Convert.ToChar(text.Substring(index + 1, 1));

					if (param == Const.CODE_N)
						formatParams[i++] = GenerateParameter(param, typeN, N);
					else if (param == Const.CODE_V)
						formatParams[i++] = GenerateParameter(param, typeV, V);
					else if (param == Const.CODE_COMPARATOR)
						formatParams[i++] = GenerateParameter(param, comp);

					startIndex = index + 6; // skip ending $ of param clause 
				}
			}

			if (!String.IsNullOrEmpty(text))
			{
				return String.Format(text, formatParams);
			}
			else
			{
				return "Requirement TYPE UNKNOWN:" + Type;
			}			
		}

		public static string ActionText(eActionType Type, string P, string Q)
		{
			string text = null;
			object[] formatParams = null;
			DataRow actionRow = DB.GetActionTypeRowForID((int)Type);
			if (actionRow != null)
			{
				text = Convert.ToString(actionRow["text"]);
				string typeP = Convert.ToString(actionRow["p"]);
				string typeQ = Convert.ToString(actionRow["q"]);

				int startIndex = 0;
				int index;
				int i = 0;
				char param;
				formatParams = new object[2];
				while ((index = text.IndexOf('$', startIndex)) >= 0)
				{
					param = Convert.ToChar(text.Substring(index + 1, 1));

					if (param == Const.CODE_P)
						formatParams[i++] = GenerateParameter(param, typeP, P);
					else if (param == Const.CODE_Q)
						formatParams[i++] = GenerateParameter(param, typeQ, Q);

					startIndex = index + 6; // skip ending $ of param clause 
				}
			}

			if (!String.IsNullOrEmpty(text))
			{
				return String.Format(text, formatParams);
			}
			else
			{
				return "Actiontype UNKNOWN:" + Type;
			}			
		}

		private static string TextTypeToText(eTextType textType)
		{
			switch (textType)
			{
				case eTextType.Broadcast:
					return "boadcasts";
				case eTextType.Dialog:
					return "a dialog pops up";				
				case eTextType.Emote:
					return "emotes";
				case eTextType.Read:
					return "the player reads";				
				default:
					return "none";
			}
		}

		private static string ComparatorToText(eComparator comp)
		{
			switch (comp)
			{
				case eComparator.Equal:
					return "exactly";
				case eComparator.Greater:
					return "greater than";
				case eComparator.Less:
					return "less than";
				case eComparator.Not:
					return "not";
				case eComparator.NotEqual:
					return "not";
				default:
					return "none";

			}

		}
		
		public static IList FindAllQuests(Assembly asm)
		{			
			IList quests = new ArrayList();
			if (asm != null)
			{
				foreach (Type type in asm.GetTypes())
				{
					if (!type.IsClass) continue;
					if (type.IsSubclassOf(typeof(AbstractQuest)))
						quests.Add(type);					
				}
			}
			return quests;
		}
		
	}
}
