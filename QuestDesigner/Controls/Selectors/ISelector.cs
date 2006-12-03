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
