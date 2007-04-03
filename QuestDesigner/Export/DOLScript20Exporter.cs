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
