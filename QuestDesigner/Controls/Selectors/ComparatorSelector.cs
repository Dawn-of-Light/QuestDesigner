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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
    [SelectorAttribute(Const.SELECTOR_COMPARATOR)]
	public class ComparatorSelector : BaseSelector
	{

		public ComparatorSelector(int itemID, char param,string comparatorType)
			: base(itemID, param)
		{
            this.list.ValueMember = DB.COL_ENUMERATION_VALUE;
            this.list.DisplayMember = DB.COL_ENUMERATION_DESCRIPTION;

            if (Const.COMPARATOR_BINARY.Equals(comparatorType))
			    this.list.DataSource = DB.comparatorBinaryBinding;
            else if (Const.COMPARATOR_QUANTITY.Equals(comparatorType))
                this.list.DataSource = DB.comparatorQuantityBinding;
            else
                this.list.DataSource = DB.comparatorBinding;
            
			this.Editable = false;
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.info;
		}
		
	}
}
