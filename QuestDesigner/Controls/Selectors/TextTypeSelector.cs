using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	[SelectorAttribute("TextType")]
	public class TextTypeSelector : BaseSelector
	{

		public TextTypeSelector(int itemID, char param)
			: base(itemID, param)
		{
			this.list.DataSource = DB.textTypeBinding;

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
