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
    public class DOLScript18Exporter : Exporter
    {
        
        public DOLScript18Exporter()
        {
            this.Name = "DOL 1.8 Questscript";
            this.Filter = "C# Files|*.cs";
            this.XsltFile = "config\\questScript18.xsl";
        }

        protected override bool ValidateData(DataSet dataSet)
        {
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
            return true;
        }

        
    }
}
