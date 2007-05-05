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
using System.Text;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Data;
using DOL.GS.Quests;
using DOL.Tools.QuestDesigner.Util;
using System.ComponentModel;
using System.Threading;
using DOL.Tools.QuestDesigner.Properties;
using DOL.Tools.QuestDesigner.Exceptions;

namespace DOL.Tools.QuestDesigner.Export
{
    public abstract class Exporter
    {        

        private SaveFileDialog saveDialog;

        private QuestDesignerConfiguration.Transformator transformator;       

        public QuestDesignerConfiguration.Transformator Transformator
        {
            get { return transformator; }
        }

        public String getFilter() {
             return Transformator.Name+"|*."+Transformator.Extension; 
        }

        public Exporter(QuestDesignerConfiguration.Transformator transformator) {
            this.transformator = transformator;
            this.saveDialog = new SaveFileDialog();            
        }
        
        public void CreateQuest()
		{			            
            saveDialog.Filter = getFilter();

            if (!String.IsNullOrEmpty(Settings.Default.LastExportDirectory))
            {                
                saveDialog.InitialDirectory = Settings.Default.LastExportDirectory;
            }

			DialogResult result = saveDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(saveDialog.FileName);
                Settings.Default.LastExportDirectory = fileInfo.DirectoryName;

                Log.Info(String.Format(Resources.msgExportingQuest, saveDialog.FileName));
                // make sure last edit is stored in dataset

                try
                {
                    QuestDesignerMain.DesignerForm.Cursor = Cursors.WaitCursor;

                    BackgroundWorker exportWorker = new BackgroundWorker();
                    exportWorker.DoWork += new DoWorkEventHandler(exportWorker_DoWork);
                    exportWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(exportWorker_RunWorkerCompleted);
                    exportWorker.RunWorkerAsync();
                }
                catch (Exception e)
                {
                    QuestDesignerMain.HandleException(e, Resources.msgExportError+": " + e.Message);
                    Cursor.Current = Cursors.Default;
                }
            }
            
		}

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Log.Info(String.Format(Resources.msgQuestExported, saveDialog.FileName));

            QuestDesignerMain.DesignerForm.Cursor = Cursors.Default;            
            QuestDesignerMain.DesignerForm.StatusProgress.Value = QuestDesignerMain.DesignerForm.StatusProgress.Minimum;
        }

        private void exportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            QuestDesignerMain.DesignerForm.StatusProgress.Value = QuestDesignerMain.DesignerForm.StatusProgress.Minimum;

            DB.SuspendBindings();

            DB.QuestDataSet.AcceptChanges();

            DB.ResumeBindings();

            QuestDesignerMain.DesignerForm.StatusProgress.Value = (int) (QuestDesignerMain.DesignerForm.StatusProgress.Maximum * 0.7);

            if (ValidateData(DB.QuestDataSet))
            {
                DataSet dataSet = PrepareDataSet(DB.QuestDataSet, saveDialog.FileName);

                QuestDesignerMain.DesignerForm.StatusProgress.Value =(int) (QuestDesignerMain.DesignerForm.StatusProgress.Maximum * 0.85);
                
                TransformDataSet(dataSet, saveDialog.FileName);

                QuestDesignerMain.DesignerForm.StatusProgress.Value = QuestDesignerMain.DesignerForm.StatusProgress.Maximum;
            }
        }


        protected abstract bool ValidateData(DataSet questDataSet);

        protected virtual String PrepareValue(DataSet dataSet, Object value, String valueDescription)
        {
            
            if (valueDescription.Contains(Const.SELECTOR_QUESTTYPE))
            {
                if (value is DBNull || String.IsNullOrEmpty(Convert.ToString(value)))
                {
                    value = "typeof(" + dataSet.Tables[DB.TABLE_QUEST].Rows[0][DB.COL_QUEST_NAME] + ")";
                } 
                else                
                {
                    value = "typeof(" + value + ")";
                }
            }
            else if (valueDescription.Contains(Const.TYPE_STRING))
            {
                if (value is DBNull || String.IsNullOrEmpty(Convert.ToString(value)))
                {
                    value = "null";
                }
                else if (!DB.isObjectName(value))
                {
                    value = Utils.ToEscapedText(value);
                }
            }
            else if (valueDescription.Contains(Const.SELECTOR_TEXTTYPE))
            {
                if (value is DBNull || String.IsNullOrEmpty(Convert.ToString(value)))
                {
                    value = typeof(eTextType).Name + "." + eTextType.None;
                }
                else
                {
                    value = "(" + typeof(eTextType).Name + ")" + value;
                }
            }
            else
            {
                if (value is DBNull || String.IsNullOrEmpty(Convert.ToString(value)))
                {
                    value = "null";
                }
            }

            return Convert.ToString(value);
        }

        protected virtual DataSet PrepareDataSet(DataSet questDataSet, string scriptPath)
        {
            DataSet dataSet = questDataSet.Copy();


            foreach (DataRow quest in dataSet.Tables[DB.TABLE_QUEST].Rows)
            {
                quest[DB.COL_QUEST_DESCRIPTION] = Utils.Escape(quest[DB.COL_QUEST_DESCRIPTION]);
                quest[DB.COL_QUEST_NAME] = Utils.Escape(quest[DB.COL_QUEST_NAME]);
                quest[DB.COL_QUEST_TITLE] = Utils.Escape(quest[DB.COL_QUEST_TITLE]);
                
            }

            foreach (DataRow questStep in dataSet.Tables[DB.TABLE_QUESTSTEP].Rows)
            {
                questStep[DB.COL_QUESTSTEP_DESCRIPTION] = Utils.Escape(questStep[DB.COL_QUESTSTEP_DESCRIPTION]);
            }

            String invitingNPC = (string)dataSet.Tables[DB.TABLE_QUEST].Rows[0][DB.COL_QUEST_INVITINGNPC];

            // check for string parameter in action, trigger, requirement and add needed ",'
            foreach (DataRow row in dataSet.Tables[DB.TABLE_QUESTPARTTRIGGER].Rows)
            {
                row[DB.COL_QUESTPARTTRIGGER_TYPENAME] = typeof(eTriggerType).Name + "." + Enum.GetName(typeof(eTriggerType), row[DB.COL_QUESTPARTTRIGGER_TYPE]);

                string triggerType = Convert.ToString(row[DB.COL_QUESTPARTTRIGGER_TYPE]);
                DataRow[] triggerRows = DB.TriggerTypeTable.Select(DB.COL_TRIGGERTYPE_ID+"=" + triggerType + "");
                if (triggerRows.Length != 1)
                    throw new QuestPartConfigurationException("No or multiple Triggertypes found for " + triggerType);

                string k = Convert.ToString(triggerRows[0][DB.COL_TRIGGERTYPE_K]);
                row[DB.COL_QUESTPARTTRIGGER_K] = PrepareValue(dataSet, row[DB.COL_QUESTPARTTRIGGER_K], k);
                
                string i = Convert.ToString(triggerRows[0][DB.COL_TRIGGERTYPE_I]);
                row[DB.COL_QUESTPARTTRIGGER_I] = PrepareValue(dataSet, row[DB.COL_QUESTPARTTRIGGER_I], i);
            }

            foreach (DataRow row in dataSet.Tables[DB.TABLE_QUESTPARTREQUIREMENT].Rows)
            {
                row[DB.COL_QUESTPARTREQUIREMENT_TYPENAME] = typeof(eRequirementType).Name + "." + Enum.GetName(typeof(eRequirementType), row[DB.COL_QUESTPARTREQUIREMENT_TYPE]);

                string requType = Convert.ToString(row[DB.COL_QUESTPARTREQUIREMENT_TYPE]);
                DataRow[] requRows = DB.RequirementTypeTable.Select(DB.COL_REQUIREMENTTYPE_ID+"=" + requType + "");
                if (requRows.Length != 1)
                    throw new QuestPartConfigurationException("No or multiple Requirementtypes found for " + requType);

                string n = Convert.ToString(requRows[0][DB.COL_REQUIREMENTTYPE_N]);
                row[DB.COL_QUESTPARTREQUIREMENT_N] = PrepareValue(dataSet, row[DB.COL_QUESTPARTREQUIREMENT_N], n);

                string v = Convert.ToString(requRows[0][DB.COL_REQUIREMENTTYPE_V]);
                row[DB.COL_QUESTPARTREQUIREMENT_V] = PrepareValue(dataSet, row[DB.COL_QUESTPARTREQUIREMENT_V], v);                
            }

            foreach (DataRow row in dataSet.Tables[DB.TABLE_QUESTPARTACTION].Rows)
            {
                row[DB.COL_QUESTPARTACTION_TYPENAME] = typeof(eActionType).Name + "." + Enum.GetName(typeof(eActionType), row[DB.COL_QUESTPARTACTION_TYPE]);

                string actionType = Convert.ToString(row[DB.COL_QUESTPARTACTION_TYPE]);
                DataRow[] actionRows = DB.ActionTypeTable.Select(DB.COL_ACTIONTYPE_ID+"=" + actionType + "");
                if (actionRows.Length != 1)
                    throw new QuestPartConfigurationException("No or multiple Actiontypes found for " + actionType);

                string p = Convert.ToString(actionRows[0][DB.COL_ACTIONTYPE_P]);
                row[DB.COL_QUESTPARTACTION_P] = PrepareValue(dataSet, row[DB.COL_QUESTPARTACTION_P], p);

                string q = Convert.ToString(actionRows[0][DB.COL_ACTIONTYPE_Q]);
                row[DB.COL_QUESTPARTACTION_Q] = PrepareValue(dataSet, row[DB.COL_QUESTPARTACTION_Q], q);                
            }

            // find a candidate for defaultNPC
            foreach (DataRow row in dataSet.Tables[DB.TABLE_QUESTPART].Rows)
            {
                int questPartID = (int)row[DB.COL_QUESTPART_ID];
                string defaultNPC = invitingNPC;

                DataRow[] triggerRows = dataSet.Tables[DB.TABLE_QUESTPARTTRIGGER].Select(DB.COL_QUESTPARTTRIGGER_QUESTPARTID+"=" + questPartID);
                foreach (DataRow triggerRow in triggerRows)
                {
                    if (DB.isMobName(triggerRow[DB.COL_QUESTPARTTRIGGER_I]))
                    {
                        defaultNPC = (string)triggerRow[DB.COL_QUESTPARTTRIGGER_I];
                        break;
                    }
                    else if (DB.isMobName(triggerRow[DB.COL_QUESTPARTTRIGGER_K]))
                    {
                        defaultNPC = (string)triggerRow[DB.COL_QUESTPARTTRIGGER_K];
                        break;
                    }
                }

                DataRow[] requRows = dataSet.Tables[DB.TABLE_QUESTPARTREQUIREMENT].Select(DB.COL_QUESTPARTREQUIREMENT_QUESTPARTID+"=" + questPartID);
                foreach (DataRow requRow in requRows)
                {
                    if (DB.isMobName(requRow[DB.COL_QUESTPARTREQUIREMENT_N]))
                    {
                        defaultNPC = (string)requRow[DB.COL_QUESTPARTREQUIREMENT_N];
                        break;
                    }
                    else if (DB.isMobName(requRow[DB.COL_QUESTPARTREQUIREMENT_V]))
                    {
                        defaultNPC = (string)requRow[DB.COL_QUESTPARTREQUIREMENT_V];
                        break;
                    }
                }

                DataRow[] actionRows = dataSet.Tables[DB.TABLE_QUESTPARTACTION].Select(DB.COL_QUESTPARTACTION_QUESTPARTID+"=" + questPartID);
                foreach (DataRow actionRow in actionRows)
                {
                    if (DB.isMobName(actionRow[DB.COL_QUESTPARTACTION_P]))
                    {
                        defaultNPC = (string)actionRow[DB.COL_QUESTPARTACTION_P];
                        break;
                    }
                    else if (DB.isMobName(actionRow[DB.COL_QUESTPARTACTION_Q]))
                    {
                        defaultNPC = (string)actionRow[DB.COL_QUESTPARTACTION_Q];
                        break;
                    }
                }

                row[DB.COL_QUESTPART_DEFAULTNPC] = defaultNPC;
            }

            // Accept all changes made
            dataSet.AcceptChanges();
            
            return dataSet;
        }

        protected virtual void TransformDataSet(DataSet dataSet,string scriptPath)
        {
            FileInfo xsltFile = new FileInfo(Transformator.XlsPath);

            string tempquest = Path.GetTempFileName();
            dataSet.WriteXml(tempquest);

            XslCompiledTransform xsltransform = new XslCompiledTransform();
            XsltSettings xsltsettings = new XsltSettings();

            XmlReaderSettings rsettings = new XmlReaderSettings();
            rsettings.CloseInput = true;

            XmlWriterSettings wsettings = new XmlWriterSettings();
            wsettings.OmitXmlDeclaration = true;
            wsettings.ConformanceLevel = ConformanceLevel.Auto;

            FileInfo outputFile = new FileInfo(scriptPath);
            FileStream outputStream = outputFile.Open(FileMode.Create,FileAccess.Write);
            
            XmlReader xmlreader = XmlReader.Create(tempquest, rsettings);
            XmlWriter xmlwriter = XmlWriter.Create(outputStream, wsettings);

            xsltransform.Load(xsltFile.FullName);
            xsltransform.Transform(xmlreader, xmlwriter);

            xmlreader.Close();
            xmlwriter.Close();
            outputStream.Close();

            File.Delete(tempquest);
        }
    }
    
}
