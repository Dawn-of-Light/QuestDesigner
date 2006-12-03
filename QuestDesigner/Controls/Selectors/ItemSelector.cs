using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	[SelectorAttribute("Item")]
	public class ItemSelector : BaseSelector
	{		

		public ItemSelector(int triggerID, char param): base(triggerID,param)
		{			
			this.list.DataSource = DB.ItemTemplateTable;
			
			this.list.ValueMember = "ItemTemplateID";
			this.list.DisplayMember = "Name";			
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.item;
		}	
		
	}
}
