/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner
{
	public partial class CustomCode : UserControl
	{

		public CustomCode()
		{
			InitializeComponent();
		}

		public void setDataSet()
		{		
			this.textBoxLoadedCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_SCRIPTLOADEDCODE, true));
            this.textBoxUnloadedCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_SCRIPTUNLOADEDCODE, true));
            this.textBoxInitCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_INITIALIZATIONCODE, true));
            this.textBoxCheckQuestQualification.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_CHECKQUESTQUALIFICATIONCODE, true));
		}
	}
}
