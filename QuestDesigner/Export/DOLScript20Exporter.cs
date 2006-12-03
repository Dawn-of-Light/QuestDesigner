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
    public class DOLScript20Exporter : Exporter
    {
        
        public DOLScript20Exporter()
        {
            this.Name = "DOL 2.0 Questscript";
            this.Filter = "C# Files|*.cs";
            this.XsltFile = "config\\questScript20.xsl";
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
