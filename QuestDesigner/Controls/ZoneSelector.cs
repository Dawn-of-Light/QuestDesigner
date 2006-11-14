using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
{
	[SelectorAttribute("Zone")]
	public class ZoneSelector : BaseSelector
	{		
		BindingSource bindingSourceZone;

		public ZoneSelector(int itemID, char param, int regionID): base (itemID,param)
		{
			if (regionID >= 0)
			{
				this.bindingSourceZone = new BindingSource();
				this.bindingSourceZone.DataSource = DB.ZoneTable;
				this.bindingSourceZone.Sort = "description";
				this.bindingSourceZone.Filter = "regionID=" + regionID;
				this.list.DataSource = this.bindingSourceZone;
			}
			else
			{
				this.list.DataSource = DB.ZoneTable;
			}
			this.list.ValueMember = "zoneID";
			this.list.DisplayMember = "description";
			this.Editable = false;
		}

		public ZoneSelector(int itemID, char param): this(itemID,param,-1) { }

		protected override System.Drawing.Image getImage(int index)
		{
			return global::QuestDesigner.Properties.Resources.area;
		}
		
	}
}
