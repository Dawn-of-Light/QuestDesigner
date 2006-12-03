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

		public void setDataSet(DataSet questData)
		{
			this.QuestName.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.Name", true));
			this.Title.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.Title", true));
			this.Author.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.Author", true));
			this.scriptDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.Date", true));
			this.Version.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.Version", true));
			this.MaxQuestCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", questData, "Quest.MaxQuestCount", true));
			this.Namespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.Namespace", true));
			this.LevelMin.DataBindings.Add(new System.Windows.Forms.Binding("Value", questData, "Quest.MinimumLevel", true));
			this.LevelMax.DataBindings.Add(new System.Windows.Forms.Binding("Value", questData, "Quest.MaximumLevel", true));
			this.Notes.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.Description", true));

			this.QuestStep.AutoGenerateColumns = true;
			this.QuestStep.DataSource = questData;
			this.QuestStep.DataMember = "QuestStep";
			this.QuestStep.Columns[0].FillWeight = 10;
			this.QuestStep.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.QuestStep.Columns[1].FillWeight = 90;
			this.QuestStep.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			

			this.InvitingNPC.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", questData, "Quest.InvitingNPC", true));
			this.InvitingNPC.DataSource = DB.mobBinding;
			this.InvitingNPC.DisplayMember = "Name";
			this.InvitingNPC.ValueMember = "ObjectName";
		}

		private void QuestName_Validating(object sender, CancelEventArgs e)
		{
			QuestName.Text = Utils.ConvertToObjectName(QuestName.Text);
			if (string.IsNullOrEmpty(QuestName.Text))
				errorProvider.SetError(QuestName, "Name of quest class is amandatory field");
			else
				errorProvider.SetError(QuestName, "");
		}

		private void Namespace_Validating(object sender, CancelEventArgs e)
		{
			Namespace.Text = Utils.ConvertToNamespace(Namespace.Text);
			if (string.IsNullOrEmpty(Namespace.Text))
				errorProvider.SetError(Namespace, "Namespace must be valid for c# and not empty");
			else
				errorProvider.SetError(Namespace, "");
		}
	}
}
