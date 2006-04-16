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
using DOL.GS.Database;
using DOL.GS;
using System.Collections;

namespace QuestDesigner
{
	public partial class NPCLookupForm : Form
	{
		public Mob SelectedMob;		

		public NPCLookupForm()
		{
			InitializeComponent();
            if (QuestDesignerMain.DatabaseSupported)
            {
                IList mobs = QuestDesignerMain.Database.SelectAllObjects(typeof(Mob));
                if (mobs.Count > 0)
                {
                    comboBoxNPC.DataSource = mobs;
                    comboBoxNPC.DisplayMember = "Name";
                    comboBoxNPC.ValueMember = "MobID";
                    propertyGridNPC.SelectedObject = comboBoxNPC.SelectedItem;
                    //propertyGridNPC.DataBindings.Add(new System.Windows.Forms.Binding("SelectedObject", this.comboBoxNPC, "SelectedItem", false));
                }
            }
		}

		private void buttonAccept_Click(object sender, EventArgs e)
		{
			SelectedMob = (Mob)comboBoxNPC.SelectedItem;
			this.DialogResult = DialogResult.OK;
            this.Close();
		}

		private void comboBoxNPC_SelectedIndexChanged(object sender, EventArgs e)
		{
			propertyGridNPC.SelectedObject = comboBoxNPC.SelectedItem;
		}		
	}
}