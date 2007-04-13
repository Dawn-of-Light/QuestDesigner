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

namespace DOL.Tools.QuestDesigner.Util
{
	public class Const
	{

        public const string SELECTOR_QUESTTYPE = "QuestType";
        public const string SELECTOR_GAMELIVING ="GameLiving";
        public const string SELECTOR_GAMENPC = "GameNPC";
        public const string SELECTOR_AREA = "Area";
        public const string SELECTOR_ITEM = "Item";
        public const string SELECTOR_WHIPSER = "Whisper";
        public const string SELECTOR_REGION = "Region";
        public const string SELECTOR_ZONE="Zone";
        public const string SELECTOR_TEXT="Text";
        public const string SELECTOR_LOCATION="Location";
        public const string SELECTOR_TEXTTYPE="TextType";
        public const string SELECTOR_EMOTE="Emote";
        public const string SELECTOR_CHARACTERCLASS = "CharacterClass";
        public const string SELECTOR_COMPARATOR = "Comparator";

        public const string TYPE_INT = "int";
        public const string TYPE_STRING = "string";
        public const string TYPE_LONG = "long";
        public const string TYPE_VAR = "var";
        
        /**
         * Value used to display in grids if value will be filled automatically         
         */
        public const String GRID_AUTOFILL_VALUE = "<AUTO>";        
		
		public const char CODE_COMPARATOR = 'C';				
		public const char CODE_K = 'K';
		public const char CODE_I = 'I';
		public const char CODE_N = 'N';
		public const char CODE_V = 'V';
		public const char CODE_P = 'P';
		public const char CODE_Q = 'Q';      

        public const string COMPARATOR_BINARY = "binary";
        public const string COMPARATOR_QUANTITY = "quantity";		

		public static string CodeToColumn(char constant) {
			switch (constant)
			{								
				case CODE_COMPARATOR:
					return DB.COL_QUESTPARTREQUIREMENT_COMPARATOR;
				default:
					return Convert.ToString(constant);
			}
		}
	}
}
