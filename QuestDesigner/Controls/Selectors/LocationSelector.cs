using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	[SelectorAttribute("Location")]
	public class LocationSelector : BaseSelector
	{		

		public LocationSelector(int triggerID, char param): base(triggerID,param)
		{			
			this.list.DataSource = DB.LocationTable;
			
			this.list.ValueMember = "ObjectName";
			this.list.DisplayMember = "Name";
			this.Editable = false;
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.area;
		}	
		
	}
}
