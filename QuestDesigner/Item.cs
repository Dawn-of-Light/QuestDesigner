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
using Flobbster.Windows.Forms;
using System.Collections;
using DOL.Tools.QuestDesigner.Controls;
using System.Reflection;
using DOL.Tools.QuestDesigner.Util;
using DOL.GS;
using DOL.Database;
using DOL.Tools.QuestDesigner.Exceptions;
using DOL.Tools.QuestDesigner.Converter;


namespace DOL.Tools.QuestDesigner
{
	public partial class Item : UserControl
	{

		View[] listViewModes = new View[] { View.Details, View.List, View.LargeIcon, View.Tile };		

		private PropertyBag itemBag;

		public Item()
		{
			InitializeComponent();
            DB.DatabaseLoaded += new DB.DatabaseLoadedEventHandler(DB_DatabaseLoaded);
		}

        void DB_DatabaseLoaded()
        {
            // setting groups
            foreach (DataRowView rowView in DB.objectTypeBinding.List)
            {
                ListViewGroup group = new ListViewGroup();
                group.Name = Convert.ToString(rowView[DB.COL_ENUMERATION_VALUE]);
                group.Header = Convert.ToString(rowView[DB.COL_ENUMERATION_DESCRIPTION]);
                this.listViewItem.Groups.Add(group);
            }

            // Load initial data from table
            foreach (DataRow itemRow in DB.ItemTemplateTable.Rows)
            {
                listViewItem.Items.Add(generateListItem(itemRow));
            }

            DB.ItemTemplateTable.RowChanged += new DataRowChangeEventHandler(itemTable_RowChanged);
            DB.ItemTemplateTable.RowDeleting += new DataRowChangeEventHandler(itemTable_RowChanged);
            DB.ItemTemplateTable.TableCleared += new DataTableClearEventHandler(itemTable_TableCleared);

            // Configure PropertyBags
            itemBag = new PropertyBag();
            itemBag.GetValue += new PropertySpecEventHandler(this.itemBag_GetValue);
            itemBag.SetValue += new PropertySpecEventHandler(this.itemBag_SetValue);
            foreach (DataColumn col in DB.ItemTemplateTable.Columns)
            {
                itemBag.Properties.Add(getItemProperties(col));
            }
            propertyGridItem.SelectedObject = itemBag;
        }

		public void SetDatabaseSupport(bool support)
		{
			B_SearchItem.Enabled = support;
		}		

		void itemTable_TableCleared(object sender, DataTableClearEventArgs e)
		{
			listViewItem.Items.Clear();
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
            else if (e.Action == DataRowAction.Delete)
            {
                foreach (ListViewItem item in listViewItem.Items)
                {
                    if (item.Tag == e.Row)
                    {
                        listViewItem.Items.Remove(item);
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

			item.Name = Convert.ToString(itemRow[DB.COL_ITEMTEMPLATE_ID]);
            item.Text = Convert.ToString(itemRow[DB.COL_ITEMTEMPLATE_NAME]);
			item.Tag = itemRow;
			item.ImageIndex = 0;

			subItem.Text = "Generic Item";
			DataRow[] rows = DB.EnumerationTable.Select(DB.COL_ENUMERATION_TYPE+"='"+typeof(eObjectType).Name+"' AND "+DB.COL_ENUMERATION_VALUE+"='"+itemRow[DB.COL_ITEMTEMPLATE_OBJECTTYPE]+"'");			
			if (rows.Length>0)
			{
				//item.ImageIndex = rows[0]["id"];
				item.Group = listViewItem.Groups[Convert.ToString(rows[0][DB.COL_ENUMERATION_VALUE])];

                subItem.Text = Convert.ToString(rows[0][DB.COL_ENUMERATION_DESCRIPTION]);
			}
			item.SubItems.Add(subItem);
			
			return item;
		}

		private void RemoveSelectedItems()
		{
			foreach (ListViewItem item in listViewItem.SelectedItems)
			{
				DB.ItemTemplateTable.Rows.Remove((DataRow)item.Tag);				
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
                case "Bonus6":
                case "Bonus7":
                case "Bonus8":
                case "Bonus9":
                case "Bonus10":
				case "ExtraBonus":
					spec.Category = "Magic";
					break;
				case "Bonus1Type":
				case "Bonus2Type":
				case "Bonus3Type":
				case "Bonus4Type":
				case "Bonus5Type":
                case "Bonus6Type":
                case "Bonus7Type":
                case "Bonus8Type":
                case "Bonus9Type":
                case "Bonus10Type":
				case "ExtraBonusType":
					spec.Category = "Magic";
					spec.ConverterTypeName = typeof(ItemBonusTypeConverter).FullName;
					break;                
                case "SpellID":
				case "ProcSpellID":
                case "SpellID1":
                case "ProcSpellID1":				
				case "Charges":
                case "Charges1":
				case "MaxCharges":
                case "MaxCharges1":                    
                case "PoisonCharges":
                case "PoisonMaxCharges":
                case "PoisonSpellID":
					spec.Category = "Magic";
					break;
                case "Extension":
                    spec.Category = "Visual";
                    spec.ConverterTypeName = typeof(ExtensionConverter).FullName;
                    break;
                case "Effect":
                    spec.Category = "Visual";
                    spec.ConverterTypeName = typeof(EffectConverter).FullName;
                    break;
                case "Model":				
				case "Emblem":
					spec.Category = "Visual";
					break;
				case "Color":
					spec.ConverterTypeName = typeof(DOL.Tools.QuestDesigner.Converter.ColorConverter).FullName;
					spec.Category = "Visual";
					break;
				case "Item_Type":
                    spec.ConverterTypeName = typeof(ItemTypeConverter).FullName;
					spec.Category = "Internal";
					break;
				case "Object_Type":
                    spec.ConverterTypeName = typeof(ObjectTypeConverter).FullName;
					spec.Category = "Internal";
					break;
				case "Hand":
                    spec.ConverterTypeName = typeof(HandConverter).FullName;
					spec.Category = "Internal";
					break;
				case "ItemTemplateID":
					spec.Category = "Internal";
					break;

				case "Durability":
				case "MaxDurability":
				case "Quality":				
				case "Condition":
				case "MaxCondition":
				case "PackSize":
				case "MaxCount":
				case "Weight":
					spec.Category = "Stats";
					break;
				case "Realm":
                    spec.ConverterTypeName = typeof(RealmConverter).FullName;
					break;
				case "Type_Damage":
                    spec.ConverterTypeName = typeof(DamageTypeConverter).FullName;
					break;

			}
			return spec;
		}

		private void B_NewItem_Click(object sender, EventArgs e)
		{
			DataRow itemRow = DB.ItemTemplateTable.NewRow();
			//
			int uniqueID = Environment.TickCount % 100; // pseudo unique
			itemRow[DB.COL_ITEMTEMPLATE_NAME] = "NewItem"+uniqueID;
            itemRow[DB.COL_ITEMTEMPLATE_ID] = Utils.ConvertToObjectName((string)itemRow[DB.COL_ITEMTEMPLATE_NAME]);
			//
			DB.ItemTemplateTable.Rows.Add(itemRow);
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
                //
                DataRow row = (DataRow)item.Tag;

                // little hack since the typconverter seems to be skipped if the mousewheel is used to select a value from propertygrid
                if (!row[e.Property.Name].GetType().IsAssignableFrom(e.Value.GetType()) && e.Property.ConverterTypeName!=null) {                
                    TypeConverter conv =(TypeConverter) Activator.CreateInstance(Assembly.GetCallingAssembly().GetType(e.Property.ConverterTypeName));

                    Type destinationType = row.Table.Columns[e.Property.Name].DataType;

                    e.Value = conv.ConvertTo(e.Value,destinationType);
                }
                // little hackend


				row[e.Property.Name] = e.Value;				
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
                    ((DataRow)item.Tag)[DB.COL_ITEMTEMPLATE_NAME] = e.Label;
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
                Object item = QuestDesignerMain.ItemLookupForm.SelectedItem;
                if (item != null)
                {
                    DataRow row = DB.ItemTemplateTable.NewRow();
                    foreach (DataColumn column in DB.ItemTemplateTable.Columns)
                    {
                        try
                        {
                            String dolColumn = QuestDesignerMain.DatabaseAdapter.ConvertXMLColumnToDOLColumn(column.ColumnName);
                            PropertyInfo field = item.GetType().GetProperty(dolColumn);
                            if (field != null)
                                row[column.ColumnName] = field.GetValue(item, null);
                            else
                            {                                
                                throw new DOLConfigurationException("No property found in DOL item object for column :" + column.ColumnName);                                                                
                            }
                        }
                        catch (DOLConfigurationException ex)
                        {
                            QuestDesignerMain.HandleException(ex);
                        }
                    }

                    //row["ObjectName"] = Utils.ConvertToObjectName(Convert.ToString(row["Name"]));

                    DB.ItemTemplateTable.Rows.Add(row);
                }
			}
		}

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (listViewItem.SelectedItems != null && listViewItem.SelectedItems.Count > 0)
            {
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteToolStripMenuItem.Enabled = false;
            }
        }

        			
	}
}
