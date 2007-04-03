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
            this.QuestName.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, "Name", true));
            this.Title.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, "Title", true));
            this.Author.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, "Author", true));
            this.scriptDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, "Date", true));
            this.Version.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, "Version", true));
            this.MaxQuestCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", DB.QuestTable, "MaxQuestCount", true));
            this.Namespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, "Namespace", true));
            this.LevelMin.DataBindings.Add(new System.Windows.Forms.Binding("Value", DB.QuestTable, "MinimumLevel", true));
            this.LevelMax.DataBindings.Add(new System.Windows.Forms.Binding("Value", DB.QuestTable, "MaximumLevel", true));
            this.Notes.DataBindings.Add(new System.Windows.Forms.Binding("Text", DB.QuestTable, "Description", true));

			this.QuestStep.AutoGenerateColumns = true;
			this.QuestStep.DataSource = DB.QuestStepTable;
			
			this.QuestStep.Columns[0].FillWeight = 10;
			this.QuestStep.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.QuestStep.Columns[1].FillWeight = 90;
			this.QuestStep.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			

			this.InvitingNPC.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", DB.QuestTable, "InvitingNPC", true));			
			this.InvitingNPC.DisplayMember = "Name";
			this.InvitingNPC.ValueMember = "ObjectName";
            this.InvitingNPC.DataSource = DB.mobBinding;
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
	}
}
