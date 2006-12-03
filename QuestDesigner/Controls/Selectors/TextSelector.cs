using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	[SelectorAttribute("Text")]
	public class TextSelector : BaseSelector
	{		

		public TextSelector(int itemID, char param): base(itemID,param)
		{
			MultiLine = true;
		}				
	}
}
