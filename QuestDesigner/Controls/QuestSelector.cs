using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;
using DOL.GS.Scripts;
using DOL.GS.Quests;
using System.Reflection;
using System.Data;

namespace QuestDesigner.Controls
{
	[SelectorAttribute("QuestType")]
	public class QuestSelector : BaseSelector
	{		

		public QuestSelector(int triggerID, char param): base(triggerID,param)
		{
			foreach (DataRow row in DB.questTable.Rows)
			{
				this.list.Items.Add(row["Namespace"] + "." + row["Name"]);
			}
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::QuestDesigner.Properties.Resources.quest;
		}	
		
	}
}
