using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Data;

namespace DOL.Tools.QuestDesigner.Util
{
    public class SQLExporter : Exporter
    {
        
        public SQLExporter()
        {
            this.Name = "SQL Export";
            this.Filter = "SQL Files|*.sql";
            this.XsltFile = "config\\sqlScript.xsl";
        }

        protected override bool ValidateData(DataSet questDataSet)
        {            
            return true;
        }

        protected override DataSet PrepareDataSet(DataSet dataSet, string scriptPath)
        {
            dataSet.AcceptChanges();
            return dataSet.Copy();
        }
    }
}
