using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Flobbster.Windows.Forms;
using DOL.GS.PacketHandler;
using System.Collections;
using QuestDesigner.Controls;
using DOL.GS.Database;
using System.Reflection;
using DOL.GS;
using QuestDesigner.Util;

namespace QuestDesigner
{
	public partial class Item : UserControl
	{

		View[] listViewModes = new View[] { View.Details, View.List, View.LargeIcon, View.Tile };

		DataTable itemTable;		

		private PropertyBag itemBag;

		public Item()
		{
			InitializeComponent();
		}

		public void SetDatabaseSupport(bool support)
		{
			B_SearchItem.Enabled = support;
		}

		public void setDataSet(DataSet questData)
		{
			// setting groups
			foreach (DataRow row in QuestDesignerMain.DesignerForm.dataTableeEnumeration.Select("Type='" + typeof(eObjectType).Name + "'"))
			{
				ListViewGroup group = new ListViewGroup();
				group.Name = Convert.ToString(row["Value"]);
				group.Header = Convert.ToString(row["Description"]);
				this.listViewItem.Groups.Add(group);
			}


			itemTable = questData.Tables["ItemTemplate"];			

			itemTable.RowChanged += new DataRowChangeEventHandler(itemTable_RowChanged);
			itemTable.RowDeleting += new DataRowChangeEventHandler(itemTable_RowDeleting);
			itemTable.TableCleared += new DataTableClearEventHandler(itemTable_TableCleared);

			// Configure PropertyBags
			itemBag = new PropertyBag();
			itemBag.GetValue += new PropertySpecEventHandler(this.itemBag_GetValue);
			itemBag.SetValue += new PropertySpecEventHandler(this.itemBag_SetValue);
			foreach (DataColumn col in itemTable.Columns)
			{
				itemBag.Properties.Add(getItemProperties(col));
			}
			propertyGridItem.SelectedObject = itemBag;

			
		}

		void itemTable_TableCleared(object sender, DataTableClearEventArgs e)
		{
			listViewItem.Items.Clear();
		}

		void itemTable_RowDeleting(object sender, DataRowChangeEventArgs e)
		{
			foreach (ListViewItem item in listViewItem.Items)
			{
				if (item.Tag == e.Row)
				{
					listViewItem.Items.Remove(item);
				}
			}
		}

		void itemTable_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (e.Action == DataRowAction.Add)
			{
				// add new item if none was found
				listViewItem.Items.Add(generateListItem(e.Row));
			}
			else if (e.Action == DataRowAction.Change)
			{
				foreach (ListViewItem item in listViewItem.Items)
				{
					if (item.Tag == e.Row)
					{
						configureListItem(item, e.Row);
					}
				}
			}
		}

		private ListViewItem generateListItem(DataRow itemRow)
		{
			ListViewItem item = new ListViewItem();
			configureListItem(item, itemRow);
			return item;
		}
		private ListViewItem configureListItem(ListViewItem item, DataRow itemRow)
		{
			item.SubItems.Clear();
			ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
			subItem.Name ="Type";

			item.Name = Convert.ToString(itemRow["ItemTemplateID"]);
			item.Text = Convert.ToString(itemRow["Name"]);
			item.Tag = itemRow;
			item.ImageIndex = 0;

			subItem.Text = "Generic Item";
			DataRow[] rows = QuestDesignerMain.DesignerForm.dataTableeEnumeration.Select("Type='"+typeof(eObjectType).Name+"' AND Value="+itemRow["Object_Type"]);
			
			if (rows.Length>0)
			{
				//item.ImageIndex = rows[0]["id"];
				item.Group = listViewItem.Groups[Convert.ToString(rows[0]["Value"])];
				
				subItem.Text = Convert.ToString(rows[0]["Description"]);
			}
			item.SubItems.Add(subItem);
			
			return item;
		}

		private void RemoveSelectedItems()
		{
			foreach (ListViewItem item in listViewItem.SelectedItems)
			{
				itemTable.Rows.Remove((DataRow)item.Tag);				
			}
		}

		private PropertySpec getItemProperties(DataColumn col)
		{
			PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
			switch (col.ColumnName)
			{
				case "Bonus":
				case "Bonus1":
				case "Bonus2":
				case "Bonus3":
				case "Bonus4":
				case "Bonus5":
				case "ExtraBonus":
					spec.Category = "Magic";
					break;
				case "Bonus1Type":
				case "Bonus2Type":
				case "Bonus3Type":
				case "Bonus4Type":
				case "Bonus5Type":
				case "ExtraBonusType":
					spec.Category = "Magic";
					spec.ConverterTypeName = "QuestDesigner.Converter.ItemBonusTypeConverter";
					break;
				case "SpellID":
				case "ProcSpellID":
				case "Effect":
				case "Charges":
				case "MaxCharges":
					spec.Category = "Magic";
					break;

				case "Model":
				case "ModelExtension":
				case "Emblem":
					spec.Category = "Visual";
					break;
				case "Color":
					spec.ConverterTypeName = "QuestDesigner.Converter.ColorConverter";
					spec.Category = "Visual";
					break;


				case "Item_Type":
					spec.ConverterTypeName = "QuestDesigner.Converter.ItemTypeConverter";
					spec.Category = "Internal";
					break;
				case "Object_Type":
					spec.ConverterTypeName = "QuestDesigner.Converter.ObjectTypeConverter";
					spec.Category = "Internal";
					break;
				case "Hand":
					spec.ConverterTypeName = "QuestDesigner.Converter.HandConverter";
					spec.Category = "Internal";
					break;
				case "ItemTemplateID":
					spec.Category = "Internal";
					break;

				case "Durability":
				case "MaxDurability":
				case "Quality":
				case "MaxQuality":
				case "Condition":
				case "MaxCondition":
				case "PackSize":
				case "MaxCount":
				case "Weight":
					spec.Category = "Stats";
					break;
				case "Realm":
					spec.ConverterTypeName = "QuestDesigner.Converter.RealmConverter";
					break;
				case "Type_Damage":
					spec.ConverterTypeName = "QuestDesigner.Converter.DamageTypeConverter";
					break;

			}
			return spec;
		}

		private void B_NewItem_Click(object sender, EventArgs e)
		{
			DataRow itemRow = itemTable.NewRow();
			//
			int uniqueID = Environment.TickCount % 100; // pseudo unique
			itemRow["Name"] = "NewItem"+uniqueID;
			itemRow["ItemTemplateID"] = Utils.ConvertToObjectName((string)itemRow["Name"]);
			//
			itemTable.Rows.Add(itemRow);
		}
				

		public void itemBag_GetValue(object sender, PropertySpecEventArgs e)
		{
			if (listViewItem.SelectedItems != null && listViewItem.SelectedItems.Count>0)
			{
				ListViewItem item = listViewItem.SelectedItems[0];							
				e.Value = ((DataRow)item.Tag)[e.Property.Name];				
			}
		}

		public void itemBag_SetValue(object sender, PropertySpecEventArgs e)
		{

			if (listViewItem.SelectedItems != null && listViewItem.SelectedItems.Count>0)
			{
				ListViewItem item = listViewItem.SelectedItems[0];				
				((DataRow)item.Tag)[e.Property.Name] = e.Value;				
			}
		}		

		private void listViewItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewItem.SelectedItems != null && listViewItem.SelectedItems.Count>0)
			{				
				propertyGridItem.Enabled = true;
				propertyGridItem.SelectedObject = itemBag;
			}
			else
				propertyGridItem.Enabled = false;
			
		}

		private void B_ListViewTiles_Click(object sender, EventArgs e)
		{
			listViewItem.View = View.Tile;
		}

		private void B_ListViewSymbols_Click(object sender, EventArgs e)
		{
			listViewItem.View = View.LargeIcon;
		}

		private void B_ListViewList_Click(object sender, EventArgs e)
		{
			listViewItem.View = View.List;
		}

		private void B_ListViewDetails_Click(object sender, EventArgs e)
		{
			listViewItem.View = View.Details;
		}

		private void B_ToggleGroups_CheckStateChanged(object sender, EventArgs e)
		{
			listViewItem.ShowGroups = ((ToolStripButton)sender).CheckState == CheckState.Checked;
		}		

		private void B_Delete_Click(object sender, EventArgs e)
		{
			RemoveSelectedItems();
		}

		private void listViewItem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				RemoveSelectedItems();
				e.Handled = true;
			}
			else
				e.Handled = false;
		}		

		private void B_ListView_ButtonClick(object sender, EventArgs e)
		{
			View view = listViewItem.View;
			for (int i = 0; i < listViewModes.Length; i++)
			{
				if (view == listViewModes[i])
				{
					listViewItem.View = listViewModes[(i + 1) % listViewModes.Length];
					break;
				}
			}
		}

		private void listViewItem_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (!e.CancelEdit)
			{
				ListViewItem item = listViewItem.Items[e.Item];
				if (e.Label != null && e.Label.Length > 0)
				{
					((DataRow)item.Tag)["Name"] = e.Label;
					propertyGridItem.SelectedObject = itemBag;
				}
			}
		}

		private void listViewItem_ColumnClick(object sender, ColumnClickEventArgs e)
		{								
			ListViewItemComparer comp = listViewItem.ListViewItemSorter as ListViewItemComparer;
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
			listViewItem.ListViewItemSorter = comp;
			listViewItem.Sort();
		}		

		private void B_SearchItem_Click(object sender, EventArgs e)
		{
			DialogResult result = QuestDesignerMain.ItemLookupForm.ShowDialog();

			if (result == DialogResult.OK)
			{
				DataRow row = itemTable.NewRow();
				GenericItemTemplate item = QuestDesignerMain.ItemLookupForm.SelectedItem;
				foreach (DataColumn column in itemTable.Columns)
				{
					PropertyInfo field = item.GetType().GetProperty(column.ColumnName);
					if (field != null)
						row[column.ColumnName] = field.GetValue(item, null);
				}
				itemTable.Rows.Add(row);
			}
		}				
	}
}
