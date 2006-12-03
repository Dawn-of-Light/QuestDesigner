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
using DOL.Tools.QuestDesigner.Util;


namespace DOL.Tools.QuestDesigner
{
	public partial class ItemLookupForm : Form
	{
		public Object SelectedItem;		

		public ItemLookupForm()
		{
			InitializeComponent();
            if (QuestDesignerMain.DatabaseSupported)
            {

                IList items = QuestDesignerMain.DatabaseAdapter.GetItemList();
                if (items.Count > 0)
                {
                    comboBoxItem.DataSource = items;
                    comboBoxItem.DisplayMember = DOLDatabaseAdapter.ITEM_NAME;
                    comboBoxItem.ValueMember = DOLDatabaseAdapter.ITEM_ID;

                    propertyGridItem.SelectedObject = comboBoxItem.SelectedItem;
                    //propertyGridItem.DataBindings.Add(new System.Windows.Forms.Binding("SelectedObject", this.comboBoxItem, "SelectedItem", false));
                }
                 
            }
		}

		private void buttonAccept_Click(object sender, EventArgs e)
		{
			SelectedItem = (Object)comboBoxItem.SelectedItem;            
			this.DialogResult = DialogResult.OK;
            this.Close();
		}

		private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			propertyGridItem.SelectedObject = comboBoxItem.SelectedItem;
		}
	}
}