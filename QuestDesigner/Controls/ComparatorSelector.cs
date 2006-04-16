using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
{
	[SelectorAttribute("Comparator")]
	public class ComparatorSelector : BaseSelector
	{

		public ComparatorSelector(int itemID, char param)
			: base(itemID, param)
		{			
			this.list.DataSource = DB.comparatorBinding;
			
			this.list.ValueMember = "Value";
			this.list.DisplayMember = "Description";
			this.Editable = false;
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::QuestDesigner.Properties.Resources.info;
		}
		
	}
}
