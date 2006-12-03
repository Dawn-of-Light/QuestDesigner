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
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Globalization;

namespace DOL.Tools.QuestDesigner.Converter
{
    class EnumerationConverterDatabase : StringConverter
    {
        protected string typename;
        protected string valueColumn;
        protected string descriptionColumn;

		public EnumerationConverterDatabase(string typename)
			: base()
		{
			this.typename = typename;
			this.valueColumn = "Value";
			this.descriptionColumn = "Description";
		}

        public EnumerationConverterDatabase(string typename, string valuecol, string desccol) : base() 
        { 
            this.typename = typename; 
            this.valueColumn = valuecol;
            this.descriptionColumn = desccol;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {            
            ArrayList vals = new ArrayList();
            foreach (DataRow row in QuestDesignerMain.DesignerForm.dataTableeEnumeration.Select("Type='"+typename+"'"))
            {
                vals.Add(row[descriptionColumn]);
            }
			vals.Sort(StringComparer.CurrentCulture);
            
            return new StandardValuesCollection(vals);

            
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
				foreach (DataRow row in QuestDesignerMain.DesignerForm.dataTableeEnumeration.Select("Type='" + typename + "'"))
                    if (Convert.ToString(row[descriptionColumn]) == (string)value)
                    {
                        return row[valueColumn];
                    }
            }
            else if (value!=null && !(value is DBNull))
            {
				DataRow[] rows = QuestDesignerMain.DesignerForm.dataTableeEnumeration.Select("Type='" + typename + "' AND " + descriptionColumn + "=" + value);
                object obj = null;
                if (rows.Length >= 1)
                {
                    DataRow row = rows[0];
                    // skip xx_First, xx_Last entries
                    foreach (DataRow tmpRow in rows)
                    {
                        string name = Convert.ToString(tmpRow["Name"]);

                        // search for a entry without _first or _last and return it, if none is found use the first entry found.
                        if (!(name.StartsWith("Max") && name.StartsWith("Min") && name.EndsWith("_Last") && name.EndsWith("_First")))
                        {
                            row = tmpRow;
                            break;
                        }
                    }

                    obj = row[valueColumn];                    
                    return obj;
                }
            }            
            return value;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is string)
            {
				foreach (DataRow row in QuestDesignerMain.DesignerForm.dataTableeEnumeration.Select("Type='" + typename + "'"))
                {
                    if (Convert.ToString(row[valueColumn]) == (string)value)
                    {
                        if (destinationType == typeof(string))
                            return Convert.ChangeType(row[descriptionColumn], destinationType, culture);
                        else
                            return Convert.ChangeType(row[valueColumn], destinationType, culture);
                    }
                    else if (Convert.ToString(row[descriptionColumn]) == (string)value)
                    {
                        if (destinationType == typeof(string))
                            return Convert.ChangeType(row[descriptionColumn], destinationType, culture);
                        else
                            return Convert.ChangeType(row[valueColumn], destinationType, culture);
                    }
                }
            } 
            else if (value!=null && !(value is DBNull))
            {
				DataRow[] rows = QuestDesignerMain.DesignerForm.dataTableeEnumeration.Select("Type='"+typename+"' AND "+ valueColumn + "=" + value);
                if (rows.Length>=1)
                {
                    DataRow row = rows[0];
                    
                    // skip xx_First, xx_Last entries
                    foreach (DataRow tmpRow in rows)
                    {
                        string name = Convert.ToString(tmpRow["Name"]);

                        // search for a entry without _first or _last and return it, if none is found use the first entry found.
                        if (!(name.StartsWith("Max") && name.StartsWith("Min") && name.EndsWith("_Last") && name.EndsWith("_First")))
                        {
                            row = tmpRow;
                            break;
                        }
                    }

                    if (destinationType == typeof(string))
                        return Convert.ChangeType(row[descriptionColumn], destinationType, culture);
                    else
                        return Convert.ChangeType(row[valueColumn], destinationType, culture);
                }
            }

            return Convert.ChangeType(value, destinationType, culture);
        }
	}
}
