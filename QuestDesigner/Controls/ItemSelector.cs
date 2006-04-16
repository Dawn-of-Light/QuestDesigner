using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
{
	[SelectorAttribute("Item")]
	public class ItemSelector : BaseSelector
	{		

		public ItemSelector(int triggerID, char param): base(triggerID,param)
		{			
			this.list.DataSource = DB.itemTemplateTable;
			
			this.list.ValueMember = "ItemTemplateID";
			this.list.DisplayMember = "Name";			
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::QuestDesigner.Properties.Resources.item;
		}	
		
	}
}
