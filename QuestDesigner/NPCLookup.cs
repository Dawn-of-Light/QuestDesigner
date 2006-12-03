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
using System.Configuration;
using System.Collections;
using DOL.GS;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner
{
	public partial class NPCLookupForm : Form
	{
		
        private Object selectedMob;

        public Object SelectedMob
        {
            get { return selectedMob; }
            set { selectedMob = value; }
        }


		public NPCLookupForm()
		{
			InitializeComponent();
            if (QuestDesignerMain.DatabaseSupported)
            {                
                IList mobs = QuestDesignerMain.DatabaseAdapter.GetNPCList();
                if (mobs.Count > 0)
                {
                    comboBoxNPC.DataSource = mobs;
                    comboBoxNPC.DisplayMember = DOLDatabaseAdapter.MOB_NAME;
                    comboBoxNPC.ValueMember = DOLDatabaseAdapter.MOB_ID;
                    propertyGridNPC.SelectedObject = comboBoxNPC.SelectedItem;
                    //propertyGridNPC.DataBindings.Add(new System.Windows.Forms.Binding("SelectedObject", this.comboBoxNPC, "SelectedItem", false));
                }
                
            }
		}

		private void buttonAccept_Click(object sender, EventArgs e)
		{
			SelectedMob = comboBoxNPC.SelectedItem;
			this.DialogResult = DialogResult.OK;
            this.Close();
		}

		private void comboBoxNPC_SelectedIndexChanged(object sender, EventArgs e)
		{
			propertyGridNPC.SelectedObject = comboBoxNPC.SelectedItem;
		}		
	}
}