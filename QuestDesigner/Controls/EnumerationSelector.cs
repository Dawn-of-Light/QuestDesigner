using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
{	
	public class EnumerationSelector : BaseSelector
	{

		public EnumerationSelector(int itemID, char param, string type)
			: base(itemID, param)
		{
			this.list.DataSource = DB.GetBindingSourceForEnumeration(type);
			
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
