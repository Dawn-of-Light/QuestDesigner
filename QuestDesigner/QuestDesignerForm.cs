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
using System.Collections;
using DOL.Tools.QuestDesigner.Properties;
using System.Reflection;
using System.Text.RegularExpressions;
using Flobbster.Windows.Forms;
using DOL.Tools.QuestDesigner.Converter;

using NETXP.Controls.Docking;
using DOL.Tools.QuestDesigner.Util;
using DOL.GS.Quests;
using DOL.GS;
using DOL.GS.PacketHandler;
using DOL.Database;
using DOL.Tools.QuestDesigner.Exceptions;
using DOL.Tools.Mapping.Forms;
using System.Net;
using DOL.Tools.Mapping.Map;
using DOL.Tools.QuestDesigner.Export;

namespace DOL.Tools.QuestDesigner
{
    public partial class QuestDesignerForm : Form
    {		

        public static string TITLE = " ::  " + Application.ProductName+" "+QuestDesignerMain.Version+" :: ";

        private const string DOWNLOAD_DATA_FILENAME = "data.zip";

        protected string openFilename = null;

        public QuestDesignerForm()
        {            
			InitializeComponent();			
			
			QuestDesignerMain.InitDB();           			
        }

        public QuestDesignerForm(FileInfo loadFile)
            : this()
        {
            LoadQuest(loadFile.FullName);
        }

        public Boolean registerCreateScriptExtension(DOL.Tools.QuestDesigner.QuestDesignerConfiguration.Transformator transformator)
        {
            ToolStripMenuItem exportMenuItem = new ToolStripMenuItem();
            exportMenuItem.Enabled = transformator.Enabled;
            exportMenuItem.Name = "QuestToolStripMenuItem" + Utils.ConvertToObjectName(transformator.Name) + this.createToolStripMenuItem.DropDownItems.Count;
            //exportMenuItem.Size = new System.Drawing.Size(156, 22);
            exportMenuItem.Text = transformator.Name;
            exportMenuItem.ToolTipText = transformator.Description;
            exportMenuItem.Tag = transformator;
            exportMenuItem.Click += new EventHandler(exportMenuItem_Click);            

            this.createToolStripMenuItem.DropDownItems.Add(exportMenuItem);
            return true;
        }

        void exportMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem exportMenuItem = (ToolStripMenuItem)sender;
            DOL.Tools.QuestDesigner.QuestDesignerConfiguration.Transformator transformator =(DOL.Tools.QuestDesigner.QuestDesignerConfiguration.Transformator) exportMenuItem.Tag;

            Exporter exporter = (Exporter)Activator.CreateInstance(transformator.ExporterClass, new object[] { transformator });            
            exporter.CreateQuest();
        }

		private void QuestDesignerForm_Load(object sender, EventArgs e)
		{
            foreach (DOL.Tools.QuestDesigner.QuestDesignerConfiguration.Transformator transformator in QuestDesignerMain.DesignerConfiguration.getTransformators())
            {                
                registerCreateScriptExtension(transformator);
            }

			// Configure L&F
			NETXP.Controls.Docking.Renderers.Office2003 XPRenderers = new NETXP.Controls.Docking.Renderers.Office2003();
			NETXP.Library.XPBlueColorTable xpColorTable = new NETXP.Library.XPBlueColorTable();
			XPRenderers.ColorTable = xpColorTable;			
			customCode.tabControlCodeSection.Renderer = XPRenderers;
			this.tabControlMain.Renderer = XPRenderers;
			this.xpTaskPane.ColorTable = NETXP.Library.ColorTables.XPBlue;
            this.xpTGActions.ColorTable = NETXP.Library.ColorTables.XPBlue;

            this.tabControlMain.Renderer = XPRenderers;

			toolStripMenuItemTaskPane.CheckState = Settings.Default.ShowTaskPane ? CheckState.Checked: CheckState.Unchecked;

            tabControlMain.TabPages["Map Editor"].Enabled = QuestDesignerMain.DataSupported;

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

            SetDataSet();									

            Log.register();

            CheckData();            
		}

        public void ShowTab(int index)
        {
            tabControlMain.SelectedIndex = index;
        }

        public void ShowTab(string title)
        {
            tabControlMain.SelectedTab = tabControlMain.TabPages[title];
        }

        public bool CheckData()
        {
            if (!QuestDesignerMain.DataSupported && Properties.Settings.Default.DownloadData)
            {
                
                string url = System.Configuration.ConfigurationManager.AppSettings["DataDownloadUrl"];

                DialogResult result = MessageBox.Show(this, "Map Data not found. Do you want to download it from " + url + "?\n You can always download the needed data later via Tools menu.", "Data download request", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    Uri uri = new Uri(url);
                    Log.Info("Downloading data files from: " + url);

                    WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadFileAsync(uri, QuestDesignerMain.WorkingDirectory + DOWNLOAD_DATA_FILENAME);
                    StatusProgress.Value = StatusProgress.Minimum;
                }
                else
                {
                    Properties.Settings.Default.DownloadData = false;
                }
            }

            return true;
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Zip.Unzip(QuestDesignerMain.WorkingDirectory + DOWNLOAD_DATA_FILENAME, QuestDesignerMain.WorkingDirectory);
            
            StatusProgress.Value = StatusProgress.Minimum;

            tabControlMain.TabPages["Map Editor"].Enabled = QuestDesignerMain.DataSupported;
        }

        void webClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {           
            StatusProgress.Value = e.ProgressPercentage;
        }

		private void SetDataSet()
		{
            if (!DB.isInitialized())
                Log.Error("DB not initialized yet");

			questInfo.setDataSet();
			npcView.setDataSet();
			itemView.setDataSet();
			customCode.setDataSet();
            areaView.setDataSet();
            locationView.SetDataSet();
			questPartItems.SetDataSet();
		}

		private void dataSetData_Initialized(object sender, EventArgs e)
		{			
			//fill via Relfection			
			FillTypeValues(new Type[] { typeof(eTextType), typeof(eDamageType), typeof(eComparator), typeof(eObjectType), typeof(eInventorySlot), typeof(eColor), typeof(eRealm), typeof(eProperty), typeof(eEmote), typeof(eCharacterClass) });
			//

            string[] xmlFiles = Directory.GetFiles(QuestDesignerMain.WorkingDirectory + System.Configuration.ConfigurationManager.AppSettings["TypeConfigDirectory"], "*.xml");			

			foreach (string filePath in xmlFiles)
			{
				dataSetData.ReadXml(filePath);
			}
            // read regions and zones from config/dol directory

            dataSetData.ReadXml(QuestDesignerMain.WorkingDirectory + System.Configuration.ConfigurationManager.AppSettings["DOLConfigDirectory"] + "regions.xml");
            dataSetData.ReadXml(QuestDesignerMain.WorkingDirectory + System.Configuration.ConfigurationManager.AppSettings["DOLConfigDirectory"] + "zones.xml");

			// check Action,Trigger,RequirementTypes and fill table with respective Ids
			foreach (DataRow row in dataTableTriggerType.Rows)
			{
                string value = Convert.ToString(row[DB.COL_TRIGGERTYPE_VALUE]);
				value = value.Substring(value.IndexOf('.') + 1);
				object id = Enum.Parse(typeof(eTriggerType), value);
				if (id is eTriggerType)
				{
                    row[DB.COL_TRIGGERTYPE_ID] = id;
				}
				else
				{
                    Log.Warning("TriggerType with name: " + row[DB.COL_TRIGGERTYPE_VALUE] + " couldn't be parsed to corresponding value:" + id);
				}
			}

			foreach (DataRow row in dataTableRequirementType.Rows)
			{
                string value = Convert.ToString(row[DB.COL_REQUIREMENTTYPE_VALUE]);
				value = value.Substring(value.IndexOf('.') + 1);
				object id = Enum.Parse(typeof(eRequirementType), value);
				if (id is eRequirementType)
				{
                    row[DB.COL_REQUIREMENTTYPE_ID] = id;
				}
				else
				{
                    Log.Warning("Requirementype with name: " + row[DB.COL_REQUIREMENTTYPE_VALUE] + " couldn't be parsed to corresponding value:" + id);
				}
			}

			foreach (DataRow row in dataTableActionType.Rows)
			{
				string value = Convert.ToString(row[DB.COL_ACTIONTYPE_VALUE]);
				value = value.Substring(value.IndexOf('.') + 1);
                try
                {
                    object id = Enum.Parse(typeof(eActionType), value);
                    if (id is eActionType)
                    {
                        row[DB.COL_ACTIONTYPE_ID] = id;
                    }
                    else
                    {
                        Log.Warning("Actiontype with name: " + row[DB.COL_ACTIONTYPE_VALUE] + " couldn't be parsed to corresponding value:" + id);
                    }
                }
                catch (ArgumentException)
                {
                    Log.Warning("Actiontype with name: " + row[DB.COL_ACTIONTYPE_VALUE] + " not found.");                    
                }
			}

            DB.ConfigDataSet = dataSetData;
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
						row[DB.COL_ENUMERATION_NAME] = enumNames[i];
                        row[DB.COL_ENUMERATION_DESCRIPTION] = enumNames[i];
                        row[DB.COL_ENUMERATION_VALUE] = Convert.ChangeType(enumArray.GetValue(i), Enum.GetUnderlyingType(type));
                        row[DB.COL_ENUMERATION_TYPE] = type.Name;
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
            DB.SuspendBindings();
                                   
            dataSetQuest.Clear();
			dataTableQuest.Rows.Add(dataTableQuest.NewRow());
            dataTableQuestPart.Rows.Add(dataTableQuestPart.NewRow());
            dataSetQuest.AcceptChanges();
            DB.ResumeBindings();
            questPartItems.RefreshQuestPartText();
            DB.questPartBinding.ResetCurrentItem();
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
                    
                    DB.SuspendBindings();
                    
					dataSetQuest.Clear();
					dataSetQuest.ReadXml(xmlfile);
                    dataSetQuest.AcceptChanges();
                    DB.ResumeBindings();
                                        
                    questPartItems.RefreshQuestPartText();
                    DB.questPartBinding.ResetCurrentItem();
                    this.questInfo.UpdateDataset();

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
					Log.Error("Quest load error: " + xmlfile);
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
            DialogResult result = MessageBox.Show("Any changes of the opened quest will be lost. Do you really want to start a new quest?", "Create new quest", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                InitEmptyQuest();

                this.Text = TITLE + openFilename;
                Log.Info("New Quest created");
            }                 
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

		private void textBoxQuestname_Validating(object sender, CancelEventArgs e)
        {
            TextBox questName = (TextBox)sender;            
            questName.Text=Utils.ConvertToObjectName(questName.Text);            
        }        		           			
		
		private void linkLoadQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult result = openQuestDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				LoadQuest(openQuestDialog.FileName);
			}    
		}

		private void toolStripMenuItemTaskPane_CheckStateChanged(object sender, EventArgs e)
		{
			Settings.Default.ShowTaskPane = toolStripMenuItemTaskPane.CheckState == CheckState.Checked;
		}		

		private void positionConverterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!QuestDesignerMain.PositionConverter.Visible)
			{
				QuestDesignerMain.PositionConverter.Show(this);
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

        private void StatusLabel_Click(object sender, EventArgs e)
        {
            Log.pullMessageQueue();
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        // This delegate enables asynchronous calls for setting
        // the image property on a TextBox control.
        delegate void ShowMessageCallback(String msg, Image image);

        public void ShowMessage(String msg, Image image)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (Form.CheckForIllegalCrossThreadCalls && this.StatusLabel.GetCurrentParent()!=null && this.StatusLabel.GetCurrentParent().Parent.InvokeRequired)
            {
                ShowMessageCallback d = new ShowMessageCallback(ShowMessage);
                this.Invoke(d, new object[] { msg ,image});

                //SetImageCallback d = new SetImageCallback(image);
                //this.Invoke(d, new object[] { image });
            }
            else
            {
                this.StatusLabel.Text = msg;
                this.StatusLabel.Image = image;
            }
        }

        private void dataSetQuest_Initialized(object sender, EventArgs e)
        {
            DB.QuestDataSet = dataSetQuest;
        }

        private void linkSaveQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InfoForm().ShowDialog();
        }

        private void dataDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DownloadData = true;
            CheckData();
        }

        private void linkLabelNewQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }        
 
    }
}