using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
{
	[SelectorAttribute("Region")]
	public class RegionSelector : BaseSelector
	{		

		public RegionSelector(int itemID, char param): base(itemID,param)
		{			
			this.list.DataSource = DB.regionTable;
			
			this.list.ValueMember = "id";
			this.list.DisplayMember = "description";
			this.Editable = false;
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::QuestDesigner.Properties.Resources.area;
		}
		
	}
}
