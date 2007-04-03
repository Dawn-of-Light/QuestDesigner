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
        /**
         * Value used to display in grids if value will be filled automatically
         * 
         */
        public const String GRID_AUTOFILL_VALUE = "<AUTO>";

        public const String AREA_OBJECT_NAME = "ObjectName";
        public const String AREA_NAME = "Name";
		
		public const char CODE_COMPARATOR = 'C';				
		public const char CODE_K = 'K';
		public const char CODE_I = 'I';
		public const char CODE_N = 'N';
		public const char CODE_V = 'V';
		public const char CODE_P = 'P';
		public const char CODE_Q = 'Q';

        public const string TRIGGER_I = "I";
        public const string TRIGGER_K = "K";

        public const string ACTION_P = "P";
        public const string ACTION_Q = "Q";
        
        public const string REQUIREMENT_N = "N";
        public const string REQUIREMENT_V = "V";

        public const string COMPARATOR_BINARY = "binary";
        public const string COMPARATOR_QUANTITY = "quantity";

		public const string COLUMN_COMPARATOR = "Comparator";

		public static string CodeToColumn(char constant) {
			switch (constant)
			{								
				case CODE_COMPARATOR:
					return "Comparator";
				default:
					return Convert.ToString(constant);
			}
		}
	}
}
