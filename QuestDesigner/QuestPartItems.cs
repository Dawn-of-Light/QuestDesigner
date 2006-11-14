using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DOL.GS.Quests;
using QuestDesigner.Util;
using QuestDesigner.Controls;
using vbAccelerator.Components.Controls;
using System.Collections;

namespace QuestDesigner
{

	public partial class QuestPartItems : UserControl
	{
		public static char[] textSplitChar = new char[] {'$'};

		private bool _initializing = false;

		#region UI Customization

		private Color foreColorSelected = Color.Gray;

		public Color ForeColorSelected
		{
			get { return foreColorSelected; }
			set { foreColorSelected = value; }
		}


		private Color requirementColor = Color.Gray;

		public Color RequirementColor
		{
			get { return requirementColor; }
			set { requirementColor = value; }
		}

		private Color actionColor = Color.Gray;

		public Color ActionColor
		{
			get { return actionColor; }
			set { actionColor = value; }
		}

		private Color triggerColor = Color.Gray;
			
		public Color TriggerColor
		{
			get { return triggerColor; }
			set { triggerColor = value; }
		}

		private Color requirementSelectedColor = Color.Orange;

		public Color RequirementSelectedColor
		{
			get { return requirementSelectedColor; }
			set { requirementSelectedColor = value; }
		}

		private Color actionSelectedColor = Color.OrangeRed;

		public Color ActionSelectedColor
		{
			get { return actionSelectedColor; }
			set { actionSelectedColor = value; }
		}

		private Color triggerSelectedColor = Color.Green;

		public Color TriggerSelectedColor
		{
			get { return triggerSelectedColor; }
			set { triggerSelectedColor = value; }
		}

		#endregion

		// Instance of VXPLib Tooltip Manager:
		private VXPLibrary.VXPTooltipManager tooltipManager = new VXPLibrary.VXPTooltipManagerClass();				

		private PopupWindowHelper popupHelper = null;

		public DataRowView QuestPartRow
		{
			get
			{
				DataRowView row = (DataRowView)DB.questPartBinding.Current;
				if (row != null && row.Row.RowState != DataRowState.Deleted)
					return row;
				else
					return null;
			}
		}

		public QuestPartItems()
		{
			InitializeComponent();			

			popupHelper = new PopupWindowHelper();
		}

		private IList<QuestPartTextInfo> questPartInfos = new List<QuestPartTextInfo>();
		
		public void SetDataSet(DataSet questSet, DataSet dataSet) {
			// Fill triggertype checklist with triggertypes...									
		}

		#region Helper Methods

		private int GetIndexForRequirementType(int type)
		{
			DataRow[] rows = DB.RequirementTypeTable.Select("id=" + type);
			if (rows.Length > 0)
				return requirementTypeList.Items.IndexOf(rows[0]["description"]);
			else
				return -1;
		}

		private int GetIndexForActionType(int type)
		{
			DataRow[] rows = DB.ActionTypeTable.Select("id=" + type);
			if (rows.Length > 0)
				return actionTypeList.Items.IndexOf(rows[0]["description"]);
			else
				return -1;
		}

		private int GetIndexForTriggerType(int type)
		{
			DataRow[] rows = DB.TriggerTypeTable.Select("id=" + type );
			if (rows.Length > 0)
				return triggerTypeList.Items.IndexOf(rows[0]["description"]);
			else
				return -1;
		}

		private int GetRequirementTypeForDescription(string desc)
		{
			DataRow[] rows = DB.RequirementTypeTable.Select("description='" + desc + "'");
			if (rows.Length > 0)
				return (int)rows[0]["id"];
			else
				return -1;
		}

		private int GetActionTypeForDescription(string desc)
		{
			DataRow[] rows = DB.ActionTypeTable.Select("description='" + desc + "'");
			if (rows.Length > 0)
				return (int)rows[0]["id"];
			else
				return -1;
		}

		private int GetTriggerTypeForDescription(string desc)
		{
			DataRow[] rows = DB.TriggerTypeTable.Select("description='" + desc + "'");
			if (rows.Length > 0)
				return (int)rows[0]["id"];
			else
				return -1;
		}

		private DataRow[] GetTriggersForType(int type) {
			if (QuestPartRow!=null && type>=0)
				return DB.TriggerTable.Select("QuestPartID=" + QuestPartRow["ID"] + " AND Type=" + type);
			else
				return new DataRow[0];					
		}

		private DataRow[] GetRequirementsForType(int type)
		{
			if (QuestPartRow != null && type >= 0)
				return DB.RequirementTable.Select("QuestPartID=" + QuestPartRow["ID"] + " AND Type=" + type);
			else
				return new DataRow[0];
		}

		private DataRow[] GetActionsForType(int type)
		{
			if (QuestPartRow != null && type >= 0)
				return DB.ActionTable.Select("QuestPartID=" + QuestPartRow["ID"] + " AND Type=" + type);
			else
				return new DataRow[0];
		}

		private DataRow[] GetTriggerRowsForDescription(string description)
		{
			DataRow[] triggerRows = new DataRow[0];
			if (description != null && QuestPartRow !=null)
			{
				DataRow[] rows = DB.TriggerTypeTable.Select("description='" + description + "'");
				if (rows.Length > 0)
				{
					int triggerType = (int) rows[0]["id"];
					triggerRows = DB.TriggerTable.Select("QuestPartID=" + QuestPartRow["ID"]+" AND Type="+triggerType);
				}
			}
			return triggerRows;
		}
		#endregion
		

		protected void RefreshQuestPartText()
		{
			questPartTextbox.BeginUpdate();
			
			questPartTextbox.Clear();
			questPartTextbox.Select(0, 0);
			questPartInfos.Clear();
			bool first = true;
			foreach (DataRowView row in DB.questPartBinding.List)
			{
				if (!first)
					questPartTextbox.InsertText("\n\n");
				first = false;
				UpdateQuestPartText(row.Row);
				
			}

			questPartTextbox.EndUpdate();
		}

		protected void RefreshQuestPartText(DataRow questPartRow)
		{
			RefreshQuestPartText();
		}
		
		private void UpdateQuestPartText(DataRow questPartRow)
		{
			tooltipManager.tool.Hide(true);
			
			bool first = true;
			bool isLink;
			if (questPartRow != null)
			{
				questPartTextbox.BeginUpdate();
				bool selected = (QuestPartRow != null && Convert.ToInt16(questPartRow["ID"]) == Convert.ToInt16(QuestPartRow["ID"]));			
				
				// textinfo
				QuestPartTextInfo textinfo = GetInfoForQuestPartRow(questPartRow);								
				if (textinfo !=null) {
					questPartTextbox.SelectRange(textinfo.BeginIndex, textinfo.EndIndex);
					questPartTextbox.ReadOnly = false;
					questPartTextbox.SelectedText = "";
					questPartTextbox.ReadOnly = true;
				} else {
					textinfo = new QuestPartTextInfo();					
					questPartInfos.Add(textinfo);
				}
				textinfo.BeginIndex = questPartTextbox.SelectionStart;				
				// textinfo

				questPartTextbox.Select(textinfo.BeginIndex, 0);
				int colorBegin = questPartTextbox.SelectionStart;
				// Trigger

				DataRow[] triggerRows = DB.TriggerTable.Select("QuestPartID=" + questPartRow["ID"]);
				questPartTextbox.InsertText("If ");				
				questPartTextbox.Color(colorBegin, questPartTextbox.SelectionEnd, selected ? ForeColorSelected : questPartTextbox.ForeColor);
				colorBegin = questPartTextbox.SelectionEnd;
				if (triggerRows.Length > 0)
				{					

					foreach (DataRow row in triggerRows)
					{
						int triggerType = (int)row["Type"];						
						string k = Convert.ToString(row["K"]);
						string i = Convert.ToString(row["I"]);
						
						k = string.IsNullOrEmpty(k) ? null : k;
						i = string.IsNullOrEmpty(i) ? null : i;

						if (!first)
							questPartTextbox.InsertText(" or ");
						first = false;

						string triggerText = Utils.TriggerText((eTriggerType)triggerType, k, i);

						string[] elements = triggerText.Split(textSplitChar, StringSplitOptions.RemoveEmptyEntries);
						isLink = triggerText.StartsWith("$");

						foreach (string str in elements)
						{
							if (isLink)
							{
								questPartTextbox.InsertLink(str.Substring(1), (int)row["ID"] + ":"+ str.Substring(0,1));
							}
							else
								questPartTextbox.InsertText(str);

							isLink = !isLink;
						}
					}										
				}
				else
				{
					questPartTextbox.InsertText("never");
				}

				questPartTextbox.Color(colorBegin, questPartTextbox.SelectionEnd,selected ? TriggerSelectedColor : TriggerColor);				
				colorBegin = questPartTextbox.SelectionEnd;
				// Requirements


				DataRow[] requirementRows = DB.RequirementTable.Select("QuestPartID=" + questPartRow["ID"]);

				if (requirementRows.Length > 0)
				{
					questPartTextbox.InsertText(" and ");

					questPartTextbox.Color(colorBegin, questPartTextbox.SelectionEnd, selected ? ForeColorSelected : questPartTextbox.ForeColor);					
					colorBegin = questPartTextbox.SelectionEnd;					

					first = true;
					foreach (DataRow row in requirementRows)
					{
						int type = (int)row["Type"];						
						string n = Convert.ToString(row["N"]);
						string v = Convert.ToString(row["V"]);
						eComparator comp = row["Comparator"] is int ? (eComparator)((int)row["Comparator"]) : eComparator.None;
						
						n = string.IsNullOrEmpty(n) ? null : n;
						v = string.IsNullOrEmpty(v) ? null : v;
						
						if (!first)
							questPartTextbox.InsertText(" and ");
						first = false;

						string requirementText = Utils.RequirementText((eRequirementType)type, n, v, comp );

						string[] elements = requirementText.Split(textSplitChar, StringSplitOptions.RemoveEmptyEntries);
						isLink = requirementText.StartsWith("$");

						foreach (string str in elements)
						{
							if (isLink)
							{
								questPartTextbox.InsertLink(str.Substring(1), (int)row["ID"] + ":" + str.Substring(0, 1));
							}
							else
								questPartTextbox.InsertText(str);

							isLink = !isLink;
						}
					}

					// color
					questPartTextbox.Color(colorBegin, questPartTextbox.SelectionEnd,selected ? RequirementSelectedColor : RequirementColor);					
					colorBegin = questPartTextbox.SelectionEnd;
				}
				

				// Actions
				questPartTextbox.InsertText(" then ");
				questPartTextbox.Color(colorBegin, questPartTextbox.SelectionEnd,selected ? ForeColorSelected : questPartTextbox.ForeColor );				
				colorBegin = questPartTextbox.SelectionEnd;

				DataRow[] actionRows = DB.ActionTable.Select("QuestPartID=" + questPartRow["ID"]);

				if (actionRows.Length > 0)
				{					
					first = true;
					foreach (DataRow row in actionRows)
					{
						int type = (int)row["Type"];						
						string p = Convert.ToString(row["P"]);
						string q = Convert.ToString(row["Q"]);
						
						p = string.IsNullOrEmpty(p) ? null : p;
						q = string.IsNullOrEmpty(q) ? null : q;

						if (!first)
							questPartTextbox.InsertText(" and ");
						first = false;

						string actionText = Utils.ActionText((eActionType)type, p, q);

						string[] elements = actionText.Split(textSplitChar, StringSplitOptions.RemoveEmptyEntries);
						isLink = actionText.StartsWith("$");

						foreach (string str in elements)
						{
							if (isLink)
							{
								questPartTextbox.InsertLink(str.Substring(1), (int)row["ID"] + ":" + str.Substring(0, 1));
							}
							else
								questPartTextbox.InsertText(str);

							isLink = !isLink;
						}
					}
				}
				else 
				{
					questPartTextbox.InsertText("nothing happens");
				}

				// end
				questPartTextbox.Color(colorBegin, questPartTextbox.SelectionEnd, selected ? ActionSelectedColor : ActionColor);
				questPartTextbox.InsertText(".");

				// recalculate index of textinfos after current one
				if (textinfo.EndIndex > 0)
				{
					int newDifference = questPartTextbox.SelectionEnd - textinfo.EndIndex;
					
					for (int i = questPartInfos.IndexOf(textinfo)+ 1; i< questPartInfos.Count;i++) {
						QuestPartTextInfo info = questPartInfos[i];
						info.BeginIndex += newDifference;
						info.EndIndex += newDifference;
					}
				}
				textinfo.EndIndex = questPartTextbox.SelectionEnd;				

				questPartTextbox.EndUpdate();
			}			
		}

		private void RefreshQuestPart()
		{
			_initializing = true;

			this.triggerTypeList.Enabled = (QuestPartRow != null);
			this.requirementTypeList.Enabled = (QuestPartRow != null);
			this.actionTypeList.Enabled = (QuestPartRow != null);

			triggerTypeList.ClearSelected();
			for (int i = 0; i < triggerTypeList.Items.Count; i++)
				triggerTypeList.SetItemCheckState(i,CheckState.Unchecked );

			requirementTypeList.ClearSelected();
			for (int i = 0; i < requirementTypeList.Items.Count; i++)
				requirementTypeList.SetItemCheckState(i, CheckState.Unchecked);

			actionTypeList.ClearSelected();
			for (int i = 0; i < actionTypeList.Items.Count; i++)
				actionTypeList.SetItemCheckState(i, CheckState.Unchecked);

			if (QuestPartRow != null)
			{				
				foreach (DataRow row in DB.TriggerTable.Select("QuestPartID=" + QuestPartRow["ID"]))
				{					
					int index = GetIndexForTriggerType((int)row["Type"]);
					if (index >= 0 && !triggerTypeList.GetItemChecked(index))
						triggerTypeList.SetItemChecked(index, true);
				}

				foreach (DataRow row in DB.RequirementTable.Select("QuestPartID=" + QuestPartRow["ID"]))
				{
					int index = GetIndexForRequirementType((int)row["Type"]);
					if (index >= 0 && !requirementTypeList.GetItemChecked(index))
						requirementTypeList.SetItemChecked(index, true);
				}

				foreach (DataRow row in DB.ActionTable.Select("QuestPartID=" + QuestPartRow["ID"]))
				{
					int index = GetIndexForActionType((int)row["Type"]);
					if (index >= 0 && !actionTypeList.GetItemChecked(index))
						actionTypeList.SetItemChecked(index, true);
				}
			}
			_initializing = false;			
		}

		private void triggerTypeList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (QuestPartRow == null || _initializing)
				return;

			if (e.NewValue == CheckState.Checked)
			{
				string description = triggerTypeList.Items[e.Index] as string;
				int triggerType = GetTriggerTypeForDescription(description);
				if (triggerType >=0)
				{					
					DataRow triggerRow = DB.TriggerTable.NewRow();
					triggerRow["QuestPartID"] = QuestPartRow["ID"];
					triggerRow["Type"] = triggerType;

					DB.TriggerTable.Rows.Add(triggerRow);
				}
			}
			else
			{
				string description = triggerTypeList.Items[e.Index] as string;				
				int triggerType = GetTriggerTypeForDescription(description);

				foreach (DataRow row in GetTriggersForType(triggerType))
				{
					DB.TriggerTable.Rows.Remove(row);
				}
			}			
		}

		private void requirementTypeList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (QuestPartRow == null || _initializing)
				return;

			if (e.NewValue == CheckState.Checked)
			{
				string description = requirementTypeList.Items[e.Index] as string;
				int requType = GetRequirementTypeForDescription(description);
				if (requType >= 0)
				{
					DataRow newRow = DB.RequirementTable.NewRow();
					newRow["QuestPartID"] = QuestPartRow["ID"];
					newRow["Type"] = requType;

					DB.RequirementTable.Rows.Add(newRow);
				}
			}
			else
			{
				string description = requirementTypeList.Items[e.Index] as string;
				int requType = GetRequirementTypeForDescription(description);

				foreach (DataRow row in GetRequirementsForType(requType))
				{
					DB.RequirementTable.Rows.Remove(row);
				}
			}
		}

		private void actionTypeList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (QuestPartRow == null || _initializing)
				return;

			if (e.NewValue == CheckState.Checked)
			{
				string description = actionTypeList.Items[e.Index] as string;
				int actionType = GetActionTypeForDescription(description);
				if (actionType >= 0)
				{
					DataRow newRow = DB.ActionTable.NewRow();
					newRow["QuestPartID"] = QuestPartRow["ID"];
					newRow["Type"] = actionType;

					DB.ActionTable.Rows.Add(newRow);

				}
			}
			else
			{
				string description = actionTypeList.Items[e.Index] as string;
				int requType = GetActionTypeForDescription(description);

				foreach (DataRow row in GetActionsForType(requType))
				{
					DB.ActionTable.Rows.Remove(row);
				}
			}
		}

		private void questPartTextbox_LinkClicked(object sender, LinkClickedEventArgs e)
		{

			string code = e.LinkText.Substring(e.LinkText.IndexOf('#')+1);
			int id = Convert.ToInt32(code.Substring(0,code.IndexOf(':')));
			char param = Convert.ToChar(code.Substring(code.IndexOf(':')+1));

			ISelector selector = null;
			switch (param) {
				case Const.CODE_I:
				case Const.CODE_K:
				{
					DataRow[] rows = DB.TriggerTable.Select("ID=" + id);
					if (rows.Length > 0)
					{
						DataRow triggerRow = rows[0];						

						int triggerType = (int)triggerRow["Type"];
						DataRow triggerTypeRow = DB.GetTriggerTypeRowForID(triggerType);

						selector = SelectorFactory.GetSelector(Convert.ToString(triggerTypeRow[Const.CodeToColumn(param).ToLower()]), (int)triggerRow["ID"], param);
						selector.SelectedValue = triggerRow[Const.CodeToColumn(param)];

					}
					break;
				}
			case Const.CODE_N:
			case Const.CODE_V:
			case Const.CODE_COMPARATOR:
				{
					DataRow[] rows = DB.RequirementTable.Select("ID=" + id);
					if (rows.Length > 0)
					{
						DataRow requirementRow = rows[0];						
						
						int requirementType = (int)requirementRow["Type"];
						DataRow requirementTypeRow = DB.GetRequirementTypeRowForID(requirementType);

						if (requirementType ==(int) eRequirementType.Region && param == Const.CODE_N)
						{
							selector = new ZoneSelector((int)requirementRow["ID"], param, requirementRow["V"] != DBNull.Value ? Convert.ToInt32(requirementRow["V"]) : -1);
						}
						else
						{
							selector = SelectorFactory.GetSelector(Convert.ToString(requirementTypeRow[Const.CodeToColumn(param).ToLower()]), (int)requirementRow["ID"], param);							
						}						
						selector.SelectedValue = requirementRow[Const.CodeToColumn(param)];

					}
					break;
				}
			case Const.CODE_P:
			case Const.CODE_Q:			
				{
					DataRow[] rows = DB.ActionTable.Select("ID=" + id);
					if (rows.Length > 0)
					{
						DataRow actionRow = rows[0];
						int actionType = (int)actionRow["Type"];
						DataRow actionTypeRow = DB.GetActionTypeRowForID(actionType);
						
						selector = SelectorFactory.GetSelector(Convert.ToString(actionTypeRow[Const.CodeToColumn(param).ToLower()]), (int)actionRow["ID"], param);
						selector.SelectedValue = actionRow[Const.CodeToColumn(param)];
					}
					break;
				}
			}

			if (selector != null)
			{
				selector.OnItemSelected += new OnItemSelectedEventHandler(itemSelector_OnItemSelected);
				selector.OnItemAdding += new OnItemSelectedEventHandler(selector_OnItemAdding);
				selector.OnItemDeleting += new OnItemSelectedEventHandler(selector_OnItemDeleting);

				if (selector is Form)
				{
					((Form)selector).Location = this.PointToClient(Cursor.Position);
					Point pt = Cursor.Position;
					pt.Y = ((pt.Y / 13) + 1) * 13;
					popupHelper.ShowPopup(QuestDesignerMain.DesignerForm, (Form)selector, pt);
				}
				else
				{
					Log.Error("Encountered Selector that is no subclass of System.Windows.Form, and cannot be displayed therefore: " + selector.GetType().Name);
				}
			}
		}

		void selector_OnItemDeleting(object sender, ItemSelectorEvent e)
		{
			if (QuestPartRow != null)
			{
				switch (Convert.ToChar(e.Param))
				{										
					case Const.CODE_I:
					case Const.CODE_K:
						{
							DataRow[] rows = DB.TriggerTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								rows[0].Delete();								
							}
							break;
						}
					case Const.CODE_N:
					case Const.CODE_V:
					case Const.CODE_COMPARATOR:
						{
							DataRow[] rows = DB.RequirementTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								rows[0].Delete();								
							}
							break;
						}
					case Const.CODE_P:
					case Const.CODE_Q:
						{
							DataRow[] rows = DB.ActionTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								rows[0].Delete();								
							}
							break;
						}
				}
			}
		}

		void selector_OnItemAdding(object sender, ItemSelectorEvent e)
		{
			if (QuestPartRow != null)
			{
				switch (Convert.ToChar(e.Param))
				{					
					case Const.CODE_I:
					case Const.CODE_K:
						{
							DataRow[] rows = DB.TriggerTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								DataRow newRow = DB.TriggerTable.NewRow();
								newRow["QuestPartID"] = rows[0]["QuestPartID"];
								newRow["Type"] = rows[0]["Type"];
								DB.TriggerTable.Rows.Add(newRow);								
							}
							break;
						}
					case Const.CODE_N:
					case Const.CODE_V:
					case Const.CODE_COMPARATOR:
						{
							DataRow[] rows = DB.RequirementTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								DataRow newRow = DB.RequirementTable.NewRow();
								newRow["QuestPartID"] = rows[0]["QuestPartID"];
								newRow["Type"] = rows[0]["Type"];
								DB.RequirementTable.Rows.Add(newRow);								
							}
							break;
						}					
					case Const.CODE_P:
					case Const.CODE_Q:
						{
							DataRow[] rows = DB.ActionTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								DataRow newRow = DB.ActionTable.NewRow();
								newRow["QuestPartID"] = rows[0]["QuestPartID"];
								newRow["Type"] = rows[0]["Type"];
								DB.ActionTable.Rows.Add(newRow);								
							}
							break;
						}
				}
			}
		}		

		void itemSelector_OnItemSelected(object sender, ItemSelectorEvent e)
		{
			if (QuestPartRow != null && e.Object != null)
			{
				switch (Convert.ToChar(e.Param))
				{
					//trigger
					case Const.CODE_I:
					case Const.CODE_K:
						{
							DataRow[] rows = DB.TriggerTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								rows[0][Const.CodeToColumn(e.Param)] = Convert.ToString(e.Object);
								RefreshQuestPartText();
							}
							break;
						}

					//Requirement
					case Const.CODE_N:
					case Const.CODE_V:
						{
							DataRow[] rows = DB.RequirementTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								rows[0][Const.CodeToColumn(e.Param)] = Convert.ToString(e.Object);
								RefreshQuestPartText();
							}
							break;
						}
					case Const.CODE_COMPARATOR:
						{
							DataRow[] rows = DB.RequirementTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								rows[0][Const.CodeToColumn(e.Param)] = e.Object;
								RefreshQuestPartText();
							}
							break;
						}

					//Actions
					case Const.CODE_P:
					case Const.CODE_Q:
						{
							DataRow[] rows = DB.ActionTable.Select("ID=" + e.ItemID);
							if (rows.Length > 0)
							{
								rows[0][Const.CodeToColumn(e.Param)] = Convert.ToString(e.Object);
								RefreshQuestPartText();
							}
							break;
						}
				}				
			}
		}

		#region Context Menu Quickmenu

		private void interactToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTrigger(eTriggerType.Interact);
		}

		private void whisperToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTrigger(eTriggerType.Whisper);
		}

		private void questGivableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddRequirement(eRequirementType.QuestGivable);
		}

		private void questPendingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddRequirement(eRequirementType.QuestPending);
		}

		private void queststepToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddRequirement(eRequirementType.QuestStep);
		}

		private void giveItemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddAction(eActionType.GiveItem);
		}

		private void increaseQueststepToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddAction(eActionType.IncQuestStep);
		}

		private void offerAcceptQuestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Add Quest Offer Step
			DataRow newRow = DB.QuestPartTable.NewRow();
			if (DB.MobTable.Rows.Count > 0)
				newRow["NPC"] = DB.MobTable.Rows[0]["ObjectName"];

			DB.QuestPartTable.Rows.Add(newRow);
			int questPartID = (int)newRow["ID"];

			AddTrigger(eTriggerType.Interact, questPartID);
			AddAction(eActionType.OfferQuest, questPartID);
			AddRequirement(eRequirementType.QuestGivable, questPartID);

			// Add Quest Accept Step
			newRow = DB.QuestPartTable.NewRow();
			if (DB.MobTable.Rows.Count > 0)
				newRow["NPC"] = DB.MobTable.Rows[0]["ObjectName"];

			DB.QuestPartTable.Rows.Add(newRow);
			questPartID = (int)newRow["ID"];

			AddTrigger(eTriggerType.AcceptQuest, questPartID);
			AddRequirement(eRequirementType.QuestGivable, questPartID);
			AddAction(eActionType.Talk, questPartID);
			AddAction(eActionType.GiveQuest, questPartID);


			// Add Quest Decline Step
			newRow = DB.QuestPartTable.NewRow();
			if (DB.MobTable.Rows.Count > 0)
				newRow["NPC"] = DB.MobTable.Rows[0]["ObjectName"];

			DB.QuestPartTable.Rows.Add(newRow);
			questPartID = (int)newRow["ID"];

			AddTrigger(eTriggerType.DeclineQuest, questPartID);
			AddRequirement(eRequirementType.QuestGivable, questPartID);
			AddAction(eActionType.Talk, questPartID);
		}	

		private void AddTrigger(eTriggerType triggerType)
		{
			if (QuestPartRow != null)
			{
				int questPartID = (int)QuestPartRow["ID"];
				AddTrigger(triggerType, questPartID);
			}
		}

		private void AddTrigger(eTriggerType triggerType, int questPartID)
		{
			DataRow row = DB.TriggerTable.NewRow();
			row["QuestPartID"] = questPartID;
			row["Type"] = triggerType;
			DB.TriggerTable.Rows.Add(row);
		}

		private void AddRequirement(eRequirementType requirementType)
		{
			if (QuestPartRow!=null)
			{
				int questPartID = (int)QuestPartRow["ID"];
				AddRequirement(requirementType, questPartID);
			}
		}

		private void AddRequirement(eRequirementType requirementType, int questPartID)
		{
			DataRow row = DB.RequirementTable.NewRow();
			row["QuestPartID"] = questPartID;
			row["Type"] = requirementType;
			DB.RequirementTable.Rows.Add(row);
		}

		private void AddAction(eActionType actionType)
		{
			if (QuestPartRow !=null)
			{
				int questPartID = (int) QuestPartRow["ID"];
				AddAction(actionType, questPartID);
			}
		}

		private void AddAction(eActionType actionType, int questPartID)
		{
			DataRow row = DB.ActionTable.NewRow();
			row["QuestPartID"] = questPartID;
			row["Type"] = actionType;
			DB.ActionTable.Rows.Add(row);
		}

		#endregion

		private void QuestPartItems_Load(object sender, EventArgs e)
		{
			if (DB.isInitialized())
			{
				DB.ActionTable.RowChanged += new DataRowChangeEventHandler(questPartItemTable_RowChanged);
				DB.ActionTable.RowDeleted += new DataRowChangeEventHandler(questPartItemTable_RowChanged);
				DB.TriggerTable.RowChanged += new DataRowChangeEventHandler(questPartItemTable_RowChanged);
				DB.TriggerTable.RowDeleted += new DataRowChangeEventHandler(questPartItemTable_RowChanged);
				DB.RequirementTable.RowChanged += new DataRowChangeEventHandler(questPartItemTable_RowChanged);
				DB.RequirementTable.RowDeleted += new DataRowChangeEventHandler(questPartItemTable_RowChanged);

				triggerTypeList.Items.Clear();
				foreach (DataRow row in DB.TriggerTypeTable.Rows)
				{
					triggerTypeList.Items.Add(row["description"], false);
				}

				requirementTypeList.Items.Clear();
				foreach (DataRow row in DB.RequirementTypeTable.Rows)
				{
					requirementTypeList.Items.Add(row["description"], false);
				}

				actionTypeList.Items.Clear();
				foreach (DataRow row in DB.ActionTypeTable.Rows)
				{
					actionTypeList.Items.Add(row["description"], false);
				}

				bindingNavigator.BindingSource = DB.questPartBinding;
			
				DB.questPartBinding.CurrentChanged += new EventHandler(questPartBinding_CurrentChanged);							
				DB.questPartBinding.ListChanged += new ListChangedEventHandler(questPartBinding_ListChanged);
			}

			toolStripLabelAction.ForeColor = ActionSelectedColor;
			toolStripLabelTrigger.ForeColor = TriggerSelectedColor;
			toolStripLabelRequirement.ForeColor = RequirementSelectedColor;
			// Attaching event handler:
			this.tooltipManager.OnActivateCustomTooltip += new VXPLibrary._IVXPTooltipManagerEvents_OnActivateCustomTooltipEventHandler(this.ttm_OnActivateCustomTooltip);
			
			// The following set of parameters seems to be
			// optimum for sliders that allow delays:
			tooltipManager.ShowDelay = 150;
			tooltipManager.tool.FadeHide = 50;
			tooltipManager.tool.FadeShow = 50;
			
			// Setting up some parameters for our simple
			// tooltip object:
			tooltipManager.tool.HasTail = false;
			tooltipManager.tool.BorderColor =(uint) SystemColors.ButtonShadow.ToArgb();
			tooltipManager.tool.HasBorder = true;			

			tooltipManager.tool.Autohide = true; // Do not hide automatically
			tooltipManager.tool.TraceMode = false;	// Follow the mouse cursor			
		}

		void questPartBinding_CurrentChanged(object sender, EventArgs e)
		{
			RefreshQuestPart();
			
			if (QuestPartRow != null)
			{
				RefreshQuestPartText(QuestPartRow.Row);
				
				QuestPartTextInfo info = GetInfoForQuestPartRow(QuestPartRow.Row);
				questPartTextbox.Select(info.BeginIndex, 0);
				questPartTextbox.ScrollToCaret();
				questPartTextbox.Focus();
			}
			
		}		

		void questPartBinding_ListChanged(object sender, ListChangedEventArgs e)
		{
			if (e.ListChangedType == ListChangedType.ItemChanged)
			{
				DataRowView changedRow = (DataRowView) DB.questPartBinding[e.NewIndex];
				RefreshQuestPartText(changedRow.Row);
			}
			else if (e.ListChangedType == ListChangedType.ItemDeleted)
			{
				RefreshQuestPartText();
			}
			else if (e.ListChangedType == ListChangedType.ItemAdded)
			{
				RefreshQuestPartText();
			}
		}
					

		void questPartItemTable_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (e.Action == DataRowAction.Delete || e.Action == DataRowAction.Add)
				RefreshQuestPartText(QuestPartRow.Row);
			else
			{
				int questPartID = (int)e.Row["QuestPartID"];

				DataRow[] rows = DB.QuestPartTable.Select("ID=" + questPartID);
				if (rows.Length > 0)
					RefreshQuestPartText(rows[0]);
				else if (QuestPartRow != null)
					RefreshQuestPartText(QuestPartRow.Row);
			}
		}

		#region Tooltip

		// This event is called for any window that doesn't have
		// a tooltip attached to it:
		private void ttm_OnActivateCustomTooltip(int hWnd, string ClassName, short X, short Y, ref string Text)
		{
			if (hWnd == triggerTypeList.Handle.ToInt32())
				ShowTooltip(triggerTypeList,triggerTypeList.IndexFromPoint((int)X,(int)Y));
			else if (hWnd == requirementTypeList.Handle.ToInt32()) 
				ShowTooltip(requirementTypeList, requirementTypeList.IndexFromPoint((int)X, (int)Y));
			if (hWnd == actionTypeList.Handle.ToInt32()) 
				ShowTooltip(actionTypeList, actionTypeList.IndexFromPoint((int)X, (int)Y));
		}

		private void ShowTooltip(CheckedListBox list, int index)
		{
			//tooltip.Hide(true);

			// Update the current QHTML document in the tooltip:
			string helpHTML = null;

			if (list == triggerTypeList)
				helpHTML = GetTriggerHelp(GetTriggerTypeForDescription(Convert.ToString(triggerTypeList.Items[index])));
			else if (list == requirementTypeList)
				helpHTML = GetRequirementHelp(GetRequirementTypeForDescription(Convert.ToString(requirementTypeList.Items[index])));
			else if (list == actionTypeList)
				helpHTML = GetActionHelp(GetActionTypeForDescription(Convert.ToString(actionTypeList.Items[index])));

			if (helpHTML != null)
			{				
				tooltipManager.tool.html.SetSourceText("<body bgcolor=INFOBK text=INFOTEXT>" + helpHTML);

				// Because we do not even hide the tooltip we have
				// to call recalculation of layout manually:
				tooltipManager.tool.html.RecalculateLayout();				

				Rectangle rect = list.GetItemRectangle(index);
				Point pt = new Point(rect.Left, rect.Top);
				pt.Offset(rect.Width / 3, rect.Height / 2);
				pt = list.PointToScreen(pt);
				tooltipManager.tool.ShowAt((short)pt.X, (short)pt.Y);
			}
		}

		private string GetActionHelp(int actionID)
		{
			DataRow[] rows = DB.ActionTypeTable.Select("id=" + actionID + "");
			if (rows.Length > 0)
			{
				return String.Format("{0}<hr><b>P:</b>{1}<br><b>Q:</b>{2}", new object[] { rows[0]["help"], rows[0]["p"], rows[0]["q"] });
			}
			else
			{
				return string.Empty;
			}
		}

		private string GetTriggerHelp(int triggerID)
		{
			DataRow[] rows = DB.TriggerTypeTable.Select("id=" + triggerID + "");
			
			if (rows.Length > 0)
			{
				return String.Format("{0}<hr><b>K:</b>{1}<br><b>I:</b>{2}", new object[] { rows[0]["help"], rows[0]["k"], rows[0]["i"] });
			}
			else
			{
				return string.Empty;
			}
		}

		private string GetRequirementHelp(int requirmentID)
		{
			DataRow[] rows = DB.RequirementTypeTable.Select("id=" + requirmentID + "");
			if (rows.Length > 0)
			{
				return String.Format("{0}<hr><b>N:</b>{1}<br><b>V:</b>{2}",new object[]{rows[0]["help"],rows[0]["n"],rows[0]["v"]});
			}
			else
			{
				return string.Empty;
			}
		}				
				
		#endregion

		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
		{
			DB.questPartBinding.MoveLast();
			DataRowView row =(DataRowView) DB.questPartBinding.Current;
			if (DB.MobTable.Rows.Count > 0)
			{				
				RefreshQuestPartText();
			}

		}

		private QuestPartTextInfo GetInfoForQuestPartRow(DataRow questPartRw)
		{
			int index = 0;
			foreach (DataRowView row in DB.questPartBinding.List)
			{
				if (row.Row == questPartRw)
				{
					if (index < questPartInfos.Count)
						return questPartInfos[index];
					else
						return null;
				}
				else
				{
					index++;
				}
			}
			return null;
		}

		/// <summary>
		/// HelperClass to hold needed information for a text descriotion of QuestPart in textbox
		/// </summary>
		class QuestPartTextInfo
		{
			public int BeginIndex;
			public int EndIndex;
		}
	}
}
