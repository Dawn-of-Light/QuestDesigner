using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Flobbster.Windows.Forms;
using System.Collections;
using QuestDesigner.Controls;
using System.Reflection;
using QuestDesigner.Util;
using DOL.GS.PacketHandler;
using DOL.GS;
using QuestDesigner.Exceptions;

namespace QuestDesigner
{
	public partial class NPC : UserControl
	{

		View[] listViewModes = new View[] { View.Details, View.List, View.LargeIcon, View.Tile };

		DataTable npcTable;		

		private PropertyBag npcBag;

		public NPC()
		{
			InitializeComponent();
			
		}

		public void SetDatabaseSupport(bool support)
		{
			B_SearchNPC.Enabled = support;
		}

		public void setDataSet(DataSet questData)
		{
			npcTable = questData.Tables["Mob"];
			
			npcTable.RowChanged += new DataRowChangeEventHandler(npcTable_RowChanged);
			npcTable.RowDeleting += new DataRowChangeEventHandler(npcTable_RowDeleting);
			npcTable.TableCleared += new DataTableClearEventHandler(npcTable_TableCleared);

			// Configure PropertyBags
			npcBag = new PropertyBag();
			npcBag.GetValue += new PropertySpecEventHandler(this.npcBag_GetValue);
			npcBag.SetValue += new PropertySpecEventHandler(this.npcBag_SetValue);
			foreach (DataColumn col in npcTable.Columns)
			{
				npcBag.Properties.Add(getNPCProperties(col));
			}
			propertyGridNPC.SelectedObject = npcBag;
		}

		void npcTable_TableCleared(object sender, DataTableClearEventArgs e)
		{
			listViewNPC.Items.Clear();
		}		

		void npcTable_RowDeleting(object sender, DataRowChangeEventArgs e)
		{
			foreach (ListViewItem item in listViewNPC.Items)
			{
				if (item.Tag == e.Row)
				{
					listViewNPC.Items.Remove(item);
				}
			}
		}		

			

		void npcTable_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (e.Action == DataRowAction.Add)
			{
				// add new item if none was found
				listViewNPC.Items.Add(generateListItem(e.Row));				
			}
			else if (e.Action == DataRowAction.Change)
			{
				foreach (ListViewItem item in listViewNPC.Items)
				{
					if (item.Tag == e.Row)
					{
						configureListItem(item, e.Row);
					}
				}
			}
		}

		private ListViewItem generateListItem(DataRow npcRow)
		{
			ListViewItem item = new ListViewItem();
			configureListItem(item, npcRow);
			return item;
		}
		private ListViewItem configureListItem(ListViewItem item, DataRow npcRow)
		{
			item.SubItems.Clear();
			ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
			subItem.Name ="Type";
			
			item.Name = Convert.ToString(npcRow["MobID"]);
			item.Text = Convert.ToString(npcRow["Name"]);
			item.Tag = npcRow;
			
			if (npcRow["Realm"] is byte && (byte)npcRow["Realm"] == 0)
			{
				item.ImageIndex = 1;
				item.Group = listViewNPC.Groups["LVG_Monster"];
				
				subItem.Text = "Monster";
				
			}
			else
			{
				item.ImageIndex = 0;
				item.Group = listViewNPC.Groups["LVG_NPC"];
				subItem.Text = "NPC";
			}
			
			item.SubItems.Add(subItem);
			
			return item;
		}

		private void RemoveSelectedNPCs()
		{
			foreach (ListViewItem item in listViewNPC.SelectedItems)
			{				
				npcTable.Rows.Remove((DataRow)item.Tag);				
			}
		}

		private PropertySpec getNPCProperties(DataColumn col)
		{
			PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
			switch (col.ColumnName)
			{
				case "X":
				case "Y":
				case "Z":
				case "Heading":
					spec.Category = "Location";
					break;
				case "Region":
					spec.ConverterTypeName = "QuestDesigner.Converter.RegionConverter";
					spec.Category = "Location";
					break;
				case "ClassType":
				case "FactionID":
				case "Flags":
				case "MobID":
				case "RespawnInterval":
				case "ObjectName":
					spec.Category = "Internal";
					break;
				case "Model":
				case "size":
				case "EquipmentTemplateID":
					spec.Category = "Visual";
					break;
				case "Realm":
					spec.ConverterTypeName = "QuestDesigner.Converter.RealmConverter";
					break;
				case "DamageType":
					spec.ConverterTypeName = "QuestDesigner.Converter.DamageTypeConverter"; ;
					break;
			}

			return spec;
		}

		private void B_NewNPC_Click(object sender, EventArgs e)
		{
			DataRow npcRow = npcTable.NewRow();
			//			
			npcRow["Realm"] = eRealm.Albion;
			npcRow["Name"] = "";			
			//
			npcTable.Rows.Add(npcRow);

			npcRow["Name"] = "NewNPC" + npcRow["MobID"];
			npcRow["ObjectName"] = Utils.ConvertToObjectName((string)npcRow["Name"]);
		}

		private void B_NewMob_Click(object sender, EventArgs e)
		{
			DataRow npcRow = npcTable.NewRow();
			//			
			npcRow["Realm"] = eRealm.None;
			npcRow["Name"] = "";			
			//
			npcTable.Rows.Add(npcRow);

			npcRow["Name"] = "NewMob" + npcRow["MobID"];
			npcRow["ObjectName"] = Utils.ConvertToObjectName((string)npcRow["Name"]);
		}		

		public void npcBag_GetValue(object sender, PropertySpecEventArgs e)
		{
			if (listViewNPC.SelectedItems != null && listViewNPC.SelectedItems.Count>0)
			{
				ListViewItem item = listViewNPC.SelectedItems[0];							
				e.Value = ((DataRow)item.Tag)[e.Property.Name];				
			}
		}

		public void npcBag_SetValue(object sender, PropertySpecEventArgs e)
		{

			if (listViewNPC.SelectedItems != null && listViewNPC.SelectedItems.Count>0)
			{
				ListViewItem item = listViewNPC.SelectedItems[0];
				((DataRow)item.Tag)[e.Property.Name] = e.Value;
			}
		}

		private void listViewNPC_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewNPC.SelectedItems != null && listViewNPC.SelectedItems.Count>0)
			{			
				propertyGridNPC.Enabled = true;
				propertyGridNPC.SelectedObject = npcBag;
			}
			else
				propertyGridNPC.Enabled = false;
			
		}

		private void B_ListViewTiles_Click(object sender, EventArgs e)
		{
			listViewNPC.View = View.Tile;
		}

		private void B_ListViewSymbols_Click(object sender, EventArgs e)
		{
			listViewNPC.View = View.LargeIcon;
		}

		private void B_ListViewList_Click(object sender, EventArgs e)
		{
			listViewNPC.View = View.List;
		}

		private void B_ListViewDetails_Click(object sender, EventArgs e)
		{
			listViewNPC.View = View.Details;
		}

		private void B_ToggleGroups_CheckStateChanged(object sender, EventArgs e)
		{
			listViewNPC.ShowGroups = ((ToolStripButton)sender).CheckState == CheckState.Checked;
		}		

		private void B_Delete_Click(object sender, EventArgs e)
		{
			RemoveSelectedNPCs();
		}

		private void listViewNPC_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				RemoveSelectedNPCs();
				e.Handled = true;
			}
			else
				e.Handled = false;
		}		

		private void B_ListView_ButtonClick(object sender, EventArgs e)
		{
			View view = listViewNPC.View;
			for (int i = 0; i < listViewModes.Length; i++)
			{
				if (view == listViewModes[i])
				{
					listViewNPC.View = listViewModes[(i + 1) % listViewModes.Length];
					break;
				}
			}
		}

		private void listViewNPC_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (!e.CancelEdit)
			{
				ListViewItem item = listViewNPC.Items[e.Item];
				if (e.Label != null && e.Label.Length > 0)
				{
					((DataRow)item.Tag)["Name"] = e.Label;
					propertyGridNPC.SelectedObject = npcBag;
				}
			}
		}

		private void listViewNPC_ColumnClick(object sender, ColumnClickEventArgs e)
		{								
			ListViewItemComparer comp = listViewNPC.ListViewItemSorter as ListViewItemComparer;
			if (comp != null)
			{
				if (comp.Column == e.Column)
				{
					comp.Invert = !comp.Invert;
				}
				else
				{
					comp.Column = e.Column;
				}
			}
			else
			{
				comp = new ListViewItemComparer(e.Column);			
			}
			listViewNPC.ListViewItemSorter = comp;
			listViewNPC.Sort();
		}		

		private void B_SearchNPC_Click(object sender, EventArgs e)
		{
			DialogResult result = QuestDesignerMain.NPCLookupForm.ShowDialog();

			if (result == DialogResult.OK)
			{				
				Object mob = QuestDesignerMain.NPCLookupForm.SelectedMob;
                if (mob != null)
                {
                    DataRow row = npcTable.NewRow();
                    foreach (DataColumn column in npcTable.Columns)
                    {
                        try
                        {
                            String dolColumn = QuestDesignerMain.DatabaseAdapter.ConvertXMLColumnToDOLColumn(column.ColumnName);
                            PropertyInfo field = mob.GetType().GetProperty(dolColumn);                            
                            if (field != null)
                                row[column.ColumnName] = field.GetValue(mob, null);
                            else
                                throw new DOLConfigurationException("No Property found in DOL Mob object for column: " + column.ColumnName);

                        }
                        catch (DOLConfigurationException ex)
                        {
                            QuestDesignerMain.HandleException(ex);
                        }
                    }
                    npcTable.Rows.Add(row);
                }
			}
		}
		
	}
}
