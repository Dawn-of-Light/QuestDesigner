using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;
using System.Reflection;
using System.Data;

namespace DOL.Tools.QuestDesigner.Controls
{
	[SelectorAttribute("QuestType")]
	public class QuestSelector : BaseSelector
	{		

		public QuestSelector(int triggerID, char param): base(triggerID,param)
		{
			foreach (DataRow row in DB.QuestTable.Rows)
			{
				this.list.Items.Add(row["Namespace"] + "." + row["Name"]);
			}
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.quest;
		}	
		
	}
}
