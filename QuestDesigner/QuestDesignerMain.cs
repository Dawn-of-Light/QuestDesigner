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
using System.Windows.Forms;
using DOL.GS.Database;
using System.Collections;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Data;
using System.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using NHibernate;
using DOL.GS.Quests;
using QuestDesigner.Util;

namespace QuestDesigner
{
    public static class QuestDesignerMain
    {
		const string TRIGGER_I = "I";
		const string TRIGGER_K = "K";

		const string ACTION_P = "P";
		const string ACTION_Q = "Q";
		const string REQUIREMENT_N = "N";
		const string REQUIREMENT_V = "V";

		public static string XSL_PATH = Path.GetFullPath("config/questScript.xsl");        

		private static ObjectDatabase m_database = null;        

		public static QuestDesignerForm qdForm;
		public static NPCLookupForm npcForm;
        public static ItemLookupForm itemForm;
		private static PositionConverterPopup posConvForm;

        private static BackgroundWorker databaseWorker = new BackgroundWorker();

		public static QuestDesignerForm DesignerForm
		{
			get {
				if (qdForm ==null)
					qdForm = new QuestDesignerForm();				
				return qdForm;
			}
		}

		public static PositionConverterPopup PositionConverter
		{
			get
			{
				if (posConvForm == null || posConvForm.IsDisposed)
					posConvForm = new PositionConverterPopup();
				return posConvForm;
			}
		}

		public static NPCLookupForm NPCLookupForm
		{
			get
			{
				if (npcForm == null)
				{
					if (databaseWorker.IsBusy)
					{
						DesignerForm.Cursor = Cursors.WaitCursor;
						while (databaseWorker.IsBusy)
							Application.DoEvents();
						DesignerForm.Cursor = Cursors.Default;
					}
					npcForm = new NPCLookupForm();
				}
				return npcForm;				 
			}
		}

        public static ItemLookupForm ItemLookupForm
        {
            get
            {
				if (itemForm == null)
				{
					if (databaseWorker.IsBusy)
					{
						DesignerForm.Cursor = Cursors.WaitCursor;
						while (databaseWorker.IsBusy)
							Application.DoEvents();
						DesignerForm.Cursor = Cursors.Default;
					}
					itemForm = new ItemLookupForm();
				}
                return itemForm;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(DesignerForm);
			//Application.Run(new QuestDesignerForm());
        }		

        public static bool DatabaseSupported
        {
            get { return Database != null; }

        }

		public static ObjectDatabase Database
		{
			get
			{                
				return m_database;
			}
		}

        static void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
				HandleException(e.Error, "Database error: " + e.Error.Message, global::QuestDesigner.Properties.Resources.databaseError);                
                DesignerForm.SetDatabaseSupport(false);
            }            
            else
            {
                DesignerForm.StatusLabel.Text = "Initialized Database";
				DesignerForm.StatusIcon.Image = global::QuestDesigner.Properties.Resources.databaseOk;
                DesignerForm.SetDatabaseSupport(true);
            }
            DesignerForm.StatusProgress.Value = DesignerForm.StatusProgress.Minimum;            
        }

		public static void HandleException(Exception e, string errorMsg, Image errorImg)
		{
			Log.ShowMessage(errorMsg, errorImg);
		}

        public static void InitDB()
        {
			try
			{
				databaseWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_doWork);
				databaseWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
				databaseWorker.RunWorkerAsync();
			}
			catch (Exception e)
			{
				HandleException(e, "Database error: " + e.Message, global::QuestDesigner.Properties.Resources.databaseError);
			}
        }

        /// <summary>
        /// Initializes the database
        /// </summary>
        static void backgroundWorker_doWork(object sender, DoWorkEventArgs e)
        {                        
            //Try to find the databaseconfig file, if it doesn't exist we create it					                
            m_database = new ObjectDatabase(ConfigurationManager.AppSettings["DatabaseConfigFile"]); // Open the connexion to the database				
            
            //m_database.CreateDatabaseStructure(ConfigurationSettings.AppSettings["DatabaseConfigFile"]);                
            // Test the database structure
            ArrayList errors = new ArrayList();
            if (!m_database.TestDatabaseStructure(ConfigurationManager.AppSettings["DatabaseConfigFile"], errors))
            {
				throw new Exception("ObjectDatabase.TestDatabaseStructure() failed: Database stucture does not match describing nhibernate mapping files.");
            }
			e.Result = true;                        
        }

		/// <summary>
		/// Checks the given name against all defined objects in quest.
		/// Needed to decide wether " should be added or not.
		/// </summary>
		/// <param name="name">Name</param>
		/// <returns>true if objectname, else false</returns>
		private static bool isObjectName(object value)
		{
			if (value is string)
			{
				string name = (string)value;
				foreach (DataRow row in DB.npcTable.Rows)
				{
					if (row["ObjectName"] is string && (string)row["ObjectName"] == name)
						return true;
				}
				foreach (DataRow row in DB.itemTemplateTable.Rows)
				{
					if (row["ItemTemplateID"] is string && (string)row["ItemTemplateID"] == name)
						return true;
				}
				foreach (DataRow row in DB.areaTable.Rows)
				{
					if (row["ObjectName"] is string && (string)row["ObjectName"] == name)
						return true;
				}
				foreach (DataRow row in DB.locationTable.Rows)
				{
					if (row["ObjectName"] is string && (string)row["ObjectName"] == name)
						return true;
				}
			}
			return false;
		}

		public static bool GenerateScript(DataSet questDataSet, string scriptPath)
		{
			DataSet dataSet = questDataSet.Copy();

			// Check for Inviting NPC
			if (dataSet.Tables["Quest"].Rows[0]["InvitingNPC"] is DBNull)
			{
				if (dataSet.Tables["Mob"].Rows.Count > 0)
				{
					dataSet.Tables["Quest"].Rows[0]["InvitingNPC"] = dataSet.Tables["Mob"].Rows[0]["ObjectName"];
					dataSet.AcceptChanges();
				}
				else
				{
					MessageBox.Show("No InvitingNPC selected.");
					return false;
				}
			}

			// check for string parameter in action, trigger, requirement and add needed ",'
			foreach (DataRow row in dataSet.Tables["QuestPartTrigger"].Rows)
			{
				row["TypeName"] = typeof(eTriggerType).Name + "." + Enum.GetName(typeof(eTriggerType), row["Type"]);

				string triggerType = Convert.ToString(row["Type"]);
				DataRow[] triggerRows = DesignerForm.dataTableTriggerType.Select("id=" + triggerType + "");				
				if (triggerRows.Length != 1)
					throw new Exception("No or multiple Triggertypes found for " + triggerType);

				//string k = Convert.ToString(triggerRows[0].ItemArray[3]);
				if (row[TRIGGER_K] is DBNull)
				{
					row[TRIGGER_K] = "null";
				}
				else
				{
					if (!isObjectName(row[TRIGGER_K]))
						row[TRIGGER_K] = '"' + Convert.ToString(row[TRIGGER_K]) + '"';
				}

				string i = Convert.ToString(triggerRows[0]["i"]);

				if (i.Contains("string") && !(row[TRIGGER_I] is DBNull))
				{
					if (!isObjectName(row[TRIGGER_I]))
						row[TRIGGER_I] = '"' + Convert.ToString(row[TRIGGER_I]) + '"';
				}
			}

			foreach (DataRow row in dataSet.Tables["QuestPartRequirement"].Rows)
			{
				row["TypeName"] =typeof(eRequirementType).Name+"."+Enum.GetName(typeof(eRequirementType), row["Type"]);

				string requType = Convert.ToString(row["Type"]);
				DataRow[] requRows = DesignerForm.dataTableRequirementType.Select("id=" + requType + "");
				if (requRows.Length != 1)
					throw new Exception("No or multiple Requirementtypes found for " + requType);

				string n = Convert.ToString(requRows[0]["n"]);
				string v = Convert.ToString(requRows[0]["v"]);

				if (n.Contains("string") && !(row[REQUIREMENT_N] is DBNull))
				{
					if (!isObjectName(row[REQUIREMENT_N]))
						row[REQUIREMENT_N] = '"' + Convert.ToString(row[REQUIREMENT_N]) + '"';
				}
				else if (row[REQUIREMENT_N] is DBNull)
				{
					row[REQUIREMENT_N] = "null";
				}

				if (v.Contains("string") && !(row[REQUIREMENT_V] is DBNull))
				{
					if (!isObjectName(row[REQUIREMENT_V]))
						row[REQUIREMENT_V] = '"' + Convert.ToString(row[REQUIREMENT_V]) + '"';
				}
			}

			foreach (DataRow row in dataSet.Tables["QuestPartAction"].Rows)
			{
				row["TypeName"] = typeof(eActionType).Name + "." + Enum.GetName(typeof(eActionType), row["Type"]);

				string actionType = Convert.ToString(row["Type"]);
				DataRow[] actionRows = DesignerForm.dataTableActionType.Select("id=" + actionType + "");
				if (actionRows.Length != 1)
					throw new Exception("No or multiple Actiontypes found for " + actionType);

				string p = Convert.ToString(actionRows[0]["p"]);
				string q = Convert.ToString(actionRows[0]["q"]);

				if (p.Contains("string") && !(row[ACTION_P] is DBNull))
				{
					if (!isObjectName(row[ACTION_P]))
						row[ACTION_P] = '"' + Convert.ToString(row[ACTION_P]) + '"';
				}
				else if (row[ACTION_P] is DBNull)
				{
					row[ACTION_P] = "null";
				}

				if (q.Contains("string") && !(row[ACTION_Q] is DBNull))
				{
					if (!isObjectName(row[ACTION_Q]))
						row[ACTION_Q] = '"' + Convert.ToString(row[ACTION_Q]) + '"';
				}
			}
			/*
			foreach (DataRow row in dataSet.Tables["QuestPart"].Rows)
			{
				row["TextTypeName"] = typeof(eTextType).Name + "." + Enum.GetName(typeof(eTextType), row["TextType"]);
			}
			*/
			dataSet.AcceptChanges();

			string tempquest = Path.GetTempFileName();			
			dataSet.WriteXml(tempquest);

			XslCompiledTransform xsltransform = new XslCompiledTransform();
			XsltSettings xsltsettings = new XsltSettings();

			XmlReaderSettings rsettings = new XmlReaderSettings();
			rsettings.CloseInput = true;

			XmlWriterSettings wsettings = new XmlWriterSettings();
			wsettings.OmitXmlDeclaration = true;
			wsettings.ConformanceLevel = ConformanceLevel.Auto;

			XmlReader xmlreader = XmlReader.Create(tempquest, rsettings);
			XmlWriter xmlwriter = XmlWriter.Create(scriptPath, wsettings);

			xsltransform.Load(XSL_PATH);
			xsltransform.Transform(xmlreader, xmlwriter);

			xmlreader.Close();
			xmlwriter.Close();

			// cleanup temp files            
			dataSet.Dispose();
			File.Delete(tempquest);
			return true;
		}
    }
}