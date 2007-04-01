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
        private IContainer components;		

		public TextSelector(int itemID, char param): base(itemID,param)
		{
			MultiLine = true;
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.Size = new System.Drawing.Size(158, 104);
            // 
            // TextSelector
            // 
            this.ClientSize = new System.Drawing.Size(160, 52);
            this.Name = "TextSelector";
            this.ShowDeleteButton = true;
            this.ShowMoreButton = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }				
	}
}
