using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	[SelectorAttribute("Comparator")]
	public class ComparatorSelector : BaseSelector
	{

		public ComparatorSelector(int itemID, char param,string comparatorType)
			: base(itemID, param)
		{			
            if (Const.COMPARATOR_BINARY.Equals(comparatorType))
			    this.list.DataSource = DB.comparatorBinaryBinding;
            else if (Const.COMPARATOR_QUANTITY.Equals(comparatorType))
                this.list.DataSource = DB.comparatorQuantityBinding;
            else
                this.list.DataSource = DB.comparatorBinding;
			
			this.list.ValueMember = "Value";
			this.list.DisplayMember = "Description";
			this.Editable = false;
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.info;
		}
		
	}
}
