using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	[SelectorAttribute("Region")]
	public class RegionSelector : BaseSelector
	{		

		public RegionSelector(int itemID, char param): base(itemID,param)
		{			
			this.list.DataSource = DB.RegionTable;
			
			this.list.ValueMember = "id";
			this.list.DisplayMember = "description";
			this.Editable = false;
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.area;
		}
		
	}
}
