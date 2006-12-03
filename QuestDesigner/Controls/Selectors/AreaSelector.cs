using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	
	[SelectorAttribute("Area")]
	public class AreaSelector : BaseSelector
	{		

		public AreaSelector(int itemID, char param): base(itemID,param)
		{			
			this.list.DataSource = DB.AreaTable;
			
			this.list.ValueMember = "ObjectName";
			this.list.DisplayMember = "Name";			
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.area;
		}
		
	}
}
