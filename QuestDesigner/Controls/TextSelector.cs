using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
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
