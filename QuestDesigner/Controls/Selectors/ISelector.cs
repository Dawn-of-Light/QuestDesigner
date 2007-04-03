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
using System.Windows.Forms;

namespace DOL.Tools.QuestDesigner.Controls
{
	public delegate void OnItemSelectedEventHandler(object sender, ItemSelectorEvent e);
	public delegate void OnItemDeletingEventHandler(object sender, ItemSelectorEvent e);
	public delegate void OnItemAddingEventHandler(object sender, ItemSelectorEvent e);
	public class ItemSelectorEvent
	{
		public int ItemID;
		public char Param;
		public object Object;

		public ItemSelectorEvent(int id, char p, object o)
		{
			ItemID = id;
			Param = p;
			Object = o;
		}		
	}

	[AttributeUsage(AttributeTargets.Class , AllowMultiple = false)]
	public class SelectorAttribute : System.Attribute
	{
		private string keyword;

		public SelectorAttribute(string keyword)
		{
			this.keyword = keyword;
		}

		public string Keyword
		{
			get { return keyword; }
		}
	}

	interface ISelector
	{
		
		event OnItemSelectedEventHandler OnItemSelected;
		event OnItemSelectedEventHandler OnItemAdding;
		event OnItemSelectedEventHandler OnItemDeleting;

		object SelectedValue { get; set; }

		bool ShowMoreButton { get; set; }
		bool ShowDeleteButton { get; set; }
	}
}
