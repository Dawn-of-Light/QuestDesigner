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
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Export
{
    public class DOLScriptExporter : Exporter
    {

        public DOLScriptExporter(DOL.Tools.QuestDesigner.QuestDesignerConfiguration.Transformator transformator)
            : base(transformator)
        {            
        }

        protected override bool ValidateData(DataSet dataSet)
        {
            // Check for Inviting NPC
            if (dataSet.Tables[DB.TABLE_QUEST].Rows[0][DB.COL_QUEST_INVITINGNPC] is DBNull)
            {
                if (dataSet.Tables[DB.TABLE_NPC].Rows.Count > 0)
                {
                    dataSet.Tables[DB.TABLE_QUEST].Rows[0][DB.COL_QUEST_INVITINGNPC] = dataSet.Tables[DB.TABLE_NPC].Rows[0][DB.COL_NPC_OBJECTNAME];
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
