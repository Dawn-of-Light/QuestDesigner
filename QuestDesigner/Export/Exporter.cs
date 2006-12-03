using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Data;
using DOL.GS.Quests;

namespace DOL.Tools.QuestDesigner.Util
{
    public abstract class Exporter
    {
        public const int DOL_18 = 0;
        public const int DOL_20 = 1;
        public const int SQL = 2;

        private String m_Filter;

        private SaveFileDialog saveDialog;

        private string m_xsltFile;

        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }


        public string XsltFile
        {
            get { return m_xsltFile; }
            set { m_xsltFile = value; }
        }


        public String Filter
        {
            get { return m_Filter; }
            set { m_Filter = value; }
        }

        public Exporter() { }

        public Exporter(string name, string filter, string xsltFile)
        {
            this.Name = name;
            this.Filter = filter;
            this.XsltFile = xsltFile;
        }

        public static Exporter getExporter(int exportType)
        {
            if (exportType == DOL_18)
                return new DOLScript18Exporter();
            else if (exportType == DOL_20)
                return new DOLScript20Exporter();
            else if (exportType == SQL)
                return new SQLExporter();
            else
                throw new ArgumentOutOfRangeException();

        }

        public void CreateQuest()
		{
			// make sure last edit is stored in dataset
			DB.QuestDataSet.AcceptChanges();

            saveDialog = new SaveFileDialog();            
            saveDialog.Filter = Filter;            
			DialogResult result = saveDialog.ShowDialog();
            
            if (result != DialogResult.OK)
                return;

            string scriptPath = saveDialog.FileName;

            if (ValidateData(DB.QuestDataSet))
            {
                DataSet dataSet = PrepareDataSet(DB.QuestDataSet, scriptPath);
                TransformDataSet(dataSet, scriptPath);                
            }
		}

        protected abstract bool ValidateData(DataSet questDataSet);

        protected virtual DataSet PrepareDataSet(DataSet questDataSet, string scriptPath)
        {
            DataSet dataSet = questDataSet.Copy();
            
            String invitingNPC = (string)dataSet.Tables["Quest"].Rows[0]["InvitingNPC"];

            // check for string parameter in action, trigger, requirement and add needed ",'
            foreach (DataRow row in dataSet.Tables["QuestPartTrigger"].Rows)
            {
                row["TypeName"] = typeof(eTriggerType).Name + "." + Enum.GetName(typeof(eTriggerType), row["Type"]);

                string triggerType = Convert.ToString(row["Type"]);
                DataRow[] triggerRows = DB.TriggerTypeTable.Select("id=" + triggerType + "");
                if (triggerRows.Length != 1)
                    throw new Exception("No or multiple Triggertypes found for " + triggerType);

                //string k = Convert.ToString(triggerRows[0].ItemArray[3]);
                if (row[Const.TRIGGER_K] is DBNull)
                {
                    row[Const.TRIGGER_K] = "null";
                }
                else
                {
                    if (!DB.isObjectName(row[Const.TRIGGER_K]))
                        row[Const.TRIGGER_K] = '"' + Convert.ToString(row[Const.TRIGGER_K]) + '"';
                }

                string i = Convert.ToString(triggerRows[0]["i"]);

                if (i.Contains("string") && !(row[Const.TRIGGER_I] is DBNull))
                {
                    if (!DB.isObjectName(row[Const.TRIGGER_I]))
                        row[Const.TRIGGER_I] = '"' + Convert.ToString(row[Const.TRIGGER_I]) + '"';
                }
            }

            foreach (DataRow row in dataSet.Tables["QuestPartRequirement"].Rows)
            {
                row["TypeName"] = typeof(eRequirementType).Name + "." + Enum.GetName(typeof(eRequirementType), row["Type"]);

                string requType = Convert.ToString(row["Type"]);
                DataRow[] requRows = DB.RequirementTypeTable.Select("id=" + requType + "");
                if (requRows.Length != 1)
                    throw new Exception("No or multiple Requirementtypes found for " + requType);

                string n = Convert.ToString(requRows[0]["n"]);
                string v = Convert.ToString(requRows[0]["v"]);

                if (n.Contains("string") && !(row[Const.REQUIREMENT_N] is DBNull))
                {
                    if (!DB.isObjectName(row[Const.REQUIREMENT_N]))
                        row[Const.REQUIREMENT_N] = '"' + Convert.ToString(row[Const.REQUIREMENT_N]) + '"';
                }
                else if (row[Const.REQUIREMENT_N] is DBNull)
                {
                    row[Const.REQUIREMENT_N] = "null";
                }

                if (v.Contains("string") && !(row[Const.REQUIREMENT_V] is DBNull))
                {
                    if (!DB.isObjectName(row[Const.REQUIREMENT_V]))
                        row[Const.REQUIREMENT_V] = '"' + Convert.ToString(row[Const.REQUIREMENT_V]) + '"';
                }
            }

            foreach (DataRow row in dataSet.Tables["QuestPartAction"].Rows)
            {
                row["TypeName"] = typeof(eActionType).Name + "." + Enum.GetName(typeof(eActionType), row["Type"]);

                string actionType = Convert.ToString(row["Type"]);
                DataRow[] actionRows = DB.ActionTypeTable.Select("id=" + actionType + "");
                if (actionRows.Length != 1)
                    throw new Exception("No or multiple Actiontypes found for " + actionType);

                string p = Convert.ToString(actionRows[0]["p"]);
                string q = Convert.ToString(actionRows[0]["q"]);

                if (p.Contains("string") && !(row[Const.ACTION_P] is DBNull))
                {
                    if (!DB.isObjectName(row[Const.ACTION_P]))
                        row[Const.ACTION_P] = '"' + Convert.ToString(row[Const.ACTION_P]) + '"';
                }
                else if (row[Const.ACTION_P] is DBNull)
                {
                    row[Const.ACTION_P] = "null";
                }

                if (q.Contains("string") && !(row[Const.ACTION_Q] is DBNull))
                {
                    if (!DB.isObjectName(row[Const.ACTION_Q]))
                        row[Const.ACTION_Q] = '"' + Convert.ToString(row[Const.ACTION_Q]) + '"';
                }
            }


            foreach (DataRow row in dataSet.Tables["QuestPart"].Rows)
            {
                int questPartID = (int)row["ID"];
                string defaultNPC = invitingNPC;

                DataRow[] triggerRows = dataSet.Tables["QuestPartTrigger"].Select("QuestPartID=" + questPartID);
                foreach (DataRow triggerRow in triggerRows)
                {
                    if (DB.isMobName(triggerRow[Const.TRIGGER_I]))
                    {
                        defaultNPC = (string)triggerRow[Const.TRIGGER_I];
                        break;
                    }
                    else if (DB.isMobName(triggerRow[Const.TRIGGER_K]))
                    {
                        defaultNPC = (string)triggerRow[Const.TRIGGER_K];
                        break;
                    }
                }

                DataRow[] requRows = dataSet.Tables["QuestPartRequirement"].Select("QuestPartID=" + questPartID);
                foreach (DataRow requRow in requRows)
                {
                    if (DB.isMobName(requRow[Const.REQUIREMENT_N]))
                    {
                        defaultNPC = (string)requRow[Const.REQUIREMENT_N];
                        break;
                    }
                    else if (DB.isMobName(requRow[Const.REQUIREMENT_V]))
                    {
                        defaultNPC = (string)requRow[Const.REQUIREMENT_V];
                        break;
                    }
                }

                DataRow[] actionRows = dataSet.Tables["QuestPartAction"].Select("QuestPartID=" + questPartID);
                foreach (DataRow actionRow in actionRows)
                {
                    if (DB.isMobName(actionRow[Const.ACTION_P]))
                    {
                        defaultNPC = (string)actionRow[Const.ACTION_P];
                        break;
                    }
                    else if (DB.isMobName(actionRow[Const.ACTION_Q]))
                    {
                        defaultNPC = (string)actionRow[Const.ACTION_Q];
                        break;
                    }
                }

                row["defaultNPC"] = defaultNPC;
            }

            dataSet.AcceptChanges();
            
            return dataSet;
        }

        protected virtual void TransformDataSet(DataSet dataSet,string scriptPath)
        {

            FileInfo xsltFile = new FileInfo(Application.StartupPath + "\\" + XsltFile);

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

            xsltransform.Load(xsltFile.FullName);
            xsltransform.Transform(xmlreader, xmlwriter);

            xmlreader.Close();
            xmlwriter.Close();

            Log.Info("Script successfully build into " + scriptPath);

            File.Delete(tempquest);
        }
    }
    
}
