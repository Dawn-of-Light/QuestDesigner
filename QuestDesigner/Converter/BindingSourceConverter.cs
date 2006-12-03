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
using System.Windows.Forms;

namespace DOL.Tools.QuestDesigner.Converter
{
    class BindingSourceConverter : StringConverter
    {
		protected BindingSource bindingsource;
		protected string valueColumn;
        protected string descriptionColumn;

		public BindingSourceConverter(BindingSource bindingsource, string valuecol, string desccol)
			: base() 
        { 
            this.bindingsource = bindingsource; 
            this.valueColumn = valuecol;
            this.descriptionColumn = desccol;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {            
            ArrayList vals = new ArrayList();
            foreach (DataRowView row in bindingsource.List)
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
				foreach (DataRowView row in bindingsource.List)
				{
					if (Convert.ToString(row[descriptionColumn]) == (string)value)
					{
						return row[valueColumn];
					}
				}
            }
            else if (value!=null && !(value is DBNull))
            {
				foreach (DataRowView row in bindingsource.List) {
					if ((int)row[descriptionColumn] == (int)value)
					{
						return row[valueColumn];
					}
				}
            }            
            return value;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is string)
            {
                foreach (DataRowView row in bindingsource.List)
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
				foreach (DataRowView row in bindingsource.List) {
					if ((int)row[valueColumn] == (int)value)                
					{                    
						if (destinationType == typeof(string))
							return Convert.ChangeType(row[descriptionColumn], destinationType, culture);
						else
							return Convert.ChangeType(row[valueColumn], destinationType, culture);
					}
				}
            }

            return Convert.ChangeType(value, destinationType, culture);
        }
    }
}
