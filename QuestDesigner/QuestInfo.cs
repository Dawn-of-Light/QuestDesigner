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
using vbAccelerator.Components.Controls;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner
{
	public partial class QuestInfo : UserControl
	{
	
		public QuestInfo()
		{
			InitializeComponent();
		}

		public void setDataSet()
		{
            this.QuestName.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_NAME, true));
            this.Title.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_TITLE ,true));
            this.Author.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_AUTHOR, true));
            this.scriptDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_DATE, true));
            this.Version.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_VERSION, true));
            this.MaxQuestCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", DB.QuestTable, DB.COL_QUEST_MAXQUESTCOUNT, true));
            this.Namespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_NAMESPACE, true));
            this.LevelMin.DataBindings.Add(new System.Windows.Forms.Binding("Value", DB.QuestTable, DB.COL_QUEST_MINIMUMLEVEL, true));
            this.LevelMax.DataBindings.Add(new System.Windows.Forms.Binding("Value", DB.QuestTable, DB.COL_QUEST_MAXIMUMLEVEL, true));
            this.Notes.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, DB.COL_QUEST_DESCRIPTION, true));

			this.QuestStep.AutoGenerateColumns = true;
			this.QuestStep.DataSource = DB.QuestStepTable;
			
			this.QuestStep.Columns[0].FillWeight = 10;
			this.QuestStep.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.QuestStep.Columns[1].FillWeight = 90;
			this.QuestStep.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
						
			this.InvitingNPC.DisplayMember = DB.COL_NPC_NAME;
			this.InvitingNPC.ValueMember = DB.COL_NPC_OBJECTNAME;
            this.InvitingNPC.DataSource = DB.mobBinding;
            this.InvitingNPC.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", DB.QuestTable, DB.COL_QUEST_INVITINGNPC, true));            

            this.listBoxAvailable.DisplayMember = DB.COL_ENUMERATION_DESCRIPTION;
            this.listBoxAvailable.ValueMember = DB.COL_ENUMERATION_VALUE;
            this.listBoxAvailable.DataSource = DB.characterClassBinding;

            this.listBoxAllowed.DisplayMember = DB.COL_QUESTCHARACTERCLASS_DESCRIPTION;
            this.listBoxAllowed.ValueMember = DB.COL_QUESTCHARACTERCLASS_VALUE;
            this.listBoxAllowed.DataSource = DB.QuestCharacterClassTable;            
		}

        public void UpdateDataset()
        {
            if (this.InvitingNPC != null)
            {
                foreach (Binding binding in this.InvitingNPC.DataBindings)
                {
                    binding.ReadValue();
                }
            }
        }

		private void QuestName_Validating(object sender, CancelEventArgs e)
		{
			QuestName.Text = Utils.ConvertToObjectName(QuestName.Text);
			if (string.IsNullOrEmpty(QuestName.Text))
				errorProvider.SetError(QuestName, "Name of quest class is a mandatory field");
			else
				errorProvider.SetError(QuestName, "");
            
		}

		private void Namespace_Validating(object sender, CancelEventArgs e)
		{
			Namespace.Text = Utils.ConvertToNamespace(Namespace.Text);
			if (string.IsNullOrEmpty(Namespace.Text))
				errorProvider.SetError(Namespace, "Namespace must be valid for C# and not empty");
			else
				errorProvider.SetError(Namespace, "");
		}

        private void buttonAddClass_Click(object sender, EventArgs e)
        {
            foreach (DataRowView item in listBoxAvailable.SelectedItems)
            {

                if (DB.QuestCharacterClassTable.Select(DB.COL_QUESTCHARACTERCLASS_VALUE + "=" + item[DB.COL_ENUMERATION_VALUE]).Length == 0)
                {
                    DataRow row = DB.QuestCharacterClassTable.NewRow();

                    row[DB.COL_QUESTCHARACTERCLASS_VALUE] = item[DB.COL_ENUMERATION_VALUE];
                    row[DB.COL_QUESTCHARACTERCLASS_DESCRIPTION] = item[DB.COL_ENUMERATION_DESCRIPTION];

                    DB.QuestCharacterClassTable.Rows.Add(row);
                }
            }
        }

        private void buttonRemoveClass_Click(object sender, EventArgs e)
        {
            DataRowView[] rowViews = new DataRowView[listBoxAllowed.SelectedItems.Count];
            int[] values = new int[listBoxAllowed.SelectedItems.Count];

            for (int i=0; i< listBoxAllowed.SelectedItems.Count;i++) {

                values[i] = (int)((DataRowView)listBoxAllowed.SelectedItems[i])[DB.COL_QUESTCHARACTERCLASS_VALUE];
            }
            foreach (int value in values)
            {                
                DB.QuestCharacterClassTable.Select(DB.COL_QUESTCHARACTERCLASS_VALUE+"=" + value)[0].Delete();
            }
        }
	}
}
