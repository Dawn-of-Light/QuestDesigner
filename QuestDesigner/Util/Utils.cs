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

namespace DOL.Tools.QuestDesigner.Util
{
	class Utils
	{
        public static string Escape(object obj)
        {
            return Convert.ToString(obj).Replace("\"", "\\\"");
        }

        public static string ToEscapedText(object obj)
        {
            
            return "\"" + Convert.ToString(obj).Replace("\"","\\\"")+"\"";
        }

		public static string ConvertToObjectName(string value)
		{            
            char[] letters = value.ToCharArray();

            StringBuilder str = new StringBuilder();
            for (int i=0; i< letters.Length;i++)            
            {
                if (str.Length>0 && Char.IsLetterOrDigit(letters[i]))
                    str.Append(letters[i]);
                else if (str.Length ==0 && Char.IsLetter(letters[i]))
                    str.Append(letters[i]);

            }

            return str.ToString();
		}

		public static string ConvertToNamespace(string value)
		{
            string[] packageNames = value.Split('.');

            StringBuilder str = new StringBuilder();

            string packageNameValid;
            foreach (String packageName in packageNames)
            {
                packageNameValid = ConvertToObjectName(packageName);

                if (str.Length > 0 && packageNameValid.Length > 0)
                    str.Append(".");

                str.Append(packageNameValid);
            }
			
			return str.ToString();
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

        public static int ConvertZoneXToRegionByRegionID(int regionID,int globalX) {
            int localX = -1;            
            foreach(DataRow row in DB.ZoneTable.Select(DB.COL_ZONE_REGIONID+"="+regionID)) {
                localX = globalX - Convert.ToInt32(row[DB.COL_ZONE_OFFSETX]) * 8192;

                if (localX >= 0 && localX <= 8 * 8192)                
                    return localX;
            }
            return -1;
        }

        public static int ConvertZoneYToRegionByRegionID(int regionID, int globalY)
        {
            int localY = -1;
            foreach (DataRow row in DB.ZoneTable.Select(DB.COL_ZONE_REGIONID+"="+regionID))
            {
                localY = globalY - Convert.ToInt32(row[DB.COL_ZONE_OFFSETY]) * 8192;

                if (localY >= 0 && localY <= 8 * 8192)
                    return localY;
            }
            return -1;
        }

        public static int GetZoneIDForLocation(int regionID, int globalX, int globalY)
        {
            int localX = -1;
            int localY = -1;
            foreach (DataRow row in DB.ZoneTable.Select(DB.COL_ZONE_REGIONID+"=" + regionID))
            {
                localX = globalX - Convert.ToInt32(row[DB.COL_ZONE_OFFSETX]) * 8192;
                localY = globalY - Convert.ToInt32(row[DB.COL_ZONE_OFFSETY]) * 8192;

                if (localX >= 0 && localX <= (int)row[DB.COL_ZONE_WIDTH] * 8192 && localY >= 0 && localY <= (int)row[DB.COL_ZONE_HEIGHT] * 8192)
                    return (int)row[DB.COL_ZONE_ID];
            }
            return -1;
        }

		public static Point3D ConvertZonePointToRegion(int zoneID, Point3D local)
		{
			Point3D global = new Point3D();
			DataRow[] row = DB.ZoneTable.Select(DB.COL_ZONE_ID+"=" + zoneID);
			if (row.Length>0) {
                global.X = Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETX]) * 8192 + local.X;
                global.Y = Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETY]) * 8192 + local.Y;
				global.Z = local.Z;
			}

			return global;
		}

		public static Point3D ConvertRegionPointToZone(int zoneID, Point3D global)
		{
			Point3D local = new Point3D();
			DataRow[] row = DB.ZoneTable.Select(DB.COL_ZONE_ID+"=" + zoneID);
			if (row.Length > 0)
			{
                local.X = global.X - Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETX]) * 8192;
                local.Y = global.Y - Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETY]) * 8192;
				local.Z = global.Z;
			}

			return global;
		}

		public static int ConvertZoneXToRegion(int zoneID, int localX)
		{
			int globalX = 0;
			DataRow[] row = DB.ZoneTable.Select(DB.COL_ZONE_ID+"=" + zoneID);
			if (row.Length > 0)
			{
                globalX = Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETX]) * 8192 + localX;
			}
			return globalX;
		}

		public static int ConvertRegionXToZone(int zoneID, int globalX)
		{
			int localX = 0;
			DataRow[] row = DB.ZoneTable.Select(DB.COL_ZONE_ID+"=" + zoneID);
			if (row.Length > 0)
			{
                localX = globalX - Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETX]) * 8192;
			}
			return localX;
		}

		public static int ConvertRegionYToZone(int zoneID, int globalY)
		{
			int localY = 0;
			DataRow[] row = DB.ZoneTable.Select(DB.COL_ZONE_ID+"=" + zoneID);
			if (row.Length > 0)
			{
                localY = globalY - Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETY]) * 8192;
			}
			return localY;
		}

		public static int ConvertZoneYToRegion(int zoneID, int localY)
		{
			int globalY = 0;
			DataRow[] row = DB.ZoneTable.Select(DB.COL_ZONE_ID+"=" + zoneID);
			if (row.Length > 0)
			{
                globalY = Convert.ToInt32(row[0][DB.COL_ZONE_OFFSETY]) * 8192 + localY;
			}

			return globalY;
		}
		
		#endregion

		private static string GenerateParameter(char param, eComparator value, string comparatorType)
		{						
			return ComparatorToText(value,comparatorType);
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
			if (type.StartsWith(Const.SELECTOR_QUESTTYPE))
			{
                if (String.IsNullOrEmpty(value))
                    return defaultValue == null ? "this quest" : defaultValue;
                else if (value == DB.QuestTable.Rows[0][DB.COL_QUEST_NAMESPACE] + "." + DB.QuestTable.Rows[0][DB.COL_QUEST_NAME])
                    return "this quest";
                else
                    return "the quest " + value;
			}
            else if (type.StartsWith(Const.SELECTOR_GAMELIVING) || type.StartsWith(Const.SELECTOR_GAMENPC))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "nobody" : defaultValue;
				else
					return DB.GetNPCNameForID(value);				
			}
			else if (type.StartsWith(Const.SELECTOR_AREA))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "an area" : defaultValue;
				else
					return DB.GetAreaNameForID(value);
			}
			else if (type.StartsWith(Const.SELECTOR_ITEM))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "an item" : defaultValue;
				else
					return DB.GetItemNameForID(value);				
			}
            else if (type.StartsWith(Const.SELECTOR_WHIPSER))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a word" : defaultValue;
				else
					return value;

			}
            else if (type.StartsWith(Const.SELECTOR_ZONE))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a zone" : defaultValue;
				else
					return DB.GetZoneNameForID(value);
			}
            else if (type.StartsWith(Const.SELECTOR_REGION))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a region" : defaultValue;
				else
					return DB.GetRegionNameForID(value);
			}
            else if (type.StartsWith(Const.SELECTOR_TEXTTYPE))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "texttype" : defaultValue;
				else
					return TextTypeToText((eTextType)Enum.Parse(typeof(eTextType),value));
			}
            else if (type.StartsWith(Const.SELECTOR_TEXT))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "text" : defaultValue;
				else
					return value;
			}
			else if (type.StartsWith(Const.TYPE_INT) || type.StartsWith(Const.TYPE_LONG))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "number" : defaultValue;
				else 
					return value;
			}
            else if (type.StartsWith(Const.SELECTOR_LOCATION))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "a location" : defaultValue;
				else
					return DB.GetLocationForID(value);
			}
            else if (type.StartsWith(Const.SELECTOR_EMOTE))
			{
				if (String.IsNullOrEmpty(value))
					return defaultValue == null ? "eEmote" : defaultValue;
				else
					return DB.getEnumerationNameForID(typeof(eEmote).Name, value);
			}
            else if (type.StartsWith(Const.SELECTOR_CHARACTERCLASS))
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
				text = Convert.ToString(triggerRow[DB.COL_TRIGGERTYPE_TEXT]);
                string typeI = Convert.ToString(triggerRow[DB.COL_TRIGGERTYPE_I]);
                string typeK = Convert.ToString(triggerRow[DB.COL_TRIGGERTYPE_K]);


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

				text = Convert.ToString(requirementRow[DB.COL_REQUIREMENTTYPE_TEXT]);
                string typeN = Convert.ToString(requirementRow[DB.COL_REQUIREMENTTYPE_N]);
                string typeV = Convert.ToString(requirementRow[DB.COL_REQUIREMENTTYPE_V]);
                string comparatorType = Convert.ToString(requirementRow[DB.COL_REQUIREMENTTYPE_COMPARATOR]);

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
						formatParams[i++] = GenerateParameter(param, comp, comparatorType);

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
                text = Convert.ToString(actionRow[DB.COL_ACTIONTYPE_TEXT]);
                string typeP = Convert.ToString(actionRow[DB.COL_ACTIONTYPE_P]);
                string typeQ = Convert.ToString(actionRow[DB.COL_ACTIONTYPE_Q]);

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

        private static string ComparatorToText(eComparator comp, string comparatorType)
        {
            if (Const.COMPARATOR_QUANTITY.Equals(comparatorType))
            {
                switch (comp)
                {
                    case eComparator.Equal:
                        return "exactly";
                    case eComparator.Greater:
                        return "greater than";
                    case eComparator.Less:
                        return "less than";
                    case eComparator.NotEqual:
                        return "not";
                    case eComparator.Not:
                        throw new ArgumentException("Comparator cannot be \"Not\" if type is quantity.");
                    default:
                        return "none";
                }
            }
            else if (Const.COMPARATOR_BINARY.Equals(comparatorType))
            {
                switch (comp)
                {
                    case eComparator.Equal:
                        throw new ArgumentException("Comparator cannot be \"Equal\" if type is quantity.");
                    case eComparator.Greater:
                        throw new ArgumentException("Comparator cannot be \"Greater\" if type is quantity.");
                    case eComparator.Less:
                        throw new ArgumentException("Comparator cannot be \"LEss\" if type is quantity.");
                    case eComparator.NotEqual:
                        throw new ArgumentException("Comparator cannot be \"NotEquals\" if type is quantity.");
                    case eComparator.Not:
                        return "is not";
                    default:
                        return "is";
                }
            }
            else
            {
                throw new ArgumentException("Unknown Comparatortype:\""+comparatorType+"\", check Requirements Config.", "comparatorType");
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
