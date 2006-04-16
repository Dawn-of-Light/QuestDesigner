using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
{

	[SelectorAttribute("GameLiving")]
	public class NPCSelector : BaseSelector
	{		

		public NPCSelector(int questPartID, char param): base(questPartID,param)
		{			
			this.list.DataSource = DB.npcTable;
			
			this.list.ValueMember = "ObjectName";
			this.list.DisplayMember = "Name";
			
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::QuestDesigner.Properties.Resources.npc;
		}	
		
	}
}
