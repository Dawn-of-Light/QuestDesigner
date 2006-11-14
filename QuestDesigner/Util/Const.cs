using System;
using System.Collections.Generic;
using System.Text;

namespace QuestDesigner.Util
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
