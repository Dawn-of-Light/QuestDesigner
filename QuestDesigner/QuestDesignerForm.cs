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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Configuration;
using DOL.GS.Database;
using System.Collections;
using QuestDesigner.Properties;
using System.Reflection;
using System.Text.RegularExpressions;
using Flobbster.Windows.Forms;
using QuestDesigner.Converter;
using DOL.GS;
using DOL.GS.PacketHandler;
using DOL.GS.Quests;
using NETXP.Controls.Docking;
using QuestDesigner.Util;

namespace QuestDesigner
{
    public partial class QuestDesignerForm : Form
    {		

        public static string TITLE = " ::  "+Application.ProductName+" "+Application.ProductVersion+" :: ";
		
        protected string openFilename = null;

		private PropertyBag locationBag;

		private PropertyBag areaCircleBag, areaSquareBag;

        public QuestDesignerForm()
        {			
			InitializeComponent();			
			
			QuestDesignerMain.InitDB();           			
        }

		private void QuestDesignerForm_Load(object sender, EventArgs e)
		{

			SetDataSet();						

			// config Location
			locationBag = new PropertyBag();
			locationBag.GetValue += new PropertySpecEventHandler(locationBag_GetValue);
			locationBag.SetValue += new PropertySpecEventHandler(locationBag_SetValue);
			
			foreach (DataColumn col in DB.locationTable.Columns)
			{
				locationBag.Properties.Add(getLocationProperties(col));
			}
			locationBag.Properties.Add(new PropertySpec("Zone X",typeof(int),"Local","Zone related X Coordinate"));
			locationBag.Properties.Add(new PropertySpec("Zone Y", typeof(int), "Local", "Zone related Y Coordinate"));
			locationBag.Properties.Add(new PropertySpec("Zone Z", typeof(int), "Local", "Zone related Z Coordinate"));

			propertyGridLocation.SelectedObject = locationBag;			
			// config area

			areaCircleBag = new PropertyBag();
			areaCircleBag.GetValue += new PropertySpecEventHandler(areaBag_GetValue);
			areaCircleBag.SetValue += new PropertySpecEventHandler(areaBag_SetValue);

			foreach (DataColumn col in DB.areaTable.Columns)
			{
				areaCircleBag.Properties.Add(getAreaCircleProperties(col));
			}
			areaSquareBag = new PropertyBag();
			areaSquareBag.GetValue += new PropertySpecEventHandler(areaBag_GetValue);
			areaSquareBag.SetValue += new PropertySpecEventHandler(areaBag_SetValue);

			foreach (DataColumn col in DB.areaTable.Columns)
			{
				areaSquareBag.Properties.Add(getAreaSquareProperties(col));
			}
			propertyGridArea.SelectedObject = areaCircleBag;			

			// Configure L&F
			NETXP.Controls.Docking.Renderers.Office2003 XPRenderers = new NETXP.Controls.Docking.Renderers.Office2003();
			NETXP.Library.XPBlueColorTable xpColorTable = new NETXP.Library.XPBlueColorTable();
			XPRenderers.ColorTable = xpColorTable;			
			customCode.tabControlCodeSection.Renderer = XPRenderers;
			this.tabControlMain.Renderer = XPRenderers;
			this.xpTaskPane.ColorTable = NETXP.Library.ColorTables.XPBlue;
			
			toolStripMenuItemTaskPane.CheckState = Settings.Default.ShowTaskPane ? CheckState.Checked: CheckState.Unchecked;
			
			// Load last file
			if (!String.IsNullOrEmpty(XMLFile))
			{
				if (!LoadQuest(XMLFile))
					InitEmptyQuest();
			}
			else
			{
				InitEmptyQuest();
			}
			this.Text = TITLE + openFilename;
		}

		void areaBag_SetValue(object sender, PropertySpecEventArgs e)
		{
			if (bindingSourceArea.Current != null)
			{
				DataRowView rowView = ((DataRowView)bindingSourceArea.Current);
				switch (e.Property.Name)
				{					
					case "Name":						
						if (string.IsNullOrEmpty(Convert.ToString(rowView["ObjectName"])))
						{
							rowView["ObjectName"] = Utils.ConvertToObjectName((string)e.Value);
						}
						rowView[e.Property.Name] = e.Value;
						break;
					case "Width":
						rowView["Z"] = e.Value;
						break;
					case "Height":
						rowView["R"] = e.Value;
						break;
					default:
						rowView[e.Property.Name] = e.Value;
						break;
				}
				propertyGridArea.Refresh();
				dataGridArea.Refresh();
			}
		}

		void areaBag_GetValue(object sender, PropertySpecEventArgs e)
		{
			if (bindingSourceArea.Current != null)
			{
				DataRowView rowView = ((DataRowView)bindingSourceArea.Current);
				switch (e.Property.Name)
				{			
					case "Width":
						e.Value = rowView["Z"];
						break;
					case "Height":
						e.Value = rowView["R"];
						break;
					default:
						e.Value = rowView[e.Property.Name];
						break;
				}
			}
		}

		private PropertySpec getAreaCircleProperties(DataColumn col)
		{
			PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
			switch (col.ColumnName)
			{				
				case "RegionID":
					spec.ConverterTypeName = "QuestDesigner.Converter.RegionConverter";
					break;
				case "X":					
				case "Y":
				case "Z":										
				case "R":
					spec.Description = "Radius of Circle";
					break;
			}
			return spec;
		}

		private PropertySpec getAreaSquareProperties(DataColumn col)
		{
			PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
			switch (col.ColumnName)
			{
				case "RegionID":
					spec.ConverterTypeName = "QuestDesigner.Converter.RegionConverter";
					break;
				case "X":
					spec.Description = "X Coordinate of Square";
					break;
				case "Y":
					spec.Description = "Y Coordinate of Square";
					break;
				case "Z":
					spec.Name = "Width";
					spec.Description = "Width of Square";
					break;
				case "R":
					spec.Name = "Height";
					spec.Description = "Height of Square";
					break;
			}
			return spec;
		}

		private PropertySpec getLocationProperties(DataColumn col)
		{
			PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
			switch (col.ColumnName)
			{
				case "ID":
					spec.Attributes = new Attribute[] { BrowsableAttribute.No };
					break;
				case "RegionID":
					spec.ConverterTypeName = "QuestDesigner.Converter.RegionConverter";
					break;
				case "ZoneID":
					spec.ConverterTypeName = "QuestDesigner.Converter.ZoneConverter";
					spec.Category = "Local";
					break;
				case "X":					
				case "Y":
				case "Z":
					spec.Category = "Global";
					break;				
				case "Heading":
					break;
			}
			return spec;
		}

		void locationBag_SetValue(object sender, PropertySpecEventArgs e)
		{
			if (bindingSourceLocation.Current != null)
			{
				DataRowView rowView;
				switch (e.Property.Name)
				{
					case "Zone X":
						rowView = ((DataRowView)bindingSourceLocation.Current);
						if (rowView["ZoneID"] is int)
						{
							rowView["X"] = Utils.ConvertZoneXToRegion((int)rowView["ZoneID"], (int)e.Value);														
						}
						else
						{
							MessageBox.Show("Select a Zone first, or the global coordinate cannot be computed.");
						}
						break;
					case "Zone Y":
						rowView = ((DataRowView)bindingSourceLocation.Current);
						if (rowView["ZoneID"] is int)
						{
							rowView["Y"] = Utils.ConvertZoneYToRegion((int)rowView["ZoneID"], (int)e.Value);							
						}
						else
						{
							MessageBox.Show("Select a Zone first, or the global coordinate cannot be computed.");
						}
						break;
					case "Zone Z":
						rowView = ((DataRowView)bindingSourceLocation.Current);
						rowView["Z"] = e.Value;						
						break;					

					case "Name":
						rowView = ((DataRowView)bindingSourceLocation.Current);
						if (string.IsNullOrEmpty(Convert.ToString(rowView["ObjectName"])))
						{
							rowView["ObjectName"] = Utils.ConvertToObjectName((string)e.Value);							
						}
						((DataRowView)bindingSourceLocation.Current)[e.Property.Name] = e.Value;
						break;
					case "RegionID":
						if (e.Value is int)
							DB.zoneBinding.Filter = "regionID=" + e.Value;
						else
							DB.zoneBinding.Filter = null;

						((DataRowView)bindingSourceLocation.Current)[e.Property.Name] = e.Value;
						break;
					default:
						((DataRowView)bindingSourceLocation.Current)[e.Property.Name] = e.Value;
						break;
				}
				propertyGridLocation.Refresh();
				dataGridViewLocation.Refresh();
			}
		}

		void locationBag_GetValue(object sender, PropertySpecEventArgs e)
		{
			if (bindingSourceLocation.Current!=null)
			{
				DataRowView rowView;
				switch (e.Property.Name)
				{
					case "Zone X":
						rowView = ((DataRowView)bindingSourceLocation.Current);
						if (rowView["ZoneID"] is int && rowView["X"] is int)
						{							
							e.Value = Utils.ConvertRegionXToZone((int)rowView["ZoneID"],(int)rowView["X"]);
						}
						
						break;
					case "Zone Y":
						rowView = ((DataRowView)bindingSourceLocation.Current);
						if (rowView["ZoneID"] is int && rowView["Y"] is int)
						{
							e.Value = Utils.ConvertRegionYToZone((int)rowView["ZoneID"], (int)rowView["Y"]);
						}
						break;
					case "Zone Z":
						e.Value = ((DataRowView)bindingSourceLocation.Current)["Z"];
						break;					
					default:
						e.Value = ((DataRowView)bindingSourceLocation.Current)[e.Property.Name];
						break;
				}
			}
		}

		private void SetDataSet()
		{
			DB.questTable = dataTableQuest;
			DB.questPartTable = dataTableQuestPart;
			DB.questPartBinding = bindingSourceQuestPart;
			DB.npcTable = dataTableMob;
			DB.itemTemplateTable = dataTableItemTemplate;
			DB.areaTable = dataTableArea;
			DB.locationTable = dataTableLocation;

			DB.triggerTable = dataTableTrigger;
			DB.requirementTable = dataTableRequirement;
			DB.actionTable = dataTableAction;

			DB.triggerTypeTable = dataTableTriggerType;
			DB.requirementTypeTable = dataTableRequirementType;
			DB.actionTypeTable = dataTableActionType;

			DB.textTypeBinding = bindingSourceTextType;
			DB.comparatorBinding = bindingSourceComparator;

			DB.zoneTable = dataTableZone;
			DB.zoneBinding = bindingSourceZone;
			DB.regionTable = dataTableRegion;

			DB.emoteBinding = bindingSourceEmote;
			DB.enumerationTable = dataTableeEnumeration;

			questInfo.setDataSet(dataSetQuest, bindingSourceMob);
			npcView.setDataSet(dataSetQuest);
			itemView.setDataSet(dataSetQuest);
			customCode.setDataSet(dataSetQuest);

			questPartItems.SetDataSet(dataSetQuest, dataSetData);
		}

		private void dataSetData_Initialized(object sender, EventArgs e)
		{			
			//fill via Relfection			
			FillTypeValues(new Type[] { typeof(eTextType), typeof(eDamageType), typeof(eComparator), typeof(eObjectType), typeof(eInventorySlot), typeof(eColor), typeof(eRealm), typeof(eProperty), typeof(eEmote), typeof(eCharacterClass) });
			//
			
			string[] xmlFiles = Directory.GetFiles("config/schema/", "*.xml");			

			foreach (string filePath in xmlFiles)
			{
				dataSetData.ReadXml(filePath);
			}
			// check Action,Trigger,RequirementTypes and fill table with respective Ids
			foreach (DataRow row in dataTableTriggerType.Rows)
			{
				string value = Convert.ToString(row["value"]);
				value = value.Substring(value.IndexOf('.') + 1);
				object id = Enum.Parse(typeof(eTriggerType), value);
				if (id is eTriggerType)
				{
					row["id"] = id;
				}
				else
				{
					MessageBox.Show("TriggerType with name: " + row["value"] + " couldn't be parsed to corresponding value:" + id);
				}
			}

			foreach (DataRow row in dataTableRequirementType.Rows)
			{
				string value = Convert.ToString(row["value"]);
				value = value.Substring(value.IndexOf('.') + 1);
				object id = Enum.Parse(typeof(eRequirementType), value);
				if (id is eRequirementType)
				{
					row["id"] = id;
				}
				else
				{
					MessageBox.Show("Requirementype with name: " + row["value"] + " couldn't be parsed to corresponding value:" + id);
				}
			}

			foreach (DataRow row in dataTableActionType.Rows)
			{
				string value = Convert.ToString(row["value"]);
				value = value.Substring(value.IndexOf('.') + 1);
				object id = Enum.Parse(typeof(eActionType), value);
				if (id is eActionType)
				{
					row["id"] = id;
				}
				else
				{
					MessageBox.Show("Actiontype with name: " + row["value"] + " couldn't be parsed to corresponding value:" + id);
				}
			}			
		}

		private void FillTypeValues(Type[] types)
		{
			string[] enumNames;
			Array enumArray;
			foreach (Type type in types)
			{
				enumNames = Enum.GetNames(type);
				enumArray = Enum.GetValues(type);
				for (int i = 0; i < enumNames.Length; i++)
				{
					if (!enumNames[i].StartsWith("_"))
					{
						//dataSetData.Tables[type.Name].Rows.Add(new object[] { enumArray.GetValue(i), enumNames[i] });
						DataRow row = dataTableeEnumeration.NewRow();
						row["Name"] = enumNames[i];
						row["Description"] = enumNames[i];
						row["Value"] = enumArray.GetValue(i);
						row["Type"] = type.Name;
						dataTableeEnumeration.Rows.Add(row);
					}
				}
			}
		}        

        public void SetDatabaseSupport(bool support)
        {
            itemView.SetDatabaseSupport( support);
			npcView.SetDatabaseSupport( support);            
        }

        protected string XMLFile
        {
            get
            {
                return (string)Settings.Default["XMLFile"];
            }
            set
            {
                Settings.Default["XMLFile"] = value;
            }
        }

        private void InitEmptyQuest()
        {
            dataSetQuest.Clear();
			dataTableQuest.Rows.Add(dataTableQuest.NewRow());
            dataTableQuest.AcceptChanges();			
            openFilename = null;
        }

        private bool SaveQuest(string xmlfile)
        {
            dataSetQuest.WriteXml(xmlfile);
            openFilename = xmlfile;
            this.Text = TITLE + xmlfile;
            Log.Info("Quest saved to " + xmlfile);
            XMLFile = xmlfile;
            return true;
        }

        private bool LoadQuest(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
				try
				{
					dataSetQuest.BeginInit();
					dataSetQuest.Clear();
					dataSetQuest.ReadXml(xmlfile);
					dataSetQuest.EndInit();										
					this.openFilename = xmlfile;

					this.Text = TITLE + xmlfile;
					Log.Info("Quest loaded from " + xmlfile);
					XMLFile = xmlfile;
					return true;
				}
				catch (Exception e)
				{					
					MessageBox.Show(e.Message, e.GetType().Name);
					InitEmptyQuest();
					Log.Error("File load error: " + xmlfile);
					return false;
				}
            }
            else
            {
                Log.Warning("File not found " + xmlfile);
                return false;
            }
        }
		
		


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitEmptyQuest();

            this.Text = TITLE + openFilename;
            Log.Info( "New Quest created");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(openFilename))
            {
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }
            else
            {
                SaveQuest(openFilename);
            }                            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveQuestDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SaveQuest(saveQuestDialog.FileName);
            }
        }  

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openQuestDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadQuest(openQuestDialog.FileName);                                
            }            
        }           

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            this.Close();
        }                                     

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
			CreateQuest();
		}

		private void CreateQuest()
		{
			// make sure last edit is stored in dataset
			dataSetQuest.AcceptChanges();

			string scriptPath = null;
			if (String.IsNullOrEmpty(openFilename))
			{
				DialogResult result = saveScriptDialog.ShowDialog();
				if (result == DialogResult.OK)
					scriptPath = saveScriptDialog.FileName;
				else
				{
					return;
				}
			}
			else
			{
				scriptPath = Path.GetDirectoryName(openFilename) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(openFilename) + ".cs";
			}
			if (QuestDesignerMain.GenerateScript(dataSetQuest, scriptPath))
				Log.Info("Script successfully build into " + scriptPath);
		}		        

		private void textBoxQuestname_Validating(object sender, CancelEventArgs e)
        {
            TextBox questName = (TextBox)sender;            
            questName.Text=Utils.ConvertToObjectName(questName.Text);            
        }        

		private void lookupNPCToolStripMenuItem_Click(object sender, EventArgs e)
		{			
			DialogResult result = QuestDesignerMain.NPCLookupForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataRow row = dataTableMob.NewRow();
                Mob mob = QuestDesignerMain.NPCLookupForm.SelectedMob;
                foreach (DataColumn column in dataTableMob.Columns)
                {
                    PropertyInfo field = mob.GetType().GetProperty(column.ColumnName);
                    if (field != null)
                        row[column.ColumnName] = field.GetValue(mob, null);
                }                
                dataTableMob.Rows.Add(row);
            }
		}

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = QuestDesignerMain.ItemLookupForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataRow row = dataTableItemTemplate.NewRow();
                GenericItemTemplate item = QuestDesignerMain.ItemLookupForm.SelectedItem;
                foreach (DataColumn column in dataTableItemTemplate.Columns)
                {
                    PropertyInfo field = item.GetType().GetProperty(column.ColumnName);
                    if (field != null)
                        row[column.ColumnName] = field.GetValue(item, null);
                }                
                dataTableItemTemplate.Rows.Add(row);
            }
        }        			

		private void dataGridArea_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{			
			e.Row.Cells[AreaObjectName.Name].Value = "<AUTO>";
		}

		private void dataGridArea_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
		{
			DataGridViewRow row = dataGridArea.Rows[e.RowIndex];
			row.ErrorText = null;
			if (e.RowIndex == (dataGridArea.Rows.Count - 2) &&
				dataGridArea.Rows[e.RowIndex + 1].IsNewRow &&
				row.Cells[AreaObjectName.Name].Value != null &&
				(row.Cells[AreaObjectName.Name].Value == DBNull.Value ||
				 row.Cells[AreaObjectName.Name].Value.ToString() == "<AUTO>")
				)
			{
				string coname = row.Cells[AreaName.Name].Value as string;
				if (coname != null)
				{
					row.Cells[AreaObjectName.Name].Value = Utils.ConvertToObjectName(coname);
					e.Cancel = false;
				}
			}
			else if (row.Cells[AreaObjectName.Name].Value !=null &&
				row.Cells[AreaObjectName.Name].Value != DBNull.Value &&
				row.Cells[AreaObjectName.Name].Value.ToString() != "<AUTO>")
			{
				row.Cells[AreaObjectName.Name].Value = Utils.ConvertToObjectName(Convert.ToString(row.Cells[AreaObjectName.Name].Value));
			}
		}

		private void dataGridArea_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			if (e.Context == DataGridViewDataErrorContexts.Commit)
			{
				dataGridArea.Rows[e.RowIndex].ErrorText = e.Exception.ToString();
				e.Cancel = true;
			}  
		}		

		private void linkLoadQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult result = openQuestDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				LoadQuest(openQuestDialog.FileName);
			}    
		}

		private void linkCreateQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CreateQuest();
		}

		private void toolStripMenuItemTaskPane_CheckStateChanged(object sender, EventArgs e)
		{
			Settings.Default.ShowTaskPane = toolStripMenuItemTaskPane.CheckState == CheckState.Checked;
		}		

			

		private void dataGridViewLocation_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[LocationObjectName.Name].Value = "<AUTO>";
		}

		private void dataGridViewLocation_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
		{
			DataGridViewRow row = dataGridViewLocation.Rows[e.RowIndex];
			row.ErrorText = null;
			if (e.RowIndex == (dataGridViewLocation.Rows.Count - 2) &&
				dataGridViewLocation.Rows[e.RowIndex + 1].IsNewRow &&
				row.Cells[LocationObjectName.Name].Value != null &&
				(row.Cells[LocationObjectName.Name].Value == DBNull.Value ||
				 row.Cells[LocationObjectName.Name].Value.ToString() == "<AUTO>")
				)
			{
				string coname = row.Cells[LocationName.Name].Value as string;
				if (coname != null)
				{
					row.Cells[LocationObjectName.Name].Value = Utils.ConvertToObjectName(coname);
					e.Cancel = false;
				}
			}
			else if (row.Cells[LocationObjectName.Name].Value != null &&
				row.Cells[LocationObjectName.Name].Value != DBNull.Value &&
				row.Cells[LocationObjectName.Name].Value.ToString() != "<AUTO>")
			{
				row.Cells[LocationObjectName.Name].Value = Utils.ConvertToObjectName(Convert.ToString(row.Cells[LocationObjectName.Name].Value));
			}
		}

		private void dataGridViewLocation_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			if (e.Context == DataGridViewDataErrorContexts.Commit)
			{
				dataGridViewLocation.Rows[e.RowIndex].ErrorText = e.Exception.ToString();
				e.Cancel = true;
			} 
		}					

		private void dataGridArea_SelectionChanged(object sender, EventArgs e)
		{
			if (bindingSourceArea.Current != null && dataGridArea.CurrentRow != null && !dataGridArea.CurrentRow.IsNewRow)
			{
				propertyGridArea.Enabled = true;
				if (Convert.ToString(((DataRowView)bindingSourceArea.Current)["AreaType"]) == "Square")
					propertyGridArea.SelectedObject = areaSquareBag;
				else
					propertyGridArea.SelectedObject = areaCircleBag;
			}
			else
				propertyGridArea.Enabled = false;
		}

		private void dataGridViewLocation_SelectionChanged(object sender, EventArgs e)
		{
			if (bindingSourceLocation.Current != null && dataGridViewLocation.CurrentRow != null && !dataGridViewLocation.CurrentRow.IsNewRow)
			{
				propertyGridLocation.Enabled = true;
				propertyGridLocation.Refresh();
			}
			else
				propertyGridLocation.Enabled = false;
		}

		private void positionConverterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!QuestDesignerMain.PositionConverter.Visible)
			{
				QuestDesignerMain.PositionConverter.Show();
			}
			else
			{
				QuestDesignerMain.PositionConverter.BringToFront();
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox about = new AboutBox();
			about.ShowDialog();
		}

		private void mapViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Viewer viewer = new Viewer();
			viewer.Show(this);
		}
 
    }
}